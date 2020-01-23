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
    public class AccountManager
    {
        #region : Get Account :
        public IEnumerable<Account> GetAccounts()
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetAccountList", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                List<Account> accountList = new List<Account>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Account account = new Account();
                        account.ID = Convert.ToInt32(reader["ID"].ToString());
                        account.Name = reader["Name"].ToString();
                        accountList.Add(account);
                    }
                }
                reader.Close();
                connection.Close();

                return accountList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }
        #endregion


        #region : Get Account Summary :
        /// <summary>
        /// Get account summary by accoutn detail 
        /// </summary>
        /// <param name="accountId">Company's account id</param>
        /// <returns></returns>
        public AccountSummary GetAccountSummary(int accountId)
        {
       
            try
            {

                SqlConnection connection = new SqlConnection(DalUtil.connectionString);
                SqlCommand cmd = new SqlCommand("GetAccountSummary", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountID", accountId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                AccountSummary asum = null;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        asum = new AccountSummary();
                        asum.ID = Convert.ToInt32(reader["AccountId"].ToString());
                        asum.ClientCount = Convert.ToInt32(reader["ClientCount"].ToString());
                        asum.EmployeeCount = Convert.ToInt32(reader["EmployeeCount"].ToString());
                        asum.ProjectCount = Convert.ToInt32(reader["ProjectCount"].ToString());
                        asum.TotalHourIncurrentMonth = Convert.ToInt32(reader["TotalHourIncurrentMonth"].ToString());

                    }
                }
                else
                {
                    throw new Exception("Account not fount accountid : " + accountId.ToString());
                }
                reader.Close();
                connection.Close();

                return asum;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }
        #endregion
  
    }
}
