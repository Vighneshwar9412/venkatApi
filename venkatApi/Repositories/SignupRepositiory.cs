using Microsoft.AspNetCore.Mvc;
using ApplicationApi.Interfaces;
using ApplicationApi.Models;
using Microsoft.AspNetCore.Http;
using ApplicationApi.Responses;
using System.Net;
using ApplicationApi.DAL.database;

namespace ApplicationApi.Repositories
{
    public class SignupRepositiory:Interface
    {

       

        public  ApiResponse RegisterNewuser( Userdata user)
        {
            var Response = new UserdataFromDb(user);

            if ( user.email == ""&& user.Password == ""&& user.ConfirmPassword == "")
            {
               // var Allusers = Response.getAllUser();
                return  new ApiResponse { status = HttpStatusCode.BadRequest, IsSuccess = false, Body = new Userdata {email ="", Password="",ConfirmPassword=""  } };
            }
            /*
            else if (Response.IsuserExist())
            {
               // var Allusers = Response.getAllUser();
                return new ApiResponse { status = System.Net.HttpStatusCode.Conflict, IsSuccess = false , Body = user , Users = Allusers };
            }*/

            else
            {
                var Allusers = Response.addNewUser();

                return new ApiResponse { status = System.Net.HttpStatusCode.OK, IsSuccess = true, Body = user };

            }
            
           
            
            
        }
    }
}
