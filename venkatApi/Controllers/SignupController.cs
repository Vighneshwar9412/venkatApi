using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationApi.Interfaces;
using ApplicationApi.Models;
using ApplicationApi.Repositories;
using ApplicationApi.Responses;

namespace ApplicationApi.Controllers
{
    [Route("api/Signup")]
    [ApiController]
    public class SignupController : ControllerBase
    {   
        private readonly Interface _Interface;
        public SignupController(Interface Input) {
            _Interface = Input;
        }

        [HttpPost]
        public JsonResult RegisterNewusers(Userdata userdata)
        {

            var response = _Interface.RegisterNewuser(userdata);

            return new JsonResult(response);

        }
        
        
       
    }
}
