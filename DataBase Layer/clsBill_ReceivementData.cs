using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Layer
{
    public class AddReceivementDTO
    {
        public int TransactionID { get; set; }
        public string Currency { get; set; }
        public decimal? CurrencyAmount { get; set; }
        public int ?Goldkarat { get; set; }
        public decimal ?GoldAmount { get; set; }
        public string Notes { get; set; }

        public AddReceivementDTO(int transacionid, string currency, decimal? CurrencyAmount, int? Goldkarat,
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

    public class FindReceivementDTO
    {
        public int ReceivementID { get; set; }
        public DateTime ReceivementDate { get; set; }
        public int TransactionID { get; set; }
        public string Currency { get; set; }
        public decimal? CurrencyAmount { get; set; }
        public int? Goldkarat { get; set; }
        public decimal? GoldAmount { get; set; }
        public decimal? EquivilantInGold21 { get; set; }
        public string Notes { get; set; }

        public FindReceivementDTO(int ReceivementID, DateTime ReceivementDate, int trasnactionid, string currecny, decimal? CurrencyAmount,
            int? Goldkarat, decimal? GoldAmount, decimal? EquivilantInGold21, string notes)
        {
            this.ReceivementID = ReceivementID;
            this.ReceivementDate = ReceivementDate;
            this.TransactionID = trasnactionid;
            this.Currency = currecny;
            this.CurrencyAmount = CurrencyAmount;
            this.Goldkarat = Goldkarat;
            this.EquivilantInGold21 = EquivilantInGold21;
            this.GoldAmount = GoldAmount;
            this.Notes = notes;
        }
    }

    public class UpdateReceivementDTO
    {
        public int ReceivementID { get; set; }
        public DateTime? Receivemntdate { get; set; }
        public string Currency { get; set; }
        public decimal? CurrencyAmount { get; set; }
        public int? Goldkarat { get; set; }
        public decimal? GoldAmount { get; set; }
        public string Notes { get; set; }

        public UpdateReceivementDTO(int ReceivementID, DateTime? ReceivementDate, string currency, decimal? CurrencyAmount, int? Goldkarat,
            decimal? GoldAmount, string notes)
        {
            this.ReceivementID = ReceivementID;
            this.Receivemntdate = ReceivementDate;
            this.Currency = currency;
            this.CurrencyAmount = CurrencyAmount;
            this.Goldkarat = Goldkarat;
            this.GoldAmount = GoldAmount;
            this.Notes = notes;
        }
    }

    public class clsBill_ReceivementData
    {
        public static FindReceivementDTO GetReceivemenByID(int ReceivementID)
        {
            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_GetBill_Receivement", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ReceiveID", ReceivementID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            return new FindReceivementDTO(
                                ReceivementID,
                                (DateTime)reader["Receive Date"],
                                (int)reader["Transaction ID"],
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
        public static DataTable GetAllReceivements()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connectiong = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_GetAllBill_Receivement", connectiong))
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

        public static DataTable GetAllReceivementsForCustomer(string CustomerName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connectiong = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_GetAllBill_Receivements_ForCustomer", connectiong))
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

        public static int AddNewReceivemen(AddReceivementDTO DTO)
        {

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_AddNewReceivement", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TrasnactionID", DTO.TransactionID);
                    command.Parameters.AddWithValue("@Currency", DTO.Currency);
                    command.Parameters.AddWithValue("@CurrencyAmount",
                        DTO.CurrencyAmount.HasValue ? (object)DTO.CurrencyAmount.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@GoldKarat", DTO.Goldkarat);
                    command.Parameters.AddWithValue("@GoldAmount", DTO.GoldAmount);
                    command.Parameters.AddWithValue("@Notes", DTO.Notes);
                    SqlParameter outputIdParam = new SqlParameter("@NewReceivementID", SqlDbType.Int)
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

        public static bool UpdateReceivement(UpdateReceivementDTO DTO)
        {
            int RowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_UpdateReceivement", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ReceiveID", DTO.ReceivementID);
                    command.Parameters.AddWithValue("@ReceiveDate", DTO.Receivemntdate);
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
