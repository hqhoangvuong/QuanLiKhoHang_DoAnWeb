#pragma checksum "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67621e02bcff0e65b3284ae5fd95ad27baf8cdde"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manager_Views_SaleOrders_Index), @"mvc.1.0.view", @"/Areas/Manager/Views/SaleOrders/Index.cshtml")]
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
#line 1 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\_ViewImports.cshtml"
using QuanLiKhoHang_DoAnWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\_ViewImports.cshtml"
using QuanLiKhoHang_DoAnWeb.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67621e02bcff0e65b3284ae5fd95ad27baf8cdde", @"/Areas/Manager/Views/SaleOrders/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c171b16c85eb52fdca1fd7ee24c1a49db8a6503", @"/Areas/Manager/Views/_ViewImports.cshtml")]
    public class Areas_Manager_Views_SaleOrders_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuanLiKhoHang_DoAnWeb.Models.SaleOrders>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TableButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<br />\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-6\">\r\n        <h2 class=\"text-info\">Danh sách lệnh xuất kho</h2>\r\n    </div>\r\n    <div class=\"col-6 text-right\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67621e02bcff0e65b3284ae5fd95ad27baf8cdde5105", async() => {
                WriteLiteral("<i class=\"fas fa-plus\"></i>&nbsp; Tạo lệnh xuất kho mới ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<br />\r\n<div>\r\n    <table class=\"table table-striped border\">\r\n        <tr class=\"table-info\">\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.client.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 30 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.OrderDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 33 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 36 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.isConfirmed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n            <th></th>\r\n        </tr>\r\n\r\n");
#nullable restore
#line 42 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>\r\n            ");
#nullable restore
#line 46 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
       Write(Html.DisplayFor(m => item.client.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 49 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
       Write(Html.DisplayFor(m => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 52 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
       Write(Html.DisplayFor(m => item.OrderDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n");
#nullable restore
#line 55 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
              
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
#nullable restore
#line 58 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
       Write(String.Format(cul.NumberFormat, "{0:c}", item.Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 61 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
       Write(Html.DisplayFor(m => item.isConfirmed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "67621e02bcff0e65b3284ae5fd95ad27baf8cdde10718", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 64 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item.Id;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 67 "C:\Users\HIKARI\Documents\GitHub\QuanLiKhoHang_DoAnWeb\QuanLiKhoHang_DoAnWeb\Areas\Manager\Views\SaleOrders\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuanLiKhoHang_DoAnWeb.Models.SaleOrders>> Html { get; private set; }
    }
}
#pragma warning restore 1591
