using DataBase_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class clsSyrianBox
    {
        public int ID { get; set; }
        public int AddedValue { get; set; }
        public DateTime RecordDate { get; set; }

        public int PaymentID { get; set; }
        public int DeliveryID { get; set; }
        public string Notes { get; set; }

        public clsSyrianBox()
        {
            this.ID = 0;
            this.AddedValue = 0;
            this.RecordDate = DateTime.Now;
            this.PaymentID = 0;
            this.DeliveryID = 0;
            this.Notes = "";
        }

        private clsSyrianBox(int iD, int addedValue, DateTime recordDate, int paymentid, int deliveryid, string notes)
        {
            this.ID = iD;
            this.AddedValue = addedValue;
            this.RecordDate = recordDate;
            this.PaymentID = paymentid;
            this.DeliveryID = deliveryid;
            this.Notes = notes;
        }

        public static int GetSyrianBoxBalance()
        {
            int Balance = clsSyrianBoxData.GetSyrianBoxBalance();
            return Balance;
        }

        public static int GetSyrianBoxBalanceInADate(DateTime recordDate = default)
        {
            if (recordDate == default)
                recordDate = DateTime.Now;

            int Balance = clsSyrianBoxData.GetSyrianBalanceInADate(recordDate);
            return Balance;
        }

        public static DataTable GetSyiranBoxMovementInDate(DateTime recordDate = default)
        {
            if (recordDate == default)
                recordDate = DateTime.Now;

            return clsSyrianBoxData.GetSyrianBoxMovementInADate(recordDate);
        }

        public static DataTable GetSyrianBoxMovement()
        {
            return clsCashBoxes.GetBoxMovement("SYP");
        }

    }
}
