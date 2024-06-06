using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using Newtonsoft.Json;
using ApplicationApi.Models;

using System.Net;
namespace ApplicationApi.DAL.database
{
    public class UserdataFromDb
    {

        SqlConnection con = new SqlConnection("Server= dc-serv; Database=Test1;Integrated Security=true");
        private Userdata _data;
       
        public UserdataFromDb(Userdata data)
        {
            _data = data;

        }
        public int addNewUser(  )
        {
            int st = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("userRegistered_vignes_ins__proc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", _data.email );
            cmd.Parameters.AddWithValue("@password", _data.Password);

            st = cmd.ExecuteNonQuery();

            return st;


        }
        public string  SelectData()
        {
            string st = "";
           

            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_V_GetEmployeeData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                st = JsonConvert.SerializeObject(ds.Tables, Newtonsoft.Json.Formatting.Indented);
            }
            else
            {
                st = JsonConvert.SerializeObject("no data found ", Newtonsoft.Json.Formatting.Indented);
            }

            return st;

             
        }


    }
}
