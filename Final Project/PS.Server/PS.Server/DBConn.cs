using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Server
{
    internal class DBConn
    {
        private MySqlConnection mySqlConnection = new MySqlConnection("server= 127.0.0.1; user = root; database=payroll; password=");
        public void openConnection()
        {
            try
            {
                if (mySqlConnection.State == System.Data.ConnectionState.Closed)
            {
                mySqlConnection.Open();
            }
            }
            catch
            {
            }
        }
        public void closeConnection()
        {
            try
            {
                if (mySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
            catch
            {
            }
        }
        public MySqlConnection getConnection()
        {
            return mySqlConnection;
        }
    }
}
