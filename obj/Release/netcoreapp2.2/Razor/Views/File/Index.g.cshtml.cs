#pragma checksum "C:\Users\Кирилл\Desktop\Geoportal\Geoportal\Views\File\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "28d153f14051d17a8b9c0677c4104aa4b3329ffa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_File_Index), @"mvc.1.0.view", @"/Views/File/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/File/Index.cshtml", typeof(AspNetCore.Views_File_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28d153f14051d17a8b9c0677c4104aa4b3329ffa", @"/Views/File/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c80c61fa86dc36c6e058b2d9559c6cd93bd7654d", @"/Views/_ViewImports.cshtml")]
    public class Views_File_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Geoportal.DemandArchiveErs>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Ramka", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "File", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Кирилл\Desktop\Geoportal\Geoportal\Views\File\Index.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(80, 27, true);
            WriteLiteral("<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(107, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "28d153f14051d17a8b9c0677c4104aa4b3329ffa4219", async() => {
                BeginContext(113, 61, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(181, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(183, 636, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "28d153f14051d17a8b9c0677c4104aa4b3329ffa5466", async() => {
                BeginContext(189, 70, true);
                WriteLiteral("\r\n    <a href=\"/File/Send\">Добавить новый файл</a>\r\n    <br />\r\n      ");
                EndContext();
                BeginContext(259, 62, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "28d153f14051d17a8b9c0677c4104aa4b3329ffa5922", async() => {
                    BeginContext(303, 14, true);
                    WriteLiteral("Добавить рамку");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(321, 173, true);
                WriteLiteral("\r\n    <!-- <button name=\"button\" value=\"ramka\">Добавить рамку</button>-->\r\n\r\n    <div>\r\n        <h3>Вы добавили файлы: </h3>\r\n        <h2>Путь к каталогу: </h2>\r\n        <p>");
                EndContext();
                BeginContext(495, 16, false);
#line 20 "C:\Users\Кирилл\Desktop\Geoportal\Geoportal\Views\File\Index.cshtml"
      Write(ViewData["Path"]);

#line default
#line hidden
                EndContext();
                BeginContext(511, 76, true);
                WriteLiteral("</p>\r\n        <br />\r\n        <h2>\"№ пакета архивирования:</h2>\r\n        <p>");
                EndContext();
                BeginContext(588, 14, false);
#line 23 "C:\Users\Кирилл\Desktop\Geoportal\Geoportal\Views\File\Index.cshtml"
      Write(ViewData["ID"]);

#line default
#line hidden
                EndContext();
                BeginContext(602, 60, true);
                WriteLiteral("</p>\r\n        <br />\r\n        <h2>\"№ файла в пакете</h2>\r\n\r\n");
                EndContext();
#line 27 "C:\Users\Кирилл\Desktop\Geoportal\Geoportal\Views\File\Index.cshtml"
         foreach (var files_id in (List<long?>)ViewBag.FilesID)
        {

#line default
#line hidden
                BeginContext(738, 15, true);
                WriteLiteral("            <p>");
                EndContext();
                BeginContext(754, 19, false);
#line 29 "C:\Users\Кирилл\Desktop\Geoportal\Geoportal\Views\File\Index.cshtml"
          Write(files_id.ToString());

#line default
#line hidden
                EndContext();
                BeginContext(773, 6, true);
                WriteLiteral("</p>\r\n");
                EndContext();
#line 30 "C:\Users\Кирилл\Desktop\Geoportal\Geoportal\Views\File\Index.cshtml"
        }

#line default
#line hidden
                BeginContext(790, 22, true);
                WriteLiteral("\r\n\r\n\r\n\r\n    </div>\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(819, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Geoportal.DemandArchiveErs>> Html { get; private set; }
    }
}
#pragma warning restore 1591
