#pragma checksum "C:\Users\asus\Documents\GitHub\TALeaveRequest\LeaveRequest\WebLeaveRequest\Views\Role\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c581f1b756ec7a1f6772710b55f3863d6559ee0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_Index), @"mvc.1.0.view", @"/Views/Role/Index.cshtml")]
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
#line 1 "C:\Users\asus\Documents\GitHub\TALeaveRequest\LeaveRequest\WebLeaveRequest\Views\_ViewImports.cshtml"
using WebLeaveRequest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\asus\Documents\GitHub\TALeaveRequest\LeaveRequest\WebLeaveRequest\Views\_ViewImports.cshtml"
using WebLeaveRequest.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c581f1b756ec7a1f6772710b55f3863d6559ee0", @"/Views/Role/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28d741b4d94d362fce5bad8bee2cc526cb0d5437", @"/Views/_ViewImports.cshtml")]
    public class Views_Role_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            WriteLiteral(@"<a href=""javascript:void(0)"" class=""btn bg-transparant text-success"" data-toggle=""modal"" data-target=""#addModal""><i class=""fas fa-plus""></i></a>

<div class=""container-fluid mt-5"">
    <table id=""myTable"" class=""table table-striped table-bordered dataTable"" style=""width:100%"">
        <thead class=""thead-light"">
            <tr role=""row"">
                <th>No</th>
                <th>Id</th>
                <th>Name</th>
                <th>Action</th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <th>No</th>
                <th>Id</th>
                <th>Name</th>
                <th>Action</th>
            </tr>
        </tfoot>
        <tbody></tbody>
    </table>
</div>

<div class=""modal fade"" id=""addModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""addModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""mod");
            WriteLiteral(@"al-title"" id=""addModalLabel"">Add Role</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c581f1b756ec7a1f6772710b55f3863d6559ee05040", async() => {
                WriteLiteral(@"
                    <div class=""form-group"" hidden>
                        <label for=""id"" class=""col-form-label"">Id:</label>
                        <input type=""text"" class=""form-control"" id=""id"" name=""id"">
                    </div>
                    <div class=""form-group"">
                        <label for=""name"" class=""col-form-label"">Name:</label>
                        <input type=""text"" class=""form-control"" id=""name"" name=""name"">
                    </div>
                    <div class=""form-check agree"">
                        <input type=""checkbox"" for=""agreement"" class=""form-check-input"" id=""agreement"" name=""agreement"">
                        <label class=""form-check-label"" for=""agreement"">I agree the Term and Conditions</label>
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
            WriteLiteral("\r\n            </div>\r\n            <div class=\"modal-footer\">\r\n                <button type=\"button\" class=\"btn btn-primary\" id=\"buttonsubmit\">Submit</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        var table = null;
        $(document).ready(function () {
            var x = $('#formrole');
            x.validate({
                rules: {
                    name: {
                        required: true,
                        maxlength: 20
                    },
                    agreement: ""required""
                },
                messages: {
                    name: {
                        required: 'Name is Mandatory',
                        maxlength: 'maximum 20 characters'
                    },
                    agreement:""You Must Check The Agreement""
                },
                errorPlacement: function (error, element) {
                    if (element.is("":checkbox"")) {
                        error.appendTo(element.parents("".agree""));
                    } else {
                        error.insertAfter(element)
                    }
                },
            });

            table = $(""#myTable"").DataTable({
   ");
                WriteLiteral(@"             ""filter"": true,
                ""orderMulti"": false,
                ""ajax"": {
                    ""url"": ""https://localhost:44383/api/role"",
                    ""type"": ""get"",
                    ""datatype"": ""json"",
                    ""dataSrc"": ""data""
                },
                ""columnDefs"": [
                    {
                        ""targets"": [1],
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
                    }
                ],
                ""columns"": [
                    {
                        ""data"": null,
                        ""render"": function (data, type, row, meta) {
                            return meta.row + meta.settings._iDisplay");
                WriteLiteral(@"Start + 1;
                        }
                    },
                    {
                        ""data"": null,
                        ""render"": function (data, type, row) {
                            return row['id'];
                        },
                        ""autoWidth"": true
                    },
                    {
                        ""data"": null,
                        ""render"": function (data, type, row) {
                            return row['name'];
                        },
                        ""autoWidth"": true
                    },
                    {
                        ""render"": function (data, type, row, meta) {
                            return '<a href=""javascript:void(0)"" class=""far fa-edit table-action text-dark"" data-toggle=""tooltip"" data-placement=""top"" title=""Edit"" onclick=""Get(\'' + row['id'] + '\')""></a> ' +
                                '<a href=""javascript:void(0)"" class=""fa fa-trash table-action text-danger"" data-toggle=");
                WriteLiteral(@"""tooltip"" data-placement=""top"" title=""Delete"" onclick=""Delete(\'' + row['id'] + '\')""></a>'
                        }
                    }
                ]
            });
        });

        $(""#buttonsubmit"").click(function (e) {
            e.preventDefault();
            if ($(""#formrole"").valid())
            {
                Submit();
            }
        });

        function Submit() {
            var id = $('#id').val();
            if (id == """" || id == "" "") {
                console.log(""post accessed"");
                Create();
            }
            else {
                console.log(""put accessed"");
                Update(id);
            }
        }

        function Get(id) {
            console.log(id);
            $.ajax({
                url: ""/Role/Get"",
                data: { id: id }
            }).done((result) => {
                console.log(result);
                var obj = JSON.parse(result)
                $(""#addModal"").modal(""show"");");
                WriteLiteral(@"
                $(""#id"").val(obj.data.id);
                $(""#name"").val(obj.data.name);
            }).fail((error) => {
                console.log(error);
            })
        }

        function Create() {
            console.log(""i'm here"");
            var role = new Object();
            role.name = $('#name').val();
            $.ajax({
                url: '/role/Create',
                type: 'POST',
                data: role
            }).done((result) => {
                if (result == 200) {
                    swal({
                        title: 'Success!',
                        text: 'Your file has been Added.',
                        icon: 'success',
                    });
                    $('#addModal').modal('hide');
                    $('#name').val(null);
                    table.ajax.reload();
                }
            }).fail((error) => {
                console.log(error);
            });
        }

        function Delete(id) {
     ");
                WriteLiteral(@"       console.log(id);
            swal({
                title: ""Are you sure?"",
                text: ""Once deleted, you will not be able to recover this imaginary file!"",
                icon: ""warning"",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        $.ajax({
                            url: '/role/Delete',
                            type: 'Delete',
                            data: { id: id }
                        }).done((result) => {
                            if (result == 200) {
                                swal(""Poof! Your imaginary file has been deleted!"", {
                                    icon: ""success"",
                                });
                                table.ajax.reload();
                            } else {
                                swal(""Data Failed Deleted"", {
                                    icon: """);
                WriteLiteral(@"warning"",
                                });
                            }
                        }).fail((error) => {
                            console.log(error)
                        });
                    } else {
                        swal(""Your imaginary file is safe!"");
                    }
                });
        }
        function Update(id) {
            var role = new Object();
            role.id = id;
            role.name = $('#name').val();
            $.ajax({
                type: ""PUT"",
                url: '/role/Update',
                data: role
            }).done((result) => {
                if (result == 200) {
                    swal('Success', 'Update Successfully', 'success');
                    $('#addModal').modal('hide');
                    $('#name').val(null);
                    table.ajax.reload();
                }
                else {
                    swal('Error', 'Something Went Wrong', 'error');
                }
     ");
                WriteLiteral("       }).fail((error) => {\r\n                console.log(error)\r\n            });\r\n        }\r\n    </script>\r\n");
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
