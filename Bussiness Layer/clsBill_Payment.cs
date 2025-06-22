using DataBase_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class clsBill_Payment
    {
        public enum enmode { addnew = 0, update = 1 }
        public enmode Mode;
        public int PaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public int TransactionID { get; set; }
        public clsTransactions TransactionInfo { get; set; }
        public clsCustomers Customerinfo { get; set; }
        public string Currency { get; set; }
        public decimal? CurrencyAmount { get; set; }
        public int? Goldkarat { get; set; }
        public decimal? GoldAmount { get; set; }
        public decimal? EquivilantInGold21 { get; set; }
        public string Notes { get; set; }
        public FindBill_PaymentDTO FindBill_PaymentDTO => new FindBill_PaymentDTO(this.PaymentID, this.PaymentDate, this.TransactionID,
            this.Currency, this.CurrencyAmount, this.Goldkarat, this.GoldAmount, this.EquivilantInGold21, this.Notes);

        public AddBill_PaymentDTO AddBill_PaymentDTO => new AddBill_PaymentDTO(this.TransactionID, this.Currency,
            this.CurrencyAmount, this.Goldkarat, this.GoldAmount, this.Notes);

        public UpdateBill_PaymentDTO UpdateBill_PaymentDTO => new UpdateBill_PaymentDTO(this.PaymentID, this.PaymentDate,
            this.Currency, this.CurrencyAmount, this.Goldkarat, this.GoldAmount, this.Notes);
        public clsBill_Payment()
        {
            this.PaymentID = 0;
            this.PaymentDate = DateTime.Now;
            this.TransactionID = 0;
            this.Currency = "";
            this.CurrencyAmount = null;
            this.Goldkarat = null;
            this.GoldAmount = null;
            this.EquivilantInGold21 = null;
            this.Notes = "";
            Mode = enmode.addnew;
        }

        private clsBill_Payment(FindBill_PaymentDTO DTO)
        {
            this.PaymentID = DTO.PaymentID;
            this.PaymentDate = DTO.PaymentDate;
            this.TransactionID = DTO.TransactionID;
            this.TransactionInfo = clsTransactions.GetTransactionInfoByID(DTO.TransactionID);
            this.Customerinfo = clsCustomers.GetCustomerInfoByID(this.TransactionInfo.CustomerID);
            this.Currency = DTO.Currency;
            this.CurrencyAmount = DTO.CurrencyAmount;
            this.Goldkarat = DTO.Goldkarat;
            this.GoldAmount = DTO.GoldAmount;
            this.EquivilantInGold21 = DTO.EquivilantInGold21;
            this.Notes = DTO.Notes;
            Mode = enmode.update;
        }
        private clsBill_Payment(int PaymentID, DateTime PaymentDate, int TransactionID, string Currency, decimal CurrencyAmount,
            int Goldkarat, decimal GoldAmount, decimal EquivilantInGold21, string notes)
        {
            this.PaymentID = PaymentID;
            this.PaymentDate = PaymentDate;
            this.TransactionID = TransactionID;
            this.TransactionInfo = clsTransactions.GetTransactionInfoByID(TransactionID);
            this.Customerinfo = clsCustomers.GetCustomerInfoByID(this.TransactionInfo.CustomerID);
            this.Currency = Currency;
            this.CurrencyAmount = CurrencyAmount;
            this.Goldkarat = Goldkarat;
            this.GoldAmount = EquivilantInGold21;
            this.EquivilantInGold21 = EquivilantInGold21;
            this.Notes = notes;
            Mode = enmode.update;
        }

        public static DataTable GetAllBillPayments()
        {
            return clsBill_PaymentData.GetAllPayments();
        }

        public static DataTable GetAllPaymentsForCustomer(string CustomerName)
        {
            return clsBill_PaymentData.Getallbill_Payments_ForCustomer(CustomerName);
        }

        public bool AddNewPayment()
        {
            return AddNewPayment(this.AddBill_PaymentDTO);
        }

        public static bool AddNewPayment(AddBill_PaymentDTO DTO)
        {
            return clsBill_PaymentData.AddNewBillPayment(DTO) > 0;
        }

        public bool UpdatePayment()
        {
            return clsBill_PaymentData.UpdatePayment(this.UpdateBill_PaymentDTO);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enmode.addnew:
                    {
                        if (AddNewPayment())
                            return true;
                        else
                            return false;
                    }
                case enmode.update:
                    {
                        return UpdatePayment();
                    }
            }

            return false;
        }
    }
}
