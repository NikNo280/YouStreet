#pragma checksum "C:\Users\nikit\OneDrive\Documents\GitHub\YouStreet\YouStreet\YouStreet\Views\Shared\TextPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43e7be97d6a8f79d4083036947ee808de56a1a2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_TextPage), @"mvc.1.0.view", @"/Views/Shared/TextPage.cshtml")]
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
#line 1 "C:\Users\nikit\OneDrive\Documents\GitHub\YouStreet\YouStreet\YouStreet\Views\_ViewImports.cshtml"
using YouStreet;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\nikit\OneDrive\Documents\GitHub\YouStreet\YouStreet\YouStreet\Views\_ViewImports.cshtml"
using YouStreet.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43e7be97d6a8f79d4083036947ee808de56a1a2d", @"/Views/Shared/TextPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87b2624ba832b38c682ac604cc3e667de8ae19f2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_TextPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\nikit\OneDrive\Documents\GitHub\YouStreet\YouStreet\YouStreet\Views\Shared\TextPage.cshtml"
  
    ViewData["Title"] = "Text";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col\" style=\"margin-top: 50px;\">\r\n            <h4 class=\"text-center border rounded\" style=\"background-color:white\">");
#nullable restore
#line 7 "C:\Users\nikit\OneDrive\Documents\GitHub\YouStreet\YouStreet\YouStreet\Views\Shared\TextPage.cshtml"
                                                                             Write(ViewData["Text"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        </div>\r\n    </div>\r\n</div>");
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
