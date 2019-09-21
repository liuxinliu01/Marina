using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ch09Cart.Models
{
    [DataObject(true)]
    public static class SlipDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        // retrieve slip with given ID
        public static Slip GetSlip(int slipID)
        {
            Slip sl = null;

            // create connection
            SqlConnection connection = MarinaDB.GetConnection();

            // create SELECT command
            string query = "SELECT ID,Width,Length,DockID " +
                           "FROM Slip " +
                           "WHERE ID = @SlipID";
            SqlCommand cmd = new SqlCommand(query, connection);
            // supply parameter value
            cmd.Parameters.AddWithValue("@SlipID", slipID);

            // run the SELECT query
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                // build slip object to return
                if (reader.Read()) // if there is a slip with this ID
                {
                    sl = new Slip();
                    sl.SlipID = (int)reader["ID"];
                    sl.Width = (int)reader["Width"];
                    sl.Length = (int)reader["Length"];
                    sl.DockID = (int)reader["DockID"];
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

            return sl;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        // retrieve slip with given ID

        public static List<Slip> GetSlipsByDock(int dockID)
        {
            List<Slip> sls = new List<Slip>();
            Slip sl = null;

            // create connection
            SqlConnection connection = MarinaDB.GetConnection();

            // create SELECT command
            string query = "SELECT ID,Width,Length,DockID " +
                           "FROM Slip " +
                           "WHERE DockID = @DockID";
            SqlCommand cmd = new SqlCommand(query, connection);
            // supply parameter value
            cmd.Parameters.AddWithValue("@DockID", dockID);

            // run the SELECT query
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //add slips to the list
            while (reader.Read()) //while there are slips
            {
                sl = new Slip();
                sl.SlipID = (int)reader["ID"];
                sl.Width = (int)reader["Width"];
                sl.Length = (int)reader["Length"];
                sl.DockID = (int)reader["DockID"];
            }
            reader.Close();
            return sls;
        }

        // insert new row to table slips
        // return new SlipID
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int AddSlip(Slip sl)
        {
            int slipID = 0;

            // create connection
            SqlConnection connection = MarinaDB.GetConnection();

            // create INSERT command
            // SlipID is IDENTITY so no value provided
            string insertStatement =
                "INSERT INTO Slip(Width,Length,DockID) " +
                "OUTPUT inserted.ID " +
                "VALUES(@Width, @Length, @DockID)";
            SqlCommand cmd = new SqlCommand(insertStatement, connection);
            cmd.Parameters.AddWithValue("@Width", sl.Width);
            cmd.Parameters.AddWithValue("@Length", sl.Length);
            cmd.Parameters.AddWithValue("@DockID", sl.DockID);
            try
            {
                connection.Open();

                // execute insert command and get inserted ID
                slipID = (int)cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                // retrieve generate Slip ID to return
                //string selectStatement =
                //    "SELECT IDENT_CURRENT('Slips')";
                //SqlCommand selectCmd = new SqlCommand(selectStatement, connection);
                //custID = Convert.ToInt32(selectCmd.ExecuteScalar()); // returns single value
                //         // (int) does not work in this case
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return slipID;
        }

        // delete Slip
        // return indiucator of success
        /*[DataObjectMethod(DataObjectMethodType.Delete)]
        public static bool DeleteSlip(Slip cust)
        {
            bool success = false;

            // create connection
            SqlConnection connection = MMABooksDB.GetConnection();

            // create DELETE command
            string deleteStatement =
                "DELETE FROM Slips " +
                "WHERE SlipID = @SlipID " + // needed for identification
                "AND Name = @Name " + // the rest - for optimistic concurrency
                "AND Address = @Address " +
                "AND City = @City " +
                "AND State = @State " +
                "AND ZipCode = @ZipCode";
            SqlCommand cmd = new SqlCommand(deleteStatement, connection);
            cmd.Parameters.AddWithValue("@SlipID", cust.SlipID);
            cmd.Parameters.AddWithValue("@Name", cust.Name);
            cmd.Parameters.AddWithValue("@Address", cust.Address);
            cmd.Parameters.AddWithValue("@City", cust.City);
            cmd.Parameters.AddWithValue("@State", cust.State);
            cmd.Parameters.AddWithValue("@ZipCode", cust.ZipCode);
            try
            {
                connection.Open();

                // execute the command
                int count = cmd.ExecuteNonQuery();
                // check if successful
                if (count > 0)
                    success = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return success;
        }

        // update Slip
        // retirn indicator of success
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static bool UpdateSlip(Slip old_Slip, Slip Slip)
        {
            bool success = false; // did not update

            // connection
            SqlConnection connection = MMABooksDB.GetConnection();
            // update command
            string updateStatement =
                "UPDATE Slips SET " +
                "Name = @NewName, " +
                "Address = @NewAddress, " +
                "City = @NewCity, " +
                "State = @NewState, " +
                "ZipCode = @NewZipCode " +
                "WHERE SlipID = @OldSlipID " + // identifies cSlip
                "AND Name = @OldName " + // remaining - for otimistic concurrency
                "AND Address = @OldAddress " +
                "AND City = @OldCity " +
                "AND State = @OldState " +
                "AND ZipCode = @OldZipCode";
            SqlCommand cmd = new SqlCommand(updateStatement, connection);
            cmd.Parameters.AddWithValue("@NewName", Slip.Name);
            cmd.Parameters.AddWithValue("@NewAddress", Slip.Address);
            cmd.Parameters.AddWithValue("@NewCity", Slip.City);
            cmd.Parameters.AddWithValue("@NewState", Slip.State);
            cmd.Parameters.AddWithValue("@NewZipCode", Slip.ZipCode);
            cmd.Parameters.AddWithValue("@OldSlipID", old_Slip.SlipID);
            cmd.Parameters.AddWithValue("@OldName", old_Slip.Name);
            cmd.Parameters.AddWithValue("@OldAddress", old_Slip.Address);
            cmd.Parameters.AddWithValue("@OldCity", old_Slip.City);
            cmd.Parameters.AddWithValue("@OldState", old_Slip.State);
            cmd.Parameters.AddWithValue("@OldZipCode", old_Slip.ZipCode);

            try
            {
                connection.Open();
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    success = true; // updated
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return success;
        }
    }*/
    }
}