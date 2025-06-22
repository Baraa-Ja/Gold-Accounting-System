using DataBase_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class clsGoldVaults
    {
        public int ID { get; set; }
        public DateTime RecordDate { get; set; }
        public decimal AddedAmount { get; set; }
        public int EquivalentToGold21 {  get; set; }
        public int PaymentID { get; set; }
        public int DeliveryID { get; set; }
        public clsGoldVaults()
        {
            this.ID = ID;
            this.AddedAmount = 0;
            this.RecordDate = DateTime.Now;
            this.EquivalentToGold21 = 0;
            this.PaymentID = 0;
            this.DeliveryID = 0;
        }

        private clsGoldVaults(int iD, decimal AddedAmount, DateTime recordDate, int EquivalentToGold21, int PaymentID,
            int DeliveryID)
        {
            this.ID = iD;
            this.RecordDate = recordDate;
            this.AddedAmount = AddedAmount;
            this.EquivalentToGold21 = EquivalentToGold21;
            this.PaymentID = PaymentID;
            this.DeliveryID = DeliveryID;
        }

        public static decimal GetGoldAmountByType(int GoldType = 21)
        {
            decimal Amount = clsGoldVaultsData.GetGoldAmountByType(GoldType);
            return Amount;
        }
        public static decimal GetGoldBoxAmountInADate(int GoldType = 21, DateTime Date = default)
        {
            if (Date == default)
                Date = DateTime.Now;

            decimal Amount = clsGoldVaultsData.GetGoldAmountInADate(Date, GoldType);
            return Amount;
        }

        public static DataTable GetGoldTypeMovement(int goldType)
        {
            return clsGoldVaultsData.GetGoldTypeMovement(goldType);
        }
        public static DataTable GetGoldBoxMovementInADate(int GoldType = 21, DateTime date = default)
        {
            if (date == default)
                date = DateTime.Now;

            return clsGoldVaultsData.GetGoldBoxMovementInADate(date, GoldType);
        }

        public static DataTable GetAllGoldTypesMovement()
        {
            return clsGoldVaultsData.GetAllGoldTypesMovement();
        }
    }
}

