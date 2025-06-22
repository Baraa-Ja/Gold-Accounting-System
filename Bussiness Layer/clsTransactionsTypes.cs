using DataBase_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Layer
{
    public class clsTransactionsTypes
    {
        public int TransactionTypeID { get; set; }
        public string TransactionTypeName { get; set; }

        public clsTransactionsTypes()
        {
            this.TransactionTypeID = 0;
            this.TransactionTypeName = "";
        }

        private clsTransactionsTypes(int TransactionTypeID, string TransactionTypeName)
        {
            this.TransactionTypeID = TransactionTypeID;
            this.TransactionTypeName = TransactionTypeName;
        }

        public static clsTransactionsTypes GetTransactiontypeByID(int TransactionTypeID)
        {
            string OperationType = "";

            bool isfound = clsTransactionsTypesData.GetTransactionTypeByID(TransactionTypeID, ref OperationType);

            if(isfound)
                return new clsTransactionsTypes(TransactionTypeID, OperationType);
            else
                return null;
        }

        public static clsTransactionsTypes GetTransactionTypeInfoByName(string TransactionTypeName)
        {
            int TransactionTypeID = 0;

            bool isfound = clsTransactionsTypesData.GetTransactionTypeByName(ref TransactionTypeName, ref TransactionTypeID);

            if (isfound)
                return new clsTransactionsTypes(TransactionTypeID, TransactionTypeName);
            else
                return null;
        }
    }
}
