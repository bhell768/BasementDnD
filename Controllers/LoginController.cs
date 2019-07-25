using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BasementRPG.Models;
using BasementRPG.Models.Login;
using Newtonsoft.Json;
using BasementRPG.Services.Abstract;
using System;

namespace BasementRPG.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LoginController : ControllerBase
    {

        private ILoginService LoginService {get; set;}

        public LoginController(ILoginService loginService)
        {
            LoginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginRequest user)
        {
            bool result = await LoginService.Login(user);
            if (!result)
            {
                return new UnauthorizedResult();
            }
            return new OkObjectResult(result);
        }

        [HttpGet]

        public async Task<IActionResult> Logout()
        {
            var result = await LoginService.Logout();
            if(result)
            {
                return new OkObjectResult(result);
            }
            return new BadRequestResult();
        }

        public async Task<IActionResult> GetInfo()
        {
            LoginInfoResponse result = await LoginService.GetInfo();
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody]SignupRequest signup)
        {
            if(signup.Password == signup.VPassword)
            {
                bool result = await LoginService.SignUp(signup);
                return new OkObjectResult(result);
            }
            else
            {
                return new OkObjectResult("Password doesn't match");
            }
        }
    }
}