﻿using Business;
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
   public class ProjectManager
    {
        public IEnumerable<Project> GetProjects()
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetProjectList", connection);
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

        public string CreateProject(
          Project project
          )
        {
            string returnValue = "";
            //try
            //{
            //    var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
            //    SqlConnection connection = new SqlConnection(connectionString);
            //    SqlCommand cmd = new SqlCommand("CreateClient", connection);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@ClientCode", client.ClientCode);
            //    cmd.Parameters.AddWithValue("@ClientName", client.ClientName);
            //    cmd.Parameters.AddWithValue("@PrimaryContact", client.PrimaryContact);
            //    cmd.Parameters.AddWithValue("@LocationInfo", client.LocationInfo);
            //    cmd.Parameters.AddWithValue("@Description", client.Description);
            //    cmd.Parameters.AddWithValue("@IsActive", client.IsActive);
            //    cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

            //    connection.Open();
            //    cmd.ExecuteNonQuery();
            //    int outputId = Convert.ToInt32(cmd.Parameters["@output"].Value);

            //    connection.Close();
            //}
            //catch (Exception ex)
            //{
            //    throw new ApplicationException(ex.Message.ToString());
            //}
            return returnValue;
        }
    }
}
