using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BasementDnD.Models;
using BasementDnD.Services.Abstract;

namespace BasementDnD.Controllers
{
    
    [Route("api/[controller]/[Action]")]
    public class LoginController
    {
        private ILoginService LoginService {get; set;}

        public LoginController(ILoginService loginService)
        {
            LoginService = loginService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            var result = await LoginService.Get();
            return new OkObjectResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var result = await LoginService.Get();
            if (result == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Login body)
        {
            var result = await LoginService.Create(body);
            return new OkObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody]Login body)
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
        public async Task<IActionResult> DeleteOne(int id)
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