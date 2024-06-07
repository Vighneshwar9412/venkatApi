using Microsoft.AspNetCore.Mvc;
using ApplicationApi.Interfaces;
using ApplicationApi.Models;
using Microsoft.AspNetCore.Http;
using ApplicationApi.Responses;
using System.Net;
using ApplicationApi.DAL.database;
using System.Data;
using ApplicationApi.Entity.Models;

namespace ApplicationApi.Repositories
{
    public class SignupRepositiory:Interface
    {
        
        List<UserdataResp> AllUsersdata = new List<UserdataResp>();




        public async  Task<ApiResponse> RegisterNewuser( Userdata user)
        {
            var Response = new UserdataFromDb(user);

            if ( user.email == ""&& user.Password == ""&& user.ConfirmPassword == "")
            {
                
                return  new ApiResponse { status = HttpStatusCode.BadRequest, IsSuccess = false, Body = new Userdata {email ="", Password="",ConfirmPassword="" } };
            }
            
            else if ( new SignupRepositiory().IsuserExist(user).Result)
            {
               // var Allusers = Response.getAllUser();
                return new ApiResponse { status = System.Net.HttpStatusCode.Conflict, IsSuccess = false , Body = user  };
            }

            else
            {

                //dynamic  userResp =  Response.AddNewUser();
                
                var  success = Convert.ToBoolean((int)Response.AddNewUser().Result[0]);

                if (success)
                {

                    dynamic Allusers = await Response.getAllUser();
                    DataSet ds = Allusers[0];
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable users = ds.Tables[0];

                        foreach (DataRow row in users.Rows) // Iterates through all rows in first tables
                        {
                            AllUsersdata.Add(new UserdataResp { email = row["email"].ToString(), Password = row["password"].ToString() });
                        }

                    }
                }
                return  new  ApiResponse {status = System.Net.HttpStatusCode.OK, IsSuccess = success, Body = user, Users = AllUsersdata };

            }

        }
        
        public  async Task<Boolean> IsuserExist(Userdata user)
        {
            Boolean flag = false;

            var Response = new UserdataFromDb(user);


            dynamic Allusers = await Response.getAllUser();
            DataSet ds = Allusers[0];
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable users = ds.Tables[0];

                foreach (DataRow row in users.Rows) // Iterates through all rows in first tables
                {
                    if(row["email"].ToString().ToUpper() == user.email.ToUpper()) { flag = true; break; }
                }
            }
            return flag;
        }
    }
}
