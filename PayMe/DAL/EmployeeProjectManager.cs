using Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL
{
    public class EmployeeProjectManager
    {

        public IEnumerable<EmployeeProject> GetEmployeeProject(int clientNo, int ProjectNo, bool IsActive)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetEmployeeProjectist", connection);
                cmd.Parameters.AddWithValue("@ProjectID", ProjectNo);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);                
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<EmployeeProject> empProjectList = new List<EmployeeProject>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EmployeeProject empProject = new EmployeeProject();
                        empProject.Id = Convert.ToInt32(reader["Id"].ToString());
                        empProject.EmpID = Convert.ToInt32(reader["EmpID"].ToString());
                        empProject.ProjectId = Convert.ToInt32(reader["ProjectID"].ToString());
                        empProject.TaskID = Convert.ToInt32(reader["TaskID"].ToString());
                        empProject.EmployeeName = reader["EmployeeName"].ToString();
                        empProject.ProjectName = reader["ProjectName"].ToString();
                        empProject.TaskName = reader["TaskName"].ToString();
                        empProject.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        empProject.EndDate = Convert.ToDateTime(reader["EndDate"]);
                        empProject.RegularRate = Convert.ToDecimal(reader["RegularRate"]);
                        empProject.OTRate = Convert.ToDecimal(reader["OTRate"]);
                        empProjectList.Add(empProject);
                    }
                }
                reader.Close();
                connection.Close();
                return empProjectList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }


        public int AddEmployeeToProject(EmployeeProject empProject)
        {
            int returnValue = 0;
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("InsertEmployeeProject", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", empProject.EmpID);
                cmd.Parameters.AddWithValue("@ProjectID", empProject.ProjectId);
                cmd.Parameters.AddWithValue("@TaskID", empProject.TaskID);
                cmd.Parameters.AddWithValue("@StartDate", empProject.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", empProject.EndDate);
                cmd.Parameters.AddWithValue("@RegularRate", empProject.RegularRate);
                cmd.Parameters.AddWithValue("@OTRate", empProject.OTRate);
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

    }
}
