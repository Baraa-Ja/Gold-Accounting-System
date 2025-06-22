using DataBase_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class clsCurrencies
    {
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }

        public clsCurrencies()
        {
            this.CurrencyID = -1;
            this.CurrencyName = "";
        }

        public clsCurrencies(int CurrencyID, string CurrencyName)
        {
            this.CurrencyID = CurrencyID;
            this.CurrencyName = CurrencyName;
        }
        public static clsCurrencies FindCurrencyByID(int id)
        {
            string CurrencyName = "";
            bool IsFound = clsCurrenciesData.GetCurrencyByID(id, ref CurrencyName);

            if (IsFound == true)
                return new clsCurrencies(id, CurrencyName);
            else
                return null;
        }

        public bool AddNewCurrency()
        {
            this.CurrencyID = clsCurrenciesData.AddNewCurrency(this.CurrencyName);
            return this.CurrencyID > 0;
        }
    }
}
