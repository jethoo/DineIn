#pragma checksum "/Users/jeewan/Desktop/georgian_college/SERVER SIDE SCRIPTING USING ASP.NET/finalProject/dineIN/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b9472c2ea9df42541f29e1314184d8306e3fb1eb"
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
#line 1 "/Users/jeewan/Desktop/georgian_college/SERVER SIDE SCRIPTING USING ASP.NET/finalProject/dineIN/Views/_ViewImports.cshtml"
using dineIN;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/jeewan/Desktop/georgian_college/SERVER SIDE SCRIPTING USING ASP.NET/finalProject/dineIN/Views/_ViewImports.cshtml"
using dineIN.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9472c2ea9df42541f29e1314184d8306e3fb1eb", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f33b94e42fac171e727428ba5e191ca042b5986", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/jeewan/Desktop/georgian_college/SERVER SIDE SCRIPTING USING ASP.NET/finalProject/dineIN/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""text-center"">
        <h2 class=""display-4"">Welcome To DINE-IN Restaurant</h2>
        <hr />
        <h3>Become a Member</h3>
       


        <!--carousel-->
        <div id=""carouselExampleControls"" class=""carousel slide"" data-ride=""carousel"">
            <div class=""carousel-inner"">
                <div class=""carousel-item active"">
                    <img class=""d-block w-100"" src=""/images/img1.jpeg"" alt=""First slide"">
                </div>
                <div class=""carousel-item"">
                    <img class=""d-block w-100"" src=""/images/img2.jpeg"" alt=""Second slide"">
                </div>
                <div class=""carousel-item"">
                    <img class=""d-block w-100"" src=""/images/img3.jpeg"" alt=""Third slide"">
                </div>
            </div>
            <a class=""carousel-control-prev"" href=""#carouselExampleControls"" role=""button"" data-slide=""prev"">
                <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
   ");
            WriteLiteral(@"             <span class=""sr-only"">Previous</span>
            </a>
            <a class=""carousel-control-next"" href=""#carouselExampleControls"" role=""button"" data-slide=""next"">
                <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                <span class=""sr-only"">Next</span>
            </a>
        </div>

        <h4>Select Your Favourite Dish From Our Menu</h4>
        <h5>Reserve A Table</h5>
        <h6>Come And Enjoy Your Favourite Food With Us</h6>

    </div>
");
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
