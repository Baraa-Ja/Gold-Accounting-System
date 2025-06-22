
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Layer
{
    public class clsCashBoxesData
    {
        public static decimal GetCashBoxBalance(string BoxName)
        {
            decimal balance = 0;
            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetBoxBalance", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BoxName", BoxName);

                    try
                    {
                        connection.Open();

                        balance = Convert.ToDecimal(command.ExecuteScalar());

                        return balance;
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                        return 0;
                    }
                }
            }
        }

        public static decimal GetCashBoxBalanceInDate(string BoxName, DateTime Date)
        {
            decimal balance = 0;
            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetBoxBalanceInDate", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BoxName", BoxName);
                    command.Parameters.AddWithValue("@Date", Date.Date);

                    try
                    {
                        connection.Open();

                        balance = Convert.ToDecimal(command.ExecuteScalar());

                        return balance;
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                        return 0;
                    }
                }
            }
        }

        public static DataTable GetCashBoxMovementInDate(string BoxName, DateTime Date)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetBoxMovementInDate", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BoxName", BoxName);
                    command.Parameters.AddWithValue("@Date", Date.Date);

                    try
                    {
                        connection.Open();

                        SqlDataReader redaer = command.ExecuteReader();

                        while (redaer.Read())
                        {
                            table.Load(redaer);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                        return null;
                    }
                }
            }

            return table;
        }

        public static DataTable GetCashBoxMovement(string BoxName)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("SP_GetBoxMovement", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BoxName", BoxName);

                    try
                    {
                        connection.Open();

                        SqlDataReader redaer = command.ExecuteReader();

                        if (redaer.HasRows)
                        {
                            table.Load(redaer);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                        return null;
                    }
                }
            }

            return table;
        }
    }
}
