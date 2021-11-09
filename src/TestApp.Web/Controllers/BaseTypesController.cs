using Microsoft.AspNetCore.Mvc;

namespace TestApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseTypesController : ControllerBase
    {
        [HttpGet]
        public string Foo(MyMinLengthString who) => $"Hallo {who}";
    }
}
