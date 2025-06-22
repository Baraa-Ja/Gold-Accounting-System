
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Layer
{
    public class clsSyrianBoxData
    {
        public static int GetSyrianBoxBalance()
        {
            int Balance = 0;

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetSyrianBoxAmount", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();

                        Balance = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                    }
                }
            }

            return Balance;
        }
        public static int GetSyrianBalanceInADate(DateTime RecordDate)
        {
            int Balance = 0;

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetSyrianBoxBalanceInADate", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Date", RecordDate);

                    try
                    {
                        connection.Open();

                        Balance = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                    }
                }
            }

            return Balance;
        }

        public static DataTable GetSyrianBoxMovementInADate(DateTime Date)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetSyrianBoxMovementInADate", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Date", Date);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                    }
                }
            }

            return dt;
        }
    }
}
