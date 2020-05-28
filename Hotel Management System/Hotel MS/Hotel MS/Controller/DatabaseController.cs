using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_MS.Controller
{
    class DatabaseController
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        
  
        public DatabaseController()
        {
            
            string connectionString = @"Data Source=DESKTOP-UA4FIBG\SQLEXPRESS;Initial Catalog=HotelManagementSystem;Integrated Security=True"; 
            conn = new SqlConnection(connectionString);
        }

        public bool DataManipulationOperation(string query)
        {
            
                conn.Open();
                cmd = new SqlCommand(query, conn);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    conn.Close();
                    return true;
                }
            

           
            conn.Close();
            return false;
        }

        public DataTable DataNavigationOperations(string query)
        {
            
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows != null)
                {
                    return dt;
                }
            
           
            return null;
        }

    }
}
