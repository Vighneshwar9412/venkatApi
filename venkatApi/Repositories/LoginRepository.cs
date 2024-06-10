using ApplicationApi.Responses;
using System.Net;
using ApplicationApi.Interfaces;
using ApplicationApi.Models;
using ApplicationApi.BLL.NewFolder;
using ApplicationApi.Entity.Models;
using System.Data;
using ApplicationApi.DAL.database;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ApplicationApi.Repositories
{
    public class LoginRepository : ILogin
    {
        private IConfiguration _Config;
        public LoginRepository() { }

        public LoginRepository(IConfiguration configuration) {
            _Config = configuration;
        }
        

        public async Task<ApiResponse> LoginRepositoryMethod(userLoginCredentialdata _user)
        {
            
            if (await pass_uName_cheeck(_user))
            {
             
                return new ApiResponse { status = HttpStatusCode.OK, IsSuccess = true, Logindata = _user };

            }
            return new ApiResponse { status = HttpStatusCode.BadRequest, IsSuccess = false, Body = new Userdata { email = "", Password = "", ConfirmPassword = "" } };

        }

        public async Task<Boolean> pass_uName_cheeck(userLoginCredentialdata _user) {
             
            Boolean flag = false;

            dynamic Allusers = await  new getAllUserInList().getAllUseriList();
            if (_user.username != null && _user.password != null)
            {

                foreach (var user in Allusers)
                {
                    if (user.email == _user.username && user.Password == _user.password)
                    {

                        flag = true;

                        break;
                    }
                }
            }

            return flag;

        }
        public async Task<ApiResponse> login(userLoginCredentialdata User)
        {
            var result = await new LoginRepository().LoginRepositoryMethod(User);

            return result;
        }


        public String GenerateToken(userLoginCredentialdata User)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_Config["Jwt:Key"], null, expires: DateTime.Now.AddHours(5), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }

}