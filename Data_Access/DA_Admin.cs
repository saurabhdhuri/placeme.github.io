using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PlaceMe.Models;
using System.Configuration;


namespace PlaceMe.Data_Access
{
    public class DA_Admin
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;


        public static Admin CheckAdminIfValid(string AdminEmailId)
        {
            var admin = new Admin();
            using (var con = new SqlConnection(connectionString))
            {

                var queryString = "SELECT AdminId, AdminEmailId, Password, AdminName FROM [dbo].[Admin] WHERE AdminEmailId = @AdminEmailId";

                var cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@AdminEmailId", AdminEmailId);
                try
                {
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        admin.AdminId = Convert.ToInt32(dataReader[0]);
                        admin.AdminEmailId = Convert.ToString(dataReader[1]);
                        admin.Password = Convert.ToString(dataReader[2]);
                        admin.AdminName = Convert.ToString(dataReader[3]);
                        
                    }
                }
                catch (Exception ex)
                {
                    //Ignored
                }
                finally
                {
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                        con.Dispose();
                    }
                }
            }
            return admin;
        }

    }
}