#pragma checksum "C:\Users\Nnh\source\repos\Sl_Proyecto\Proyecto\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f00c44878fac029e348dcb8c8498370d689f1bbe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Proyecto.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace Proyecto.Pages
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
#line 1 "C:\Users\Nnh\source\repos\Sl_Proyecto\Proyecto\Pages\_ViewImports.cshtml"
using Proyecto;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f00c44878fac029e348dcb8c8498370d689f1bbe", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"021c0587621d874ef19d5e70e46092064258cf8c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Nnh\source\repos\Sl_Proyecto\Proyecto\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<!--<table class=""arriba"">

    <tbody class=""tabla"" style=""color:red"">
        <tr>
            <td style=""width: 228px; text-align: center"">
                <a class=""btn btn-secondary"" asp-page=""./TemaPages/Index"">Crud Temas</a>
            </td>
        </tr>
        <tr>
            <td style=""width: 228px; text-align: center"">
                <a asp-page=""./DocentesPages/Index"">Crud Docentes</a>
            </td>
        </tr>
        <tr>
            <td style=""width: 228px; text-align: center"">
                <a asp-page=""./EstudiantesPages/Index"">Crud Estudiantes</a>
            </td>
        </tr>

        <tr>
            <td style=""width: 228px; text-align: center"">
                <a asp-page=""./GruposPages/Index"">Crud Grupos</a>
            </td>
        </tr>
        <tr>
            <td style=""width: 228px; text-align: center"">
                <a asp-page=""./IntegracionPages/Index"">Crud Integracion</a>
            </td>
        </tr>
        <tr>
          ");
            WriteLiteral("  <td style=\"width: 228px; text-align: center\">\r\n                <a asp-page=\"./EntregasPages/Index\">Crud Entregas</a>\r\n            </td>\r\n        </tr>\r\n    </tbody>\r\n</table>-->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
