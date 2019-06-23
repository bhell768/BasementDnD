using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BasementDnD.Models;
using Newtonsoft.Json;
using BasementDnD.Services.Abstract;
using System;

namespace BasementDnD.Controllers
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
        public async Task<IActionResult> Login([FromBody]Login user)
        {
            var result = await LoginService.Login(user.Name, user.Password);
            if (result == "Invalid Login")
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(result);
        }

        [HttpGet]

        public async Task<IActionResult> Logout()
        {
            var result = await LoginService.Logout();
            if(result == "Logged Out")
            {
                return new OkObjectResult(result);
            }
            return new OkObjectResult("Something has gone wrone");
        }

        public async Task<IActionResult> GetInfo()
        {
            var result = await LoginService.GetInfo();
            if(result == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody]Login body)
        {
            var result = await LoginService.Create(body);
            return new OkObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(byte[] id, [FromBody]Login body)
        {
            var result = await LoginService.Get(id);
            if (result == null)
            {
                return new NotFoundResult();
            }
            var updateBool = await LoginService.Update(id, body);
            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(byte[] id)
        {
            var result = await LoginService.Get(id);
            if (result == null)
            {
                return new NotFoundResult();
            }
            var updateBool = await LoginService.Remove(id);
            return new OkResult();
        }

    }
}