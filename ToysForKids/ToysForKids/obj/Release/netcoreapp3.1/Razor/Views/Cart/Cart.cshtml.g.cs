#pragma checksum "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72bf576efe1f13a5272316bcff09ee4b0c999abe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Cart), @"mvc.1.0.view", @"/Views/Cart/Cart.cshtml")]
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
#line 1 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\_ViewImports.cshtml"
using ToysForKids;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\_ViewImports.cshtml"
using ToysForKids.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\_ViewImports.cshtml"
using ToysForKids.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\_ViewImports.cshtml"
using ToysForKids.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\_ViewImports.cshtml"
using ToysForKids.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\_ViewImports.cshtml"
using ToysForKids.DbContexts;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72bf576efe1f13a5272316bcff09ee4b0c999abe", @"/Views/Cart/Cart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f07495ba8269e4a7562af15dfe8d2a2503e0bca1", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Cart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ToysForKids.Models.CartItem>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/scripts/cart.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
  
    ViewData["Title"] = "Cart";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var userId = "userIs";
    if (User.Identity.IsAuthenticated)
    {
        userId = userManager.GetUserId(User);
    }


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>Cart</h3>\r\n\r\n");
#nullable restore
#line 16 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
 if (Model.Count > 0)
{
    long totalAmount = 0;
    long count = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table table-hover table-dark"">
        <thead>
            <tr>
                <th>#</th>
                <th>Product Name</th>
                <th>Unit Price</th>
                <th>Count</th>
                <th>Total</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody class=""tbody"">
");
#nullable restore
#line 32 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
             foreach (var item in Model)
            {
                var cost = item.quantity * item.product.UnitPrice;
                totalAmount += cost;
                count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 38 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
                   Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 40 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
                   Write(item.product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 43 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
                   Write(item.product.UnitPrice.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "72bf576efe1f13a5272316bcff09ee4b0c999abe7016", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 46 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => item.quantity);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 46 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
AddHtmlAttributeValue("", 1315, $"quantity-{item.product.ProductId}", 1315, 39, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 49 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
                   Write(cost.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <button class=\"btn btn-success updatecartitem\" data-productid=\"");
#nullable restore
#line 52 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
                                                                                  Write(item.product.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            Update\r\n                        </button>\r\n                        <a data-productid=\"");
#nullable restore
#line 55 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
                                      Write(item.product.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"btn btn-danger removeproduct\">Remove</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 58 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n        <tfoot id=\"tfoot\">\r\n            <tr>\r\n                <td colspan=\"4\" class=\"text-right\">Total Amount</td>\r\n                <td>");
#nullable restore
#line 64 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
                Write(totalAmount.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><a class=\"btn btn-success checkout\" data-userid=\"");
#nullable restore
#line 65 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
                                                                Write(userId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-total=\"");
#nullable restore
#line 65 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
                                                                                     Write(totalAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Checkout</a></td>\r\n            </tr>\r\n        </tfoot>\r\n    </table>\r\n");
#nullable restore
#line 69 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p class=\"alert alert-danger\">Empty Cart</p>\r\n");
#nullable restore
#line 74 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
}

#line default
#line hidden
#nullable disable
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 77 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
     if (User.Identity.IsAuthenticated)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"        <script>
            $('.checkout').click(function (event) {               
                event.preventDefault();
                var userid = $(this).attr(""data-userid"");
                var total = parseInt($(this).attr(""data-total""));
                bootbox.confirm({
                    message: ""Are you sure?"",
                    buttons: {
                        confirm: {
                            label: 'Yes',
                            className: 'btn-success'
                        },
                        cancel: {
                            label: 'No',
                            className: 'btn-danger'
                        }
                    },
                    callback: function () {
                        $.ajax({
                            url: '/Cart/Checkout',
                            method: 'GET',
                            success: function (result) {
                                $.ajax({
                                    url:");
                WriteLiteral(@" `/Order/CreateOrder/${userid}/${result}/${total}`,
                                    method: 'POST',
                                    contentType: 'application/json',
                                    dataType: 'json',
                                    success: function () {
                                        bootbox.alert({
                                            message: ""Thank you! Click Ok to continued shopping"",
                                            callback: function () {
                                                location.reload();
                                            }
                                        })
                                    },
                                    error: function () {
                                        bootbox.alert(""Checkout failed! Please try again!"");
                                    }
                                })
                            }
                        })
                    }
");
                WriteLiteral("                });               \r\n            })\r\n        </script>\r\n");
#nullable restore
#line 124 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script>\r\n            $(\'.checkout\').click(function () {\r\n                window.location.href = \'/Account/Login\';\r\n            })\r\n        </script>\r\n");
#nullable restore
#line 132 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72bf576efe1f13a5272316bcff09ee4b0c999abe15080", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 133 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Cart\Cart.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<AppIdentityUser> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ToysForKids.Models.CartItem>> Html { get; private set; }
    }
}
#pragma warning restore 1591
