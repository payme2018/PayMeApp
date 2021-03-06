﻿using Business;
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
                SqlConnection connection = new SqlConnection(DalUtil.connectionString);
                SqlCommand cmd = new SqlCommand("GetProjectList", connection);
                cmd.Parameters.AddWithValue("@AccountID", HttpContext.Current.Session["AccountID"]);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Project> projectList = new List<Project>();
             
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
                        project.ManagerName = reader["ManagerName"].ToString();
                        project.ManagerID = Convert.ToInt32(reader["ManagerID"] == null?0: reader["ManagerID"]);

                    projectList.Add(project);
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

        public Project GetProjectByID(int projectId)
        {
            try
            {
               SqlConnection connection = new SqlConnection(DalUtil.connectionString);
                SqlCommand cmd = new SqlCommand("GetProjectByID", connection);
                cmd.Parameters.AddWithValue("@Id", projectId);
                cmd.Parameters.AddWithValue("@AccountID", HttpContext.Current.Session["AccountID"]);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Project project = new Project();
               
                    while (reader.Read())
                    {
                       
                        project.ID = Convert.ToInt32(reader["ID"].ToString());
                        project.ProjectName = reader["ProjectName"].ToString();
                        project.LocationInfo = reader["LocationInfo"].ToString();
                        project.Description = reader["Description"].ToString();
                        project.PrimaryContact = reader["PrimaryContact"].ToString();
                        project.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                        //project.ClientName = reader["ClientName"].ToString();
                        project.ClientID = Convert.ToInt32(reader["fkClientId"]);
                        project.ManagerName = reader["ManagerName"].ToString();
                        project.ManagerID = Convert.ToInt32(reader["ManagerID"]);

                    }
                
                connection.Close();
                return project;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }
        public IEnumerable<Project> GetProjectListByClient(int ClientId)
        {
            try
            {
                SqlConnection connection = new SqlConnection(DalUtil.connectionString);
                SqlCommand cmd = new SqlCommand("GetProjectListByClient", connection);
                cmd.Parameters.AddWithValue("@ClientID", ClientId);
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
       



        public int CreateProject(Project project)
        {
            int returnValue = 0;
            try
            {
                SqlConnection connection = new SqlConnection(DalUtil.connectionString);
                SqlCommand cmd = new SqlCommand("CreateProject", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", project.ClientID);
                cmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                cmd.Parameters.AddWithValue("@PrimaryContact", project.PrimaryContact);
                cmd.Parameters.AddWithValue("@LocationInfo", project.LocationInfo);
                cmd.Parameters.AddWithValue("@Description", project.Description);
                cmd.Parameters.AddWithValue("@IsActive", project.IsActive);
                cmd.Parameters.AddWithValue("@AccountID", HttpContext.Current.Session["AccountID"]);
                cmd.Parameters.AddWithValue("@ManagerID", project.ManagerID);
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

        public int UpdateProject(Project project)
        {
            int returnValue = 0;
            try
            {
                SqlConnection connection = new SqlConnection(DalUtil.connectionString);
                SqlCommand cmd = new SqlCommand("UpdateProject", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", project.ID);
                cmd.Parameters.AddWithValue("@ClientID", project.ClientID);
                cmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                cmd.Parameters.AddWithValue("@PrimaryContact", project.PrimaryContact);
                cmd.Parameters.AddWithValue("@LocationInfo", project.LocationInfo);
                cmd.Parameters.AddWithValue("@Description", project.Description);
                cmd.Parameters.AddWithValue("@IsActive", project.IsActive);
                cmd.Parameters.AddWithValue("@ManagerID", project.ManagerID);
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
     
     public IEnumerable<Project> GetProjectsByClient( int clientID)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetProjectsByClient", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountID", HttpContext.Current.Session["AccountID"]);
                cmd.Parameters.AddWithValue("@ClientID", clientID);
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



    

    }
}
