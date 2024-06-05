using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using venkatApi.Interfaces;
using venkatApi.Models;


namespace venkatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        public readonly Interface _Interface;
        public SignupController(Interface Input) {
            _Interface = Input;
        }

        [HttpPost]
        [Route("Report")]
        public Task<dynamic> RegisterNewuser(Userdata userdata) {

            return new _Interface.RegisterNewuser(Request,userdata);

        }  
    }
}
