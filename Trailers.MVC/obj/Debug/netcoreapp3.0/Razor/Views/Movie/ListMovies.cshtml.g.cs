#pragma checksum "D:\Projects\DotNet Kurzus\MovieTrailers\Trailers\Trailers.MVC\Views\Movie\ListMovies.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "747d99b23f3b7550fc79935afbcde1c736b31529"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movie_ListMovies), @"mvc.1.0.view", @"/Views/Movie/ListMovies.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Projects\DotNet Kurzus\MovieTrailers\Trailers\Trailers.MVC\Views\_ViewImports.cshtml"
using Trailers.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\DotNet Kurzus\MovieTrailers\Trailers\Trailers.MVC\Views\_ViewImports.cshtml"
using Trailers.MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"747d99b23f3b7550fc79935afbcde1c736b31529", @"/Views/Movie/ListMovies.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85de0a65ae50a8aaafa01fc203c7f7b4f7988157", @"/Views/_ViewImports.cshtml")]
    public class Views_Movie_ListMovies : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Movie>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Projects\DotNet Kurzus\MovieTrailers\Trailers\Trailers.MVC\Views\Movie\ListMovies.cshtml"
  
    ViewData["Title"] = "Movie Trailers";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome to the Companies page!</h1>
    <p>Learn about <a href=""https://docs.microsoft.com/aspnet/core"">building Web apps with ASP.NET Core</a>.</p>
    <table>
        <tr>
            <th>Title</th>
            <th>Trailer</th>
        </tr>
");
#nullable restore
#line 14 "D:\Projects\DotNet Kurzus\MovieTrailers\Trailers\Trailers.MVC\Views\Movie\ListMovies.cshtml"
         foreach (var movie in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 17 "D:\Projects\DotNet Kurzus\MovieTrailers\Trailers\Trailers.MVC\Views\Movie\ListMovies.cshtml"
               Write(movie.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                   <iframe");
            BeginWriteAttribute("src", " src=\"", 531, "\"", 554, 1);
#nullable restore
#line 19 "D:\Projects\DotNet Kurzus\MovieTrailers\Trailers\Trailers.MVC\Views\Movie\ListMovies.cshtml"
WriteAttributeValue("", 537, movie.TrailerUrl, 537, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></iframe> \r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 22 "D:\Projects\DotNet Kurzus\MovieTrailers\Trailers\Trailers.MVC\Views\Movie\ListMovies.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </table>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Movie>> Html { get; private set; }
    }
}
#pragma warning restore 1591
