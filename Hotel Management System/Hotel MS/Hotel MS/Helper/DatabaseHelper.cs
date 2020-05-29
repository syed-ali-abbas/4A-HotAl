using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Hotel_MS.Helper;
using System.Windows.Forms;


namespace Hotel_MS
 
{
    internal class DatabaseHelper
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        static MessageAlerts msg;


        public DatabaseHelper()
        {
            msg = new MessageAlerts();
            string connectionString = @"Data Source=DESKTOP-UA4FIBG\SQLEXPRESS;Initial Catalog=HotelManagementSystem;Integrated Security=True"; ;
            conn = new SqlConnection(connectionString);
        }

        public bool DataManipulationOperation(string query)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {

                    conn.Close();
                    return true;
                }
            }

            catch (Exception ex)
            {
                msg.UserDefinedErrorMessage(ex.Message);
            }
            conn.Close();
            return false;
        }

        public DataTable DataNavigationOperations(string query)
        {
            try
            {
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows != null)
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                msg.UserDefinedErrorMessage(ex.Message);
            }
            return null;
        }

        public int loginForm(String query) {

            int count = 0;
            conn.Open();
            cmd = new SqlCommand(query, conn);
            cmd.Connection = conn;
            cmd.CommandText = query;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                count = count + 1;
            }
            if (count == 1)
            {
                conn.Close();
                return 1;

            }
            else {
                conn.Close();
                return 0;
            }

        }





    }
}