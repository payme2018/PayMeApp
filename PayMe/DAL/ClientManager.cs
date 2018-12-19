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
    public class ClientManager
    {
        public IEnumerable<Client> GetClients()
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("GetClientList", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                List<Client> clientList = new List<Client>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Client client = new Client();
                        client.ID = Convert.ToInt32(reader["ID"].ToString());
                        client.LocationInfo = reader["LocationInfo"].ToString();
                        client.Description = reader["Description"].ToString();
                        client.PrimaryContact = reader["PrimaryContact"].ToString();
                        client.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                        client.ClientName   = reader["ClientName"].ToString();
                        client.ClientCode = reader["ClientCode"].ToString();
                        clientList.Add(client);
                    }
                }
                reader.Close();
                connection.Close();

                return clientList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }

        public string CreateClient(
            string ClientName, string ClientCode, string PrimaryContact,
             string Description, string LocationInfo, bool IsActive
            )
        {
            string returnValue = "";
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("CreateClient", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientCode", ClientCode);
                cmd.Parameters.AddWithValue("@ClientName", ClientName);
                cmd.Parameters.AddWithValue("@PrimaryContact", PrimaryContact);
                cmd.Parameters.AddWithValue("@LocationInfo", LocationInfo);
                cmd.Parameters.AddWithValue("@Designation", Description);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                cmd.ExecuteNonQuery();
                int outputId = Convert.ToInt32(cmd.Parameters["@output"].Value);

                connection.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
            return returnValue;
        }

        public string CreateClient(
          Client client
          )
        {
            string returnValue = "";
            try
            {
                var connectionString = ConfigurationManager.AppSettings["PayMe-Connectionstring"];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("CreateClient", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientCode", client.ClientCode);
                cmd.Parameters.AddWithValue("@ClientName", client.ClientName);
                cmd.Parameters.AddWithValue("@PrimaryContact", client.PrimaryContact);
                cmd.Parameters.AddWithValue("@LocationInfo", client.LocationInfo);
                cmd.Parameters.AddWithValue("@Description", client.Description);
                cmd.Parameters.AddWithValue("@IsActive", client.IsActive);
                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                cmd.ExecuteNonQuery();
                int outputId = Convert.ToInt32(cmd.Parameters["@output"].Value);

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
