using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataBase_Layer
{
    public class clsCurrenciesData
    {
        public static string Conectionstring = clsGlobal.Conectionstring;
        public static bool GetCurrencyByID(int CurrencyID, ref string CurrencyName)
        {
            bool isfound = false;

            using (SqlConnection Connection = new SqlConnection(Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("SP_GetCurrencyByID", Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

                    try
                    {
                        Connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            CurrencyName = (string)reader["CurrencyName"];
                            isfound = true;
                        }
                        else
                        {
                            isfound = false;
                        }
                        Connection.Close();
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, EventLogEntryType.Information);
                        isfound = true;
                    }
                }
            }

            return isfound;
        }

        public static bool GetCurrencyByName(string CurrencyName, ref int CurrencyID)
        {
            bool isfound = false;

            using (SqlConnection Connection = new SqlConnection(Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("SP_GetCurrencyByID", Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

                    try
                    {
                        Connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            CurrencyName = (string)reader["CurrencyName"];
                            isfound = true;
                        }
                        else
                        {
                            isfound = false;
                        }
                        Connection.Close();
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, EventLogEntryType.Information);
                        isfound = true;
                    }
                }
            }

            return isfound;
        }
        public static int AddNewCurrency(string CurrencyName)
        {
            using (SqlConnection connection = new SqlConnection(Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewCurrency", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CurrencyName", CurrencyName);
                    var outputIdParam = new SqlParameter("@NewCurrencyID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        return (int)outputIdParam.Value;
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, EventLogEntryType.Information);
                        return -1;
                    }
                }
            }
        }
    }
}
