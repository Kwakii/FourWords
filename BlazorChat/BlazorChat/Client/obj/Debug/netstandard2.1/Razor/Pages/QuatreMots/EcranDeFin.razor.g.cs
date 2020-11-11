#pragma checksum "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\EcranDeFin.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1da53f4b128c23e5b376a724f8b67923851af07"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorChat.Client.Pages.QuatreMots
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
#line 1 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\EcranDeFin.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\EcranDeFin.razor"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\EcranDeFin.razor"
using BlazorChat.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\EcranDeFin.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\EcranDeFin.razor"
using BlazorChat.Client.Pages.QuatreMots;

#line default
#line hidden
#nullable disable
    public partial class EcranDeFin : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>EcranDeFin</h3>");
        }
        #pragma warning restore 1998
#nullable restore
#line 11 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\EcranDeFin.razor"
       

    [Parameter]
    public Joueur Joueur { get; set; }


    [Parameter]
    public HubConnection hubConnection { get; set; }

    public List<Joueur> Joueurs { get; set; }

    protected override async Task OnInitializedAsync()
    {
        //Récupérer les trois mots
        hubConnection.On<List<String>>("RecupererJoueurs", (joueurs) =>
        {


            StateHasChanged();
        });

        await hubConnection.SendAsync("RecupererJoueurs");

    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILogger<FourWords> _logger { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
