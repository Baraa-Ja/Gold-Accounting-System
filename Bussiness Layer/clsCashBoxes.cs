using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataBase_Layer;

namespace Bussiness_Layer
{
    public class clsCashBoxes
    {
        public int BoxID { get; set; }
        public string BoxName { get; set; }
        public decimal BoxBalance { get; set; }
        public DateTime Date { get; set; }

        public clsCashBoxes()
        {
            this.BoxID = 0;
            this.BoxName = "";
            this.BoxBalance = 0;
            this.Date = DateTime.Now.Date;
        }

        private clsCashBoxes(int boxID, string boxName, decimal boxBalance, DateTime Date)
        {
            this.BoxID = boxID;
            this.BoxName = boxName;
            this.BoxBalance = boxBalance;
            this.Date = Date.Date;
        }

        public static decimal GetBoxBalance(string boxName)
        {
            return clsCashBoxesData.GetCashBoxBalance(boxName);
        }

        public static decimal GetBoxBalanceInDate(string BoxName, DateTime Date = default)
        {
            if(Date == default)
                Date = DateTime.Now;
            return clsCashBoxesData.GetCashBoxBalanceInDate(BoxName, Date.Date);
        }

        public static DataTable GetBoxMovementInDate(string BoxName, DateTime Date = default)
        {
            return clsCashBoxesData.GetCashBoxMovementInDate(BoxName,Date.Date);   
        }

        public static DataTable GetBoxMovement(string BoxName)
        {
            return clsCashBoxesData.GetCashBoxMovement(BoxName);
        }
    }
}

