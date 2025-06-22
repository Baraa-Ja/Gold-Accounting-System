using Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frm_TransactionBills : Form
    {
        private int _TransactionID;
        private clsBill_Payment _Payments;
        private clsBill_Receivement _Receivement;
        private DataTable _CustomersTable;
        private string _CustomerName;
        private clsTransactions _Transaction;
        public enum enmode { addnew = 0, update = 1}
        private enmode _Mode;
        public frm_TransactionBills(int TransactionID, string CustomerName, enmode Mode = enmode.addnew )
        {
            InitializeComponent();

            _TransactionID = TransactionID;
            _CustomerName = CustomerName;
            _Transaction = clsTransactions.GetTransactionInfoByID(_TransactionID);

            AttachPaintHandler(splitContainer1);
            AttachPaintHandler(splitContainer2);
            AttachPaintHandler(splitContainer3);
            AttachPaintHandler(splitContainer4);

            _Mode = Mode;
        }

        private void _LoadData()
        {

        }
        private void AttachPaintHandler(SplitContainer splitContainer)
        {
            splitContainer.Panel1.Paint += SharedSplitContainerPanel_Paint;
            splitContainer.Panel2.Paint += SharedSplitContainerPanel_Paint;
        }

        private void SharedSplitContainerPanel_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
                    Color.Black, ButtonBorderStyle.Solid);
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            _CustomersTable = clsCustomers.GetAllCustomers();
            string searchValue = txtCustomerSearch.Text.ToString();
            string searchColumn = "CustomerName";

            if (!string.IsNullOrEmpty(searchValue))
            {
                _CustomersTable.DefaultView.RowFilter = string.Format("{0} LIKE '%{1}%'", searchColumn, searchValue);

                DataView view = _CustomersTable.DefaultView;

                // Check if any match found
                if (view.Count > 0)
                {
                    // Get first match
                    string matchedName = view[0]["CustomerName"].ToString();

                    txtCustomerSearch.Text = matchedName;
                }

            }
            else
            {
                _CustomersTable.DefaultView.RowFilter = "";
            }
        }

        private void frm_TransactionBills_Load(object sender, EventArgs e)
        {
            dtpCurrentDate.Value = DateTime.Now;
            //if(_Mode == enmode.addnew)
            //{
            //    _Payments = new clsBill_Payment();
            //    _Receivement = new clsBill_Receivement();
            //}
            lblTransactionID.Text = _TransactionID.ToString();
            txtCustomerSearch.Text = _CustomerName;
        }

        private void cbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private bool CheckIfPaymentFieldsHaveValues()
        {
            //return ((!string.IsNullOrEmpty(txtGoldPaymentAmount.Text) && cbGoldTypePayment.SelectedIndex != -1) ||
            //       (!string.IsNullOrEmpty(txtCashPaymentAmount.Text);

            return txtEquivilantToType21Payment.Text != "" || (cbCurrecnyPayment.SelectedIndex != -1 && txtCurrencyAmountPayment.Text != "");
        }

        private bool CheckIfReceivementFieldsHaveValues()
        {
            //return !string.IsNullOrEmpty(txtReceivementAmount.Text) ||
            //       cmbReceivementType.SelectedIndex != -1 ||
            //       !string.IsNullOrEmpty(txtCashReceivementAmount.Text);

            return txtEquivilantToGold21Receivement.Text != "" || (cbCurrencyReceive.SelectedIndex != -1 && txtCurencyAmountReceive.Text != "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (!this.ValidateChildren())
            //{
            //    this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            //    //Here we dont continue becuase the form is not valid
            //    MessageBox.Show("بعض الحقول غير صالحة، ضع الماوس فوق الأيقونات الحمراء لرؤية الخطأ",
            //        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    return;
            //}

            bool hasPaymentData = CheckIfPaymentFieldsHaveValues();
            bool hasReceivementData = CheckIfReceivementFieldsHaveValues();
            bool Result = false;
            if (!hasPaymentData && !hasReceivementData)
            {
                MessageBox.Show("Please enter at least payment or receivement data.");
                return;
            }

            if(hasReceivementData)
            {
                _Receivement = new clsBill_Receivement();
                _Receivement.TransactionID = _TransactionID;
                _Receivement.Goldkarat = int.TryParse(cbGoldTypeReceivement.Text, out var goldkaratReceiveresult) ? goldkaratReceiveresult : (int?)null;
                _Receivement.GoldAmount = decimal.TryParse(txtGoldAmountReceive.Text, out var goldamountReceiveresult) ? goldamountReceiveresult : (decimal?)null;
                _Receivement.EquivilantInGold21 = (Convert.ToInt32(cbGoldTypeReceivement.Text) * Convert.ToDecimal(txtGoldAmountReceive.Text) / 21);
                if (cbCurrencyReceive.Text == "دولار")
                    _Receivement.Currency = "USD";
                else if (cbCurrencyReceive.Text == "ليرة سورية")
                    _Receivement.Currency = "SYP";
                _Receivement.CurrencyAmount = _Receivement.CurrencyAmount = decimal.TryParse(txtCurencyAmountReceive.Text, out var Receiveresult) ? Receiveresult : (decimal?)null;
                _Receivement.Notes = txtNotesReceive.Text;

                Result = _Receivement.Save();
            }
            
            if(hasPaymentData)
            {
                _Payments = new clsBill_Payment();
                _Payments.TransactionID = _TransactionID;
                _Payments.Goldkarat = int.TryParse(cbGoldTypePayment.Text, out var goldkaratpaymentresult) ? goldkaratpaymentresult : (int?)null;
                _Payments.GoldAmount = decimal.TryParse(txtGoldPaymentAmount.Text, out var goldamountpaymentresult) ? goldamountpaymentresult : (decimal?)null;
                if (cbCurrecnyPayment.Text == "دولار")
                    _Payments.Currency = "USD";
                else if (cbCurrecnyPayment.Text == "ليرة سورية")
                    _Payments.Currency = "SYP";
                _Payments.CurrencyAmount = decimal.TryParse(txtCurrencyAmountPayment.Text, out var Paymentresult) ? Paymentresult : (decimal?)null;
                _Payments.Notes = txtNotesPayments.Text;

                Result =  _Payments.Save();
            }

            if(Result == true)
            {
                _Mode = enmode.update;
                MessageBox.Show("تم اضافة عملية بنجاح.", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }

            //if(_Receivement.Save() && _Payments.Save())
            //{
            //    _Mode = enmode.update;
            //    MessageBox.Show("تم اضافة عملية بنجاح.", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //btnSave.Enabled = false;
            //    //btnEdit.Enabled = true;
            //    //btnDelete.Enabled = true;
            //}
            //else
            //{
            //    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            this.Close();
        }

        private void UpdateTrasnactionStatus()
        {
            decimal? TotalMoenyReceivement = null;
            decimal? TotalGoldReceivement = null;
            decimal? TotalMoenyPaid = null;
            decimal? TotalGoldPaid = null;
        }
        private void txtGoldAmountReceive_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                txtEquivilantToGold21Receivement.Text = (Convert.ToInt32(cbGoldTypeReceivement.Text) * Convert.ToDecimal(txtGoldAmountReceive.Text) / 21).ToString();
        }

        private void txtFillter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtGoldPaymentAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGoldPaymentAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtEquivilantToGold21Receivement.Text = (Convert.ToInt32(cbGoldTypeReceivement.Text) * Convert.ToDecimal(txtGoldAmountReceive.Text) / 21).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtGoldAmountReceive_Leave(object sender, EventArgs e)
        {
             txtEquivilantToGold21Receivement.Text = (Convert.ToInt32(cbGoldTypeReceivement.Text) * Convert.ToDecimal(txtGoldAmountReceive.Text) / 21).ToString();
        }

        private void txtGoldPaymentAmount_Leave(object sender, EventArgs e)
        {
                txtEquivilantToType21Payment.Text = (Convert.ToInt32(cbGoldTypePayment.Text) * Convert.ToDecimal(txtGoldPaymentAmount.Text) / 21).ToString();
        }
    }
}
