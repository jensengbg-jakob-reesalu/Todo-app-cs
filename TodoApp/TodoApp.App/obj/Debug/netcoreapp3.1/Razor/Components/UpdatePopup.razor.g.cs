#pragma checksum "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\Components\UpdatePopup.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6303eae477d9d6f7ad773464ba26f583d9a61aa0"
// <auto-generated/>
#pragma warning disable 1591
namespace TodoApp.App.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\_Imports.razor"
using TodoApp.App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\_Imports.razor"
using TodoApp.App.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\_Imports.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
    public partial class UpdatePopup : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Blazorise.Modal>(0);
            __builder.AddAttribute(1, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(2, "\r\n    ");
                __builder2.OpenComponent<Blazorise.ModalBackdrop>(3);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(4, "\r\n    ");
                __builder2.OpenComponent<Blazorise.ModalContent>(5);
                __builder2.AddAttribute(6, "IsCentered", "true");
                __builder2.AddAttribute(7, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(8, "\r\n        ");
                    __builder3.OpenComponent<Blazorise.ModalHeader>(9);
                    __builder3.AddAttribute(10, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddMarkupContent(11, "\r\n            ");
                        __builder4.OpenComponent<Blazorise.CloseButton>(12);
                        __builder4.AddAttribute(13, "Clicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 5 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\Components\UpdatePopup.razor"
                                   HideModal

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(14, "\r\n        ");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(15, "\r\n        ");
                    __builder3.OpenComponent<Blazorise.ModalBody>(16);
                    __builder3.AddAttribute(17, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddMarkupContent(18, "\r\n            ");
                        __builder4.OpenComponent<Blazorise.Field>(19);
                        __builder4.AddAttribute(20, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddMarkupContent(21, "\r\n                ");
                            __builder5.OpenComponent<Blazorise.TextEdit>(22);
                            __builder5.AddAttribute(23, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 9 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\Components\UpdatePopup.razor"
                                       UpdateTextInput

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(24, "TextChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => UpdateTextInput = __value, UpdateTextInput))));
                            __builder5.AddAttribute(25, "TextExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => UpdateTextInput));
                            __builder5.AddAttribute(26, "Placeholder", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 9 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\Components\UpdatePopup.razor"
                                                                            PlaceHolderText

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(27, "PlaceholderChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PlaceHolderText = __value, PlaceHolderText));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(28, "\r\n            ");
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(29, "\r\n        ");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(30, "\r\n        ");
                    __builder3.OpenComponent<Blazorise.ModalFooter>(31);
                    __builder3.AddAttribute(32, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddMarkupContent(33, "\r\n            ");
                        __builder4.OpenComponent<Blazorise.Button>(34);
                        __builder4.AddAttribute(35, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.Color>(
#nullable restore
#line 13 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\Components\UpdatePopup.razor"
                           Color.Primary

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(36, "Clicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 13 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\Components\UpdatePopup.razor"
                                                    UpdateTodoItem

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.AddAttribute(37, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddContent(38, "Done");
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(39, "\r\n        ");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(40, "\r\n    ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(41, "\r\n");
            }
            ));
            __builder.AddComponentReferenceCapture(42, (__value) => {
#nullable restore
#line 1 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\Components\UpdatePopup.razor"
             modalRef = (Blazorise.Modal)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
