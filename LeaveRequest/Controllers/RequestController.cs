using LeaveRequest.Base.Controller;
using LeaveRequest.Models;
using LeaveRequest.Repositories.Data;
using LeaveRequest.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : BaseController<Request, RequestRepository,int>
    {
        private readonly RequestRepository requestRepository;


        public RequestController(RequestRepository requestRepository) : base(requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        [HttpPost("SubmitRequest")]
        public ActionResult SubmitRequest(RequestVM requestVM)
        {
            var data = requestRepository.Request(requestVM);
            if (data == 1)
            {
                return Ok(new { status = "Request success" });
            }
            else if (data == 2)
            {
                return StatusCode(500, new { status = "Input Total Day Request less than Remaining Quota And Less Than 5 day" });
            }
            else if (data == 3)
            {
                return StatusCode(500, new { status = "Input Total Day Request 90 day" });
            }
            else if (data == 4)
            {
                return StatusCode(500, new { status = "Input Total Day Request 3 day" });
            }
            else if (data == 5)
            {
                return StatusCode(500, new { status = "Input Total Day Request 2 day" });
            }
            else if (data == 6)
            {
                return StatusCode(500, new { status = "Input Total Day Request 1 day" });
            }
            else
            {
                return StatusCode(500, new { status = "Interlan Server Error" });
            }
        }

        [HttpPut("SubmitApprovedHRD")]
        public ActionResult SubmitApprovedHRD(ApproveRequestVM approveRequestVM)
        {
            var data = requestRepository.ApprovedHRD(approveRequestVM);
            if (data == 1)
            {
                return Ok(new { status = "Approved success" });
            }
            else
            {
                return StatusCode(500, new { status = "Internal Server Error" });
            }
            
        }
        
        [HttpPut("SubmitRejectHRD")]
        public ActionResult SubmitRejectHRD(ApproveRequestVM approveRequestVM)
        {
            var data = requestRepository.RejectHRD(approveRequestVM);
            if (data == 1)
            {
                return Ok(new { status = "Reject success" });
            }
            else
            {
                return StatusCode(500, new { status = "Internal Server Error" });
            }
            
        }
        
        [HttpPut("SubmitApprovedManager")]
        public ActionResult SubmitApprovedManager(ApproveRequestVM approveRequestVM)
        {
            var data = requestRepository.ApprovedManager(approveRequestVM);
            if (data == 1)
            {
                return Ok(new { status = "Approved success" });
            }
            else
            {
                return StatusCode(500, new { status = "Internal Server Error" });
            }
            
        }
        
        [HttpPut("SubmitRejectManager")]
        public ActionResult SubmitRejectManager(ApproveRequestVM approveRequestVM)
        {
            var data = requestRepository.RejectManager(approveRequestVM);
            if (data == 1)
            {
                return Ok(new { status = "Reject success" });
            }
            else
            {
                return StatusCode(500, new { status = "Internal Server Error" });
            }
            
        }

    }
}
