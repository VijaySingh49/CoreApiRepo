using CoreAPI.Interface;
using CoreAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IJwtAuthenticationManager JwtAuthenticationManager;
        public HomeController(IJwtAuthenticationManager JwtAuthenticationManager)
        {
            this.JwtAuthenticationManager = JwtAuthenticationManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var abc = new { id = "101", name = "Vijay" };
            return new JsonResult(abc);
        }

        //get token
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate(User user)
        {
            var token = JwtAuthenticationManager.Authenticate(user.UserName, user.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
