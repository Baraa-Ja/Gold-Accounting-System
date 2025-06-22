using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Layer
{
    public class AddBill_PaymentDTO
    {
        public int TransactionID { get; set; }
        public string Currency { get; set; }
        public decimal? CurrencyAmount { get; set; }
        public int? Goldkarat { get; set; }
        public decimal? GoldAmount { get; set; }
        public string Notes { get; set; }

        public AddBill_PaymentDTO(int transacionid, string currency, decimal? CurrencyAmount, int? Goldkarat,
            decimal? GoldAmount, string notes)
        {
            this.TransactionID = transacionid;
            this.Currency = currency;
            this.CurrencyAmount = CurrencyAmount;
            this.Goldkarat = Goldkarat;
            this.GoldAmount = GoldAmount;
            this.Notes = notes;
        }
    }

    public class UpdateBill_PaymentDTO
    {
        public int PaymentID { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Currency { get; set; }
        public decimal? CurrencyAmount { get; set; }
        public int? Goldkarat { get; set; }
        public decimal? GoldAmount { get; set; }
        public string Notes { get; set; }

        public UpdateBill_PaymentDTO(int PaymentID, DateTime? PaymentDate, string currency, decimal? CurrencyAmount, int? Goldkarat,
            decimal? GoldAmount, string notes)
        {
            this.PaymentID = PaymentID;
            this.PaymentDate = PaymentDate;
            this.Currency = currency;
            this.CurrencyAmount = CurrencyAmount;
            this.Goldkarat = Goldkarat;
            this.GoldAmount = GoldAmount;
            this.Notes = notes;
        }
    }
    public class FindBill_PaymentDTO
    {
        public int PaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public int TransactionID { get; set; }
        public string Currency { get; set; }
        public decimal? CurrencyAmount { get; set; }
        public int? Goldkarat { get; set; }
        public decimal? GoldAmount { get; set; }
        public decimal? EquivilantInGold21 { get; set; }
        public string Notes { get; set; }

        public FindBill_PaymentDTO(int PaymentID, DateTime PaymentDate, int trasnactionid, string currecny, decimal? CurrencyAmount,
            int? Goldkarat, decimal? GoldAmount, decimal? EquivilantInGold21, string notes)
        {
            this.PaymentID = PaymentID;
            this.PaymentDate = PaymentDate;
            this.TransactionID = trasnactionid;
            this.Currency = currecny;
            this.CurrencyAmount = CurrencyAmount;
            this.Goldkarat = Goldkarat;
            this.EquivilantInGold21 = EquivilantInGold21;
            this.GoldAmount = GoldAmount;
            this.Notes = notes;
        }
    }
    public class clsBill_PaymentData
    {
        public static FindBill_PaymentDTO GetBill_PaymentByID(int PaymentID)
        {
            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_GetBill_PaymentByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PaymentID", PaymentID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            return new FindBill_PaymentDTO(
                                PaymentID,
                                (DateTime)reader["PaymentDate"],
                                (int)reader["TransactionID"],
                                (string)reader["Currency"],
                                (decimal)reader["Currency Amount"],
                                (int)reader["Gold karat"],
                                (decimal)reader["Gold Amount"],
                                (decimal)reader["EquivalentInGold21"],
                                (string)reader["notes"]
                                );
                        }
                        else
                            return null;
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                        return null;
                    }
                }
            }
        }
        public static DataTable GetAllPayments()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connectiong = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_Getallbill_Payments", connectiong))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connectiong.Open();

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

        public static DataTable Getallbill_Payments_ForCustomer(string CustomerName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connectiong = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_Getallbill_Payments_ForCustomer", connectiong))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerName", CustomerName);
                    try
                    {
                        connectiong.Open();

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

        public static int AddNewBillPayment(AddBill_PaymentDTO DTO)
        {

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_AddBill_Payment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TrasnactionID", DTO.TransactionID);
                    command.Parameters.AddWithValue("@Currency", DTO.Currency);
                    command.Parameters.AddWithValue("@CurrecnyAmount",
                        DTO.CurrencyAmount.HasValue ? (object)DTO.CurrencyAmount.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@GoldKarat", DTO.Goldkarat);
                    command.Parameters.AddWithValue("@GoldAmount", DTO.GoldAmount);
                    command.Parameters.AddWithValue("@Notes", DTO.Notes);
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

        public static bool UpdatePayment(UpdateBill_PaymentDTO DTO)
        {
            int RowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_UpdatePayment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PaymentID", DTO.PaymentID);
                    command.Parameters.AddWithValue("@PaymentDate", DTO.PaymentDate);
                    command.Parameters.AddWithValue("@Currency", DTO.Currency);
                    command.Parameters.AddWithValue("@CurrencyAmount", DTO.CurrencyAmount);
                    command.Parameters.AddWithValue("@GoldKarat", DTO.Goldkarat);
                    command.Parameters.AddWithValue("@GoldAmount", DTO.GoldAmount);
                    command.Parameters.AddWithValue("@Notes", DTO.Notes);

                    try
                    {
                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                        return RowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        clsEventLogHandler.ExeptionsEventLog(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                        return false;
                    }
                }
            }
        }
    }
}
