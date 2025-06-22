using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Layer
{
    public class AddPaymentDTO
    {
        public int TransactionID { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public string Notes { get; set; }
        public bool IsCanceled { get; set; }
        public int CanceledForPaymentID { get; set; }
        public AddPaymentDTO(int Transactionid, string currency, decimal amount,
            decimal unitprice, string notes, bool iscanceled, int canceledforpaymentid)
        {

            this.TransactionID = Transactionid;
            this.Currency = currency;
            this.Amount = amount;
            this.UnitPrice = unitprice;
            this.Notes = notes;
            this.IsCanceled = iscanceled;
            this.CanceledForPaymentID = canceledforpaymentid;
        }
    }

    public class FindPaymentDTO
    {
        public int PaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public int TransactionID { get; set; }
        public string CustomerName { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal EquivilantinGold21 { get; set; }
        public decimal TotalAmount { get; set; }
        public string Notes { get; set; }
        public bool IsCanceled { get; set; }
        public int CanceledForPaymentID { get; set; }
        public FindPaymentDTO(int paymentid, DateTime paymentdate,int Transactionid,string customername,
            string currency, decimal amount,decimal unitprice, decimal equivilantingold21, decimal totalamount
            , string notes, bool iscanceled, int canceledforpaymentid)
        {

            this.TransactionID = Transactionid;
            this.Currency = currency;
            this.Amount = amount;
            this.UnitPrice = unitprice;
            this.Notes = notes;
            this.IsCanceled = iscanceled;
            this.CanceledForPaymentID = canceledforpaymentid;
            this.TotalAmount = totalamount;
            this.EquivilantinGold21 = equivilantingold21;
            this.PaymentID = paymentid;
            this.PaymentDate = paymentdate;
            this.CustomerName = customername;
        }
    }

    public class clsPaymentsData
    {
        public static FindPaymentDTO GetPaymentByID(int paymentid)
        {
            using(SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using(SqlCommand command = new SqlCommand("@SP_GetPaymentByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PaymentID", paymentid);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            return new FindPaymentDTO(
                                paymentid,
                                (DateTime)reader["PaymentDate"],
                                (int)reader["TransactionID"],
                                (string)reader["CustomerName"],
                                (string)reader["Currency"],
                                (decimal)reader["Amount"],
                                (decimal)reader["UnitPrice"],
                                (decimal)reader["EquivalentInGold21"],
                                (decimal)reader["TotalAmount"],
                                (string)reader["Notes"],
                                (bool)reader["IsCanceled"],
                                (int)reader["CanceledForPaymentID"]
                                );
                        }
                        else
                            return null;
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                        return null;
                    }
                }
            }
        }
        public static DataTable GetAllPayments()
        {
            DataTable dt = new DataTable();

            using(SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetAllPayments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

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
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                        return null;
                    }
                }
            }

            return dt;
        }

        public static DataTable GetAllPaymentsForCustomer(string CustomerName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetAllPaymentsForCustomer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerName", CustomerName);
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
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                        return null;
                    }
                }
            }

            return dt;

        }

        public static DataTable GetAllPaymentsinDate(DateTime Date)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetAllPaymentsInDate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Date", Date.Date);
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
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                        return null;
                    }
                }
            }

            return dt;
        }

        public static int AddNewPayment(AddPaymentDTO DTO)
        {

            using(SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using(SqlCommand command = new SqlCommand("SP_AddnewPayment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TransactionID", DTO.TransactionID);
                    command.Parameters.AddWithValue("@Currecny", DTO.Currency);
                    command.Parameters.AddWithValue("@Amount", DTO.Amount);
                    command.Parameters.AddWithValue("@UnitPrice", DTO.UnitPrice);
                    command.Parameters.AddWithValue("@Notes", DTO.Notes);
                    command.Parameters.AddWithValue("@Iscanceled", DTO.IsCanceled);
                    command.Parameters.AddWithValue("@CanceledForPaymentID", DTO.CanceledForPaymentID);
                    SqlParameter outputIdParam = new SqlParameter("@NewPaymentID", SqlDbType.Int)
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
