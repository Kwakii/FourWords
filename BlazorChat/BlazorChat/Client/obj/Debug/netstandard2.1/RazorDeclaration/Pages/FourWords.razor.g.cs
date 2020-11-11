#pragma checksum "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\FourWords.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0e4539edcf7bfcdd41091244f8ee6c0d930e21b"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorChat.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\_Imports.razor"
using BlazorChat.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\_Imports.razor"
using BlazorChat.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\FourWords.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\FourWords.razor"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\FourWords.razor"
using BlazorChat.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\FourWords.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\FourWords.razor"
using BlazorChat.Client.Pages.QuatreMots;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/FourWordsGame")]
    public partial class FourWords : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 64 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\FourWords.razor"
       

    private HubConnection hubConnection;
    private string pseudo = "";
    private bool Connecte = false;
    private Joueur Joueur = null;
    private bool PartieEnCours = false;


    private int nbJoueursConnectes = 0;

    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl(NavigationManager.ToAbsoluteUri("/FourWords"))
            .Build();

        hubConnection.On<int>("NombreJoueurs", (nbJoueurs) =>
        {
            nbJoueursConnectes = nbJoueurs;
            _logger.LogInformation("Nombre Joueur");
            StateHasChanged();
        });

        hubConnection.On<string>("InfoJoueur", (retour) =>
        {
            _logger.LogInformation(retour);

            try
            {
                Joueur = JsonSerializer.Deserialize<Joueur>(retour);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                Joueur = null;
            }
            StateHasChanged();
        });

        hubConnection.On<bool>("PartieEnCours", (enCours) =>
        {
            PartieEnCours = enCours;
            StateHasChanged();
        });


        await hubConnection.StartAsync();
        await hubConnection.SendAsync("Initialiser");
    }

    public bool IsConnected => hubConnection?.State == HubConnectionState.Connected;


    public async Task Jouer()
    {
        await hubConnection.SendAsync("Jouer", pseudo, hubConnection.ConnectionId);
        Connecte = true;
    }


    public void Dispose()
    {
        _logger.LogInformation("Dispose");
        Task.Run(() =>
        {
            hubConnection.SendAsync("Deconnecter", pseudo, hubConnection.ConnectionId);
        }).Wait();

        _ = hubConnection.DisposeAsync();
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILogger<FourWords> _logger { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591