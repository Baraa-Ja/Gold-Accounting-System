using DataBase_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class clsPayments
    {
        public enum enmode { AddNew = 0, update = 1}
        public enmode Mode;
        public int PaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public int TransactionID { get; set; }
        public clsTransactions TransactionInfo { get; set; }
        public clsCustomers CustomerInfo { get; set; }
        public string Currency {  get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal EquivilantinGold21 { get; set; }
        public decimal TotalAmount { get; set; }
        public string Notes { get; set; }
        public bool IsCanceled { get; set; }
        public int CanceledForTransactionID { get; set; }
        public AddPaymentDTO AddPaymentDTO { get { return new AddPaymentDTO(this.TransactionID, this.Currency, this.Amount,
            this.UnitPrice, this.Notes, this.IsCanceled, this.CanceledForTransactionID); } }

        public FindPaymentDTO FindPaymentDTO { get { return new FindPaymentDTO(this.PaymentID, this.PaymentDate,
            this.TransactionID, this.CustomerInfo.CustomerName, this.Currency, this.Amount, this.UnitPrice,this.EquivilantinGold21,
            this.TotalAmount, this.Notes, this.IsCanceled, this.CanceledForTransactionID); } }
        public clsPayments()
        {
            this.PaymentID = 0;
            this.PaymentDate = DateTime.Now;
            this.TransactionID = 0;
            this.Currency = "";
            this.Amount = 0;
            this.UnitPrice = 0;
            this.EquivilantinGold21 = 0;
            this.TotalAmount = 0;
            this.Notes = "";
            this.IsCanceled = false;
            this.CanceledForTransactionID = 0;
            this.Mode = enmode.AddNew;
        }

        private clsPayments(FindPaymentDTO DTO)
        {
            this.PaymentID = DTO.PaymentID;
            this.PaymentDate = DTO.PaymentDate;
            this.TransactionID = DTO.TransactionID;
            this.TransactionInfo = clsTransactions.GetTransactionInfoByID(DTO.TransactionID);
            this.CustomerInfo = clsCustomers.GetCustomerInfoByID(this.TransactionInfo.CustomerID);
            this.Currency = DTO.Currency;
            this.Amount = DTO.Amount;
            this.UnitPrice = DTO.UnitPrice;
            this.EquivilantinGold21 = DTO.EquivilantinGold21;
            this.TotalAmount = DTO.TotalAmount;
            this.Notes = DTO.Notes;
            this.IsCanceled = DTO.IsCanceled;
            this.CanceledForTransactionID = CanceledForTransactionID;

            Mode = enmode.update;
        }

        private clsPayments(int paymentid, DateTime paymentDate, int transactionID, string currecny, decimal amount,
            decimal unitprice, decimal equivilantingold21, decimal totalamount, string notes, bool iscanceled,
            int CanceledForTransactionID)
        {
            this.PaymentID = paymentid;
            this.PaymentDate = paymentDate;
            this.TransactionID = transactionID;
            this.TransactionInfo = clsTransactions.GetTransactionInfoByID(transactionID);
            this.CustomerInfo = clsCustomers.GetCustomerInfoByID(this.TransactionInfo.CustomerID);
            this.Currency = currecny;
            this.Amount = amount;
            this.UnitPrice = unitprice;
            this.EquivilantinGold21 = equivilantingold21;
            this.TotalAmount = totalamount;
            this.Notes = notes;
            this.IsCanceled = iscanceled;
            this.CanceledForTransactionID = CanceledForTransactionID;

            Mode = enmode.update;
        }

        public static clsPayments FindPaymentByID(int paymentid)
        {
            FindPaymentDTO DTO = clsPaymentsData.GetPaymentByID(paymentid);

            if (DTO != null)
                return new clsPayments(DTO);
            else
                return null;
        }
        public static DataTable GetAllPayments()
        {
            return clsPaymentsData.GetAllPayments();
        }

        public static DataTable GetAllPaymentsInDate(DateTime date)
        {
            return clsPaymentsData.GetAllPaymentsinDate(date.Date);
        }

        public static DataTable GetAllPaymentsForCustomer(string CustomerName)
        {
            return clsPaymentsData.GetAllPaymentsForCustomer(CustomerName);
        }

        public bool AddNewPayment()
        {
            return AddNewPayment(this.AddPaymentDTO);
        }

        public static bool AddNewPayment(AddPaymentDTO DTO)
        {
            return AddNewPayment(DTO);
        }
    }
}
