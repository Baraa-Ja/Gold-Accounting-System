using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase_Layer;

namespace Bussiness_Layer
{
    public class clsTransactions
    {
        public enum enstatus { Pending = 1, Completed = 2}
        public enstatus Status;

        public enum enMode { Addnew = 0, Update = 1}
        public enMode Mode;
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionTypeID { get; set; }
        public clsTransactionsTypes TransactionTypeinfo { get; set; }
        public int CustomerID   { get; set; }
        public clsCustomers CustomerInfo { get; set; }
        public string Currency { get; set; }
        //clsCurrencies CurrencyInfo { get; set; }
        public decimal Quantity  { get; set; }
        public decimal UnitPrice { get; set; }
        public string CurrencyToGive {  get; set; }
        public decimal EquivilantToGold21 { get; set; }
        public decimal TotalAmount { get; set; }
        public int StatusID { get; set; }
        public string Notes { get; set; }
        public bool IsCanceled { get; set; }
        public int CanceledForTransactionID { get; set; }
        public FindTransactionDTO FindingTransactionDTO { get {
                return new FindTransactionDTO(this.TransactionID, this.TransactionDate,
            this.TransactionTypeID, this.CustomerID, this.Currency, this.Quantity, this.UnitPrice, this.CurrencyToGive,
            this.EquivilantToGold21, this.TotalAmount, this.StatusID, this.Notes, this.IsCanceled, this.CanceledForTransactionID);
            } }

        public AddingTransactionDTO AddTranscationDTO { get {
                return new AddingTransactionDTO(this.TransactionTypeID, this.CustomerID,
            this.Currency, this.Quantity, this.UnitPrice, this.CurrencyToGive, this.Notes, this.IsCanceled, this.CanceledForTransactionID);
            } }


        public clsTransactions()
        {
            this.TransactionID = 0;
            this.TransactionDate = DateTime.Now;
            this.TransactionTypeID = 0;
            this.CustomerID = 0;
            this.Currency = "";
            this.Quantity = 0;
            this.UnitPrice = 0;
            this.CurrencyToGive = "";
            this.EquivilantToGold21 = 0;
            this.TotalAmount = 0;
            this.StatusID = 1;
            this.Notes = "";
            this.IsCanceled = false;
            this.CanceledForTransactionID = 0;

            Mode = enMode.Addnew;
            Status = enstatus.Pending;
        }

        private clsTransactions(int TransactionID, DateTime TransactionDate, int TransactionTypeID, int CustomerID, string Currency,
            decimal Quantity, decimal UnitPrice, string CurrencyToGive, decimal EquivilantToGold21, decimal TotalAmount,
            int StatusID, string Notes, bool Iscanceled, int CanceledForTransactionID)
        {
            this.TransactionID = TransactionID;
            this.TransactionDate = TransactionDate;
            this.TransactionTypeID = TransactionTypeID;
            this.TransactionTypeinfo = clsTransactionsTypes.GetTransactiontypeByID(TransactionTypeID);
            this.CustomerID = CustomerID;
            this.CustomerInfo = clsCustomers.GetCustomerInfoByID(CustomerID);
            this.Currency = Currency;
            //this.CurrencyInfo = clsCurrencies.FindCurrencyByID(CurrencyID);
            this.Quantity = Quantity;
            this.UnitPrice = UnitPrice;
            this.CurrencyToGive = CurrencyToGive;
            this.EquivilantToGold21 = EquivilantToGold21;
            this.TotalAmount = TotalAmount;
            this.StatusID = StatusID;
            this.Notes = Notes;
            this.IsCanceled = IsCanceled;
            this.CanceledForTransactionID = CanceledForTransactionID;
            Mode = enMode.Update;
        }

        private clsTransactions(FindTransactionDTO TransDTO)
        {
            this.TransactionID = TransDTO.TransactionID;
            this.TransactionDate = TransDTO.TransactionDate;
            this.TransactionTypeID = TransDTO.TransactionTypeID;
            this.TransactionTypeinfo = clsTransactionsTypes.GetTransactiontypeByID(TransactionTypeID);
            this.CustomerID = TransDTO.CustomerID;
            this.CustomerInfo = clsCustomers.GetCustomerInfoByID(CustomerID);
            this.Currency = TransDTO.Currency;
            this.Quantity = TransDTO.Quantity;
            this.UnitPrice = TransDTO.UnitPrice;
            this.CurrencyToGive = TransDTO.CurrencyToGive;
            this.EquivilantToGold21 = (decimal)TransDTO.EquivilantToGold21;
            this.TotalAmount = (decimal)TransDTO.TotalAmount;
            this.StatusID = TransDTO.StatusID;
            this.Notes = TransDTO.Notes;

            Mode = enMode.Update;
        }

        public static clsTransactions GetTransactionInfoByID(int TransactionID)
        {
            FindTransactionDTO TrasDTO = clsTransactionsData.GetTransactionInfoByID(TransactionID);

            if(TrasDTO != null)
            {
                return new clsTransactions(TrasDTO);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllTransactions()
        {
            return clsTransactionsData.GetAllTransactions();
        }

        public static DataTable GetAllTransactionsFiltered()
        {
            return clsTransactionsData.GetAllTransactionsFiltered();
        }

        public bool AddNewTransaction()
        {
            return AddNewTransaction(this.AddTranscationDTO);
        }

        public static bool AddNewTransaction(AddingTransactionDTO DTO)
        {
            int TransactionID = clsTransactionsData.AddNewTransaction(DTO);
            return TransactionID > 0;
        }
    }
}
