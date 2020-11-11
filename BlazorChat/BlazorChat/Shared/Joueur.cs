using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChat.Shared
{
    [Serializable]
    public class Joueur
    {


        public string Pseudo { get; set; }

        public string ConnectionId { get; set; }

        /// <summary>Ou se trouve le joueur dans les étapes du jeu</summary>
        public EtapeJeu EtapeJeu { get; set; }

        /// <summary>Mot à deviner du joueur</summary>
        public string MotADeviner { get; set; }

        /// <summary>Indices du mot</summary>
        public List<String> Indices { get; set; } = new List<string>();

        /// <summary>Proposition du joueur</summary>
        public string Proposition { get; set; }

        /// <summary>Pour la serialization on a besoin d'un constructeur sans paramètre</summary>
        public Joueur()
        {

        }

        public Joueur(string pseudo, string connectionId)
        {
            Pseudo = pseudo;
            ConnectionId = connectionId;
        }

        /// <summary>Indique si l'utilisateur est en jeu</summary>
        /// <returns></returns>
        public bool EstEnJeu()
        {
            return EtapeJeu != EtapeJeu.Lobby && EtapeJeu != EtapeJeu.EnAttenteDeLancement;
        }

    }

    public enum EtapeJeu
    {
        Lobby,
        EnAttenteDeLancement, 
        EstEnTrainDeDonnerIndice, 
        AFiniDeDonnerIndices,
        EstEnTrainDeDeviner,
        AFiniDeDeviner,
        EcranDeFin
    }
}
