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
    public class DA_User
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

        public static int AddUser(User user)
        {
            int Id = 0;
            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "INSERT INTO [dbo].[User] (UserFirstName,UserLastName,UserEmailId,Password,UserContact,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn,IsDeleted)" +
                    " OUTPUT INSERTED.UserId VALUES (@UserFirstName,@UserLastName,@UserEmailId,@Password,@UserContact,@CreatedBy,GETDATE(),@ModifiedBy,GETDATE(),0)";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@UserFirstName", user.UserFirstName);
                cmd.Parameters.AddWithValue("@UserLastName", user.UserLastName);
                cmd.Parameters.AddWithValue("@UserEmailId", user.UserEmailId);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@UserContact", user.UserContact);
                cmd.Parameters.AddWithValue("@CreatedBy", user.CreatedBy);
                cmd.Parameters.AddWithValue("@ModifiedBy", user.ModifiedBy);


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


        public static int UpdateUser(User user)
        {
            int Id = 0;
            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "UPDATE [dbo].[User] SET UserFirstName=@UserFirstName, UserLastName=@UserLastName, UserEmailId=@UserEmailId," +
                    " UserContact=@UserContact, Password=@Password, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE UserId=@UserId";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@UserFirstName", user.UserFirstName);
                cmd.Parameters.AddWithValue("@UserLastName", user.UserLastName);
                cmd.Parameters.AddWithValue("@UserEmailId", user.UserEmailId);
                cmd.Parameters.AddWithValue("@UserContact", user.UserContact);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@ModifiedBy", user.ModifiedBy);
                cmd.Parameters.AddWithValue("@UserId", user.UserId);

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


        public static int DeleteUser(User user)
        {
            int Id = 0;

            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "UPDATE [dbo].[User] SET IsDeleted=1, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE() WHERE UserId=@UserId";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@ModifiedBy", user.ModifiedBy);
                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                

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


        public static User CheckUserIfValid(string UserEmailId)
        {
            var user = new User();
            using (var con = new SqlConnection(connectionString))
            {

                var queryString = "SELECT UserId, UserFirstName, UserLastName, UserEmailId, Password, UserContact FROM [dbo].[User] WHERE UserEmailId = @UserEmailId";

                var cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@UserEmailId", UserEmailId);
                try
                {
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        user.UserId = Convert.ToInt32(dataReader[0]);
                        user.UserFirstName = Convert.ToString(dataReader[1]);
                        user.UserLastName = Convert.ToString(dataReader[2]);
                        user.UserEmailId = Convert.ToString(dataReader[3]);
                        user.Password = Convert.ToString(dataReader[4]);
                        user.UserContact = Convert.ToString(dataReader[5]);

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
            return user;
        }


        public static List<User> GetAllUsers()
        {
            var users = new List<User>();
            using (var con = new SqlConnection(connectionString))
            {
                const string query = "SELECT UserId, UserFirstName, UserLastName, UserEmailId, Password, UserContact FROM [dbo].[User] WHERE IsDeleted=0";
                var cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        users.Add(new User
                        {
                            UserId = Convert.ToInt32(dataReader[0]),
                            UserFirstName = Convert.ToString(dataReader[1]),
                            UserLastName = Convert.ToString(dataReader[2]),
                            UserEmailId = Convert.ToString(dataReader[3]),
                            Password = Convert.ToString(dataReader[4]),
                            UserContact = Convert.ToString(dataReader[5])

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
            return users;
        }


        public static User GetUserById(int UserId)
        {
            var user = new User();
            using (var con = new SqlConnection(connectionString))
            {

                var queryString = "SELECT UserId, UserFirstName, UserLastName, UserEmailId, Password, UserContact FROM [dbo].[User] WHERE IsDeleted=0 AND UserId=@UserId";

                var cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                try
                {
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {

                        user.UserId = Convert.ToInt32(dataReader[0]);
                        user.UserFirstName = Convert.ToString(dataReader[1]);
                        user.UserLastName = Convert.ToString(dataReader[2]);
                        user.UserEmailId = Convert.ToString(dataReader[3]);
                        user.Password = Convert.ToString(dataReader[4]);
                        user.UserContact = Convert.ToString(dataReader[5]);
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
            return user;
        }


        public static int GetTotalUsers()
        {
            int totalusers = 0;
            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "SELECT COUNT(UserId) FROM [dbo].[User] WHERE IsDeleted=0";
                var cmd = new SqlCommand(queryString, con);
                try
                {
                    con.Open();
                    totalusers = Convert.ToInt32(cmd.ExecuteScalar());
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
            return totalusers;

        }


    }
}