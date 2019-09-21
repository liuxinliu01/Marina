using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ch09Cart.Models
{
    public class MarinaDB
    {
        internal static SqlConnection GetConnection()
        {
            string connectingString = @"Data Source=localhost\sqlexpress;Initial Catalog=Marina;Integrated Security=True";
            return new SqlConnection(connectingString);
        }
    }
}