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
    }
}
