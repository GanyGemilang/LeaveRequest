using LeaveRequest.Base.Controller;
using LeaveRequest.Handler;
using LeaveRequest.Models;
using LeaveRequest.Repositories.Data;
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
    public class UserController : BaseController<User, UserRepository>
    {
        private readonly IJWTAuthenticationManager jwtAuthenticationManager;
        private readonly UserRepository userRepository;
        public UserController(IJWTAuthenticationManager jwtAuthenticationManager, UserRepository userRepository) : base(userRepository)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            //this.userRepository = userRepository;
        }
    }
}
