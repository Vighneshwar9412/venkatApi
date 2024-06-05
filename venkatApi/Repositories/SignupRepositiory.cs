using Microsoft.AspNetCore.Mvc;
using venkatApi.Interfaces;
using venkatApi.Models;
using Microsoft.AspNetCore.Http;
using venkatApi.Responses;
using System.Net.Http;
namespace venkatApi.Repositories
{
    public class SignupRepositiory: Interface
    {

        ApiResponse response = new ApiResponse { status = Status.OK() , isSuccess = true};
        public async Task<dynamic> RegisterNewuser(HttpRequest req, Userdata userdata) => await return response;
    }
}
