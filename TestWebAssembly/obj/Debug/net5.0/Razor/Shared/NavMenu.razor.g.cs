#pragma checksum "D:\RiderProjects\Diploma_Project\TestWebAssembly\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97fd7f27829c4597d398bd7751f7cb46f90125a2"
// <auto-generated/>
#pragma warning disable 1591
namespace TestWebAssembly.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\RiderProjects\Diploma_Project\TestWebAssembly\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\RiderProjects\Diploma_Project\TestWebAssembly\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\RiderProjects\Diploma_Project\TestWebAssembly\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\RiderProjects\Diploma_Project\TestWebAssembly\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\RiderProjects\Diploma_Project\TestWebAssembly\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\RiderProjects\Diploma_Project\TestWebAssembly\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\RiderProjects\Diploma_Project\TestWebAssembly\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\RiderProjects\Diploma_Project\TestWebAssembly\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\RiderProjects\Diploma_Project\TestWebAssembly\_Imports.razor"
using TestWebAssembly;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\RiderProjects\Diploma_Project\TestWebAssembly\_Imports.razor"
using TestWebAssembly.Shared;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "top-row pl-4 navbar navbar-dark");
            __builder.AddAttribute(2, "b-6of1yvn6rc");
            __builder.AddMarkupContent(3, "<a class=\"navbar-brand\" href b-6of1yvn6rc>АПК ДК АРМ</a>\r\n    ");
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "class", "navbar-toggler");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 3 "D:\RiderProjects\Diploma_Project\TestWebAssembly\Shared\NavMenu.razor"
                                             ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "b-6of1yvn6rc");
            __builder.AddMarkupContent(8, "<span class=\"navbar-toggler-icon\" b-6of1yvn6rc></span>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n\r\n");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", 
#nullable restore
#line 8 "D:\RiderProjects\Diploma_Project\TestWebAssembly\Shared\NavMenu.razor"
             NavMenuCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(12, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "D:\RiderProjects\Diploma_Project\TestWebAssembly\Shared\NavMenu.razor"
                                        ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(13, "b-6of1yvn6rc");
            __builder.OpenElement(14, "ul");
            __builder.AddAttribute(15, "class", "nav flex-column");
            __builder.AddAttribute(16, "b-6of1yvn6rc");
            __builder.OpenElement(17, "li");
            __builder.AddAttribute(18, "class", "nav-item px-3");
            __builder.AddAttribute(19, "b-6of1yvn6rc");
            __builder.OpenElement(20, "li");
            __builder.AddAttribute(21, "class", "nav-item px-3");
            __builder.AddAttribute(22, "b-6of1yvn6rc");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(23);
            __builder.AddAttribute(24, "class", "nav-link");
            __builder.AddAttribute(25, "href", "newInfo");
            __builder.AddAttribute(26, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(27, "<span class=\"oi oi-timer\" aria-hidden=\"true\" b-6of1yvn6rc></span> Новое\r\n                ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n            ");
            __builder.OpenElement(29, "li");
            __builder.AddAttribute(30, "class", "nav-item px-3");
            __builder.AddAttribute(31, "b-6of1yvn6rc");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(32);
            __builder.AddAttribute(33, "class", "nav-link");
            __builder.AddAttribute(34, "href", "revealed");
            __builder.AddAttribute(35, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(36, "<span class=\"oi oi-bell\" aria-hidden=\"true\" b-6of1yvn6rc></span> Выявлено\r\n                ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n            ");
            __builder.OpenElement(38, "li");
            __builder.AddAttribute(39, "class", "nav-item px-3");
            __builder.AddAttribute(40, "b-6of1yvn6rc");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(41);
            __builder.AddAttribute(42, "class", "nav-link");
            __builder.AddAttribute(43, "href", "plans");
            __builder.AddAttribute(44, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(45, "<span class=\"oi oi-list-rich\" aria-hidden=\"true\" b-6of1yvn6rc></span> Планы\r\n                ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n            ");
            __builder.OpenElement(47, "li");
            __builder.AddAttribute(48, "class", "nav-item px-3");
            __builder.AddAttribute(49, "b-6of1yvn6rc");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(50);
            __builder.AddAttribute(51, "class", "nav-link");
            __builder.AddAttribute(52, "href", "charts");
            __builder.AddAttribute(53, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(54, "<span class=\"oi oi-bar-chart\" aria-hidden=\"true\" b-6of1yvn6rc></span> Графики\r\n                ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n            ");
            __builder.OpenElement(56, "li");
            __builder.AddAttribute(57, "class", "nav-item px-3");
            __builder.AddAttribute(58, "b-6of1yvn6rc");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(59);
            __builder.AddAttribute(60, "class", "nav-link");
            __builder.AddAttribute(61, "href", "measurements");
            __builder.AddAttribute(62, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(63, "<span class=\"oi oi-graph\" aria-hidden=\"true\" b-6of1yvn6rc></span> Измерения\r\n                ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n            ");
            __builder.OpenElement(65, "li");
            __builder.AddAttribute(66, "class", "nav-item px-3");
            __builder.AddAttribute(67, "b-6of1yvn6rc");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(68);
            __builder.AddAttribute(69, "class", "nav-link");
            __builder.AddAttribute(70, "href", "translationCurrents");
            __builder.AddAttribute(71, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(72, "<span class=\"oi oi-transfer\" aria-hidden=\"true\" b-6of1yvn6rc></span> Токи перевода\r\n                ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(73, "\r\n            ");
            __builder.OpenElement(74, "li");
            __builder.AddAttribute(75, "class", "nav-item px-3");
            __builder.AddAttribute(76, "b-6of1yvn6rc");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(77);
            __builder.AddAttribute(78, "class", "nav-link");
            __builder.AddAttribute(79, "href", "settingsPage");
            __builder.AddAttribute(80, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(81, "<span class=\"oi oi-cog\" aria-hidden=\"true\" b-6of1yvn6rc></span> Настройки\r\n                ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 50 "D:\RiderProjects\Diploma_Project\TestWebAssembly\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
