using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationApi.Models;

namespace ApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        public JsonResult login(Userdata User)
        {

            return new JsonResult(true);
        }
    }
}
