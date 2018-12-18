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

    }
}
