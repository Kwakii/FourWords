#pragma checksum "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DonnerIndice.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60ad018c80cf7ddf3f221fc3517695b29c2018d1"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 1 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DonnerIndice.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DonnerIndice.razor"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DonnerIndice.razor"
using BlazorChat.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DonnerIndice.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DonnerIndice.razor"
using BlazorChat.Client.Pages.QuatreMots;

#line default
#line hidden
#nullable disable
    public partial class DonnerIndice : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 44 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DonnerIndice.razor"
       

    [Parameter]
    public Joueur Joueur { get; set; }


    [Parameter]
    public HubConnection hubConnection { get; set; }

    private List<MutableKeyValue<string, string>> MotsAFaireDeviner = new List<MutableKeyValue<string, string>>();


    protected override async Task OnInitializedAsync()
    {
        //Récupérer les trois mots
        hubConnection.On<List<String>>("MotsAFaireDeviner", (motsAFaireDeviner) =>
        {
            _logger.LogInformation("On arrive dans client mot à faire deviner");

            foreach (string mot in motsAFaireDeviner)
            {
                MotsAFaireDeviner.Add(new MutableKeyValue<string, string>(mot, ""));
            }

            StateHasChanged();
        });

        await hubConnection.SendAsync("RecupererMotsAFaireDeviner");

    }

    public async Task EnvoyerIndices()
    {
        string envoi = JsonSerializer.Serialize(MotsAFaireDeviner);

        _logger.LogInformation("On envoi les mots" + envoi.ToString());
        await hubConnection.SendAsync("EnvoyerIndices", envoi);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILogger<FourWords> _logger { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
