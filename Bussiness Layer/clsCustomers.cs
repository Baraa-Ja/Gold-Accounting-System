using DataBase_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class clsCustomers
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public clsCustomers()
        {
            this.CustomerID = 0;
            this.CustomerName = "";
        }

        private clsCustomers(int CustomerID, string CustomerName)
        {
            this.CustomerID = CustomerID;
            this.CustomerName = CustomerName;
        }

        public bool AddNewCustomer()
        {
            this.CustomerID = clsCustomersData.AddNewCustomer(this.CustomerName);
            return this.CustomerID > 0;
        }

        public static clsCustomers GetCustomerInfoByID(int CustomerID)
        {
            string CustomerName = "";

            bool isfound = clsCustomersData.GetCustomerInfoByID(CustomerID, ref CustomerName);

            if (isfound)
                return new clsCustomers(CustomerID, CustomerName);
            else
                return null;
        }

        public static clsCustomers GetCustmerInfoByName(string Name)
        {
            int CustomerID = 0;
            
            bool isfound = clsCustomersData.GetCustomerInfoByName(ref CustomerID, ref Name);

            if(isfound)
                return new clsCustomers(CustomerID, Name);
            else 
                return null;

        }

        public static DataTable GetAllCustomers()
        {
            return clsCustomersData.GetAllCustomers();
        }
    }
}
