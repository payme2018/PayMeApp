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
    public class ExpenseManager
    {
        public IEnumerable<ExpenseSummary> GetExpenseSummaries(int userId)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetExpenseSummaryByUserID", connection);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ExpenseSummary> ExpenseSummaryList = new List<ExpenseSummary>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ExpenseSummary expenseSummary = new ExpenseSummary();
                        expenseSummary.ID = Convert.ToInt32(reader["ID"].ToString());
                        expenseSummary.Name = reader["Name"].ToString();
                        expenseSummary.ExpenseStatusID = Convert.ToInt32(reader["ExpenseStatusID"]);
                        expenseSummary.ExpenseStatusName = reader["ExpenseStatusName"].ToString();
                        expenseSummary.TotalAmount = Convert.ToDecimal(reader["TotalAmount"] == DBNull.Value ? 0 : reader["TotalAmount"]);
                        expenseSummary.ApprovedAmount = Convert.ToDecimal(reader["ApprovedAmount"] == DBNull.Value ? 0 : reader["ApprovedAmount"]);
                        expenseSummary.ProjectName = reader["ProjectName"].ToString();
                        expenseSummary.EmpID = Convert.ToInt32(reader["EmpID"]);
                        expenseSummary.ProjectID = Convert.ToInt32(reader["ProjectID"]);
                        expenseSummary.ProjectName = reader["ProjectName"].ToString();
                        expenseSummary.FromDate = Convert.ToDateTime( reader["FromDate"].ToString());
                        expenseSummary.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                        expenseSummary.Description = reader["Description"].ToString();
                        ExpenseSummaryList.Add(expenseSummary);


                    }
                }
                reader.Close();
                connection.Close();
                return ExpenseSummaryList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }

        public IEnumerable<ExpenseDetail> GetExpenseDetailBySummary(int id)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetExpenseDetailBySummary", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ExpenseSummaryID", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ExpenseDetail> ExpenseDetailList = new List<ExpenseDetail>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ExpenseDetail expenseDetail = new ExpenseDetail();
                        expenseDetail.ID = Convert.ToInt32(reader["ID"].ToString());
                        expenseDetail.CategoryID = Convert.ToInt32(reader["CategoryID"].ToString());
                        expenseDetail.CategoryName = reader["CategoryName"].ToString();
                        expenseDetail.ExpenseSummaryID = Convert.ToInt32(reader["ExpenseSummaryID"].ToString());
                        expenseDetail.CurrencyBillNo = reader["CurrencyBillNo"].ToString();
                        expenseDetail.Amount = Convert.ToDecimal(reader["Amount"] == DBNull.Value ? 0 : reader["Amount"]);
                        expenseDetail.BillDate = Convert.ToDateTime(reader["BillDate"].ToString());
                        expenseDetail.Location = reader["Location"].ToString();
                        expenseDetail.HasAttachment = Convert.ToBoolean(reader["HasAttachment"]);
                        expenseDetail.Notes = reader["Notes"].ToString();
                        ExpenseDetailList.Add(expenseDetail);

                    }
                }
                reader.Close();
                connection.Close();
                return ExpenseDetailList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }

        public int CreateExpense(ExpenseSummary expenseSummary)
        {
            int returnValue = 0;
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("CreateExpenseSummary", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectID", expenseSummary.ProjectID);
                cmd.Parameters.AddWithValue("@ExpenseName", expenseSummary.Name);
                cmd.Parameters.AddWithValue("@FromDate", expenseSummary.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", expenseSummary.ToDate);
                cmd.Parameters.AddWithValue("@Description", expenseSummary.Description);
                cmd.Parameters.AddWithValue("@EmployeeID", expenseSummary.EmpID);
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
        public IEnumerable<ExpenseCategory> GetExpenseCategory()
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetExpenseCategoryList", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ExpenseCategory> expenseCategoryList = new List<ExpenseCategory>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ExpenseCategory expenseCategory = new ExpenseCategory();
                        expenseCategory.ID = Convert.ToInt32(reader["ID"].ToString());
                        expenseCategory.Name = reader["Name"].ToString();
                        expenseCategoryList.Add(expenseCategory);
                    }
                }
                reader.Close();
                connection.Close();
                return expenseCategoryList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }

        public string GetExpenseSummaryName(int id)
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetExpenseSummaryByID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.AddWithValue("@ID", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string name = "";
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                       
                        name = reader["Name"].ToString();

                    }
                }
                reader.Close();
                connection.Close();
                return name;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }

        public int CreateExpenseDetail(ExpenseDetail expenseDetail)
        {
            int returnValue = 0;
            try
            {

                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("CreateExpenseDetail", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", expenseDetail.CategoryID);
                cmd.Parameters.AddWithValue("@ExpenseSummaryID", expenseDetail.ExpenseSummaryID);
                cmd.Parameters.AddWithValue("@CurrencyBillNo", expenseDetail.CurrencyBillNo);
                cmd.Parameters.AddWithValue("@Amount", expenseDetail.Amount);
                cmd.Parameters.AddWithValue("@BillDate", expenseDetail.BillDate);
                cmd.Parameters.AddWithValue("@Location", expenseDetail.Location);
                cmd.Parameters.AddWithValue("@HasAttachment", expenseDetail.HasAttachment);
                cmd.Parameters.AddWithValue("@Notes", expenseDetail.Notes);
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
