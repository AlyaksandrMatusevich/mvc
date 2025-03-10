#pragma checksum "Z:\mvc\app\Views\Roles\Edit.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4ec685314c5ef4857653a7f96f32db7c2b469f2e34543c078b1cdae4ea8df1ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCoreGeneratedDocument.Views_Roles_Edit), @"mvc.1.0.view", @"/Views/Roles/Edit.cshtml")]
namespace AspNetCoreGeneratedDocument
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "Z:\mvc\app\Views\_ViewImports.cshtml"
using appmvc

#nullable disable
    ;
#nullable restore
#line 2 "Z:\mvc\app\Views\_ViewImports.cshtml"
using appmvc.Models

#nullable disable
    ;
#nullable restore
#line 1 "Z:\mvc\app\Views\Roles\Edit.cshtml"
 using Microsoft.AspNetCore.Identity

#nullable disable
    ;
    #line default
    #line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"4ec685314c5ef4857653a7f96f32db7c2b469f2e34543c078b1cdae4ea8df1ad", @"/Views/Roles/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"84b7b2404be8aebee8ca8eccdd6d78d4c5ab07f4166dda8aa64c2f3af1e0741f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    internal sealed class Views_Roles_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<
#nullable restore
#line 3 "Z:\mvc\app\Views\Roles\Edit.cshtml"
       appmvc.AuthApp.ChangeRole

#line default
#line hidden
#nullable disable
    >
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n<h2>Изменить роль для пользователя ");
            Write(
#nullable restore
#line 5 "Z:\mvc\app\Views\Roles\Edit.cshtml"
                                    Model.UserEmail

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</h2>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ec685314c5ef4857653a7f96f32db7c2b469f2e34543c078b1cdae4ea8df1ad4470", async() => {
                WriteLiteral("\n    <input type=\"hidden\" name=\"userId\"");
                BeginWriteAttribute("value", " value=\"", 207, "\"", 228, 1);
                WriteAttributeValue("", 215, 
#nullable restore
#line 8 "Z:\mvc\app\Views\Roles\Edit.cshtml"
                                               Model.UserId

#line default
#line hidden
#nullable disable
                , 215, 13, false);
                EndWriteAttribute();
                WriteLiteral(" />\n    <div class=\"form-group\">\n");
#nullable restore
#line 10 "Z:\mvc\app\Views\Roles\Edit.cshtml"
         foreach (IdentityRole role in Model.AllRoles)
        {

#line default
#line hidden
#nullable disable

                WriteLiteral("            <input type=\"checkbox\" name=\"roles\"");
                BeginWriteAttribute("value", " value=\"", 374, "\"", 392, 1);
                WriteAttributeValue("", 382, 
#nullable restore
#line 12 "Z:\mvc\app\Views\Roles\Edit.cshtml"
                                                        role.Name

#line default
#line hidden
#nullable disable
                , 382, 10, false);
                EndWriteAttribute();
                WriteLiteral("\n            ");
                Write(
#nullable restore
#line 13 "Z:\mvc\app\Views\Roles\Edit.cshtml"
              Model.UserRoles.Contains(role.Name) ? "checked=\"checked\"" : ""

#line default
#line hidden
#nullable disable
                );
                WriteLiteral(" />\n");
                Write(
#nullable restore
#line 15 "Z:\mvc\app\Views\Roles\Edit.cshtml"
             role.Name

#line default
#line hidden
#nullable disable
                );
                WriteLiteral(" <br />\n");
#nullable restore
#line 16 "Z:\mvc\app\Views\Roles\Edit.cshtml"
        }

#line default
#line hidden
#nullable disable

                WriteLiteral("    </div>\n    <button type=\"submit\" class=\"btn btn-primary\">Сохранить</button>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<appmvc.AuthApp.ChangeRole> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
