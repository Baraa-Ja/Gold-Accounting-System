using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Layer
{
    public class AddDeliveryDTO
    {
        public int TransactionID { get; set; }
        public string Currency { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Notes { get; set; }
        public bool IsCanceled { get; set; }
        public int CanceledForDeliveryID { get; set; }

        public AddDeliveryDTO(int transacionid, string currency, decimal quantity, decimal unitprice, string notes,
            bool iscanceled, int canceledfordeliveryid)
        {
            this.TransactionID = transacionid;
            this.Currency = currency;
            this.Quantity = quantity;
            this.UnitPrice = unitprice;
            this.Notes = notes;
            this.IsCanceled = iscanceled;
            this.CanceledForDeliveryID = canceledfordeliveryid;
        }
    }

    public class FindDeliveryDTO
    {
        public int DeliveryId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int TransactionID { get; set; }
        public string Currency { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal EquivilantInGold21 { get; set; }
        public decimal TotalAmount { get; set; }
        public string Notes { get; set; }
        public bool IsCanceled { get; set; }
        public int CanceledForDeliveryID { get; set; }

        public FindDeliveryDTO(int deliveryid, DateTime deliverydate, int trasnactionid, string currecny, decimal quantity,
            decimal unitprice, decimal EquivilantInGold21, decimal totalamount, string notes, bool iscanceled, int 
            canceledfordeliveryid)
        {
            this.DeliveryId = deliveryid;
            this.DeliveryDate = deliverydate;
            this.TransactionID = trasnactionid;
            this.Currency = currecny;
            this.Quantity = quantity;
            this.UnitPrice = unitprice;
            this.EquivilantInGold21 = EquivilantInGold21;
            this.TotalAmount = totalamount;
            this.Notes = notes;
            this.IsCanceled = iscanceled;
            this.CanceledForDeliveryID = canceledfordeliveryid;
        }
    }
    public class clsDeliveriesData
    {
        public static FindDeliveryDTO GetDeliveryByID(int deliveryid)
        {
            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetDeliveryByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DeliveryID", deliveryid);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            return new FindDeliveryDTO(
                                deliveryid,
                                (DateTime)reader["DeliveryDate"],
                                (int)reader["TransactionID"],
                                (string)reader["Currency"],
                                (decimal)reader["Quantity"],
                                (decimal)reader["UnitPrice"],
                                (decimal)reader["EquivalentInGold21"],
                                (decimal)reader["TotalAmount"],
                                (string)reader["Notes"],
                                (bool)reader["IsCanceled"],
                                (int)reader["CanceledForDeliveryID"]
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
        public static DataTable GetAllDeliveries()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connectiong = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetAllDeliveries", connectiong))
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

        public static DataTable GetAllDeliveriesForCustomer(string CustomerName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connectiong = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("@SP_GetAllDeliveriesForCustomer", connectiong))
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

        public static DataTable GetAllDeliveriesInDate(DateTime Date)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connectiong = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllDeliveriesInDate", connectiong))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Date", Date.Date);
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

        public static int AddNewDelivery(AddDeliveryDTO DTO)
        {

            using (SqlConnection connection = new SqlConnection(clsGlobal.Conectionstring))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewDelivery", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TransactionID", DTO.TransactionID);
                    command.Parameters.AddWithValue("@Currency", DTO.Currency);
                    command.Parameters.AddWithValue("@Quantity", DTO.Quantity);
                    command.Parameters.AddWithValue("@UnitPrice", DTO.UnitPrice);
                    command.Parameters.AddWithValue("@Notes", DTO.Notes);
                    command.Parameters.AddWithValue("@Iscanceled", DTO.IsCanceled);
                    command.Parameters.AddWithValue("@CanceledForDeliveryID", DTO.CanceledForDeliveryID);
                    SqlParameter outputIdParam = new SqlParameter("@NewDeliveryID", SqlDbType.Int)
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
