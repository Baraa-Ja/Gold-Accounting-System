using Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frm_AddNewTransaction : Form
    {
        private clsTransactions _Transaction;
        public frm_AddNewTransaction()
        {
            InitializeComponent();

        }

        private void LoadCustomersName()
        {
            DataTable CustomersTable = clsCustomers.GetAllCustomers();

            foreach(DataRow row in  CustomersTable.Rows)
            {
                cbCustomerName.Items.Add(row["CustomerName"]);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void _ValidateEmptyComboBox(object sender, CancelEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            if (string.IsNullOrWhiteSpace(cb.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(cb, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider1.SetError(cb, "");
            }
        }


        private void _ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(Temp.Text.Trim()))
            {
                e.Cancel = true;
                //Temp.Focus();
                errorProvider1.SetError(Temp, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider1.SetError(Temp, "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("بعض الحقول غير صالحة، ضع الماوس فوق الأيقونات الحمراء لرؤية الخطأ",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
                _Transaction.TransactionDate = DateTime.Now;

                switch (cbTransactionType.Text)
                {
                    case "شراء":
                        {
                            _Transaction.TransactionTypeID = clsTransactionsTypes.GetTransactionTypeInfoByName("شراء").TransactionTypeID;
                            break;
                        }
                    case "بيع":
                        {
                            _Transaction.TransactionTypeID = clsTransactionsTypes.GetTransactionTypeInfoByName("بيع").TransactionTypeID;
                            break;
                        }
                    case "صرافة":
                        {
                            _Transaction.TransactionTypeID = clsTransactionsTypes.GetTransactionTypeInfoByName("صرافة").TransactionTypeID;
                            break;
                        }
                }

                _Transaction.CustomerID = clsCustomers.GetCustmerInfoByName(cbCustomerName.Text).CustomerID;

                switch (cbCurrency_Gold.Text)
                {
                    case "دولار":
                        {
                            _Transaction.Currency = "USD";
                            break;
                        }
                    case "ليرة سورية":
                        {
                            _Transaction.Currency = "SYP";
                            break;
                        }
                    case "عيار 14":
                        {
                            _Transaction.Currency = "14";
                            break;
                        }
                    case "عيار 18":
                        {
                            _Transaction.Currency = "18";
                            break;
                        }
                    case "عيار 21":
                        {
                            _Transaction.Currency = "21";
                            break;
                        }
                    case "عيار 22":
                        {
                            _Transaction.Currency = "22";
                            break;
                        }
                    case "عيار 24":
                        {
                            _Transaction.Currency = "24";
                            break;

                        }
                }

                _Transaction.Quantity = Convert.ToDecimal(txtAmount.Text);
                _Transaction.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);

                switch (cbCurrecnyToGive.Text)
                {
                    case "دولار":
                        {
                            _Transaction.CurrencyToGive = "USD";
                            break;
                        }
                    case "ليرة سورية":
                        {
                            _Transaction.CurrencyToGive = "SYP";
                            break;
                        }
                    case "عيار 14":
                        {
                            _Transaction.CurrencyToGive = "14";
                            break;
                        }
                    case "عيار 18":
                        {
                            _Transaction.CurrencyToGive = "18";
                            break;
                        }
                    case "عيار 21":
                        {
                            _Transaction.CurrencyToGive = "21";
                            break;
                        }
                    case "عيار 22":
                        {
                            _Transaction.CurrencyToGive = "22";
                            break;
                        }
                    case "عيار 24":
                        {
                            _Transaction.CurrencyToGive = "24";
                            break;

                        }
                }

                _Transaction.IsCanceled = rbIsCanceled.Checked;
                _Transaction.CanceledForTransactionID = 0;
                _Transaction.Notes = txtNotes.Text;

                if (_Transaction.AddNewTransaction())
                {
                    MessageBox.Show("تم اضافة عملية بنجاح.", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Close();
            }


        private void frm_AddNewTransaction_Load(object sender, EventArgs e)
        {
            this.ActiveControl = cbTransactionType;
            rbIsCanceled.Checked = false;
            LoadCustomersName();

            _Transaction = new clsTransactions();

        }

        private void frm_AddNewTransaction_Activated(object sender, EventArgs e)
        {
            
        }
    }
}
