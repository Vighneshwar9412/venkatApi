﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationApi.Models;
using ApplicationApi.Interfaces;
using ApplicationApi.Repositories;

namespace ApplicationApi.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Interface _Interface;
        public LoginController(Interface Input)
        {
            _Interface = Input;
        }

        [HttpPost]
        public JsonResult login(Userdata User)
        {
           // var res = new LoginRepository().RegisterNewuser();
            return new JsonResult("");
        }
    }
}
