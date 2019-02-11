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
    public class TimesheetManager
    {
        public IEnumerable<Timesheet> GetTimesheetEntries(int userId)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetTimesheetByUserID", connection);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Timesheet> timesheetList = new List<Timesheet>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Timesheet timesheet = new Timesheet();
                        timesheet.ID = Convert.ToInt32(reader["ID"].ToString());
                        timesheet.fkEmpId = Convert.ToInt32(reader["fkEmpId"]);
                        timesheet.fkProjectID = Convert.ToInt32(reader["fkProjectID"]);
                        timesheet.fkClientId = Convert.ToInt32(reader["fkClientId"]);
                        timesheet.fkTaskID = Convert.ToInt32(reader["fkTaskID"]);
                        timesheet.CheckInDate = Convert.ToDateTime(reader["CheckInDate"].ToString());
                        timesheet.CheckInDateTime = Convert.ToDateTime(reader["CheckInDateTime"].ToString());
                        timesheet.CheckOutDatetime = Convert.ToDateTime(reader["CheckOutDatetime"].ToString());
                        timesheet.Description = reader["Description"].ToString();
                        timesheet.ProjectName = reader["ProjectName"].ToString();
                        
                        timesheet.ClientName = reader["ClientName"].ToString();
                        timesheetList.Add(timesheet);


                    }
                }
                reader.Close();
                connection.Close();
                return timesheetList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }



        public IEnumerable<Timesheet> TimesheetDetailReport(string FromDate, string ToDate)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetTimesheetDetailReportByDate", connection);
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Timesheet> timesheetList = new List<Timesheet>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Timesheet timesheet = new Timesheet();
                        timesheet.ID = Convert.ToInt32(reader["ID"].ToString());
                        timesheet.fkEmpId = Convert.ToInt32(reader["fkEmpId"]);
                        timesheet.fkProjectID = Convert.ToInt32(reader["fkProjectID"]);
                        timesheet.fkClientId = Convert.ToInt32(reader["fkClientId"]);
                        timesheet.fkTaskID = Convert.ToInt32(reader["fkTaskID"]);
                        timesheet.CheckInDate = Convert.ToDateTime(reader["CheckInDate"].ToString());
                        timesheet.CheckInDateTime = Convert.ToDateTime(reader["CheckInDateTime"].ToString());
                        timesheet.CheckOutDatetime = Convert.ToDateTime(reader["CheckOutDatetime"].ToString());
                        timesheet.Description = reader["Description"].ToString();
                        timesheet.ProjectName = reader["ProjectName"].ToString();
                        timesheet.TaskName = reader["TaskName"].ToString();
                        timesheet.ClientName = reader["ClientName"].ToString();
                        timesheet.EmployeeName = reader["EmployeeName"].ToString();
                        timesheetList.Add(timesheet);


                    }
                }
                reader.Close();
                connection.Close();
                return timesheetList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }

        public int CreateTimesheet(Timesheet timesheet)
        {
            int returnValue = 0;
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("CreateTimesheet", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", timesheet.fkEmpId);
                cmd.Parameters.AddWithValue("@UserName", timesheet.CreatedBy);
                cmd.Parameters.AddWithValue("@ClientId", timesheet.fkClientId);
                cmd.Parameters.AddWithValue("@ProjectId", timesheet.fkProjectID);
                cmd.Parameters.AddWithValue("@TaskId", timesheet.fkTaskID);
                cmd.Parameters.AddWithValue("@CheckInDate", timesheet.CheckInDate);
                cmd.Parameters.AddWithValue("@CheckInDateTime", timesheet.CheckInDateTime);
                cmd.Parameters.AddWithValue("@CheckOutDateTime", timesheet.CheckOutDatetime);
                cmd.Parameters.AddWithValue("@Description", timesheet.Description);
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
