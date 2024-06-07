using ApplicationApi.Responses;
using System.Net;
using ApplicationApi.DAL.database;
using ApplicationApi.Interfaces;
using ApplicationApi.Models;
using ApplicationApi.BLL.NewFolder;
using ApplicationApi.Entity.Models;
using System.Data;

namespace ApplicationApi.Repositories
{
    public class LoginRepository : ILogin
    {
        public readonly userLoginCredentialdata _user;

        public LoginRepository(userLoginCredentialdata user) {
        
            _user = user;
        
        }

        public dynamic LoginRepository()
        {
            if (_user.username == null && _user.password == null)
            {
                return new ApiResponse { status = HttpStatusCode.BadRequest, IsSuccess = false, Body = new Userdata { email = "", Password = "", ConfirmPassword = "" } };
            }
            
        }

        public Boolean pass_uName_cheeck() {

            Boolean flag = false;

            dynamic Allusers = new getAllUserInList().getAllUseriList();

            foreach (var user in Allusers)
            {
                if (user.username != null && user.password != null && user.username == _user.username && user.password == _user.password) {

                     flag = true;

                     break;
                }
            }


            return flag;

        }
    }

}