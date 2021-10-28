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
    public class DA_UserQualification
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

        public static int AddUserQualification(UserQualification userqualification)
        {
            int Id = 0;
            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "INSERT INTO [dbo].[UserQualification] (UserId,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn,IsDeleted)" +
                    " VALUES (@UserId,@CreatedBy,GETDATE(),@ModifiedBy,GETDATE(),0)";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@UserId", userqualification.UserId);
                cmd.Parameters.AddWithValue("@CreatedBy", userqualification.CreatedBy);
                cmd.Parameters.AddWithValue("@ModifiedBy", userqualification.ModifiedBy);


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


        public static int UpdateUserQualification(UserQualification userqualification)
        {
            int Id = 0;
            var queryString = "";
            using (var con = new SqlConnection(connectionString))
            {

                if (userqualification.Resume == "")
                {
                    queryString = "UPDATE [dbo].[UserQualification] SET SscPercentage=@SscPercentage, HscPercentage=@HscPercentage, UgCourseName=@UgCourseName, UgPercentage=@UgPercentage, " +
                    "PgCourseName=@PgCourseName, PgPercentage=@PgPercentage, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE UserId=@UserId";

                }
                else
                {
                    queryString = "UPDATE [dbo].[UserQualification] SET SscPercentage=@SscPercentage, HscPercentage=@HscPercentage, UgCourseName=@UgCourseName, UgPercentage=@UgPercentage, " +
                 "PgCourseName=@PgCourseName, PgPercentage=@PgPercentage, Resume=@Resume, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE UserId=@UserId";

                }


                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@SscPercentage", userqualification.SscPercentage);
                cmd.Parameters.AddWithValue("@HscPercentage", userqualification.HscPercentage);
                cmd.Parameters.AddWithValue("@UgCourseName", userqualification.UgCourseName);
                cmd.Parameters.AddWithValue("@UgPercentage", userqualification.UgPercentage);
                cmd.Parameters.AddWithValue("@PgCourseName", userqualification.PgCourseName);
                cmd.Parameters.AddWithValue("@PgPercentage", userqualification.PgPercentage);
                cmd.Parameters.AddWithValue("@ModifiedBy", userqualification.ModifiedBy);
                cmd.Parameters.AddWithValue("@UserId", userqualification.UserId);
                cmd.Parameters.AddWithValue("@Resume", userqualification.Resume);

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


        public static int DeleteUserQualificationByUserId(UserQualification userqualification)
        {
            int Id = 0;

            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "UPDATE [dbo].[UserQualification] SET IsDeleted=1, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE() OUTPUT INSERTED.QualificationId WHERE UserId=@UserId";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@ModifiedBy", userqualification.ModifiedBy);
                cmd.Parameters.AddWithValue("@UserId", userqualification.UserId);


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


        public static UserQualification GetUserQualificationByUserId(int UserId)
        {
            var userqualification = new UserQualification();
            using (var con = new SqlConnection(connectionString))
            {

                var queryString = "SELECT QualificationId, UserId, SscPercentage, HscPercentage, UgCourseName, UgPercentage, PgCourseName, PgPercentage, Resume FROM [dbo].[UserQualification] WHERE UserId=@UserId";

                var cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                try
                {
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        userqualification.QualificationId = Convert.ToInt32(dataReader[0]);
                        userqualification.UserId = Convert.ToInt32(dataReader[1]);
                        userqualification.SscPercentage = Convert.ToString(dataReader[2]);
                        userqualification.HscPercentage = Convert.ToString(dataReader[3]);
                        userqualification.UgCourseName = Convert.ToString(dataReader[4]);
                        userqualification.UgPercentage = Convert.ToString(dataReader[5]);
                        userqualification.PgCourseName = Convert.ToString(dataReader[6]);
                        userqualification.PgPercentage = Convert.ToString(dataReader[7]);
                        userqualification.Resume = Convert.ToString(dataReader[8]);
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
            return userqualification;
        }


    }
}