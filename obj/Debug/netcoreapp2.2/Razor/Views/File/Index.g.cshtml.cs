#pragma checksum "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "629b1e79393bcedbc63400a4518a47f636675f6d"
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
#line 1 "/Users/kirill/Projects/Geoportal/Geoportal/Views/_ViewImports.cshtml"
using Geoportal;

#line default
#line hidden
#line 2 "/Users/kirill/Projects/Geoportal/Geoportal/Views/_ViewImports.cshtml"
using Geoportal.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"629b1e79393bcedbc63400a4518a47f636675f6d", @"/Views/File/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c80c61fa86dc36c6e058b2d9559c6cd93bd7654d", @"/Views/_ViewImports.cshtml")]
    public class Views_File_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Geoportal.DemandArchiveErs>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Ramka", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Ramka", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OnPostDeleteAsync", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "file", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("Data_bd"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml"
  
        Layout = "_Layout";
    

#line default
#line hidden
            BeginContext(110, 27, true);
            WriteLiteral("<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(137, 113, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "629b1e79393bcedbc63400a4518a47f636675f6d6580", async() => {
                BeginContext(143, 100, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Все значения из бд</title>\r\n");
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
            BeginContext(250, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(252, 1758, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "629b1e79393bcedbc63400a4518a47f636675f6d7850", async() => {
                BeginContext(258, 70, true);
                WriteLiteral("\r\n    <a href=\"/File/Create\">Добавить новый файл</a>\r\n    <br />\r\n    ");
                EndContext();
                BeginContext(328, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "629b1e79393bcedbc63400a4518a47f636675f6d8301", async() => {
                    BeginContext(373, 14, true);
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
                BeginContext(391, 51, true);
                WriteLiteral("\r\n\r\n    <div>\r\n        <h3>Названия файлов</h3>\r\n\r\n");
                EndContext();
                BeginContext(579, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(681, 94, true);
                WriteLiteral("    </div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n    <!--Вывод значений из бд-->\r\n    <h3>вы добавили запись с id: ");
                EndContext();
                BeginContext(776, 14, false);
#line 43 "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml"
                            Write(ViewData["ID"]);

#line default
#line hidden
                EndContext();
                BeginContext(790, 11, true);
                WriteLiteral("</h3>\r\n    ");
                EndContext();
                BeginContext(801, 1200, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "629b1e79393bcedbc63400a4518a47f636675f6d10707", async() => {
                    BeginContext(869, 270, true);
                    WriteLiteral(@"
        <table class=""table"">
            <tr><td>DemandArchiveErsNr</td><td>WorkstationsNr</td><td>Status</td><td>DtstampBeginDemand</td><td>RegionTypesNr</td><td>TypesDemandNr</td><td>Priority</td><td>ConfirmDeleteAfterArchive</td><td>ServiceTypeToShare</td></tr>
");
                    EndContext();
#line 47 "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
                    BeginContext(1196, 46, true);
                    WriteLiteral("                <tr>\r\n                    <td>");
                    EndContext();
                    BeginContext(1243, 23, false);
#line 50 "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml"
                   Write(item.DemandArchiveErsNr);

#line default
#line hidden
                    EndContext();
                    BeginContext(1266, 31, true);
                    WriteLiteral("</td>\r\n                    <td>");
                    EndContext();
                    BeginContext(1298, 19, false);
#line 51 "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml"
                   Write(item.WorkstationsNr);

#line default
#line hidden
                    EndContext();
                    BeginContext(1317, 31, true);
                    WriteLiteral("</td>\r\n                    <td>");
                    EndContext();
                    BeginContext(1349, 11, false);
#line 52 "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml"
                   Write(item.Status);

#line default
#line hidden
                    EndContext();
                    BeginContext(1360, 31, true);
                    WriteLiteral("</td>\r\n                    <td>");
                    EndContext();
                    BeginContext(1392, 23, false);
#line 53 "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml"
                   Write(item.DtstampBeginDemand);

#line default
#line hidden
                    EndContext();
                    BeginContext(1415, 31, true);
                    WriteLiteral("</td>\r\n                    <td>");
                    EndContext();
                    BeginContext(1447, 18, false);
#line 54 "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml"
                   Write(item.RegionTypesNr);

#line default
#line hidden
                    EndContext();
                    BeginContext(1465, 31, true);
                    WriteLiteral("</td>\r\n                    <td>");
                    EndContext();
                    BeginContext(1497, 18, false);
#line 55 "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml"
                   Write(item.TypesDemandNr);

#line default
#line hidden
                    EndContext();
                    BeginContext(1515, 31, true);
                    WriteLiteral("</td>\r\n                    <td>");
                    EndContext();
                    BeginContext(1547, 13, false);
#line 56 "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml"
                   Write(item.Priority);

#line default
#line hidden
                    EndContext();
                    BeginContext(1560, 31, true);
                    WriteLiteral("</td>\r\n                    <td>");
                    EndContext();
                    BeginContext(1592, 30, false);
#line 57 "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml"
                   Write(item.ConfirmDeleteAfterArchive);

#line default
#line hidden
                    EndContext();
                    BeginContext(1622, 31, true);
                    WriteLiteral("</td>\r\n                    <td>");
                    EndContext();
                    BeginContext(1654, 23, false);
#line 58 "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml"
                   Write(item.ServiceTypeToShare);

#line default
#line hidden
                    EndContext();
                    BeginContext(1677, 33, true);
                    WriteLiteral("</td>\r\n\r\n                    <td>");
                    EndContext();
                    BeginContext(1710, 69, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "629b1e79393bcedbc63400a4518a47f636675f6d15257", async() => {
                        BeginContext(1771, 4, true);
                        WriteLiteral("edit");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                    if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                    {
                        throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                    }
                    BeginWriteTagHelperAttribute();
#line 60 "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml"
                                               WriteLiteral(item.DemandArchiveErsNr);

#line default
#line hidden
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(1779, 36, true);
                    WriteLiteral(" </td>\r\n\r\n\r\n                    <td>");
                    EndContext();
                    BeginContext(1815, 108, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "629b1e79393bcedbc63400a4518a47f636675f6d17840", async() => {
                        BeginContext(1908, 6, true);
                        WriteLiteral("Delete");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                    if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                    {
                        throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                    }
                    BeginWriteTagHelperAttribute();
#line 63 "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml"
                                                                               WriteLiteral(item.DemandArchiveErsNr);

#line default
#line hidden
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(1923, 34, true);
                    WriteLiteral("</td>\r\n\r\n\r\n                </tr>\r\n");
                    EndContext();
#line 67 "/Users/kirill/Projects/Geoportal/Geoportal/Views/File/Index.cshtml"
            }

#line default
#line hidden
                    BeginContext(1972, 22, true);
                    WriteLiteral("        </table>\r\n    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2001, 2, true);
                WriteLiteral("\r\n");
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
            BeginContext(2010, 11, true);
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
