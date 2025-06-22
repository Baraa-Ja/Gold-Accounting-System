using DataBase_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class clsCustomerBalances
    {
        public int BalanceID { get; set; }
        public int CustomerID { get; set; }
        public decimal SYPBalance { get; set; }
        public decimal USDBalance { get; set; }
        public decimal Gold14Balance { get; set; }
        public decimal Gold18Balance { get; set; }
        public decimal Gold21Balance { get; set; }
        public decimal Gold22Balance { get; set; }
        public decimal Gold24Balance { get; set; }
        public decimal OtherCurrenciesBalance { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public clsCustomerBalances()
        {
            this.BalanceID = 0;
            this.CustomerID = 0;
            this.USDBalance = 0;
            this.SYPBalance = 0;
            this.Gold14Balance = 0;
            this.Gold18Balance = 0;
            this.Gold21Balance = 0;
            this.Gold22Balance = 0;
            this.Gold24Balance = 0;
            this.OtherCurrenciesBalance = 0;
            this.LastUpdatedDate = DateTime.Now;
        }

        private clsCustomerBalances(int BalanceID, int CustomerID, int SYPBalance, int USDBalance, decimal Gold14Balance,
            decimal Gold18Balance, decimal Gold21Balance, decimal Gold22Balance, decimal Gold24Balance, decimal OtherCurrenciesBalance,
            DateTime LastUpdatedDate)
        {
            this.BalanceID = BalanceID;
            this.CustomerID = CustomerID;
            this.SYPBalance = SYPBalance;
            this.USDBalance = USDBalance;
            this.Gold14Balance = Gold14Balance;
            this.Gold18Balance = Gold18Balance;
            this.Gold21Balance = Gold21Balance;
            this.Gold22Balance = Gold22Balance;
            this.Gold24Balance = Gold24Balance;
            this.OtherCurrenciesBalance = OtherCurrenciesBalance;
            this.LastUpdatedDate = LastUpdatedDate;
        }

        //public static clsCustomerBalances GetCustomerBalance(int CustomerID)
        //{
        //    int SYPBalance = 0, USDBalance = 0;
        //    double GoldBalance = 0;

        //    bool isfound = clsCustomerBalancesData.GetCustomerBalances(CustomerID, ref SYPBalance, ref USDBalance,
        //        ref GoldBalance);

        //    if (isfound)
        //        return new clsCustomerBalances(CustomerID, SYPBalance, USDBalance, GoldBalance);
        //    else
        //        return null;
        //}

        //public static clsCustomerBalances GetCustomerBalanceInDate(int CustomerID)
        //{
        //    int SYPBalance = 0, USDBalance = 0;
        //    decimal GoldBalance = 0;

        //    bool isfound = clsCustomerBalancesData.GetCustomerBalancesInDate(CustomerID, ref SYPBalance, ref USDBalance,
        //        ref GoldBalance);

        //    if (isfound)
        //        return new clsCustomerBalances(CustomerID, SYPBalance, USDBalance, GoldBalance);
        //    else
        //        return null;
        //}

        //public static clsCustomerBalances GetCustomerBalanceByName(string CustomerName)
        //{
        //    int SYPBalance = 0, USDBalance = 0, CustomerID = 0;
        //    double GoldBalance = 0;

        //    bool isfound = clsCustomerBalancesData.GetCustomerBalanceByName(CustomerName, ref SYPBalance,
        //        ref USDBalance, ref GoldBalance, ref CustomerID);

        //    if (isfound)
        //        return new clsCustomerBalances(CustomerID, SYPBalance, USDBalance, GoldBalance);
        //    else
        //        return null;
        //}

        public static DataTable GetCustomersBalances()
        {
            return clsCustomerBalancesData.GetCustomersBalances();
        }
    }
}
