#pragma checksum "C:\Users\Кирилл\Desktop\Geoportal\Geoportal\Views\File\Ramka_Added_SHP.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c19c0262a9485a1c88be9f8c0c392a85f85e3726"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_File_Ramka_Added_SHP), @"mvc.1.0.view", @"/Views/File/Ramka_Added_SHP.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/File/Ramka_Added_SHP.cshtml", typeof(AspNetCore.Views_File_Ramka_Added_SHP))]
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
#line 1 "C:\Users\Кирилл\Desktop\Geoportal\Geoportal\Views\_ViewImports.cshtml"
using Geoportal;

#line default
#line hidden
#line 2 "C:\Users\Кирилл\Desktop\Geoportal\Geoportal\Views\_ViewImports.cshtml"
using Geoportal.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c19c0262a9485a1c88be9f8c0c392a85f85e3726", @"/Views/File/Ramka_Added_SHP.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c80c61fa86dc36c6e058b2d9559c6cd93bd7654d", @"/Views/_ViewImports.cshtml")]
    public class Views_File_Ramka_Added_SHP : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Кирилл\Desktop\Geoportal\Geoportal\Views\File\Ramka_Added_SHP.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(34, 81, true);
            WriteLiteral("<h1>Рамка в виде SHP файла была успешна добавлена</h1>\r\n<p>Номер рамки: </p>\r\n<p>");
            EndContext();
            BeginContext(116, 18, false);
#line 7 "C:\Users\Кирилл\Desktop\Geoportal\Geoportal\Views\File\Ramka_Added_SHP.cshtml"
Write(ViewData["Cmr_id"]);

#line default
#line hidden
            EndContext();
            BeginContext(134, 8, true);
            WriteLiteral("</p>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
