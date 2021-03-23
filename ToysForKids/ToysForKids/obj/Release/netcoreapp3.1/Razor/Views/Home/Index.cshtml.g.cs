#pragma checksum "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cfe6aeac93e3c28b03c3808170885cdb795853e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfe6aeac93e3c28b03c3808170885cdb795853e7", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f07495ba8269e4a7562af15dfe8d2a2503e0bca1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Category", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("primary-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("filter__controls primary-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
  
    var categories = categoryService.GetAll();
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!--Carousel Section Begin -->
<section class=""hero"">
    <div class=""container"">
        <div class=""hero__slider owl-carousel"">
            <div class=""hero__items set-bg"" data-setbg=""images/Carousel1.jpg"">
                <div class=""row"">
                    <div class=""col-lg-6"">
                        <div class=""hero__text"">
                            <div class=""label"">RC Car</div>
                            <h2>Fate / Stay Night: Unlimited Blade Works</h2>
                            <p>After 30 days of travel across the world...</p>
                            <a href=""#""><span>See More</span> <i class=""fa fa-angle-right""></i></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""hero__items set-bg"" data-setbg=""images/Carousel2.jpg"">
                <div class=""row"">
                    <div class=""col-lg-6"">
                        <div class=""hero__text"">
                            <div class=""label"">");
            WriteLiteral(@"RC Aircraft</div>
                            <h2>Fate / Stay Night: Unlimited Blade Works</h2>
                            <p>After 30 days of travel across the world...</p>
                            <a href=""#""><span>See More</span> <i class=""fa fa-angle-right""></i></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""hero__items set-bg"" data-setbg=""images/Carousel3.jpg"">
                <div class=""row"">
                    <div class=""col-lg-6"">
                        <div class=""hero__text"">
                            <div class=""label"">RC Destroyer</div>
                            <h2>Fate / Stay Night: Unlimited Blade Works</h2>
                            <p>After 30 days of travel across the world...</p>
                            <a href=""#""><span>See More</span> <i class=""fa fa-angle-right""></i></a>
                        </div>
                    </div>
                </div>
            </div>
 ");
            WriteLiteral(@"           <div class=""hero__items set-bg"" data-setbg=""images/Carousel4.jpg"">
                <div class=""row"">
                    <div class=""col-lg-6"">
                        <div class=""hero__text"">
                            <div class=""label"">RC Tank</div>
                            <h2>Fate / Stay Night: Unlimited Blade Works</h2>
                            <p>After 30 days of travel across the world...</p>
                            <a href=""#""><span>See More</span> <i class=""fa fa-angle-right""></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!--Carousel Section Begin -->
<!-- Product Section Begin -->
<section class=""product spad"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-8"">
                <div class=""row"">
");
#nullable restore
#line 68 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                     foreach (var items in categories)
                    {
                        if (items.CategoryName != "Drone")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-lg-8 col-md-8 col-sm-8\">\r\n                                <div class=\"section-title\">\r\n                                    <h4>");
#nullable restore
#line 74 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                   Write(items.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"col-lg-4 col-md-4 col-sm-4\">\r\n                                <div class=\"btn__all\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cfe6aeac93e3c28b03c3808170885cdb795853e710027", async() => {
                WriteLiteral("View All <span class=\"arrow_right\"></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 79 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                                                                       WriteLiteral(items.CategoryId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"row\">\r\n");
#nullable restore
#line 83 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                  
                                    var prod = new Stack<Product>(items.Products);
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                 for (int i = 0; i < 3; i++)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""col-lg-4 col-md-6 col-sm-6"">
                                        <div class=""product__item"">
                                            <div class=""product__item__pic set-bg"" data-setbg=""images/Products/");
#nullable restore
#line 90 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                                                                                          Write(prod.Peek().FileAvatarName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                                <div class=\"comment\"><i class=\"fa fa-coins\"></i>   ");
#nullable restore
#line 91 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                                                                              Write(prod.Peek().UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                                <button class=""view""><i class=""fa fa-shopping-cart""></i>  ADD CART</button>
                                            </div>
                                            <div class=""product__item__text"">
                                                <h5>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cfe6aeac93e3c28b03c3808170885cdb795853e714626", async() => {
#nullable restore
#line 95 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                                                                                                                     Write(prod.Pop().ProductName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 95 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                                                                                      WriteLiteral(prod.Peek().ProductId);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("</h5>\r\n                                            </div>\r\n                                        </div>\r\n                                    </div>\r\n");
#nullable restore
#line 99 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n");
#nullable restore
#line 101 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n            <div class=\"col-lg-4 col-md-6 col-sm-8\">\r\n                <div class=\"product__sidebar\">\r\n                    <div class=\"product__sidebar__view\">\r\n");
#nullable restore
#line 108 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                         foreach (var items in categories)
                        {
                            if (items.CategoryName == "Drone")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"section-title\">\r\n                                    <h5>Drone</h5>\r\n                                </div>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cfe6aeac93e3c28b03c3808170885cdb795853e718775", async() => {
                WriteLiteral("\r\n                                    View All <span class=\"arrow_right\"></span>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 115 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                                                                                                        WriteLiteral(items.CategoryId);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n                                <div class=\"filter__gallery\">\r\n");
#nullable restore
#line 119 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                      
                                        var prod = new Stack<Product>
                                        (items.Products);
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 122 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                         for (int i = 0; i < 3; i++)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <div class=\"product__sidebar__view__item set-bg\"\r\n                                                 data-setbg=\"images/Products/");
#nullable restore
#line 125 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                                                        Write(prod.Peek().FileAvatarName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                                <div class=\"ep\">\r\n                                                    <i class=\"fa fa-coins\"></i>   ");
#nullable restore
#line 127 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                                                             Write(prod.Peek().UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </div>\r\n                                                <button class=\"view\"><i class=\"fa fa-shopping-cart\"></i>  ADD CART</button>\r\n                                                <h5>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cfe6aeac93e3c28b03c3808170885cdb795853e723330", async() => {
#nullable restore
#line 130 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                                                                                                                     Write(prod.Pop().ProductName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 130 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                                                                                      WriteLiteral(prod.Peek().ProductId);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("</h5>              \r\n                                            </div>\r\n");
#nullable restore
#line 132 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n");
#nullable restore
#line 135 "D:\codegym\CaseStudyModule3\ToysForKids\ToysForKids\Views\Home\Index.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<!-- Product Section End -->\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ICategoryService categoryService { get; private set; }
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