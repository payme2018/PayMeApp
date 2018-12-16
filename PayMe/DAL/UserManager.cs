using Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<Registration> GetUsers()
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetUserList", connection);
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

        public string CreateUser(string firstName, string lastName, string email, DateTime? dateOfJoining, DateTime? dob, string designation, string emplyeeCode,
            int gender, string userName, string password, int roleID, string createdBy)
        {
            string returnValue = "";
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("CreateUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@DateOfJoining", dateOfJoining);
                cmd.Parameters.AddWithValue("@DOB", dob);
                cmd.Parameters.AddWithValue("@Designation", designation);
                cmd.Parameters.AddWithValue("@EmployeeCode", emplyeeCode);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@RoleID", roleID);
                cmd.Parameters.AddWithValue("@CreatedBy", createdBy);
                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                cmd.ExecuteNonQuery();
                int outputId = Convert.ToInt32(cmd.Parameters["@output"].Value);

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
