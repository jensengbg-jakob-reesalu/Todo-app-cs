#pragma checksum "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\Components\Popup.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99f5e90037c78cb4d5860ac6abf5d109a6c2a0e2"
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
    public partial class Popup : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Blazorise.Button>(0);
            __builder.AddAttribute(1, "Clicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 1 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\Components\Popup.razor"
                  ShowModal

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(3, "ADD");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(4, "\r\n\r\n");
            __builder.OpenComponent<Blazorise.Modal>(5);
            __builder.AddAttribute(6, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(7, "\r\n    ");
                __builder2.OpenComponent<Blazorise.ModalBackdrop>(8);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(9, "\r\n    ");
                __builder2.OpenComponent<Blazorise.ModalContent>(10);
                __builder2.AddAttribute(11, "IsCentered", "true");
                __builder2.AddAttribute(12, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(13, "\r\n        ");
                    __builder3.OpenComponent<Blazorise.ModalHeader>(14);
                    __builder3.AddAttribute(15, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddMarkupContent(16, "\r\n            ");
                        __builder4.OpenComponent<Blazorise.CloseButton>(17);
                        __builder4.AddAttribute(18, "Clicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 7 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\Components\Popup.razor"
                                   HideModal

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(19, "\r\n        ");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(20, "\r\n        ");
                    __builder3.OpenComponent<Blazorise.ModalBody>(21);
                    __builder3.AddAttribute(22, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddMarkupContent(23, "\r\n            ");
                        __builder4.OpenComponent<Blazorise.Field>(24);
                        __builder4.AddAttribute(25, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddMarkupContent(26, "\r\n                ");
                            __builder5.OpenComponent<Blazorise.TextEdit>(27);
                            __builder5.AddAttribute(28, "Text", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\Components\Popup.razor"
                                       TodoItemTextInput

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(29, "TextChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => TodoItemTextInput = __value, TodoItemTextInput))));
                            __builder5.AddAttribute(30, "TextExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => TodoItemTextInput));
                            __builder5.AddAttribute(31, "Placeholder", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\Components\Popup.razor"
                                                                              PlaceHolderText

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(32, "PlaceholderChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PlaceHolderText = __value, PlaceHolderText));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(33, "\r\n            ");
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(34, "\r\n        ");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(35, "\r\n        ");
                    __builder3.OpenComponent<Blazorise.ModalFooter>(36);
                    __builder3.AddAttribute(37, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddMarkupContent(38, "\r\n            ");
                        __builder4.OpenComponent<Blazorise.Button>(39);
                        __builder4.AddAttribute(40, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.Color>(
#nullable restore
#line 15 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\Components\Popup.razor"
                           Color.Primary

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(41, "Clicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 15 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\Components\Popup.razor"
                                                    AddTodoItem

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.AddAttribute(42, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddContent(43, "Done");
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(44, "\r\n        ");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(45, "\r\n    ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(46, "\r\n");
            }
            ));
            __builder.AddComponentReferenceCapture(47, (__value) => {
#nullable restore
#line 3 "D:\Repositories-BitBucket\JR\TodoApp\TodoApp.App\Components\Popup.razor"
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