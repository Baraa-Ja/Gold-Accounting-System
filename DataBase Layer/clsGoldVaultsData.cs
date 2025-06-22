
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Layer
{
    public class clsGoldVaultsData
    {
        public static DataTable GetAllGoldTypesMovement()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllGoldTypesMovement", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
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
        public static decimal GetGoldAmountByType(int GoldType)
        {
            decimal Balance = 0;

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("SP_GetGoldAmountByID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GoldType", GoldType);

                    try
                    {
                        connection.Open();

                        Balance = (decimal)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                    }
                }
            }

            return Balance;
        }

        public static DataTable GetGoldTypeMovement(int GoldType)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("SP_GetGoldTypeMovement", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GoldType", GoldType);

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

        public static int GetGoldAmountInADate(DateTime RecordDate, int GoldType)
        {
            int Balance = 0;

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("SP_GetGoldAmountInDate", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Date", RecordDate.Date);
                    command.Parameters.AddWithValue("@GoldType", GoldType);

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

        public static DataTable GetGoldBoxMovementInADate(DateTime Date, int GoldType)
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand($"@SP_GetGoldTypeMovementByDate", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Date", Date.Date);
                    command.Parameters.AddWithValue("@GoldType", GoldType);

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
        public static int GetGold_14AmountInADate(DateTime RecordDate)
        {
            int Balance = 0;

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetGold14AmountInADate", connection))
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

        public static int GetGold_18AmountInADate(DateTime RecordDate)
        {
            int Balance = 0;

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetGold18AmountInADate", connection))
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

        public static int GetGold_21AmountInADate(DateTime RecordDate)
        {
            int Balance = 0;

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetGold21AmountInADate", connection))
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

        public static int GetGold_22AmountInADate(DateTime RecordDate)
        {
            int Balance = 0;

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetGold22AmountInADate", connection))
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

        public static int GetGold_24AmountInADate(DateTime RecordDate)
        {
            int Balance = 0;

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetGold24AmountInADate", connection))
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

        public static DataTable GetGold_14MovementInADate(DateTime Date)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetGold_14BoxMovementInADate", connection))
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

        public static DataTable GetGold_18MovementInADate(DateTime Date)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetGold_18BoxMovementInADate", connection))
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

        public static DataTable GetGold_21MovementInADate(DateTime Date)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetGold_21BoxMovementInADate", connection))
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

        public static DataTable GetGold_22MovementInADate(DateTime Date)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetGold_22BoxMovementInADate", connection))
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

        public static DataTable GetGold_24MovementInADate(DateTime Date)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetGold_24BoxMovementInADate", connection))
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
