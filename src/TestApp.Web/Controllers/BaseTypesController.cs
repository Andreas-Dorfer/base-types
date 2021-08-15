using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseTypesController : ControllerBase
    {
        [HttpGet]
        public string Foo(MyNonEmptyString who) => $"Hallo {who}";
    }
}
