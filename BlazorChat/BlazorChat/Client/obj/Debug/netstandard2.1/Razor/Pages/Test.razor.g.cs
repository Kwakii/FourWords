#pragma checksum "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\Test.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ecf21e9cda2aa04439b3a9b1894134588f4f0f3"
// <auto-generated/>
#pragma warning disable 1591
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/mescouilles")]
    public partial class Test : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Test</h3>\r\n\r\n");
            __builder.OpenElement(1, "p");
            __builder.AddContent(2, 
#nullable restore
#line 5 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\Test.razor"
    mescouilles

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 8 "C:\Users\crapo\source\repos\BlazorChat\BlazorChat\Client\Pages\Test.razor"
       

    private string mescouilles = "";


    protected override async Task OnInitializedAsync()
    {
        mescouilles = await Http.GetFromJsonAsync<string>("Test");
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
