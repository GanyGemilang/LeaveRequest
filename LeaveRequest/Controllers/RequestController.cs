using LeaveRequest.Base.Controller;
using LeaveRequest.Models;
using LeaveRequest.Repositories.Data;
using LeaveRequest.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Controllers
{
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
            else
            {
                return StatusCode(500, new { status = "Internal Server Error" });
            }
        }

        [HttpPost("SubmitApproved")]
        public ActionResult SubmitApproved(ApproveRequestVM approveRequestVM)
        {
            var data = requestRepository.Approved(approveRequestVM);
            if (data == 1)
            {
                return Ok(new { status = "Approved success" });
            }
            else
            {
                return StatusCode(500, new { status = "Internal Server Error" });
            }
        }
    }
}
