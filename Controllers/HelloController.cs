using BasementRPG.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BasementRPG.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HelloController : Controller
    {
        private IHelloRepository HelloRepository { get; set; }

        public HelloController(IHelloRepository helloRepository)
        {
            HelloRepository = helloRepository;
        }

        [HttpPost]
        public HelloResponse GreetInfo([FromBody]HelloRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Input))
            {
                return new HelloResponse
                {
                    Result = "You have not selected a Name. Please enter a value in the Name field to say hello!"
                };
            }

            return new HelloResponse
            {
                Result = $"Hello {request.Input}!"
            };
        }

        [HttpGet]
        public HelloResponse GreetInfoDb([FromQuery]HelloRequest request)
        {            
            if (string.IsNullOrWhiteSpace(request.Input))
            {
                return new HelloResponse
                {
                    Result = "You have not selected a Name. Please enter a value in the Name field to say hello!"
                };
            }

            var result = HelloRepository.GetHelloMessage(request.Input);

            return new HelloResponse
            {
                Result = $"{result} {request.Input}!"
            };
        }

        public class HelloRequest
        {
            public string Input { get; set; }
        }

        public class HelloResponse
        {
            public string Result { get; set; }
        }
    }
}
