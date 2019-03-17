using Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL
{
   public class UserManager
    {
        public Registration ValidateUser(string username, string password)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("ValidateUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Registration registration = new Registration();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        registration.RoleID = Convert.ToInt32( reader["fkRoleId"].ToString());
                        registration.EmployeeID = Convert.ToInt32(reader["ID"].ToString());
                        registration.Username = reader["UserName"].ToString();
                        registration.FirstName = reader["FirstName"].ToString();
                        registration.LastName = reader["LastName"].ToString();
                    }
                }
                reader.Close();
                connection.Close();

                return registration;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }


        public IEnumerable<Employee> GetUserForDD()
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetUserForDD", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                List<Employee> registrationList = new List<Employee>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee registration = new Employee();
                        
                        registration.ID = Convert.ToInt32(reader["ID"].ToString());
                        registration.EmployeeName = reader["EmployeeName"].ToString();
                       
                        registrationList.Add(registration);
                    }
                }
                reader.Close();
                connection.Close();

                return registrationList;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }

        public IEnumerable<Registration> GetUsers()
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetUserList", connection);
                cmd.Parameters.AddWithValue("@AccountID", HttpContext.Current.Session["AccountID"]);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
               

                List<Registration> registrationList = new List<Registration>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Registration registration = new Registration();
                        registration.RoleID = Convert.ToInt32(reader["fkRoleId"].ToString());
                        registration.EmployeeID = Convert.ToInt32(reader["ID"].ToString());
                        registration.Username = reader["UserName"].ToString();
                        registration.FirstName = reader["FirstName"].ToString();
                        registration.LastName = reader["LastName"].ToString();
                        registration.RoleName = reader["RoleName"].ToString();
                        registration.GenderName = reader["Gender"].ToString();
                        registration.EmailID = reader["EmailID"].ToString();
                        registrationList.Add(registration);
                    }
                }
                reader.Close();
                connection.Close();

                return registrationList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }

        public Registration GetEmployeeByID(int id)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetEmployeeByID", connection);
                cmd.Parameters.AddWithValue("@EmployeeID", id);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                Registration registration = new Registration();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                     
                        registration.RoleID = Convert.ToInt32(reader["fkRoleId"].ToString());
                        registration.EmployeeID = Convert.ToInt32(reader["ID"].ToString());
                        registration.FirstName = reader["FirstName"].ToString();
                        registration.LastName = reader["LastName"].ToString();
                        registration.Gender = Convert.ToInt32(reader["Gender"].ToString());
                        registration.EmailID = reader["EmailID"].ToString();
                        registration.MobileNo = reader["MobileNo"].ToString();
                        registration.Birthdate = Convert.ToDateTime(reader["DOB"].ToString());
                        registration.DateofJoining = Convert.ToDateTime(reader["JoiningDate"].ToString());
                        registration.EmployeeCode = reader["EmployeeCode"].ToString(); 
                        registration.Designation = reader["Designation"].ToString();
                        if (reader["fkDepartmentID"] != DBNull.Value)
                            registration.fkDepartmentID = Convert.ToInt32(reader["fkDepartmentID"].ToString());
                        if (reader["fkManagerId"] != DBNull.Value)
                            registration.fkManagerId = Convert.ToInt32(reader["fkManagerId"].ToString());
                        if (reader["fkEmploymentLocationID"] != DBNull.Value)
                            registration.fkEmploymentLocationID = Convert.ToInt32(reader["fkEmploymentLocationID"].ToString());
                        registration.PassportNo = reader["PassportNo"].ToString();
                        registration.PassportIssuedBy = reader["PassportIssuedBy"].ToString();
                        if (reader["PassportIssuedOn"] != DBNull.Value)
                            registration.PassportIssuedOn = Convert.ToDateTime(reader["PassportIssuedOn"].ToString());
                        if (reader["PassportExpireOn"] != DBNull.Value)
                            registration.PassportExpireOn = Convert.ToDateTime(reader["PassportExpireOn"].ToString());
                        registration.VISANo = reader["VISANo"].ToString();
                        registration.VISAIssuedBy = reader["VISAIssuedBy"].ToString();
                        if (reader["VISAIssuedOn"] != DBNull.Value)
                            registration.VISAIssuedOn = Convert.ToDateTime(reader["VISAIssuedOn"].ToString());
                        if (reader["VISAExpireOn"] != DBNull.Value)
                            registration.VISAExpireOn = Convert.ToDateTime(reader["VISAExpireOn"].ToString());

                        registration.LabourCardNo= reader["LabourCardNo"].ToString();
                        registration.LabourCardIssuedBy = reader["LabourCardIssuedBy"].ToString();
                        if (reader["LabourCardIssuedOn"] != DBNull.Value)
                            registration.LabourCardIssuedOn = Convert.ToDateTime(reader["LabourCardIssuedOn"].ToString());
                        if (reader["LabourCardExpireOn"] != DBNull.Value)
                            registration.LabourCardExpireOn = Convert.ToDateTime(reader["LabourCardExpireOn"].ToString());

                    }
                }
                reader.Close();
                connection.Close();

                return registration;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }



        public int CreateUser(Registration registration)
        {
            int returnValue = 0;
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("CreateUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", registration.FirstName);
                cmd.Parameters.AddWithValue("@LastName", registration.LastName);
                cmd.Parameters.AddWithValue("@Email", registration.EmailID);
                cmd.Parameters.AddWithValue("@DateOfJoining", registration.DateofJoining);
                cmd.Parameters.AddWithValue("@DOB", registration.Birthdate);
                cmd.Parameters.AddWithValue("@MobileNo", registration.MobileNo);
                cmd.Parameters.AddWithValue("@Designation", registration.Designation);
                cmd.Parameters.AddWithValue("@EmployeeCode", registration.EmployeeCode);
                cmd.Parameters.AddWithValue("@Gender", registration.Gender);
                cmd.Parameters.AddWithValue("@UserName", registration.Username);
                cmd.Parameters.AddWithValue("@Password", registration.Password);
                cmd.Parameters.AddWithValue("@RoleID", registration.RoleID);
                cmd.Parameters.AddWithValue("@CreatedBy", registration.Username);
                cmd.Parameters.AddWithValue("@fkDepartmentID", registration.fkDepartmentID);
                cmd.Parameters.AddWithValue("@fkManagerId", registration.fkManagerId);
                cmd.Parameters.AddWithValue("@fkEmploymentLocationID", registration.fkEmploymentLocationID);
                //
                cmd.Parameters.AddWithValue("@PassportNo", registration.PassportNo);
                cmd.Parameters.AddWithValue("@PassportIssuedBy", registration.PassportIssuedBy);
                cmd.Parameters.AddWithValue("@PassportIssuedOn", registration.PassportExpireOn);
                cmd.Parameters.AddWithValue("@PassportExpireOn", registration.PassportExpireOn);
                cmd.Parameters.AddWithValue("@VISANo", registration.VISANo);
                cmd.Parameters.AddWithValue("@VISAIssuedBy", registration.VISAIssuedBy);
                cmd.Parameters.AddWithValue("@VISAIssuedOn", registration.VISAIssuedOn);
                cmd.Parameters.AddWithValue("@VISAExpireOn", registration.VISAExpireOn);

                cmd.Parameters.AddWithValue("@LabourCardNo", registration.LabourCardNo);
                cmd.Parameters.AddWithValue("@LabourCardIssuedBy", registration.LabourCardIssuedBy);
                cmd.Parameters.AddWithValue("@LabourCardIssuedOn", registration.LabourCardIssuedOn);
                cmd.Parameters.AddWithValue("@LabourCardExpireOn", registration.LabourCardExpireOn);
                cmd.Parameters.AddWithValue("@AccountID", HttpContext.Current.Session["AccountID"]);
                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                cmd.ExecuteNonQuery();
                returnValue = Convert.ToInt32(cmd.Parameters["@output"].Value);

                connection.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
            return returnValue;
        }
        public int UpdateUser(Registration registration)
        {
            int returnValue = 0;
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("UpdateUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", registration.EmployeeID);
                cmd.Parameters.AddWithValue("@FirstName", registration.FirstName);
                cmd.Parameters.AddWithValue("@LastName", registration.LastName);
                cmd.Parameters.AddWithValue("@Email", registration.EmailID);
                cmd.Parameters.AddWithValue("@DateOfJoining", registration.DateofJoining);
                cmd.Parameters.AddWithValue("@DOB", registration.Birthdate);
                cmd.Parameters.AddWithValue("@MobileNo", registration.MobileNo);
                cmd.Parameters.AddWithValue("@Designation", registration.Designation);
                cmd.Parameters.AddWithValue("@EmployeeCode", registration.EmployeeCode);
                cmd.Parameters.AddWithValue("@Gender", registration.Gender);
                cmd.Parameters.AddWithValue("@RoleID", registration.RoleID);
                cmd.Parameters.AddWithValue("@fkDepartmentID", registration.fkDepartmentID);
                cmd.Parameters.AddWithValue("@fkManagerId", registration.fkManagerId);
                cmd.Parameters.AddWithValue("@fkEmploymentLocationID", registration.fkEmploymentLocationID);

                //
                cmd.Parameters.AddWithValue("@PassportNo", registration.PassportNo);
                cmd.Parameters.AddWithValue("@PassportIssuedBy", registration.PassportIssuedBy);
                cmd.Parameters.AddWithValue("@PassportIssuedOn", registration.PassportExpireOn);
                cmd.Parameters.AddWithValue("@PassportExpireOn", registration.PassportExpireOn);
                cmd.Parameters.AddWithValue("@VISANo", registration.VISANo);
                cmd.Parameters.AddWithValue("@VISAIssuedBy", registration.VISAIssuedBy);
                cmd.Parameters.AddWithValue("@VISAIssuedOn", registration.VISAIssuedOn);
                cmd.Parameters.AddWithValue("@VISAExpireOn", registration.VISAExpireOn);

                cmd.Parameters.AddWithValue("@LabourCardNo", registration.LabourCardNo);
                cmd.Parameters.AddWithValue("@LabourCardIssuedBy", registration.LabourCardIssuedBy);
                cmd.Parameters.AddWithValue("@LabourCardIssuedOn", registration.LabourCardIssuedOn);
                cmd.Parameters.AddWithValue("@LabourCardExpireOn", registration.LabourCardExpireOn);
                cmd.Parameters.AddWithValue("@AccountID", HttpContext.Current.Session["AccountID"]);
                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                cmd.ExecuteNonQuery();
                returnValue = Convert.ToInt32(cmd.Parameters["@output"].Value);

                connection.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
            return returnValue;
        }
        //public IEnumerable<Dropdown> GetMobileList()
        //{
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MYConnector"].ToString());
        //    string query = "SELECT [ID],[RoleName] AS Name FROM [dbo].[Role]";
        //    var result = con.Query<Dropdown>(query);
        //    return result;
        //}
        public IEnumerable<Role>GetRoleList()
        {
            List<Role> items = new List<Role>();
            string constr = ConfigurationManager.ConnectionStrings["PayMe-Connectionstring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT [ID],[RoleName] AS Name FROM [dbo].[Role]";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new Role
                            {
                                RoleID = Convert.ToInt32(sdr["ID"].ToString()),
                                RoleName = sdr["Name"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return items;
        }

        public IEnumerable<ManagerDropdown> GetManagerList()
        {
            List<ManagerDropdown> items = new List<ManagerDropdown>();
            string constr = ConfigurationManager.ConnectionStrings["PayMe-Connectionstring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetManagersList", con))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new ManagerDropdown
                            {
                                fkManagerId = Convert.ToInt32(sdr["ID"].ToString()),
                                Name = sdr["Name"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return items;
        }

        public IEnumerable<LocationDropdown> GetLocationList()
        {
            List<LocationDropdown> items = new List<LocationDropdown>();
            string constr = ConfigurationManager.ConnectionStrings["PayMe-Connectionstring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT [ID],[Location] AS Name FROM [dbo].[Location]";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new LocationDropdown
                            {
                               fkEmploymentLocationID = Convert.ToInt32(sdr["ID"].ToString()),
                                Name = sdr["Name"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return items;
        }
        public IEnumerable<DepartmentDropdown> GetDepartmentList()
        {
            List<DepartmentDropdown> items = new List<DepartmentDropdown>();
            string constr = ConfigurationManager.ConnectionStrings["PayMe-Connectionstring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT  [DeptId],[DepartmentName] AS Name FROM [dbo].[Department]";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new DepartmentDropdown
                            {
                                fkDepartmentID = Convert.ToInt32(sdr["DeptId"].ToString()),
                                Name = sdr["Name"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return items;
        }

        public IEnumerable<EmployeePayRate> GetPayrateByEmployeeID(int id)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetPayRateByEmployeeID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<EmployeePayRate> EmployeePayRateList = new List<EmployeePayRate>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EmployeePayRate employeePayRate = new EmployeePayRate();
                        employeePayRate.ID = Convert.ToInt32(reader["ID"].ToString());
                        employeePayRate.EmployeeID = Convert.ToInt32(reader["EmployeeID"].ToString());
                        employeePayRate.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                        employeePayRate.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                        employeePayRate.PayRateTypeID = Convert.ToInt32(reader["PayRateTypeID"].ToString());
                        employeePayRate.RegularRate = Convert.ToDecimal(reader["RegularRate"] == DBNull.Value ? 0 : reader["RegularRate"]);
                        employeePayRate.OTRate = Convert.ToDecimal(reader["OTRate"] == DBNull.Value ? 0 : reader["OTRate"]);
                        employeePayRate.Name = reader["Name"].ToString();
                        EmployeePayRateList.Add(employeePayRate);

                    }
                }
                reader.Close();
                connection.Close();
                return EmployeePayRateList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }

        public int AddPayEmployeePayRate(EmployeePayRate employeePayRate)
        {
            int returnValue = 0;
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("AddEmployeePayRate", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", employeePayRate.ID);
                cmd.Parameters.AddWithValue("@StartDate", employeePayRate.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", employeePayRate.EndDate);
                cmd.Parameters.AddWithValue("@PayRateID", employeePayRate.PayRateTypeID);
                cmd.Parameters.AddWithValue("@RegularRate", employeePayRate.RegularRate);
                cmd.Parameters.AddWithValue("@OTRate", employeePayRate.OTRate);               
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
            return returnValue;
        }

    }
}
