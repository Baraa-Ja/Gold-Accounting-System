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
    public partial class frm_AddDelivery : Form
    {

        private clsDeliveries _Delivery;
        private int _TransactionID;  
        public frm_AddDelivery(int TransactionID)
        {
            InitializeComponent();
            _TransactionID = TransactionID;
        }

        private void frm_AddDelivery_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txttransactionID;
            rbIsCanceled.Checked = false;

            _Delivery = new clsDeliveries();
            _Delivery.TransactionID = _TransactionID;
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

            _Delivery.TransactionID = _TransactionID;
            _Delivery.DeliveryDate = DateTime.Now;

            switch (cbCurrency_Gold.Text)
            {
                case "دولار":
                    {
                        _Delivery.Currency = "USD";
                        break;
                    }
                case "ليرة سورية":
                    {
                        _Delivery.Currency = "SYP";
                        break;
                    }
                case "عيار 14":
                    {
                        _Delivery.Currency = "14";
                        break;
                    }
                case "عيار 18":
                    {
                        _Delivery.Currency = "18";
                        break;
                    }
                case "عيار 21":
                    {
                        _Delivery.Currency = "21";
                        break;
                    }
                case "عيار 22":
                    {
                        _Delivery.Currency = "22";
                        break;
                    }
                case "عيار 24":
                    {
                        _Delivery.Currency = "24";
                        break;

                    }
            }

            _Delivery.Quantity = Convert.ToDecimal(txtAmount.Text);
            //_Delivery.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            _Delivery.UnitPrice = decimal.TryParse(txtUnitPrice.Text, out var price) ? price : 0m;


            _Delivery.IsCanceled = rbIsCanceled.Checked;
            _Delivery.CanceledForDeliveryID = 0;
            _Delivery.Notes = txtNotes.Text;

            if (_Delivery.AddNewDelivery())
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
