
using Microsoft.AspNetCore.Mvc;
using ApplicationApi.Entity.Models;
using ApplicationApi.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
using ApplicationApi.Repositories;
using ApplicationApi.Responses;

namespace ApplicationApi.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        public readonly ILogin _ILogin;
        public LoginController(ILogin ILogin)
        {
            _ILogin = ILogin;

        }



        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Login(userLoginCredentialdata User)
        {
            var response = _ILogin.LoginRepositoryMethod(User);
            
            return new JsonResult(response);



        }
    }










    /*
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private  IConfiguration _Config;
        private readonly ILogin _ILogin;
        public LoginController( IConfiguration configuration, ILogin ILogin)
        {
            _ILogin = ILogin;
            _Config = configuration;
        }

        
        private async  Task<Boolean> login(userLoginCredentialdata User)
        {
            var result = await _ILogin.LoginRepositoryMethod(User);

           return result.IsSuccess;
        }

        
        private String GenerateToken(userLoginCredentialdata User) {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_Config["Jwt:Key"], null, expires: DateTime.Now.AddHours(5), signingCredentials: credentials);
        
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAuthentication(userLoginCredentialdata User)
        {
            IActionResult response = Unauthorized();
            
            dynamic isUserExist = await  login(User);
            Console.WriteLine(isUserExist);
            if ( isUserExist) {

                var token = GenerateToken(User);
                response = Ok(new { token = token });
            }
            return response;

        }
    }
    */
}
