using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DalUtil
    {
        public static string connectionString { get { return ConfigurationManager.AppSettings["PayMe-Connectionstring"]; } }
        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {

            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
    }
}
