using ApplicationApi.Entity.Models;
using ApplicationApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationApi.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public readonly ILogin _ILogin;
        public AuthenticationController(ILogin ILogin)
        {
            _ILogin = ILogin;

        }
        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> LoginAuthentication(userLoginCredentialdata User)
        {
            IActionResult response = Unauthorized();

            dynamic response1 = await _ILogin.login(User);
            Boolean isUserExist = response1.IsSuccess;
            Console.WriteLine(isUserExist);
            if (isUserExist)
            {

                var token = _ILogin.GenerateToken(User);
                response = Ok(new { token = token });
            }
            return response;

        }
    }
}
