using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Layer
{
    public class clsCustomersData
    {
        public static bool GetCustomerInfoByID(int CustomerID, ref string CustomerName)
        {
            bool isfound = false;

            using(SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using(SqlCommand command = new SqlCommand("@SP_GetCustomerInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if(reader.Read())
                        {
                            CustomerName = (string)reader["CustomerName"];
                            isfound = true;
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

        public static bool GetCustomerInfoByName(ref int CustomerID, ref string CustomerName)
        {
            bool isfound = false;

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("SP_GetCustmerInfoByName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustmerName", CustomerName);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            CustomerName = (string)reader["CustomerName"];
                            CustomerID = (int)reader["CustomerID"];
                            isfound = true;
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
        public static int AddNewCustomer(string CustomerName)
        {
            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewCustomer", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerName", CustomerName);
                    var outputIdParam = new SqlParameter("@NewCustomerID", SqlDbType.Int)
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
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                        return -1;
                    }
                }
            }
        }

        public static DataTable GetAllCustomers()
        {
            DataTable CustomersTable = new DataTable();

            using(SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using(SqlCommand command = new SqlCommand("SP_GetAllCustomers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    
                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if(reader.HasRows)
                        {
                            CustomersTable.Load(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                        return null;
                    }
                }
            }
            
            return CustomersTable;
        }
    }
}
