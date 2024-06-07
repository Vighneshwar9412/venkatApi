using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using Newtonsoft.Json;
using ApplicationApi.Models;

using System.Net;
using ApplicationApi.Entity.Models;

namespace ApplicationApi.DAL.database
{
    public class UserdataFromDb
    {

        SqlConnection con = new SqlConnection("Server= dc-serv; Database=Test1;Integrated Security=true");
        private Userdata _data;
        public UserdataFromDb() { 
        }
        public UserdataFromDb(Userdata data)
        {
            _data = data;

        }
        public async Task<dynamic> AddNewUser( )
        {
            int st = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("userRegistered_vignes_ins__proc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", _data.email );
            cmd.Parameters.AddWithValue("@password", _data.Password);

            st = await cmd.ExecuteNonQueryAsync();
            con.Close();
            return new int [] { st };


        }
        public async Task<dynamic> getAllUser()
        {
            List<UserdataResp> NewList = new List<UserdataResp>();



            con.Open();
            SqlCommand cmd = new SqlCommand("userRegistered_vignes_get__proc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {

                return new dynamic[] { ds };
            }
            else
            {
               
                return new dynamic[] {  "something went wrong with emails and passwords " };
            }

            

             
        }


    }
}
