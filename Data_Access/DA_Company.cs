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
    public class DA_Company
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;

        public static int AddCompany(Company company)
        {
            int Id = 0;
            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "INSERT INTO [dbo].[Company] (CompanyName, CompanyDescription, CompanyEmailId, CompanyContact, JobOpenings, JobProfile, JobRequirements, " +
                    "DocAttachment1, DocAttachment2, DocAttachment3, DocAttachment4, SscCriteria, HscCriteria, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn, IsDeleted)" +
                    " VALUES (@CompanyName, @CompanyDescription, @CompanyEmailId, @CompanyContact, @JobOpenings, @JobProfile, @JobRequirements, @DocAttachment1, " +
                    "@DocAttachment2, @DocAttachment3, @DocAttachment4, @SscCriteria, @HscCriteria, @CreatedBy, GETDATE(), @ModifiedBy, GETDATE(), 0)";
                var cmd = new SqlCommand(queryString, con);


                cmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                cmd.Parameters.AddWithValue("@CompanyDescription", company.CompanyDescription);
                cmd.Parameters.AddWithValue("@CompanyEmailId", company.CompanyEmailId);
                cmd.Parameters.AddWithValue("@CompanyContact", company.CompanyContact);
                cmd.Parameters.AddWithValue("@JobOpenings", company.JobOpenings);
                cmd.Parameters.AddWithValue("@JobProfile", company.JobProfile);
                cmd.Parameters.AddWithValue("@JobRequirements", company.JobRequirements);
                cmd.Parameters.AddWithValue("@DocAttachment1", company.DocAttachment1);
                cmd.Parameters.AddWithValue("@DocAttachment2", company.DocAttachment2);
                cmd.Parameters.AddWithValue("@DocAttachment3", company.DocAttachment3);
                cmd.Parameters.AddWithValue("@DocAttachment4", company.DocAttachment4);
                cmd.Parameters.AddWithValue("@SscCriteria", company.SscCriteria);
                cmd.Parameters.AddWithValue("@HscCriteria", company.HscCriteria);
                cmd.Parameters.AddWithValue("@CreatedBy", company.CreatedBy);
                cmd.Parameters.AddWithValue("@ModifiedBy", company.ModifiedBy);


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

        public static int UpdateCompany(Company company)
        {
            int Id = 0;
            var queryString = "";
            using (var con = new SqlConnection(connectionString))
            {
                if (company.DocAttachment1 == "" && company.DocAttachment2 == "" && company.DocAttachment3 == "" && company.DocAttachment4 == "")
                {
                    queryString = "UPDATE [dbo].[Company] SET CompanyName=@CompanyName, CompanyDescription=@CompanyDescription, CompanyEmailId=@CompanyEmailId," +
                    " CompanyContact=@CompanyContact, JobOpenings=@JobOpenings, JobProfile=@JobProfile, JobRequirements=@JobRequirements, " +
                    "SscCriteria=@SscCriteria, HscCriteria=@HscCriteria, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE CompanyId=@CompanyId";

                }
                else if (company.DocAttachment1 != "" && company.DocAttachment2 == "" && company.DocAttachment3 == "" && company.DocAttachment4 == "")
                {
                    queryString = "UPDATE [dbo].[Company] SET CompanyName=@CompanyName, CompanyDescription=@CompanyDescription, CompanyEmailId=@CompanyEmailId," +
                    " CompanyContact=@CompanyContact, JobOpenings=@JobOpenings, JobProfile=@JobProfile, JobRequirements=@JobRequirements, " +
                    "DocAttachment1=@DocAttachment1, " +
                    "SscCriteria=@SscCriteria, HscCriteria=@HscCriteria, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE CompanyId=@CompanyId";

                }
                else if (company.DocAttachment1 != "" && company.DocAttachment2 != "" && company.DocAttachment3 == "" && company.DocAttachment4 == "")
                {
                    queryString = "UPDATE [dbo].[Company] SET CompanyName=@CompanyName, CompanyDescription=@CompanyDescription, CompanyEmailId=@CompanyEmailId," +
                    " CompanyContact=@CompanyContact, JobOpenings=@JobOpenings, JobProfile=@JobProfile, JobRequirements=@JobRequirements, " +
                    "DocAttachment1=@DocAttachment1, DocAttachment2=@DocAttachment2, " +
                    "SscCriteria=@SscCriteria, HscCriteria=@HscCriteria, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE CompanyId=@CompanyId";

                }
                else if (company.DocAttachment1 != "" && company.DocAttachment2 != "" && company.DocAttachment3 != "" && company.DocAttachment4 == "")
                {
                    queryString = "UPDATE [dbo].[Company] SET CompanyName=@CompanyName, CompanyDescription=@CompanyDescription, CompanyEmailId=@CompanyEmailId," +
                    " CompanyContact=@CompanyContact, JobOpenings=@JobOpenings, JobProfile=@JobProfile, JobRequirements=@JobRequirements, " +
                    "DocAttachment1=@DocAttachment1, DocAttachment2=@DocAttachment2, DocAttachment3=@DocAttachment3, " +
                    "SscCriteria=@SscCriteria, HscCriteria=@HscCriteria, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE CompanyId=@CompanyId";

                }
                else if (company.DocAttachment1 != "" && company.DocAttachment2 != "" && company.DocAttachment3 != "" && company.DocAttachment4 != "")
                {
                    queryString = "UPDATE [dbo].[Company] SET CompanyName=@CompanyName, CompanyDescription=@CompanyDescription, CompanyEmailId=@CompanyEmailId," +
                    " CompanyContact=@CompanyContact, JobOpenings=@JobOpenings, JobProfile=@JobProfile, JobRequirements=@JobRequirements, " +
                    "DocAttachment1=@DocAttachment1, DocAttachment2=@DocAttachment2, DocAttachment3=@DocAttachment3, DocAttachment4=@DocAttachment4, " +
                    "SscCriteria=@SscCriteria, HscCriteria=@HscCriteria, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE CompanyId=@CompanyId";

                }
                else if (company.DocAttachment1 == "" && company.DocAttachment2 != "" && company.DocAttachment3 == "" && company.DocAttachment4 == "")
                {
                    queryString = "UPDATE [dbo].[Company] SET CompanyName=@CompanyName, CompanyDescription=@CompanyDescription, CompanyEmailId=@CompanyEmailId," +
                    " CompanyContact=@CompanyContact, JobOpenings=@JobOpenings, JobProfile=@JobProfile, JobRequirements=@JobRequirements, " +
                    "DocAttachment2=@DocAttachment2, " +
                    "SscCriteria=@SscCriteria, HscCriteria=@HscCriteria, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE CompanyId=@CompanyId";

                }
                else if (company.DocAttachment1 == "" && company.DocAttachment2 != "" && company.DocAttachment3 != "" && company.DocAttachment4 == "")
                {
                    queryString = "UPDATE [dbo].[Company] SET CompanyName=@CompanyName, CompanyDescription=@CompanyDescription, CompanyEmailId=@CompanyEmailId," +
                    " CompanyContact=@CompanyContact, JobOpenings=@JobOpenings, JobProfile=@JobProfile, JobRequirements=@JobRequirements, " +
                    "DocAttachment2=@DocAttachment2, DocAttachment3=@DocAttachment3, " +
                    "SscCriteria=@SscCriteria, HscCriteria=@HscCriteria, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE CompanyId=@CompanyId";

                }
                else if (company.DocAttachment1 == "" && company.DocAttachment2 != "" && company.DocAttachment3 != "" && company.DocAttachment4 != "")
                {
                    queryString = "UPDATE [dbo].[Company] SET CompanyName=@CompanyName, CompanyDescription=@CompanyDescription, CompanyEmailId=@CompanyEmailId," +
                    " CompanyContact=@CompanyContact, JobOpenings=@JobOpenings, JobProfile=@JobProfile, JobRequirements=@JobRequirements, " +
                    "DocAttachment2=@DocAttachment2, DocAttachment3=@DocAttachment3, DocAttachment4=@DocAttachment4, " +
                    "SscCriteria=@SscCriteria, HscCriteria=@HscCriteria, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE CompanyId=@CompanyId";

                }
                else if (company.DocAttachment1 == "" && company.DocAttachment2 == "" && company.DocAttachment3 != "" && company.DocAttachment4 == "")
                {
                    queryString = "UPDATE [dbo].[Company] SET CompanyName=@CompanyName, CompanyDescription=@CompanyDescription, CompanyEmailId=@CompanyEmailId," +
                    " CompanyContact=@CompanyContact, JobOpenings=@JobOpenings, JobProfile=@JobProfile, JobRequirements=@JobRequirements, " +
                    "DocAttachment3=@DocAttachment3, " +
                    "SscCriteria=@SscCriteria, HscCriteria=@HscCriteria, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE CompanyId=@CompanyId";

                }
                else if (company.DocAttachment1 == "" && company.DocAttachment2 == "" && company.DocAttachment3 != "" && company.DocAttachment4 != "")
                {
                    queryString = "UPDATE [dbo].[Company] SET CompanyName=@CompanyName, CompanyDescription=@CompanyDescription, CompanyEmailId=@CompanyEmailId," +
                    " CompanyContact=@CompanyContact, JobOpenings=@JobOpenings, JobProfile=@JobProfile, JobRequirements=@JobRequirements, " +
                    "DocAttachment3=@DocAttachment3, DocAttachment4=@DocAttachment4, " +
                    "SscCriteria=@SscCriteria, HscCriteria=@HscCriteria, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE CompanyId=@CompanyId";

                }
                else if (company.DocAttachment1 != "" && company.DocAttachment2 == "" && company.DocAttachment3 != "" && company.DocAttachment4 != "")
                {
                    queryString = "UPDATE [dbo].[Company] SET CompanyName=@CompanyName, CompanyDescription=@CompanyDescription, CompanyEmailId=@CompanyEmailId," +
                    " CompanyContact=@CompanyContact, JobOpenings=@JobOpenings, JobProfile=@JobProfile, JobRequirements=@JobRequirements, " +
                    "DocAttachment1=@DocAttachment1, DocAttachment3=@DocAttachment3, DocAttachment4=@DocAttachment4, " +
                    "SscCriteria=@SscCriteria, HscCriteria=@HscCriteria, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE CompanyId=@CompanyId";

                }
                else if (company.DocAttachment1 == "" && company.DocAttachment2 == "" && company.DocAttachment3 == "" && company.DocAttachment4 != "")
                {
                    queryString = "UPDATE [dbo].[Company] SET CompanyName=@CompanyName, CompanyDescription=@CompanyDescription, CompanyEmailId=@CompanyEmailId," +
                    " CompanyContact=@CompanyContact, JobOpenings=@JobOpenings, JobProfile=@JobProfile, JobRequirements=@JobRequirements, " +
                    "DocAttachment4=@DocAttachment4, " +
                    "SscCriteria=@SscCriteria, HscCriteria=@HscCriteria, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE CompanyId=@CompanyId";

                }
                else if (company.DocAttachment1 != "" && company.DocAttachment2 == "" && company.DocAttachment3 == "" && company.DocAttachment4 != "")
                {
                    queryString = "UPDATE [dbo].[Company] SET CompanyName=@CompanyName, CompanyDescription=@CompanyDescription, CompanyEmailId=@CompanyEmailId," +
                    " CompanyContact=@CompanyContact, JobOpenings=@JobOpenings, JobProfile=@JobProfile, JobRequirements=@JobRequirements, " +
                    "DocAttachment1=@DocAttachment1, DocAttachment4=@DocAttachment4, " +
                    "SscCriteria=@SscCriteria, HscCriteria=@HscCriteria, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE CompanyId=@CompanyId";

                }
                else if (company.DocAttachment1 != "" && company.DocAttachment2 != "" && company.DocAttachment3 == "" && company.DocAttachment4 != "")
                {
                    queryString = "UPDATE [dbo].[Company] SET CompanyName=@CompanyName, CompanyDescription=@CompanyDescription, CompanyEmailId=@CompanyEmailId," +
                    " CompanyContact=@CompanyContact, JobOpenings=@JobOpenings, JobProfile=@JobProfile, JobRequirements=@JobRequirements, " +
                    "DocAttachment1=@DocAttachment1, DocAttachment2=@DocAttachment2, DocAttachment4=@DocAttachment4, " +
                    "SscCriteria=@SscCriteria, HscCriteria=@HscCriteria, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE(), IsDeleted=0 WHERE CompanyId=@CompanyId";

                }

                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                cmd.Parameters.AddWithValue("@CompanyDescription", company.CompanyDescription);
                cmd.Parameters.AddWithValue("@CompanyEmailId", company.CompanyEmailId);
                cmd.Parameters.AddWithValue("@CompanyContact", company.CompanyContact);
                cmd.Parameters.AddWithValue("@JobOpenings", company.JobOpenings);
                cmd.Parameters.AddWithValue("@JobProfile", company.JobProfile);
                cmd.Parameters.AddWithValue("@JobRequirements", company.JobRequirements);
                cmd.Parameters.AddWithValue("@DocAttachment1", company.DocAttachment1);
                cmd.Parameters.AddWithValue("@DocAttachment2", company.DocAttachment2);
                cmd.Parameters.AddWithValue("@DocAttachment3", company.DocAttachment3);
                cmd.Parameters.AddWithValue("@DocAttachment4", company.DocAttachment4);
                cmd.Parameters.AddWithValue("@SscCriteria", company.SscCriteria);
                cmd.Parameters.AddWithValue("@HscCriteria", company.HscCriteria);
                cmd.Parameters.AddWithValue("@ModifiedBy", company.ModifiedBy);
                cmd.Parameters.AddWithValue("@CompanyId", company.CompanyId);

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


        public static int DeleteCompany(Company company)
        {
            int Id = 0;

            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "UPDATE [dbo].[Company] SET IsDeleted=1, ModifiedBy=@ModifiedBy, ModifiedOn=GETDATE() WHERE CompanyId=@CompanyId";
                var cmd = new SqlCommand(queryString, con);

                cmd.Parameters.AddWithValue("@ModifiedBy", company.ModifiedBy);
                cmd.Parameters.AddWithValue("@CompanyId", company.CompanyId);


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


        public static List<Company> GetAllCompanies()
        {
            var companies = new List<Company>();
            using (var con = new SqlConnection(connectionString))
            {
                const string query = "SELECT CompanyId, CompanyName, CompanyDescription, CompanyEmailId, CompanyContact, JobOpenings, JobProfile, JobRequirements, " +
                    "DocAttachment1, DocAttachment2, DocAttachment3, DocAttachment4, SscCriteria, HscCriteria FROM [dbo].[Company] WHERE IsDeleted=0";
                var cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        companies.Add(new Company
                        {
                            CompanyId = Convert.ToInt32(dataReader[0]),
                            CompanyName = Convert.ToString(dataReader[1]),
                            CompanyDescription = Convert.ToString(dataReader[2]),
                            CompanyEmailId = Convert.ToString(dataReader[3]),
                            CompanyContact = Convert.ToString(dataReader[4]),
                            JobOpenings = Convert.ToString(dataReader[5]),
                            JobProfile = Convert.ToString(dataReader[6]),
                            JobRequirements = Convert.ToString(dataReader[7]),
                            DocAttachment1 = Convert.ToString(dataReader[8]),
                            DocAttachment2 = Convert.ToString(dataReader[9]),
                            DocAttachment3 = Convert.ToString(dataReader[10]),
                            DocAttachment4 = Convert.ToString(dataReader[11]),
                            SscCriteria = Convert.ToString(dataReader[12]),
                            HscCriteria = Convert.ToString(dataReader[13])

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
            return companies;
        }


        public static int GetTotalCompanies()
        {
            int totalcompanies = 0;
            using (var con = new SqlConnection(connectionString))
            {
                var queryString = "SELECT COUNT(CompanyId) FROM [dbo].[Company] WHERE IsDeleted=0";
                var cmd = new SqlCommand(queryString, con);
                try
                {
                    con.Open();
                    totalcompanies = Convert.ToInt32(cmd.ExecuteScalar());
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
            return totalcompanies;

        }


        public static Company GetCompanyById(int CompanyId)
        {
            var company = new Company();
            using (var con = new SqlConnection(connectionString))
            {

                var queryString = "SELECT CompanyId, CompanyName, CompanyDescription, CompanyEmailId, CompanyContact, JobOpenings, JobProfile, JobRequirements, " +
                    "DocAttachment1, DocAttachment2, DocAttachment3, DocAttachment4, SscCriteria, HscCriteria FROM [dbo].[Company] WHERE CompanyId=@CompanyId AND IsDeleted=0";

                var cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                try
                {
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {

                        company.CompanyId = Convert.ToInt32(dataReader[0]);
                        company.CompanyName = Convert.ToString(dataReader[1]);
                        company.CompanyDescription = Convert.ToString(dataReader[2]);
                        company.CompanyEmailId = Convert.ToString(dataReader[3]);
                        company.CompanyContact = Convert.ToString(dataReader[4]);
                        company.JobOpenings = Convert.ToString(dataReader[5]);
                        company.JobProfile = Convert.ToString(dataReader[6]);
                        company.JobRequirements = Convert.ToString(dataReader[7]);
                        company.DocAttachment1 = Convert.ToString(dataReader[8]);
                        company.DocAttachment2 = Convert.ToString(dataReader[9]);
                        company.DocAttachment3 = Convert.ToString(dataReader[10]);
                        company.DocAttachment4 = Convert.ToString(dataReader[11]);
                        company.SscCriteria = Convert.ToString(dataReader[12]);
                        company.HscCriteria = Convert.ToString(dataReader[13]);
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
            return company;
        }



    }
}