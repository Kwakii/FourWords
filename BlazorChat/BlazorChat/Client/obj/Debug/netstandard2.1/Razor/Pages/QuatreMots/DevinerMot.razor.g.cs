#pragma checksum "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cff1a172202c904c548f3a64d28df4b709aee08c"
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
#line 1 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor"
using BlazorChat.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor"
using BlazorChat.Client.Pages.QuatreMots;

#line default
#line hidden
#nullable disable
    public partial class DevinerMot : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>DevinerMot</h3>\r\n\r\n");
#nullable restore
#line 11 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor"
 if (Joueur != null)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor"
     foreach (string indice in Joueur.Indices)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(1, "        ");
            __builder.OpenElement(2, "label");
            __builder.AddContent(3, 
#nullable restore
#line 15 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor"
                indice

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n");
#nullable restore
#line 16 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.AddContent(5, "    ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "form-group");
            __builder.AddMarkupContent(8, "\r\n        ");
            __builder.OpenElement(9, "label");
            __builder.AddMarkupContent(10, "\r\n            Votre proposition:\r\n            ");
            __builder.OpenElement(11, "input");
            __builder.AddAttribute(12, "size", "50");
            __builder.AddAttribute(13, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 21 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor"
                           proposition

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(14, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => proposition = __value, proposition));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n");
            __builder.AddContent(18, "    ");
            __builder.OpenElement(19, "button");
            __builder.AddAttribute(20, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 25 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor"
                      EnvoyerProposition

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(21, "Envoyer proposition");
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n");
#nullable restore
#line 27 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor"
     if (Joueur.EtapeJeu == EtapeJeu.AFiniDeDeviner)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(23, "        ");
            __builder.AddMarkupContent(24, "<p>En attente des autres joueurs</p>\r\n");
#nullable restore
#line 30 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor"
     
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 33 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\QuatreMots\DevinerMot.razor"
       
    [Parameter]
    public Joueur Joueur { get; set; }

    [Parameter]
    public HubConnection hubConnection { get; set; }

    private string proposition;

    public async Task EnvoyerProposition()
    {

        _logger.LogInformation("On envoi la proposition" + proposition.ToString());
        await hubConnection.SendAsync("EnvoyerProposition", proposition);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILogger<FourWords> _logger { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
