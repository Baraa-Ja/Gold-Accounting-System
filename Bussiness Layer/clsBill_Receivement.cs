using DataBase_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class clsBill_Receivement
    {
        public enum enmode { addnew = 0, update = 1 }
        public enmode Mode;
        public int ReceiveID { get; set; }
        public DateTime ReceiveDate { get; set; }
        public int TransactionID { get; set; }
        public clsTransactions TransactionInfo { get; set; }
        public clsCustomers Customerinfo { get; set; }
        public string Currency { get; set; }
        public decimal? CurrencyAmount { get; set; }
        public int ?Goldkarat { get; set; }
        public decimal ?GoldAmount { get; set; }
        public decimal ?EquivilantInGold21 { get; set; }
        public string Notes { get; set; }
        public FindReceivementDTO FindReceivementDTO => new FindReceivementDTO(this.ReceiveID, this.ReceiveDate, this.TransactionID,
            this.Currency, this.CurrencyAmount, this.Goldkarat, this.GoldAmount, this.EquivilantInGold21, this.Notes);

        public AddReceivementDTO AddReceivementDTO => new AddReceivementDTO(this.TransactionID, this.Currency,
            this.CurrencyAmount, this.Goldkarat, this.GoldAmount, this.Notes);

        public UpdateReceivementDTO UpdateReceivementDTO => new UpdateReceivementDTO(this.ReceiveID, this.ReceiveDate,
            this.Currency, this.CurrencyAmount, this.Goldkarat, this.GoldAmount, this.Notes);
        public clsBill_Receivement()
        {
            this.ReceiveID = 0;
            this.ReceiveDate = DateTime.Now;
            this.TransactionID = 0;
            this.Currency = "";
            this.CurrencyAmount = null;
            this.Goldkarat = null;
            this.GoldAmount = null;
            this.EquivilantInGold21 = null;
            this.Notes = "";
            Mode = enmode.addnew;
        }

        private clsBill_Receivement(FindReceivementDTO DTO)
        {
            this.ReceiveID = DTO.ReceivementID;
            this.ReceiveDate = DTO.ReceivementDate;
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
        private clsBill_Receivement(int ReceiveID, DateTime ReceiveDate, int TransactionID, string Currency, decimal CurrencyAmount,
            int Goldkarat, decimal GoldAmount, decimal EquivilantInGold21, string notes)
        {
            this.ReceiveID = ReceiveID;
            this.ReceiveDate = ReceiveDate;
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

        public static DataTable GetAllReceivements()
        {
            return clsBill_ReceivementData.GetAllReceivements();
        }

        public static DataTable GetAllReceivementsForCustomer(string CustomerName)
        {
            return clsBill_ReceivementData.GetAllReceivementsForCustomer(CustomerName);
        }

        public bool AddNewReceivemen()
        {
            return AddNewReceivemen(this.AddReceivementDTO);
        }

        public static bool AddNewReceivemen(AddReceivementDTO DTO)
        {
            return clsBill_ReceivementData.AddNewReceivemen(DTO) > 0;
        }

        public bool UpdateReceivement()
        {
            return clsBill_ReceivementData.UpdateReceivement(this.UpdateReceivementDTO);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enmode.addnew:
                    {
                        if(AddNewReceivemen())
                        {
                            Mode = enmode.update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enmode.update:
                    {
                        return UpdateReceivement();
                    }
            }

            return false;
        }
    }
}
