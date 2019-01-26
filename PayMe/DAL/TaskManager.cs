using Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TaskManager
    {

        public IEnumerable<Task> GetTaskList()
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetTaskList", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Task> taskList = new List<Task>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Task task = new Task();
                        task.ID = Convert.ToInt32(reader["ID"].ToString());
                        task.ClientID = Convert.ToInt32(reader["ClientID"].ToString());
                        task.ClientName = reader["ClientName"].ToString();                       
                        task.ProjectId = Convert.ToInt32(reader["ProjectId"].ToString());
                        task.ProjectName = reader["ProjectName"].ToString();                 
                        task.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                        task.TaskName = reader["TaskName"].ToString();
                        taskList.Add(task);
                    }
                }
                reader.Close();
                connection.Close();
                return taskList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }


        public IEnumerable<Task> GetTaskListByID(int ID)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetTaskListByID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Task> taskList = new List<Task>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Task task = new Task();
                        task.ID = Convert.ToInt32(reader["ID"].ToString());
                        task.ClientID = Convert.ToInt32(reader["ClientID"].ToString());
                        task.ClientName = reader["ClientName"].ToString();
                        task.ProjectId = Convert.ToInt32(reader["ProjectId"].ToString());
                        task.ProjectName = reader["ProjectName"].ToString();
                        task.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                        task.TaskName = reader["TaskName"].ToString();
                        taskList.Add(task);
                    }
                }
                reader.Close();
                connection.Close();
                return taskList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }

        public int CreateTask(Task task)
        {
            int returnValue = 0;
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("CreateTask", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectID", task.ProjectId);
                cmd.Parameters.AddWithValue("@TaskName", task.TaskName);         
                cmd.Parameters.AddWithValue("@IsActive", task.IsActive);
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

        public int UpdateTask(Task task)
        {
            int returnValue = 0;
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("UpdateTask", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", task.ID);
                cmd.Parameters.AddWithValue("@ProjectID", task.ProjectId);
                cmd.Parameters.AddWithValue("@TaskName", task.TaskName);
                cmd.Parameters.AddWithValue("@IsActive", task.IsActive);
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


        public int DeleteTask(int id)
        {
            int returnValue = 0;
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("DeleteTask", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);              
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
