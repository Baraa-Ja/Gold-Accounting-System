using DataBase_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class clsDeliveries
    {
        public enum enmode { addnew = 0, update =1 }
        public enmode Mode;
        public int DeliveryId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int TransactionID { get; set; }
        public clsTransactions TransactionInfo { get; set; }
        public clsCustomers Customerinfo { get; set; }
        public string Currency {  get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal EquivilantInGold21 { get; set; }
        public decimal TotalAmount { get; set; }
        public string Notes { get; set; }
        public bool IsCanceled { get; set; }
        public int CanceledForDeliveryID { get; set; }
        public FindDeliveryDTO FindDeliveryDTO { get { return new FindDeliveryDTO(this.DeliveryId,this.DeliveryDate, this.TransactionID,
            this.Currency, this.Quantity, this.UnitPrice, this.EquivilantInGold21, this.TotalAmount, this.Notes, this.IsCanceled, this.CanceledForDeliveryID); } }

        public AddDeliveryDTO AddDeliveryDTO { get { return new AddDeliveryDTO(this.TransactionID, this.Currency,
            this.Quantity, this.UnitPrice, this.Notes, this.IsCanceled, this.CanceledForDeliveryID); } }
        public clsDeliveries()
        {
            this.DeliveryId = 0;
            this.DeliveryDate = DateTime.Now;
            this.TransactionID = 0;
            this.Currency = "";
            this.Quantity = 0;
            this.UnitPrice = 0;
            this.EquivilantInGold21 = 0;
            this.TotalAmount = 0;
            this.Notes = "";
            Mode = enmode.addnew;
        }

        private clsDeliveries(FindDeliveryDTO DTO)
        {
            this.DeliveryId = DTO.DeliveryId;
            this.DeliveryDate = DTO.DeliveryDate;
            this.TransactionID = DTO.TransactionID;
            this.TransactionInfo = clsTransactions.GetTransactionInfoByID(DTO.TransactionID);
            this.Customerinfo = clsCustomers.GetCustomerInfoByID(this.TransactionInfo.CustomerID);
            this.Currency = DTO.Currency;
            this.Quantity = DTO.Quantity;
            this.UnitPrice = DTO.UnitPrice;
            this.EquivilantInGold21 = DTO.EquivilantInGold21;
            this.TotalAmount = DTO.TotalAmount;
            this.Notes = DTO.Notes;
            this.IsCanceled = DTO.IsCanceled;
            this.CanceledForDeliveryID = DTO.CanceledForDeliveryID;
            Mode = enmode.update;
        }
        private clsDeliveries(int DeliveryId, DateTime DeliveryDate, int TransactionID, string Currency, decimal Quantity,
            decimal Unitprice, decimal EquivilantInGold21, int Paidbyanothercustomerid, decimal totalamount, string notes)
        {
            this.DeliveryId = DeliveryId;
            this.DeliveryDate= DeliveryDate;
            this.TransactionID = TransactionID;
            this.TransactionInfo = clsTransactions.GetTransactionInfoByID(TransactionID);
            this.Customerinfo = clsCustomers.GetCustomerInfoByID(this.TransactionInfo.CustomerID);
            this.Currency = Currency;
            this.Quantity=Quantity;
            this.UnitPrice =Unitprice;
            this.EquivilantInGold21 =EquivilantInGold21;
            this.TotalAmount = totalamount;
            this.Notes = notes;
            this.IsCanceled = IsCanceled;
            this.CanceledForDeliveryID = CanceledForDeliveryID;
            Mode = enmode.update;
        }

        public static DataTable GetAllDeliveries()
        {
            return clsDeliveriesData.GetAllDeliveries();
        }

        public static DataTable GetAllDeliveriesForCustomer(string CustomerName)
        {
            return clsDeliveriesData.GetAllDeliveriesForCustomer(CustomerName);
        }

        public static DataTable GetAllDeliveriesinDate(DateTime Date)
        {
            return clsDeliveriesData.GetAllDeliveriesInDate(Date.Date);
        }

        public bool AddNewDelivery()
        {
            this.DeliveryId = clsDeliveriesData.AddNewDelivery(this.AddDeliveryDTO);
            return this.DeliveryId > 0;
        }

        public static bool AddNewDelivery(AddDeliveryDTO DTO)
        {
            return AddNewDelivery(DTO);
        }
    }
}
