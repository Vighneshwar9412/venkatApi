
using System.Data;
using ApplicationApi.Entity.Models;
using ApplicationApi.DAL.database;
using ApplicationApi.Models;

namespace ApplicationApi.BLL.NewFolder
{
    public class getAllUserInList
    {
        List<UserdataResp> userdataResps = new List<UserdataResp>();    
        public Userdata _user ;
        public getAllUserInList() {
  

         }

    public async Task<List<UserdataResp>> getAllUseriList(){

        dynamic Allusers = await new UserdataFromDb().getAllUser();
        DataSet ds = Allusers[0];
                   
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable users = ds.Tables[0];

                        foreach (DataRow row in users.Rows) // Iterates through all rows in first tables
                        {
                            userdataResps.Add(new UserdataResp { email = row["email"].ToString(), Password = row["password"].ToString() });
                        }

                    }

                return userdataResps;

        }
    }
}

