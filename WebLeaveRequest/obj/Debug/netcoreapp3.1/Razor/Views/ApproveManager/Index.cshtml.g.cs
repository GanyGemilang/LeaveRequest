#pragma checksum "F:\Kerja\Final Project\LeaveRequest\WebLeaveRequest\Views\ApproveManager\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d7a06df61944852407579370022a2e48d6c8f48"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ApproveManager_Index), @"mvc.1.0.view", @"/Views/ApproveManager/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d7a06df61944852407579370022a2e48d6c8f48", @"/Views/ApproveManager/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28d741b4d94d362fce5bad8bee2cc526cb0d5437", @"/Views/_ViewImports.cshtml")]
    public class Views_ApproveManager_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            WriteLiteral(@"
<div class=""p-3"">
    <h4 class=""text-muted font-18 m-b-5 text-center"">Welcome</h4>
    <p class=""text-muted text-center"">Approved Manager Data Leave Request</p>

    <div class=""container-fluid mt-5"">
        <table id=""myTable"" class=""table table-striped table-bordered dataTable"" style=""width:100%"">
            <thead class=""thead-light"">
                <tr role=""row"">
                    <th>No</th>
                    <th>Id</th>
                    <th>NIK</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Reason Request</th>
                    <th>Start Date</th>
                    <th>End Date</th>
                    <th>Status</th>
                    <th>Notes</th>
                    <th>Approved HRD</th>
                    <th>Approved Manager</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th>No</th>
            ");
            WriteLiteral(@"        <th>Id</th>
                    <th>NIK</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Reason Request</th>
                    <th>Start Date</th>
                    <th>End Date</th>
                    <th>Status</th>
                    <th>Notes</th>
                    <th>Approved HRD</th>
                    <th>Approved Manager</th>
                    <th>Action</th>
                </tr>
            </tfoot>
            <tbody></tbody>
        </table>
    </div>
</div>

<div class=""modal fade"" id=""Request"" tabindex=""-1"" role=""dialog"" aria-labelledby=""addModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""addModalLabel"">Approve Request</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-");
            WriteLiteral("hidden=\"true\">&times;</span>\r\n                </button>\r\n            </div>\r\n            <div class=\"modal-body\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d7a06df61944852407579370022a2e48d6c8f485911", async() => {
                WriteLiteral(@"
                    <div class=""row"">
                        <div class=""col-6"">
                            <div class=""form-group"">
                                <label for=""id"" class=""col-form-label"">Id:</label>
                                <input disabled type=""text"" class=""form-control"" id=""id"" name=""id"">
                            </div>
                            <div class=""form-group"">
                                <label for=""name"" class=""col-form-label"">Start Date:</label>
                                <input disabled type=""text"" class=""form-control"" id=""startdate"" name=""startdate"">
                            </div>
                            <div class=""form-group"">
                                <label for=""name"" class=""col-form-label"">Reason Request:</label>
                                <input disabled id=""reasonrequest"" class=""form-control"" name=""reasonrequest"">
                            </div>
                        </div>
                        <div clas");
                WriteLiteral(@"s=""col-6"">
                            <div class=""form-group"">
                                <label for=""id"" class=""col-form-label"">NIK:</label>
                                <input disabled type=""text"" class=""form-control"" id=""nik"" name=""nik"">
                            </div>
                            <div class=""form-group"">
                                <label for=""name"" class=""col-form-label"">End Date:</label>
                                <input disabled type=""text"" class=""form-control"" id=""enddate"" name=""enddate"">
                            </div>
                            <div class=""form-group"">
                                <label for=""name"" class=""col-form-label"">Notes:</label>
                                <textarea disabled type=""text"" class=""form-control"" id=""notes"" name=""notes""></textarea>
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
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-primary"" onclick=""approve()"">Approve</button>
                <button type=""button"" class=""btn btn-primary"" onclick=""reject()"">Reject</button>
            </div>
        </div>
    </div>
</div>
");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        var table = null;
        $(document).ready(function () {
            table = $(""#myTable"").DataTable({
                ""filter"": true,
                ""orderMulti"": false,
                ""ajax"": {
                    ""url"": ""https://localhost:44330/api/request"",
                    ""type"": ""get"",
                    ""datatype"": ""json"",
                    ""dataSrc"": ""data""
                },
                ""columnDefs"": [
                    {
                        ""targets"": [1, 10, 11],
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
                ],
                ""columns"": [
                    {
                        ""data"": nu");
                WriteLiteral(@"ll,
                        ""render"": function (data, type, row, meta) {
                            return meta.row + meta.settings._iDisplayStart + 1;
                        }
                    },
                    {
                        ""data"": 'id'
                    },
                    {
                        ""data"": 'nik'
                    },
                    {
                        ""data"": 'user.firstName'
                    },
                    {
                        ""data"": 'user.lastName'
                    },
                    {
                        ""data"": 'reasonRequest'
                    },
                    {
                        ""data"": 'startDate'
                    },
                    {
                        ""data"": 'endDate'
                    },
                    {
                        ""data"": 'status',
                        ""render"": function (status) {
                            if (status == ""0"") {
    ");
                WriteLiteral(@"                            return ""Waiting Approve"";
                            }
                            else if (status == ""1"") {
                                return ""Approved By HRD"";
                            }
                            else if (status == ""3"") {
                                return ""Approved"";
                            }
                            else {
                                return ""Reject"";
                            }
                        }
                    },
                    {
                        ""data"": 'notes'
                    },
                    {
                        ""data"": 'approvedHRD'
                    },
                    {
                        ""data"": 'approvedManager'
                    },
                    {
                        ""data"": 'id',
                        ""render"": function (data, type, row, meta) {
                            return '<a href=""javascript:void(0)"" class=""far");
                WriteLiteral(@" fa-check-square table-action text-dark"" data-toggle=""tooltip"" data-placement=""top"" title=""Approve"" onclick=""Get(\'' + row['id'] + '\')""></a> '
                        }
                    }
                ]
            });
        });

        function approve() {
            var id = $('#id').val();
            console.log(""put accessed"");
            Approve(id);
        }

        function reject() {
            var id = $('#id').val();
            console.log(""put accessed"");
            Reject(id);
        }


        function Get(id) {
            console.log(id);
            $.ajax({
                url: ""/Request/Get"",
                data: { id: id }
            }).done((result) => {
                console.log(result);
                var obj = JSON.parse(result);
                $(""#Request"").modal(""show"");
                $(""#nik"").val(obj.data.nik);
                $(""#id"").val(obj.data.id);
                $(""#reasonrequest"").val(obj.data.reasonRequest);
      ");
                WriteLiteral(@"          $(""#startdate"").val(obj.data.startDate);
                $(""#enddate"").val(obj.data.endDate);
                $(""#notes"").val(obj.data.notes);
                $(""#ApprovedHRD"").val(obj.data.approvedHRD);
                $(""#ApprovedManager"").val(obj.data.approvedManager);
            }).fail((error) => {
                console.log(error);
            })
        }

        function Approve(id) {
            var approve = new Object();
            approve.id = $('#id').val();
            $.ajax({
                type: ""PUT"",
                url: '/approveManager/ApproveManager',
                data: approve
            }).done((result) => {
                console.log(""ok"");
                if (result == 200) {
                    swal('Success', 'Update Successfully', 'success');
                    $('#Request').modal('hide');
                    $(""#nik"").val(null);
                    $(""#id"").val(null);
                    $(""#reasonrequest"").val(null);
                ");
                WriteLiteral(@"    $(""#startdate"").val(null);
                    $(""#enddate"").val(null);
                    $(""#notes"").val(null);
                    $(""#ApprovedHRD"").val(null);
                    $(""#ApprovedManager"").val(null);
                    table.ajax.reload();
                }
                else {
                    swal('Error', 'Something Went Wrong', 'error');
                }
            }).fail((error) => {
                console.log(error)
            });
        }

        function Reject(id) {
            var reject = new Object();
            reject.id = $('#id').val();
            $.ajax({
                type: ""PUT"",
                url: '/approveManager/RejectManager',
                data: reject
            }).done((result) => {

                if (result == 200) {
                    swal('Success', 'Update Successfully', 'success');
                    table.ajax.reload();
                }
                else {
                    swal('Error', 'Something");
                WriteLiteral(@" Went Wrong', 'error');
                }
            }).fail((error) => {
                console.log(error)
            });
        }

        function SubmitRequest() {
            console.log(""ok"");
            var Request = new Object();
            Request.nik = $('#nik').val();
            Request.reasonrequest = $('#reasonrequest').val();
            Request.startdate = $('#startdate').val();
            Request.enddate = $('#enddate').val();
            Request.notes = $('#notes').val();
            $.ajax({
                url: '/request/SubmitRequest',
                type: ""POST"",
                data: Request
            }).done((result) => {
                if (result == 200) {
                    swal('Success', 'Request Has Been Added, Cek Your Email', 'success');
                    $('#Request').modal('hide');
                    $(""#nik"").val(null);
                    $(""#id"").val(null);
                    $(""#reasonrequest"").val(null);
                    $(""#st");
                WriteLiteral(@"artdate"").val(null);
                    $(""#enddate"").val(null);
                    $(""#notes"").val(null);
                    $(""#ApprovedHRD"").val(null);
                    $(""#ApprovedManager"").val(null);
                    table.ajax.reload();
                }
                else {
                    swal('Error', 'Something Went Wrong', 'error');
                }
            }).fail((error) => {
                console.log(error)
            });
        }

    </script>
");
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
