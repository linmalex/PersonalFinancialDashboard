#pragma checksum "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7cb5bb4f83ff685268b585d6426d485bebb4cf1b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_YnabLiabilityAccount_Delete), @"mvc.1.0.view", @"/Views/YnabLiabilityAccount/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/YnabLiabilityAccount/Delete.cshtml", typeof(AspNetCore.Views_YnabLiabilityAccount_Delete))]
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
#line 1 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\_ViewImports.cshtml"
using FinancialDashboard;

#line default
#line hidden
#line 2 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\_ViewImports.cshtml"
using FinancialDashboard.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7cb5bb4f83ff685268b585d6426d485bebb4cf1b", @"/Views/YnabLiabilityAccount/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79477945a6a1409120aa7368be286ae442cb4915", @"/Views/_ViewImports.cshtml")]
    public class Views_YnabLiabilityAccount_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FinancialDashboard.Models.YnabLiabilityAccount>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(99, 181, true);
            WriteLiteral("\r\n<h2>Delete</h2>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>YnabLiabilityAccount</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(281, 46, false);
#line 15 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PayOffDate));

#line default
#line hidden
            EndContext();
            BeginContext(327, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(371, 42, false);
#line 18 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PayOffDate));

#line default
#line hidden
            EndContext();
            BeginContext(413, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(457, 57, false);
#line 21 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.GoalDateMonthlyAmount));

#line default
#line hidden
            EndContext();
            BeginContext(514, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(558, 53, false);
#line 24 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayFor(model => model.GoalDateMonthlyAmount));

#line default
#line hidden
            EndContext();
            BeginContext(611, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(655, 50, false);
#line 27 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PayoffPriority));

#line default
#line hidden
            EndContext();
            BeginContext(705, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(749, 46, false);
#line 30 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PayoffPriority));

#line default
#line hidden
            EndContext();
            BeginContext(795, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(839, 40, false);
#line 33 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(879, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(923, 36, false);
#line 36 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(959, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1003, 40, false);
#line 39 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Type));

#line default
#line hidden
            EndContext();
            BeginContext(1043, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1087, 36, false);
#line 42 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Type));

#line default
#line hidden
            EndContext();
            BeginContext(1123, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1167, 45, false);
#line 45 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.On_budget));

#line default
#line hidden
            EndContext();
            BeginContext(1212, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1256, 41, false);
#line 48 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayFor(model => model.On_budget));

#line default
#line hidden
            EndContext();
            BeginContext(1297, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1341, 42, false);
#line 51 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Closed));

#line default
#line hidden
            EndContext();
            BeginContext(1383, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1427, 38, false);
#line 54 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Closed));

#line default
#line hidden
            EndContext();
            BeginContext(1465, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1509, 40, false);
#line 57 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Note));

#line default
#line hidden
            EndContext();
            BeginContext(1549, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1593, 36, false);
#line 60 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Note));

#line default
#line hidden
            EndContext();
            BeginContext(1629, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1673, 43, false);
#line 63 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Balance));

#line default
#line hidden
            EndContext();
            BeginContext(1716, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1760, 39, false);
#line 66 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Balance));

#line default
#line hidden
            EndContext();
            BeginContext(1799, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1843, 51, false);
#line 69 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Cleared_balance));

#line default
#line hidden
            EndContext();
            BeginContext(1894, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1938, 47, false);
#line 72 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Cleared_balance));

#line default
#line hidden
            EndContext();
            BeginContext(1985, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2029, 53, false);
#line 75 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Uncleared_balance));

#line default
#line hidden
            EndContext();
            BeginContext(2082, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2126, 49, false);
#line 78 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Uncleared_balance));

#line default
#line hidden
            EndContext();
            BeginContext(2175, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2219, 53, false);
#line 81 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Transfer_payee_id));

#line default
#line hidden
            EndContext();
            BeginContext(2272, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2316, 49, false);
#line 84 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Transfer_payee_id));

#line default
#line hidden
            EndContext();
            BeginContext(2365, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2409, 43, false);
#line 87 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Deleted));

#line default
#line hidden
            EndContext();
            BeginContext(2452, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2496, 39, false);
#line 90 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Deleted));

#line default
#line hidden
            EndContext();
            BeginContext(2535, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2579, 39, false);
#line 93 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.APR));

#line default
#line hidden
            EndContext();
            BeginContext(2618, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2662, 35, false);
#line 96 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayFor(model => model.APR));

#line default
#line hidden
            EndContext();
            BeginContext(2697, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2741, 57, false);
#line 99 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.MostRecentStatementID));

#line default
#line hidden
            EndContext();
            BeginContext(2798, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2842, 53, false);
#line 102 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
       Write(Html.DisplayFor(model => model.MostRecentStatementID));

#line default
#line hidden
            EndContext();
            BeginContext(2895, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(2933, 207, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6678edd2e5284dbf86f0bef32ad71aaf", async() => {
                BeginContext(2959, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(2969, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fc9e20812a914178811f46865efb77f8", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 107 "C:\Users\linma\source\repos\FinancialSitch\FinancialDashboard\Views\YnabLiabilityAccount\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ID);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3005, 84, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n        ");
                EndContext();
                BeginContext(3089, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bdeba6f269174970808ceed3f5d41b13", async() => {
                    BeginContext(3111, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3127, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3140, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FinancialDashboard.Models.YnabLiabilityAccount> Html { get; private set; }
    }
}
#pragma warning restore 1591
