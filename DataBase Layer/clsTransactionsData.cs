
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataBase_Layer
{
    public class AddingTransactionDTO
    {
        public int TransactionTypeID { get; set; }
        public int CustomerID { get; set; }
        public string Currency { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string CurrencyToGive { get; set; }
        public string Notes { get; set; }
        public bool IsCanceled { get; set; }
        public int CanceledForTransactionID { get; set; }

        public AddingTransactionDTO(int TransactionTypeID, int customerid, string Currency,decimal Quantity,
            decimal UnitPrice, string CurrencyToGive,string notes, bool iscanceled, int CanceledForTransactionID)
        {
            this.TransactionTypeID = TransactionTypeID;
            this.CustomerID = customerid;
            this.Currency = Currency;
            this.Quantity = Quantity;
            this.UnitPrice = UnitPrice;
            this.CurrencyToGive = CurrencyToGive;
            this.Notes = notes;
            this.IsCanceled = IsCanceled;
            this.CanceledForTransactionID = CanceledForTransactionID;
        }
    }

    public class FindTransactionDTO
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionTypeID { get; set; }
        public int CustomerID { get; set; }
        public string Currency { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string CurrencyToGive { get; set; }
        public decimal EquivilantToGold21 { get; set; }
        public decimal TotalAmount { get; set; }
        public int StatusID { get; set; }
        public string Notes { get; set; }
        public bool IsCanceled { get; set; }
        public int CanceledForTransactionID { get; set; }

        public FindTransactionDTO(int TransactionID, DateTime TransactionDate, int TransactionTypeID, int CustomerID, string Currency,
            decimal Quantity, decimal UnitPrice, string CurrencyToGive, decimal EquivilantToGold21, decimal TotalAmount,
            int StatusID, string Notes, bool Iscanceled, int CanceledForTransactionID)
        {
            this.TransactionID = TransactionID;
            this.TransactionDate = TransactionDate;
            this.TransactionTypeID = TransactionTypeID;
            this.CustomerID = CustomerID;
            this.Currency = Currency;
            this.Quantity = Quantity;
            this.UnitPrice = UnitPrice;
            this.CurrencyToGive = CurrencyToGive;
            this.EquivilantToGold21 = EquivilantToGold21;
            this.TotalAmount = TotalAmount;
            this.StatusID = StatusID;
            this.Notes = Notes;
            this.IsCanceled = IsCanceled;
            this.CanceledForTransactionID = CanceledForTransactionID;
        }
    }
    public class clsTransactionsData
    {
        public static FindTransactionDTO GetTransactionInfoByID(int TransactionID)
        {
            using(SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using(SqlCommand command = new SqlCommand("SP_GetTransactionInfoByID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TransactionID", TransactionID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if(reader.Read())
                        {
                            return new FindTransactionDTO(
                                TransactionID,
                                (DateTime)reader["TransactionDate"],
                                (int)reader["TransactionTypeID"],
                                (int)reader["CustomerID"],
                                (string)reader["Currency"],
                                (decimal)reader["Quantity"],
                                (decimal)reader["UnitPrice"],
                                (string)reader["CurrencyToGive"],
                                (decimal)reader["EquivalentInGold21"],
                                (decimal)reader["TotalAmount"],
                                (int)reader["StatusID"],
                                (string)reader["Notes"],
                                (bool)reader["IsCanceled"],
                                (int)reader["CanceledForTransactionID"]
                                );
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                        return null;
                    }
                }
            }
        }

        public static DataTable GetAllTransactions()
        {
            DataTable dt = new DataTable();

            using(SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using(SqlCommand command = new SqlCommand("SP_GetAllTransactions", connection))
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

                        reader.Close();
                    }
                    catch (SqlException ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                        return null;
                    }
                }
            }

            return dt;
        }

        public static DataTable GetAllTransactionsFiltered()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllTransactionsFiltered", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }

                        reader.Close();
                    }
                    catch (SqlException ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                        return null;
                    }
                }
            }

            return dt;
        }

        public static int AddNewTransaction(AddingTransactionDTO DTO)
        {

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using(SqlCommand command = new SqlCommand("SP_AddnewTransaction", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TransactionTypeID", DTO.TransactionTypeID);
                    command.Parameters.AddWithValue("@CustomerID", DTO.CustomerID);
                    command.Parameters.AddWithValue("@Currency", DTO.Currency);
                    command.Parameters.AddWithValue("@Quantity", DTO.Quantity);
                    command.Parameters.AddWithValue("@CurrencyToGive", DTO.CurrencyToGive);
                    command.Parameters.AddWithValue("@UnitPrice", DTO.UnitPrice);
                    command.Parameters.AddWithValue("@Notes", DTO.Notes);
                    command.Parameters.AddWithValue("@IsCanceled", DTO.IsCanceled);
                    command.Parameters.AddWithValue("@CanceledForTransactionID", DTO.CanceledForTransactionID);
                    SqlParameter outputIdParam = new SqlParameter("@NewTransactionID", SqlDbType.Int)
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
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                        return -1;
                    }
                }
            }
        }
    }
}
