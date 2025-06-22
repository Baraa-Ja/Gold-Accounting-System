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
    public partial class frm_Customers : Form
    {
        public frm_Customers()
        {
            InitializeComponent();
        }

        private DataTable _CustomersBalancesTable = clsCustomerBalances.GetCustomersBalances();
        private void _Refresh()
        {
            {
                dgvCustomers.RowTemplate.Height = 40; // sets default row height
                dgvCustomers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

                _CustomersBalancesTable = clsCustomerBalances.GetCustomersBalances();
                dgvCustomers.DataSource = _CustomersBalancesTable;
                cbFilterBy.SelectedIndex = 0;
                lblRecordsCount.Text = dgvCustomers.Rows.Count.ToString();

                if (dgvCustomers.Rows.Count > 0)
                {
                    dgvCustomers.Columns[2].DefaultCellStyle.Format = "N2";

                    dgvCustomers.Columns[3].DefaultCellStyle.Format = "N2";
                    dgvCustomers.Columns[4].DefaultCellStyle.Format = "N2";
                    dgvCustomers.Columns[5].DefaultCellStyle.Format = "N2";
                    dgvCustomers.Columns[6].DefaultCellStyle.Format = "N2";
                    dgvCustomers.Columns[7].DefaultCellStyle.Format = "N2";
                    dgvCustomers.Columns[8].DefaultCellStyle.Format = "N2";
                    dgvCustomers.Columns[9].DefaultCellStyle.Format = "N2";


                    dgvCustomers.Columns[0].HeaderText = "الرقم التسلسلي";
                    dgvCustomers.Columns[0].Width = 100;


                    dgvCustomers.Columns[1].HeaderText = "اسم الزبون";
                    dgvCustomers.Columns[1].Width = 150;


                    dgvCustomers.Columns[2].HeaderText = "رصيد سوري";
                    dgvCustomers.Columns[2].Width = 100;


                    dgvCustomers.Columns[3].HeaderText = "رصيد دولار";
                    dgvCustomers.Columns[3].Width = 150;


                    dgvCustomers.Columns[4].HeaderText = "رصيد 14";
                    dgvCustomers.Columns[4].Width = 150;


                    dgvCustomers.Columns[5].HeaderText = "رصيد 18";
                    dgvCustomers.Columns[5].Width = 100;


                    dgvCustomers.Columns[6].HeaderText = "رصيد 21";
                    dgvCustomers.Columns[6].Width = 100;

                    dgvCustomers.Columns[7].HeaderText = "رصيد 22";
                    dgvCustomers.Columns[7].Width = 400;

                    dgvCustomers.Columns[8].HeaderText = "رصيد 24";
                    dgvCustomers.Columns[8].Width = 400;

                    dgvCustomers.Columns[9].HeaderText = "رصيد عملات اخرى";
                    dgvCustomers.Columns[9].Width = 400;

                    dgvCustomers.Columns[10].HeaderText = "تاريخ اخر تعديل";
                    dgvCustomers.Columns[10].Width = 400;

                }
            }
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfilter.Visible = cbFilterBy.Text != "لاشيء";
            dtpFilter.Visible = cbFilterBy.Text == "تاريخ أخر تعديل";
            if (cbFilterBy.Text == "تاريخ أخر تعديل")
            {
                txtfilter.Visible = false;
                dtpFilter.Visible = true;
            }

            if (txtfilter.Visible)
            {
                txtfilter.Text = "";
                txtfilter.Focus();
            }

            if (dtpFilter.Visible == false)
                _CustomersBalancesTable.DefaultView.RowFilter = "";

        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            clsCustomers Customer = clsCustomers.GetCustmerInfoByName(txtfilter.Text);

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "الرقم التسلسلي":
                    FilterColumn = "BalanceID";
                    break;

                case "اسم الزبون":
                    FilterColumn = "CustomerName";
                    break;

                case "رصيد سوري":
                    FilterColumn = "SYPBalance";
                    break;

                case "رصيد دولار":
                    FilterColumn = "USDBalance";
                    break;

                case "رصيد ذهب 14":
                    FilterColumn = "Gold14Balance";
                    break;

                case "رصيد ذهب 18":
                    FilterColumn = "Gold18Balance";
                    break;

                case "رصيد ذهب 21":
                    FilterColumn = "Gold21Balance";
                    break;

                case "رصيد ذهب 22":
                    FilterColumn = "Gold22Balance";
                    break;

                case "رصيد ذهب 24":
                    FilterColumn = "Gold24Balance";
                    break;

                case "رصيد عملات اخرى":
                    FilterColumn = "OtherCurrenciesBalance";
                    break;

                case "تاريخ أخر تعديل":
                    FilterColumn = "LastUpdatedDate";
                    break;

                default:
                    FilterColumn = "لاشيء";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtfilter.Text.Trim() == "" || FilterColumn == "لاشيء")
            {
                _CustomersBalancesTable.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvCustomers.Rows.Count.ToString();

                return;
            }
            else if(FilterColumn == "CustomerName")
            {
                if (Customer == null)
                    _CustomersBalancesTable.DefaultView.RowFilter = "";
                else
                    _CustomersBalancesTable.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, Customer.CustomerName.ToString());
            }

            else if (FilterColumn == "BalanceID" || FilterColumn == "SYPBalance"
                || FilterColumn == "USDBalance" || FilterColumn == "Gold14Balance" || FilterColumn == "Gold18Balance"||
                FilterColumn == "Gold21Balance" || FilterColumn == "Gold22Balance" || FilterColumn == "Gold24Balance"||
                FilterColumn == "OtherCurrenciesBalance")
            {
                _CustomersBalancesTable.DefaultView.RowFilter = string.Format("Convert([{0}], 'System.String') LIKE '{1}%'", FilterColumn, txtfilter.Text.ToString().Trim());
            }
            else if (FilterColumn == "LastUpdatedDate")
            {
                _CustomersBalancesTable.DefaultView.RowFilter = string.Format("[{0}] = #{1}#", FilterColumn, dtpFilter.Value.ToString("MM/dd/yyyy"));
            }
        }

        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpFilter.Value.Date;

            _CustomersBalancesTable.DefaultView.RowFilter = string.Format(
                "[{0}] >= #{1}# AND [{0}] < #{2}#",
                "LastUpdatedDate",
                selectedDate.ToString("MM/dd/yyyy"),
                selectedDate.AddDays(1).ToString("MM/dd/yyyy")
            );
        }

        private void cbBalances_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal Balance = 0;

            switch (cbBalances.Text)
            {
                case "رصيد سوري":
                    Balance = dgvCustomers.Rows
                         .Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow && row.Cells["SYPBalance"].Value != DBNull.Value)
                         .Sum(row => Convert.ToDecimal(row.Cells["SYPBalance"].Value));
                    lblBalance.Text = Balance.ToString("F2");
                    break;

                case "رصيد دولار":
                    Balance = dgvCustomers.Rows
                         .Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow && row.Cells["USDBalance"].Value != DBNull.Value)
                         .Sum(row => Convert.ToDecimal(row.Cells["USDBalance"].Value));
                    lblBalance.Text = Balance.ToString("F2");
                    break;

                case "رصيد ذهب 14":
                    Balance = dgvCustomers.Rows
                         .Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow && row.Cells["Gold14Balance"].Value != DBNull.Value)
                         .Sum(row => Convert.ToDecimal(row.Cells["Gold14Balance"].Value));
                    lblBalance.Text = Balance.ToString("F2");
                    break;

                case "رصيد ذهب 18":
                    Balance = dgvCustomers.Rows
                         .Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow && row.Cells["Gold18Balance"].Value != DBNull.Value)
                         .Sum(row => Convert.ToDecimal(row.Cells["Gold18Balance"].Value));
                    lblBalance.Text = Balance.ToString("F2");
                    break;

                case "رصيد ذهب 21":
                    Balance = dgvCustomers.Rows
                         .Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow && row.Cells["Gold21Balance"].Value != DBNull.Value)
                         .Sum(row => Convert.ToDecimal(row.Cells["Gold21Balance"].Value));
                    lblBalance.Text = Balance.ToString("F2");
                    break;

                case "رصيد ذهب 22":
                    Balance = dgvCustomers.Rows
                         .Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow && row.Cells["Gold22Balance"].Value != DBNull.Value)
                         .Sum(row => Convert.ToDecimal(row.Cells["Gold22Balance"].Value));
                    lblBalance.Text = Balance.ToString("F2");
                    break;

                case "رصيد ذهب 24":
                    Balance = dgvCustomers.Rows
                         .Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow && row.Cells["Gold24Balance"].Value != DBNull.Value)
                         .Sum(row => Convert.ToDecimal(row.Cells["Gold24Balance"].Value));
                    lblBalance.Text = Balance.ToString("F2");
                    break;

                case "رصيد مكافئ 21":
                    Balance = dgvCustomers.Rows
                         .Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow && row.Cells[""].Value != DBNull.Value)
                         .Sum(row => Convert.ToDecimal(row.Cells[""].Value));
                    lblBalance.Text = Balance.ToString("F2");
                    break;

                case "رصيد عملات اخرى":
                    Balance = dgvCustomers.Rows
                         .Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow && row.Cells["OtherCurrenciesBalance"].Value != DBNull.Value)
                         .Sum(row => Convert.ToDecimal(row.Cells["OtherCurrenciesBalance"].Value));
                    lblBalance.Text = Balance.ToString("F2");
                    break;

            }
        }

        private void frm_Customers_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void txtfilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text == "الرقم التسلسلي" || cbFilterBy.Text == "رصيد سوري" || cbFilterBy.Text == "رصيد عملات اخرى" ||
                cbFilterBy.Text == "رصيد دولار" || cbFilterBy.Text == "رصيد ذهب 14" || cbFilterBy.Text == "رصيد ذهب 18" ||
                cbFilterBy.Text == "رصيد ذهب 21" || cbFilterBy.Text == "رصيد ذهب 22" || cbFilterBy.Text == "رصيد ذهب 24"||
                cbFilterBy.Text == "رصيد عملات اخرى")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddNewTransaction_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer frm = new frmAddEditCustomer();
            frm.ShowDialog();
        }
    }
}
