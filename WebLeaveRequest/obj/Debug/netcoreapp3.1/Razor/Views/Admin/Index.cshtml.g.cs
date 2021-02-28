#pragma checksum "F:\Kerja\Final Project\LeaveRequest\WebLeaveRequest\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d72e2f87a30278984c71c419d918f6665bb29d07"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
#line 1 "F:\Kerja\Final Project\LeaveRequest\WebLeaveRequest\Views\_ViewImports.cshtml"
using WebLeaveRequest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Kerja\Final Project\LeaveRequest\WebLeaveRequest\Views\_ViewImports.cshtml"
using WebLeaveRequest.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d72e2f87a30278984c71c419d918f6665bb29d07", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28d741b4d94d362fce5bad8bee2cc526cb0d5437", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formrole"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<div class=""p-3"">
    <h4 class=""text-muted font-18 m-b-5 text-center"">Welcome</h4>
    <p class=""text-muted text-center"">Manage Role Leave Request.</p>

    <div class=""container-fluid mt-5"">
        <table id=""myTable"" class=""table table-striped table-bordered dataTable"" style=""width:100%"">
            <thead class=""thead-light"">
                <tr role=""row"">
                    <th>No</th>
                    <th>NIK</th>
                    <th>FirstName</th>
                    <th>LastName</th>
                    <th>BirthDate</th>
                    <th>Gender</th>
                    <th>Position</th>
                    <th>Address</th>
                    <th>PhoneNumber</th>
                    <th>Email</th>
                    <th>RoleId</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th>No</th>
                    <th>NIK</th>
                    <th>FirstName</th>
   ");
            WriteLiteral(@"                 <th>LastName</th>
                    <th>BirthDate</th>
                    <th>Gender</th>
                    <th>Position</th>
                    <th>Address</th>
                    <th>PhoneNumber</th>
                    <th>Email</th>
                    <th>RoleId</th>
                    <th>Action</th>
                </tr>
            </tfoot>
            <tbody></tbody>
        </table>
    </div>
</div>

<div class=""modal fade"" id=""addModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""addModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""addModalLabel"">Update Role</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
       ");
            WriteLiteral("         ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d72e2f87a30278984c71c419d918f6665bb29d075736", async() => {
                WriteLiteral(@"
                    <div class=""row"">
                        <div class=""col-6"">
                            <div class=""form-group"">
                                <label for=""id"" class=""col-form-label"">NIK:</label>
                                <input type=""text"" class=""form-control"" id=""nik"" name=""nik"">
                            </div>
                            <div class=""form-group"">
                                <label for=""name"" class=""col-form-label"">First Name:</label>
                                <input type=""date"" class=""form-control"" id=""firstName"" name=""firstName"">
                            </div>
                            <div class=""form-group"">
                                <label for=""name"" class=""col-form-label"">Last Name:</label>
                                <input type=""text"" class=""form-control"" id=""lastName"" name=""lastName"">
                            </div>
                        </div>
                        <div class=""col-6"">
               ");
                WriteLiteral(@"             <div class=""form-group"">
                                <label for=""name"" class=""col-form-label"">Email:</label>
                                <input type=""date"" class=""form-control"" id=""email"" name=""email"">
                            </div>
                            <div class=""form-group"">
                                <label for=""name"" class=""col-form-label"">Role Id:</label>
                                <input type=""date"" class=""form-control"" id=""roleId"" name=""roleId"">
                            </div>
                        </div>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <div class=\"modal-footer\">\r\n                <button type=\"button\" class=\"btn btn-primary\" id=\"buttonsubmit\">Submit</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
            var table = null;
            $(document).ready(function () {
                table = $(""#myTable"").DataTable({
                    ""filter"": true,
                    ""orderMulti"": false,
                    ""ajax"": {
                        ""url"": ""https://localhost:44330/api/user"",
                        ""type"": ""get"",
                        ""datatype"": ""json"",
                        ""dataSrc"": ""data""
                    },
                    ""columnDefs"": [
                        {
                            ""targets"": [4, 7, 8],
                            ""visible"": false,

                        },
                        {
                            ""targets"": [0, 2],
                            ""searchable"": true
                        },
                        {
                            ""targets"": [3],
                            ""searchable"": false,
                            ""orderable"": false
                        },
          ");
                WriteLiteral(@"          ],
                    ""columns"": [
                        {
                            ""data"": null,
                            ""render"": function (data, type, row, meta) {
                                return meta.row + meta.settings._iDisplayStart + 1;
                            }
                        },
                        {
                            ""data"": 'nik'
                        },
                        {
                            ""data"": 'firstName'
                        },
                        {
                            ""data"": 'lastName'
                        },
                        {
                            ""data"": 'birthDate'
                        },
                        {
                            ""data"": 'gender'
                        },
                        {
                            ""data"": 'position'
                        },
                        {
                            ""data"": 'address'
 ");
                WriteLiteral(@"                       },
                        {
                            ""data"": 'phoneNumber'
                        },
                        {
                            ""data"": 'email'
                        },
                        {
                            ""data"": 'roleId'
                        },
                        {
                            ""data"": 'id',
                            ""render"": function (data, type, row, meta) {
                                return '<a href=""javascript:void(0)"" class=""far fa-check-circle table-action text-dark"" data-toggle=""tooltip"" data-placement=""top"" title=""Approve"" onclick=""Get(\'' + row['id'] + '\')""></a> ' +
                                    '<a href=""javascript:void(0)"" class=""far fa-times-circle table-action text-danger"" data-toggle=""tooltip"" data-placement=""top"" title=""Reject"" onclick=""Reject(\'' + row['id'] + '\')""></a>'
                            }
                        }
                    ]
               ");
                WriteLiteral(@" });
            });

            function Get(id) {
                console.log(id);
                $.ajax({
                    url: ""/Admin/Get"",
                    data: { id: id }
                }).done((result) => {
                    console.log(result);
                    var obj = JSON.parse(result);
                    $(""#addModal"").modal(""show"");
                    $(""#nik"").val(obj.data.nik);
                    $(""#firstName"").val(obj.data.firstName);
                    $(""#lastName"").val(obj.data.lastName);
                    $(""#email"").val(obj.data.email);
                    $(""#roleId"").val(obj.data.roleId);
                }).fail((error) => {
                    console.log(error);
                })
            }

            function Update(nik) {
                var user = new Object();
                user.nik = $('#nik').val();
                user.firstName = $('#firstName').val();
                user.lastName = $('#lastName').val();
             ");
                WriteLiteral(@"   user.email = $('#email').val();
                user.roleId = $('#roleId').val();
                $.ajax({
                    type: ""PUT"",
                    url: '/admin/Update',
                    data: user
                }).done((result) => {
                    if (result == 200) {
                        swal('Success', 'Update Successfully', 'success');
                        $('#addModal').modal('hide');
                        $(""#nik"").val(obj.data.nik);
                        $(""#firstName"").val(obj.data.firstName);
                        $(""#lastName"").val(obj.data.lastName);
                        $(""#email"").val(obj.data.email);
                        $(""#roleId"").val(obj.data.roleId);
                        table.ajax.reload();
                    }
                    else {
                        swal('Error', 'Something Went Wrong', 'error');
                    }
                }).fail((error) => {
                    console.log(error)
                }");
                WriteLiteral(");\r\n            }\r\n    </script>\r\n");
            }
            );
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
