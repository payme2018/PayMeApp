using Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL
{
   public class ProjectManager
    {
        public IEnumerable<Project> GetProjects()
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetProjectList", connection);
                cmd.Parameters.AddWithValue("@AccountID", HttpContext.Current.Session["AccountID"]);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Project> projectList = new List<Project>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Project project = new Project();
                        project.ID = Convert.ToInt32(reader["ID"].ToString());
                        project.ProjectName = reader["ProjectName"].ToString();
                        project.LocationInfo = reader["LocationInfo"].ToString();
                        project.Description = reader["Description"].ToString();
                        project.PrimaryContact = reader["PrimaryContact"].ToString();
                        project.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                        project.ClientName = reader["ClientName"].ToString();
                        project.ClientID = Convert.ToInt32(reader["fkClientId"]);

                        projectList.Add(project);
                    }
                }
                reader.Close();
                connection.Close();
                return projectList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }


        public IEnumerable<Project> GetProjectsByClient(int ClientID)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetProjectsByClient", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", ClientID);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Project> projectList = new List<Project>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Project project = new Project();
                        project.ID = Convert.ToInt32(reader["ID"].ToString());
                        project.ProjectName = reader["ProjectName"].ToString();                      
                        projectList.Add(project);
                    }
                }
                reader.Close();
                connection.Close();
                return projectList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }



        public int CreateProject(Project project)
        {
            int returnValue = 0;
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("CreateProject", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", project.ClientID);
                cmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                cmd.Parameters.AddWithValue("@PrimaryContact", project.PrimaryContact);
                cmd.Parameters.AddWithValue("@LocationInfo", project.LocationInfo);
                cmd.Parameters.AddWithValue("@Description", project.Description);
                cmd.Parameters.AddWithValue("@IsActive", project.IsActive);
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
    }
}
