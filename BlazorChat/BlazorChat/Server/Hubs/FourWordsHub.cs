using BlazorChat.Shared;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorChat.Server.Hubs
{
    public class FourWordsHub : Hub
    {

        //Le static fait la persistance de données (Car lié à Chathub et pas à l'instanciation: commun à tous les chathubs)
        /// <summary>Liste des joueurs</summary>
        static ConcurrentDictionary<string, Joueur> Joueurs = new ConcurrentDictionary<string, Joueur>();

        static bool PartieEnCours = false;


        public async Task SendMessage(string user, string message, string id)
        {
            await Clients.Client(id).SendAsync("ReceiveMessage", Context.ConnectionId, id);
            await Clients.All.SendAsync("ReceiveMessage", user, message);

        }

        public async Task Initialiser()
        {
            await Clients.All.SendAsync("NombreJoueurs", Joueurs.Count);
            await Clients.All.SendAsync("PartieEnCours", PartieEnCours);
        }

        /// <summary>Lors du click sur le bouton jouer: Ajouter le joueur dans la liste des joueurs</summary>
        /// <param name="pseudo"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public async Task Jouer(string pseudo, string connectionId)
        {
            Joueur joue = null;
            if (Joueurs.Count < 4)
            {
                Joueurs.TryAdd(connectionId, new Joueur(pseudo, connectionId));

                await Clients.All.SendAsync("NombreJoueurs", Joueurs.Count);
                Joueurs[Context.ConnectionId].EtapeJeu = EtapeJeu.EnAttenteDeLancement;


                joue = Joueurs[Context.ConnectionId];

                //On démarre la partie
                if (Joueurs.Count == 4)
                {
                    PartieEnCours = true;
                    foreach (KeyValuePair<string, Joueur> KeyValue in Joueurs)
                    {
                        Joueur gamer = KeyValue.Value;

                        //On définit les mots à faire deviner pour chaque joueur
                        gamer.MotADeviner = "Charlie" + gamer.ConnectionId;

                        //On passe à l'écran de devinage et on quitte l'attente de lancement
                        gamer.EtapeJeu = EtapeJeu.EstEnTrainDeDonnerIndice;
                        await Clients.Client(KeyValue.Value.ConnectionId).SendAsync("InfoJoueur", JsonSerializer.Serialize(gamer));

                    }
                    return;
                }
                //On retourne le joueur
                string retour = JsonSerializer.Serialize(joue);
                await Clients.Caller.SendAsync("InfoJoueur", retour);
            }
        }

        /// <summary>Récupère les mots à faire deviner aux autres</summary>
        /// <returns></returns>
        public async Task RecupererMotsAFaireDeviner()
        {
            List<Joueur> dicoGamers = Joueurs.Values.Where<Joueur>(x => x.ConnectionId != Context.ConnectionId).ToList();

            List<string> motsAFaireDeviner = new List<string>();
            foreach (Joueur gamer in dicoGamers)
            {
                motsAFaireDeviner.Add(gamer.MotADeviner);
            }

            await Clients.Caller.SendAsync("MotsAFaireDeviner", motsAFaireDeviner);
        }


        public override Task OnDisconnectedAsync(Exception exception)
        {

            bool ok = Joueurs.TryRemove(Context.ConnectionId, out Joueur joueur);

            Task.Run(() =>
            {
                if (PartieEnCours)
                {
                    if (Joueurs.Count <= 2)
                    {
                        PartieEnCours = false;
                        Joueurs = new ConcurrentDictionary<string, Joueur>();
                        Clients.All.SendAsync("InfoJoueur", null);

                    }
                    Clients.All.SendAsync("PartieEnCours", PartieEnCours);
                }
            }).Wait();

            Task.Run(() => { Clients.Others.SendAsync("NombreJoueurs", Joueurs.Count); }).Wait();
            return base.OnDisconnectedAsync(exception);
        }


        #region Ecran Indices
        public async Task EnvoyerIndices(string retour)
        {
            try
            {
                List<MutableKeyValue<string, string>> ListeMots = JsonSerializer.Deserialize<List<MutableKeyValue<string, string>>>(retour);

                foreach (Joueur gamer in Joueurs.Values)
                {
                    foreach (MutableKeyValue<string, string> mot in ListeMots)
                    {
                        if (mot.Key == gamer.MotADeviner)
                        {
                            gamer.Indices.Add(mot.Value);
                        }
                    }
                }

                Joueurs[Context.ConnectionId].EtapeJeu = EtapeJeu.AFiniDeDonnerIndices;

                string retr = JsonSerializer.Serialize(Joueurs[Context.ConnectionId]);
                await Clients.Caller.SendAsync("InfoJoueur", retr);




                bool toutLeMondeATermine = true;
                foreach (KeyValuePair<string, Joueur> KeyValue in Joueurs)
                {
                    Joueur gamer = KeyValue.Value;

                    if (gamer.EtapeJeu != EtapeJeu.AFiniDeDonnerIndices)
                    {
                        toutLeMondeATermine = false;
                    }
                }

                if (toutLeMondeATermine)
                {
                    foreach (KeyValuePair<string, Joueur> KeyValue in Joueurs)
                    {
                        Joueur gamer = KeyValue.Value;

                        gamer.EtapeJeu = EtapeJeu.EstEnTrainDeDeviner;
                        await Clients.Client(KeyValue.Value.ConnectionId).SendAsync("InfoJoueur", JsonSerializer.Serialize(gamer));
                    }
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }


        #endregion

        #region Ecran Deviner

        public async Task EnvoyerProposition(string proposition)
        {
            try
            {
                Joueurs[Context.ConnectionId].Proposition = proposition;
                Joueurs[Context.ConnectionId].EtapeJeu = EtapeJeu.AFiniDeDeviner;

                string retr = JsonSerializer.Serialize(Joueurs[Context.ConnectionId]);
                await Clients.Caller.SendAsync("InfoJoueur", retr);


                bool toutLeMondeATermine = true;
                foreach (KeyValuePair<string, Joueur> KeyValue in Joueurs)
                {
                    Joueur gamer = KeyValue.Value;

                    if (gamer.EtapeJeu != EtapeJeu.AFiniDeDeviner)
                    {
                        toutLeMondeATermine = false;
                    }
                }

                if (toutLeMondeATermine)
                {
                    foreach (KeyValuePair<string, Joueur> KeyValue in Joueurs)
                    {
                        Joueur gamer = KeyValue.Value;

                        gamer.EtapeJeu = EtapeJeu.EcranDeFin;
                        await Clients.Client(KeyValue.Value.ConnectionId).SendAsync("InfoJoueur", JsonSerializer.Serialize(gamer));
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }
        #endregion

        #region Ecran de fin
        public async Task RecupererJoueurs()
        {
            List<Joueur> gamers = new List<Joueur>();

            foreach (KeyValuePair<string, Joueur> KeyValue in Joueurs)
            {
                Joueur gamer = KeyValue.Value;

                gamer.EtapeJeu = EtapeJeu.EcranDeFin;
                await Clients.Client(KeyValue.Value.ConnectionId).SendAsync("InfoJoueur", JsonSerializer.Serialize(gamer));
            }


            string retr = JsonSerializer.Serialize(Joueurs);
                await Clients.Caller.SendAsync("InfoJoueur", retr);

        }

        #endregion

    }
}
