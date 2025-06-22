
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Layer
{
    public class clsTransactionsTypesData
    {
        public static bool GetTransactionTypeByID(int OperationID, ref string OperationType)
        {
            bool isfound = false;

            using(SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using(SqlCommand command = new SqlCommand("@SP_GetOperationInfoByID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OperationID", OperationID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if(reader.Read())
                        {
                            OperationType = (string)reader["OperationType"];
                            isfound = true;
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                    }
                }
            }
            return isfound;
        }

        public static bool GetTransactionTypeByName(ref string TransactionType, ref int TransactionTypeID)
        {
            bool isfound = false;

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("SP_GetTransactionTypeByName", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TransactionType", TransactionType);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            TransactionType = (string)reader["TransactionType"];
                            TransactionTypeID = (int)reader["TransactionTypeID"];
                            isfound = true;
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                    }
                }
            }
            return isfound;
        }
    }
}
