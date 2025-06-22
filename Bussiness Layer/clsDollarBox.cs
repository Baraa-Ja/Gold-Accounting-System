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
    public class clsDollarBox
    {
        public int ID {  get; set; }
        public int AddedValue { get; set; }
        public DateTime RecordDate { get; set; }
        public int PaymentID { get; set; }
        public int DeliveryID { get; set; }
        public string Notes { get; set; }

        public clsDollarBox()
        {
            this.ID = 0;
            this.AddedValue = 0;
            this.RecordDate = DateTime.Now;
            this.PaymentID = 0;
            this.DeliveryID = 0;
            this.Notes = "";
        }

        private clsDollarBox(int iD, DateTime recordDate, int addedValue, int PaymentID, int DeliverID, string Notes)
        {
            this.ID = iD;
            this.AddedValue = addedValue;
            this.RecordDate = recordDate;
            this.PaymentID = PaymentID;
            this.DeliveryID = DeliveryID;
            
        }

        public static int GetDollarBoxBalanceInADate(DateTime recordDate = default)
        {
            if (recordDate == default)
                recordDate = DateTime.Now;

            int Balance = clsDollarBoxData.GetDollarBalanceInADate(recordDate);
            return Balance;
        }

        public static DataTable GetDollarBoxMovementInDate(DateTime recordDate = default)
        {
            if (recordDate == default)
                recordDate = DateTime.Now;

            return clsDollarBoxData.GetDollarBoxMovementInADate(recordDate);
        }

        public static DataTable GetDollarBoxMovement()
        {
            return clsCashBoxesData.GetCashBoxMovement("USD");
        }

    }
}
