using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ch09Cart.Models
{
    [DataObject(true)]
    public class DockDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        // retrieve customer with given ID
        public static List<Dock> GetDocks()
        {
            List<Dock> docks = new List<Dock>();
            Dock dck;
            SqlConnection connection = MarinaDB.GetConnection();
            string query = "SELECT ID , Name FROM Dock " +
                            "ORDER by Name";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dck = new Dock();
                    dck.Name = reader["Name"].ToString();
                    dck.DockID = (int)reader["ID"];
                    docks.Add(dck);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return docks;
        }
    }
}