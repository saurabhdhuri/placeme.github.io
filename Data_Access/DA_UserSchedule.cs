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
    public class DA_UserSchedule
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

        public static int AddUserSchedule(UserSchedule userschedule)
        {
            int Id = 0;
            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "INSERT INTO [dbo].[UserSchedule] (UserId, CompanyId, ApplicationId, InterviewName, InterviewDescription, InterviewDate, " +
                    "InterviewDoc1, InterviewDoc2, InterviewDoc3, InterviewDoc4, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn, IsDeleted)" +
                    " VALUES (@UserId, @CompanyId, @ApplicationId, @InterviewName, @InterviewDescription, @InterviewDate, @InterviewDoc1, " +
                    "@InterviewDoc2, @InterviewDoc3, @InterviewDoc4, @CreatedBy, GETDATE(), @ModifiedBy, GETDATE(), 0)";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@UserId", userschedule.UserId);
                cmd.Parameters.AddWithValue("@CompanyId", userschedule.CompanyId);
                cmd.Parameters.AddWithValue("@ApplicationId", userschedule.ApplicationId);
                cmd.Parameters.AddWithValue("@InterviewName", userschedule.InterviewName);
                cmd.Parameters.AddWithValue("@InterviewDescription", userschedule.InterviewDescription);
                cmd.Parameters.AddWithValue("@InterviewDate", userschedule.InterviewDate);
                cmd.Parameters.AddWithValue("@InterviewDoc1", userschedule.InterviewDoc1);
                cmd.Parameters.AddWithValue("@InterviewDoc2", userschedule.InterviewDoc2);
                cmd.Parameters.AddWithValue("@InterviewDoc3", userschedule.InterviewDoc3);
                cmd.Parameters.AddWithValue("@InterviewDoc4", userschedule.InterviewDoc4);
                cmd.Parameters.AddWithValue("@CreatedBy", userschedule.CreatedBy);
                cmd.Parameters.AddWithValue("@ModifiedBy", userschedule.ModifiedBy);


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

        public static int UpdateUserSchedule(UserSchedule userschedule)
        {
            int Id = 0;
            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "";


                if (userschedule.InterviewDoc1 == "" && userschedule.InterviewDoc2 == "" && userschedule.InterviewDoc3 == "" && userschedule.InterviewDoc4 == "")
                {
                    queryString = "UPDATE [dbo].[UserSchedule] SET InterviewName=@InterviewName, InterviewDescription=@InterviewDescription, InterviewDate=@InterviewDate, " +
                    "ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE ScheduleId=@ScheduleId";

                }
                else if (userschedule.InterviewDoc1 != "" && userschedule.InterviewDoc2 == "" && userschedule.InterviewDoc3 == "" && userschedule.InterviewDoc4 == "")
                {
                    queryString = "UPDATE [dbo].[UserSchedule] SET InterviewName=@InterviewName, InterviewDescription=@InterviewDescription, InterviewDate=@InterviewDate, InterviewDoc1=@InterviewDoc1, " +
                    "ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE ScheduleId=@ScheduleId";

                }
                else if (userschedule.InterviewDoc1 != "" && userschedule.InterviewDoc2 != "" && userschedule.InterviewDoc3 == "" && userschedule.InterviewDoc4 == "")
                {
                    queryString = "UPDATE [dbo].[UserSchedule] SET InterviewName=@InterviewName, InterviewDescription=@InterviewDescription, InterviewDate=@InterviewDate, InterviewDoc1=@InterviewDoc1, " +
                    "InterviewDoc2=@InterviewDoc2, InterviewDoc4=@InterviewDoc4, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE ScheduleId=@ScheduleId";

                }
                else if (userschedule.InterviewDoc1 != "" && userschedule.InterviewDoc2 != "" && userschedule.InterviewDoc3 != "" && userschedule.InterviewDoc4 == "")
                {
                    queryString = "UPDATE [dbo].[UserSchedule] SET InterviewName=@InterviewName, InterviewDescription=@InterviewDescription, InterviewDate=@InterviewDate, InterviewDoc1=@InterviewDoc1, " +
                    "InterviewDoc2=@InterviewDoc2, InterviewDoc3=@InterviewDoc3, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE ScheduleId=@ScheduleId";

                }
                else if (userschedule.InterviewDoc1 != "" && userschedule.InterviewDoc2 != "" && userschedule.InterviewDoc3 != "" && userschedule.InterviewDoc4 != "")
                {
                    queryString = "UPDATE [dbo].[UserSchedule] SET InterviewName=@InterviewName, InterviewDescription=@InterviewDescription, InterviewDate=@InterviewDate, InterviewDoc1=@InterviewDoc1, " +
                    "InterviewDoc2=@InterviewDoc2, InterviewDoc3=@InterviewDoc3, InterviewDoc4=@InterviewDoc4, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE ScheduleId=@ScheduleId";

                }
                else if (userschedule.InterviewDoc1 == "" && userschedule.InterviewDoc2 != "" && userschedule.InterviewDoc3 == "" && userschedule.InterviewDoc4 == "")
                {
                    queryString = "UPDATE [dbo].[UserSchedule] SET InterviewName=@InterviewName, InterviewDescription=@InterviewDescription, InterviewDate=@InterviewDate, " +
                    "InterviewDoc2=@InterviewDoc2, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE ScheduleId=@ScheduleId";

                }
                else if (userschedule.InterviewDoc1 == "" && userschedule.InterviewDoc2 != "" && userschedule.InterviewDoc3 != "" && userschedule.InterviewDoc4 == "")
                {
                    queryString = "UPDATE [dbo].[UserSchedule] SET InterviewName=@InterviewName, InterviewDescription=@InterviewDescription, InterviewDate=@InterviewDate, " +
                    "InterviewDoc2=@InterviewDoc2, InterviewDoc3=@InterviewDoc3, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE ScheduleId=@ScheduleId";

                }
                else if (userschedule.InterviewDoc1 == "" && userschedule.InterviewDoc2 != "" && userschedule.InterviewDoc3 != "" && userschedule.InterviewDoc4 != "")
                {
                    queryString = "UPDATE [dbo].[UserSchedule] SET InterviewName=@InterviewName, InterviewDescription=@InterviewDescription, InterviewDate=@InterviewDate, " +
                    "InterviewDoc2=@InterviewDoc2, InterviewDoc3=@InterviewDoc3, InterviewDoc4=@InterviewDoc4, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE ScheduleId=@ScheduleId";

                }
                else if (userschedule.InterviewDoc1 == "" && userschedule.InterviewDoc2 == "" && userschedule.InterviewDoc3 != "" && userschedule.InterviewDoc4 == "")
                {
                    queryString = "UPDATE [dbo].[UserSchedule] SET InterviewName=@InterviewName, InterviewDescription=@InterviewDescription, InterviewDate=@InterviewDate, " +
                    "InterviewDoc3=@InterviewDoc3, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE ScheduleId=@ScheduleId";

                }
                else if (userschedule.InterviewDoc1 == "" && userschedule.InterviewDoc2 == "" && userschedule.InterviewDoc3 != "" && userschedule.InterviewDoc4 != "")
                {
                    queryString = "UPDATE [dbo].[UserSchedule] SET InterviewName=@InterviewName, InterviewDescription=@InterviewDescription, InterviewDate=@InterviewDate, " +
                    "InterviewDoc3=@InterviewDoc3, InterviewDoc4=@InterviewDoc4, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE ScheduleId=@ScheduleId";

                }
                else if (userschedule.InterviewDoc1 != "" && userschedule.InterviewDoc2 == "" && userschedule.InterviewDoc3 != "" && userschedule.InterviewDoc4 != "")
                {
                    queryString = "UPDATE [dbo].[UserSchedule] SET InterviewName=@InterviewName, InterviewDescription=@InterviewDescription, InterviewDate=@InterviewDate, InterviewDoc1=@InterviewDoc1, " +
                    "InterviewDoc3=@InterviewDoc3, InterviewDoc4=@InterviewDoc4, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE ScheduleId=@ScheduleId";

                }
                else if (userschedule.InterviewDoc1 == "" && userschedule.InterviewDoc2 == "" && userschedule.InterviewDoc3 == "" && userschedule.InterviewDoc4 != "")
                {
                    queryString = "UPDATE [dbo].[UserSchedule] SET InterviewName=@InterviewName, InterviewDescription=@InterviewDescription, InterviewDate=@InterviewDate, " +
                    "InterviewDoc4=@InterviewDoc4, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE ScheduleId=@ScheduleId";

                }
                else if (userschedule.InterviewDoc1 != "" && userschedule.InterviewDoc2 == "" && userschedule.InterviewDoc3 == "" && userschedule.InterviewDoc4 != "")
                {
                    queryString = "UPDATE [dbo].[UserSchedule] SET InterviewName=@InterviewName, InterviewDescription=@InterviewDescription, InterviewDate=@InterviewDate, InterviewDoc1=@InterviewDoc1, " +
                    "InterviewDoc4=@InterviewDoc4, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE ScheduleId=@ScheduleId";

                }
                else if (userschedule.InterviewDoc1 != "" && userschedule.InterviewDoc2 != "" && userschedule.InterviewDoc3 == "" && userschedule.InterviewDoc4 != "")
                {
                    queryString = "UPDATE [dbo].[UserSchedule] SET InterviewName=@InterviewName, InterviewDescription=@InterviewDescription, InterviewDate=@InterviewDate, InterviewDoc1=@InterviewDoc1, " +
                    "InterviewDoc2=@InterviewDoc2, InterviewDoc4=@InterviewDoc4, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE ScheduleId=@ScheduleId";

                }


                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@InterviewName", userschedule.InterviewName);
                cmd.Parameters.AddWithValue("@InterviewDescription", userschedule.InterviewDescription);
                cmd.Parameters.AddWithValue("@InterviewDate", userschedule.InterviewDate);
                cmd.Parameters.AddWithValue("@InterviewDoc1", userschedule.InterviewDoc1);
                cmd.Parameters.AddWithValue("@InterviewDoc2", userschedule.InterviewDoc2);
                cmd.Parameters.AddWithValue("@InterviewDoc3", userschedule.InterviewDoc3);
                cmd.Parameters.AddWithValue("@InterviewDoc4", userschedule.InterviewDoc4);
                cmd.Parameters.AddWithValue("@ModifiedBy", userschedule.ModifiedBy);
                cmd.Parameters.AddWithValue("@ScheduleId", userschedule.ScheduleId);

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


        public static int DeleteUserSchedule(UserSchedule userschedule)
        {
            int Id = 0;

            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "UPDATE [dbo].[UserSchedule] SET IsDeleted=1, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE() WHERE ScheduleId=@ScheduleId";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@ModifiedBy", userschedule.ModifiedBy);
                cmd.Parameters.AddWithValue("@ScheduleId", userschedule.ScheduleId);


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

        public static int DeleteUserScheduleByApplicationId(UserSchedule userschedule)
        {
            int Id = 0;

            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "UPDATE [dbo].[UserSchedule] SET IsDeleted=1, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE() WHERE ApplicationId=@ApplicationId";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@ModifiedBy", userschedule.ModifiedBy);
                cmd.Parameters.AddWithValue("@ApplicationId", userschedule.ApplicationId);


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


        public static int DeleteUserScheduleByUserId(UserSchedule userschedule)
        {
            int Id = 0;

            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "UPDATE [dbo].[UserSchedule] SET IsDeleted=1, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE() WHERE UserId=@UserId";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@ModifiedBy", userschedule.ModifiedBy);
                cmd.Parameters.AddWithValue("@UserId", userschedule.UserId);


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


        public static int DeleteUserScheduleByCompanyId(UserSchedule userschedule)
        {
            int Id = 0;

            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "UPDATE [dbo].[UserSchedule] SET IsDeleted=1, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE() WHERE CompanyId=@CompanyId";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@ModifiedBy", userschedule.ModifiedBy);
                cmd.Parameters.AddWithValue("@CompanyId", userschedule.CompanyId);


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


        public static List<UserSchedule> GetAllUserSchedules()
        {
            var userschedules = new List<UserSchedule>();
            using (var con = new SqlConnection(connectionString))
            {
                var query = "SELECT ScheduleId, UserId, CompanyId, ApplicationId, InterviewName, InterviewDescription, InterviewDate, " +
                    "InterviewDoc1, InterviewDoc2, InterviewDoc3, InterviewDoc4 FROM [dbo].[UserSchedule] WHERE IsDeleted=0";
                var cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        userschedules.Add(new UserSchedule
                        {
                            ScheduleId = Convert.ToInt32(dataReader[0]),
                            UserId = Convert.ToInt32(dataReader[1]),
                            CompanyId = Convert.ToInt32(dataReader[2]),
                            ApplicationId = Convert.ToInt32(dataReader[3]),
                            InterviewName = Convert.ToString(dataReader[4]),
                            InterviewDescription = Convert.ToString(dataReader[5]),
                            InterviewDate = Convert.ToDateTime(dataReader[6]),
                            InterviewDoc1 = Convert.ToString(dataReader[7]),
                            InterviewDoc2 = Convert.ToString(dataReader[8]),
                            InterviewDoc3 = Convert.ToString(dataReader[9]),
                            InterviewDoc4 = Convert.ToString(dataReader[10])

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
            return userschedules;
        }



        public static List<UserSchedule> GetAllUserScheduleByUserId(int UserId)
        {
            var userschedules = new List<UserSchedule>();
            using (var con = new SqlConnection(connectionString))
            {
                var query = "SELECT ScheduleId, UserId, CompanyId, ApplicationId, InterviewName, InterviewDescription, InterviewDate, " +
                    "InterviewDoc1, InterviewDoc2, InterviewDoc3, InterviewDoc4 FROM [dbo].[UserSchedule] WHERE IsDeleted=0 AND UserId=@UserId";
                
                var cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@UserId", UserId);

                try
                {
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        userschedules.Add(new UserSchedule
                        {
                            ScheduleId = Convert.ToInt32(dataReader[0]),
                            UserId = Convert.ToInt32(dataReader[1]),
                            CompanyId = Convert.ToInt32(dataReader[2]),
                            ApplicationId = Convert.ToInt32(dataReader[3]),
                            InterviewName = Convert.ToString(dataReader[4]),
                            InterviewDescription = Convert.ToString(dataReader[5]),
                            InterviewDate = Convert.ToDateTime(dataReader[6]),
                            InterviewDoc1 = Convert.ToString(dataReader[7]),
                            InterviewDoc2 = Convert.ToString(dataReader[8]),
                            InterviewDoc3 = Convert.ToString(dataReader[9]),
                            InterviewDoc4 = Convert.ToString(dataReader[10])

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
            return userschedules;
        }



    }
}