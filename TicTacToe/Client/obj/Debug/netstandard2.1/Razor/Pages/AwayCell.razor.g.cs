#pragma checksum "G:\HORVAT\workshop\initial\TicTacToe\Client\Pages\AwayCell.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5dbc7b2f526b51c8f70b93ae5a7d633dc418135"
// <auto-generated/>
#pragma warning disable 1591
namespace TicTacToe.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "G:\HORVAT\workshop\initial\TicTacToe\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\HORVAT\workshop\initial\TicTacToe\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\HORVAT\workshop\initial\TicTacToe\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\HORVAT\workshop\initial\TicTacToe\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "G:\HORVAT\workshop\initial\TicTacToe\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "G:\HORVAT\workshop\initial\TicTacToe\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "G:\HORVAT\workshop\initial\TicTacToe\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "G:\HORVAT\workshop\initial\TicTacToe\Client\_Imports.razor"
using TicTacToe.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "G:\HORVAT\workshop\initial\TicTacToe\Client\_Imports.razor"
using TicTacToe.Client.Shared;

#line default
#line hidden
#nullable disable
    public partial class AwayCell : CellComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "svg");
            __builder.AddAttribute(1, "viewBox", "0 0 300 300");
            __builder.AddAttribute(2, "x", 
#nullable restore
#line 2 "G:\HORVAT\workshop\initial\TicTacToe\Client\Pages\AwayCell.razor"
                              X

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(3, "y", 
#nullable restore
#line 2 "G:\HORVAT\workshop\initial\TicTacToe\Client\Pages\AwayCell.razor"
                                   Y

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(4, "width", "300");
            __builder.AddAttribute(5, "height", "300");
            __builder.AddMarkupContent(6, "\r\n    <ellipse cx=\"150\" cy=\"150\" rx=\"75\" ry=\"105\" stroke-width=\"35\" stroke=\"darkgreen\" fill-opacity=\"0\"></ellipse>\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
