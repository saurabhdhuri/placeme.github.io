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
    public class DA_UserApplication
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

        public static int AddUserApplication(UserApplication userapplication)
        {
            int Id = 0;
            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "INSERT INTO [dbo].[UserApplication] (UserId, CompanyId, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn, IsDeleted, IsEligible)" +
                    " VALUES (@UserId, @CompanyId, @CreatedBy, GETDATE(), @ModifiedBy, GETDATE(), 0, 0)";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@UserId", userapplication.UserId);
                cmd.Parameters.AddWithValue("@CompanyId", userapplication.CompanyId);
                cmd.Parameters.AddWithValue("@CreatedBy", userapplication.CreatedBy);
                cmd.Parameters.AddWithValue("@ModifiedBy", userapplication.ModifiedBy);
                


                try
                {
                    con.Open();
                    Id = cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

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
            return Id;
        }


        public static int UpdateUserApplication(UserApplication userapplication)
        {
            int Id = 0;
            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "UPDATE [dbo].[UserApplication] SET IsEligible=@IsEligible, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE ApplicationId=@ApplicationId";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@IsEligible", userapplication.IsEligible);
                cmd.Parameters.AddWithValue("@ModifiedBy", userapplication.ModifiedBy);
                cmd.Parameters.AddWithValue("@ApplicationId", userapplication.ApplicationId);

                try
                {
                    con.Open();
                    Id = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

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
            return Id;
        }


        public static int DeleteUserApplication(UserApplication userapplication)
        {
            int Id = 0;

            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "UPDATE [dbo].[UserApplication] SET IsDeleted=1, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE() WHERE ApplicationId=@ApplicationId";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@ModifiedBy", userapplication.ModifiedBy);
                cmd.Parameters.AddWithValue("@ApplicationId", userapplication.ApplicationId);


                try
                {
                    con.Open();
                    Id = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

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

            return Id;
        }


        public static int DeleteUserApplicationByUserId(UserApplication userapplication)
        {
            int Id = 0;

            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "UPDATE [dbo].[UserApplication] SET IsDeleted=1, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE() OUTPUT INSERTED.ApplicationId WHERE UserId=@UserId";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@ModifiedBy", userapplication.ModifiedBy);
                cmd.Parameters.AddWithValue("@UserId", userapplication.UserId);


                try
                {
                    con.Open();
                    Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {

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

            return Id;
        }


        public static int DeleteUserApplicationByCompanyId(UserApplication userapplication)
        {
            int Id = 0;

            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "UPDATE [dbo].[UserApplication] SET IsDeleted=1, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE() OUTPUT INSERTED.ApplicationId WHERE CompanyId=@CompanyId";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@ModifiedBy", userapplication.ModifiedBy);
                cmd.Parameters.AddWithValue("@CompanyId", userapplication.CompanyId);


                try
                {
                    con.Open();
                    Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {

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

            return Id;
        }



        public static List<UserApplication> GetAllUserApplications()
        {
            var userapplications = new List<UserApplication>();
            using (var con = new SqlConnection(connectionString))
            {
                var query = "SELECT ApplicationId, UserId, CompanyId, IsEligible FROM [dbo].[UserApplication] WHERE IsDeleted=0";
                var cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        userapplications.Add(new UserApplication
                        {
                            ApplicationId = Convert.ToInt32(dataReader[0]),
                            UserId = Convert.ToInt32(dataReader[1]),
                            CompanyId = Convert.ToInt32(dataReader[2]),
                            IsEligible = Convert.ToBoolean(dataReader[3])
                            
                        });
                    }
                }
                catch (Exception e)
                {
                    //ignored
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
            return userapplications;
        }



        public static UserApplication GetUserApplicationById(UserApplication userapplication)
        {
            var userapplications = new UserApplication();

            using (var con = new SqlConnection(connectionString))
            {
                var query = "SELECT ApplicationId, UserId, CompanyId FROM [dbo].[UserApplication] WHERE IsDeleted=0 AND UserId=@UserId AND CompanyId=@CompanyId";
                var cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@UserId", userapplication.UserId);
                cmd.Parameters.AddWithValue("@CompanyId", userapplication.CompanyId);
                try
                {
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {

                        userapplications.ApplicationId = Convert.ToInt32(dataReader[0]);
                        userapplications.UserId = Convert.ToInt32(dataReader[1]);
                        userapplications.CompanyId = Convert.ToInt32(dataReader[2]);
                        
                    }
                }
                catch (Exception ex)
                {
                    //ignored
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
            return userapplications;
        }



        public static List<UserApplication> GetUserApplicationsByEligibility()
        {
            var userapplications = new List<UserApplication>();
            using (var con = new SqlConnection(connectionString))
            {
                const string query = "SELECT ApplicationId, UserId, CompanyId, IsEligible FROM [dbo].[UserApplication] WHERE IsDeleted=0 AND IsEligible=1";
                var cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        userapplications.Add(new UserApplication
                        {
                            ApplicationId = Convert.ToInt32(dataReader[0]),
                            UserId = Convert.ToInt32(dataReader[1]),
                            CompanyId = Convert.ToInt32(dataReader[2]),
                            IsEligible = Convert.ToBoolean(dataReader[3])

                        });
                    }
                }
                catch (Exception)
                {
                    //ignored
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
            return userapplications;
        }


        public static int GetTotalUserApplications()
        {
            int totaluserapplications = 0;
            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "SELECT COUNT(ApplicationId) FROM [dbo].[UserApplication] WHERE IsDeleted=0";
                var cmd = new SqlCommand(queryString, con);
                try
                {
                    con.Open();
                    totaluserapplications = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception)
                {
                    //ignored
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
            return totaluserapplications;

        }




    }
}