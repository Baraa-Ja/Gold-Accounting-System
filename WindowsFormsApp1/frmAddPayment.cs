using Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmAddPayment : Form
    {
        private clsPayments _payments;
        private int _TransactionID;
        public frmAddPayment(int TransactionID)
        {
            InitializeComponent();
            _TransactionID = TransactionID;
        }


        private void rbIsCanceled_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmAddPayment_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txttransactionID;
            rbIsCanceled.Checked = false;

            _payments = new clsPayments();
            _payments.TransactionID = _TransactionID;
            txttransactionID.Text = _TransactionID.ToString();
        }

        private void _ValidateEmptyComboBox(object sender, CancelEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            if (string.IsNullOrWhiteSpace(cb.Text.Trim()))
            {

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
                //e.Cancel = true;
                //Temp.Focus();
                errorProvider1.SetError(Temp, "هذا الحقل مطلوب");
            }
            else
            {
                errorProvider1.SetError(Temp, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                this.AutoValidate = AutoValidate.EnableAllowFocusChange;
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("بعض الحقول غير صالحة، ضع الماوس فوق الأيقونات الحمراء لرؤية الخطأ",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _payments.TransactionID = _TransactionID;
            _payments.PaymentDate = DateTime.Now;

            switch (cbCurrency_Gold.Text)
            {
                case "دولار":
                    {
                        _payments.Currency = "USD";
                        break;
                    }
                case "ليرة سورية":
                    {
                        _payments.Currency = "SYP";
                        break;
                    }
                case "عيار 14":
                    {
                        _payments.Currency = "14";
                        break;
                    }
                case "عيار 18":
                    {
                        _payments.Currency = "18";
                        break;
                    }
                case "عيار 21":
                    {
                        _payments.Currency = "21";
                        break;
                    }
                case "عيار 22":
                    {
                        _payments.Currency = "22";
                        break;
                    }
                case "عيار 24":
                    {
                        _payments.Currency = "24";
                        break;

                    }
            }

            _payments.Amount = Convert.ToDecimal(txtAmount.Text);
            //_payments.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            _payments.UnitPrice = decimal.TryParse(txtUnitPrice.Text, out var price) ? price : 0m;

            _payments.IsCanceled = rbIsCanceled.Checked;
            _payments.CanceledForTransactionID = 0;
            _payments.Notes = txtNotes.Text;

            if (_payments.AddNewPayment())
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
    }
}
