using ApplicationApi.Entity.Models;

using ApplicationApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationApi.Interfaces
{
    public interface ILogin
    {

        public  Task<ApiResponse>  LoginRepositoryMethod(userLoginCredentialdata _user);

        public Task<Boolean> pass_uName_cheeck(userLoginCredentialdata _user);
        public  Task<ApiResponse> login(userLoginCredentialdata User);

        public String GenerateToken(userLoginCredentialdata User);
        

    }
}
