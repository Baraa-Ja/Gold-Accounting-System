
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Layer
{
    public class clsCustomerBalancesData
    {
    //    public static bool GetCustomerBalances(int CustomerID, ref int SYPBalance, ref int USDBalance,
    //ref double GoldBalance)
    //    {
    //        bool isfound = false;

    //        using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
    //        {
    //            using (SqlCommand command = new SqlCommand("@SP_GetCustomerBalance", connection))
    //            {
    //                command.CommandType = System.Data.CommandType.StoredProcedure;
    //                command.Parameters.AddWithValue("@CustomerID", CustomerID);

    //                try
    //                {
    //                    connection.Open();

    //                    SqlDataReader reader = command.ExecuteReader();

    //                    if (reader.Read())
    //                    {
    //                        SYPBalance = (int)reader["SYPBalance"];
    //                        USDBalance = (int)reader["USDBalance"];
    //                        GoldBalance = (double)reader["GoldBalance"];
    //                        isfound = true;
    //                    }
    //                }
    //                catch (Exception ex)
    //                {
    //                    clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
    //                }
    //            }
    //        }

    //        return isfound;
    //    }

        //public static bool GetCustomerBalancesInDate(int CustomerID, ref int SYPBalance, ref int USDBalance,
        //    ref decimal GoldBalance)
        //{
        //    bool isfound = false;

        //    using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
        //    {
        //        using (SqlCommand command = new SqlCommand("@SP_GetCustomerBalancesInDate", connection))
        //        {
        //            command.CommandType = System.Data.CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@CustomerID", CustomerID);

        //            try
        //            {
        //                connection.Open();

        //                SqlDataReader reader = command.ExecuteReader();

        //                if (reader.Read())
        //                {
        //                    SYPBalance = (int)reader["SYPBalance"];
        //                    USDBalance = (int)reader["USDBalance"];
        //                    GoldBalance = (decimal)reader["GoldBalance"];
        //                    isfound = true;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                EventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
        //            }
        //        }
        //    }

        //    return isfound;
        //}

        //public static bool GetCustomerBalanceByName(string CustomerName, ref int SYPBalance, ref int USDBalance,
        //    ref double GoldBalance, ref int CustomerID)
        //{
        //    bool isfound = false;

        //    using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
        //    {
        //        using (SqlCommand command = new SqlCommand("@SP_GetCustomerBalancesByName", connection))
        //        {
        //            command.CommandType = System.Data.CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@CustomerName", CustomerName);
        //            var outputIdParam = new SqlParameter("@CustomerID", SqlDbType.Int)
        //            {
        //                Direction = ParameterDirection.Output
        //            };
        //            command.Parameters.Add(outputIdParam);

        //            try
        //            {
        //                connection.Open();

        //                SqlDataReader reader = command.ExecuteReader();

        //                CustomerID = (int)outputIdParam.Value;

        //                if (reader.Read())
        //                {
        //                    SYPBalance = (int)reader["SYPBalance"];
        //                    USDBalance = (int)reader["USDBalance"];
        //                    GoldBalance = (double)reader["GoldBalance"];
        //                    isfound = true;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
        //            }
        //        }
        //    }

        //    return isfound;
        //}

        public static DataTable GetCustomersBalances()
        {
            DataTable dt = new DataTable();

            using(SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using(SqlCommand command = new SqlCommand("SP_GetCustomersBalances", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    
                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if(reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                        return null;
                    }
                }
            }

            return dt;
        }
    }
}
