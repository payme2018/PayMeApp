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
   public class TimeTrackerManager
    {
        public IEnumerable<TimeTracker> GetTimeTracker()
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetTimeTracker", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<TimeTracker> timeTrackerList = new List<TimeTracker>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TimeTracker timeTracker = new TimeTracker();
                        timeTracker.ID = Convert.ToInt32(reader["ID"].ToString());
                        timeTracker.EmployeeID = Convert.ToInt32(reader["EmployeeID"].ToString());
                        timeTracker.ClientID = Convert.ToInt32(reader["ClientID"].ToString());
                        timeTracker.TaskID = Convert.ToInt32(reader["TaskID"].ToString());
                        timeTracker.CheckInDateTime = Convert.ToDateTime(reader["CheckInDateTime"].ToString());
                        if (reader["CheckOutDateTime"] != DBNull.Value)
                        {
                            timeTracker.CheckOutDateTime = Convert.ToDateTime(reader["CheckOutDateTime"].ToString());
                        }
                        timeTracker.ClientName = reader["ClientName"].ToString();
                        timeTracker.ProjectName = reader["ProjectName"].ToString();
                        timeTracker.TaskName = reader["TaskName"].ToString();
                        timeTracker.EmployeeName = reader["EmployeeName"].ToString();
                        timeTracker.TaskName = reader["TaskName"].ToString();
                        timeTracker.CreatedBy = reader["CreatedBy"].ToString();
                        timeTracker.TimeWorked = reader["TimeWorked"].ToString();
                        timeTrackerList.Add(timeTracker);
                    }
                }
                reader.Close();
                connection.Close();
                return timeTrackerList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }

        public int CreateTimeTracker(TimeTracker timeTracker)
        {
            int returnValue = 0;
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("CreateTimeTracker", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", timeTracker.EmployeeID);
                cmd.Parameters.AddWithValue("@ClientID", timeTracker.ClientID);
                cmd.Parameters.AddWithValue("@ProjectID", timeTracker.ProjectID);
                cmd.Parameters.AddWithValue("@TaskID", timeTracker.TaskID);
                cmd.Parameters.AddWithValue("@CheckInDateTime", timeTracker.CheckInDateTime);
                cmd.Parameters.AddWithValue("@CheckOutDateTime", timeTracker.CheckOutDateTime);
                cmd.Parameters.AddWithValue("@UserName", timeTracker.CreatedBy);
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

        public void UpdateTimeTrackerCheckoutDate(int id)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("UpdateTimeTrackerDate", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
           
        }
    }
}
