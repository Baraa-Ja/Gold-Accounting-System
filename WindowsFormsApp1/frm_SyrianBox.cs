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
    public partial class frm_SyrianBox : Form
    {
        private int Sum = 0;
        public frm_SyrianBox()
        {
            InitializeComponent();
        }

        private DataTable _SyrianBoxDataTable = clsSyrianBox.GetSyrianBoxMovement();

        private void _Refresh()
        {
            dgvSyrianBox.RowTemplate.Height = 40; // sets default row height
            dgvSyrianBox.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgvSyrianBox.DataSource = _SyrianBoxDataTable;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvSyrianBox.Rows.Count.ToString();
            int Sum = dgvSyrianBox.Rows
                          .Cast<DataGridViewRow>()
                          .Where(row => !row.IsNewRow && row.Cells["AddedValue"].Value != DBNull.Value)
                          .Sum(row => Convert.ToInt32(row.Cells["AddedValue"].Value));
            lblBalance.Text = Sum.ToString();

            if (dgvSyrianBox.Rows.Count > 0)
            {

                dgvSyrianBox.Columns[0].HeaderText = "ID";
                dgvSyrianBox.Columns[0].Width = 100;

                dgvSyrianBox.Columns[1].HeaderText = "التاريخ";
                dgvSyrianBox.Columns[1].Width = 150;
                //dgvSyrianBox.Rows[1].Height = 30;

                dgvSyrianBox.Columns[2].HeaderText = "القيمة المضافة";
                dgvSyrianBox.Columns[2].Width = 150;
                //dgvSyrianBox.Rows[2].Height = 30;

                dgvSyrianBox.Columns[3].HeaderText = "تابع للدفعة رقم";
                dgvSyrianBox.Columns[3].Width = 150;
                //dgvSyrianBox.Rows[3].Height = 30;

                dgvSyrianBox.Columns[4].HeaderText = "تابع للقبضة رقم";
                dgvSyrianBox.Columns[4].Width = 150;
                //dgvSyrianBox.Rows[4].Height = 30;

                dgvSyrianBox.Columns[5].HeaderText = "الملاحظات";
                dgvSyrianBox.Columns[5].Width = 400;

            }
        }

        private void frm_SyrianBox_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void cbFilterBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtfilter.Visible = cbFilterBy.Text != "لاشيء";
            dtpFilter.Visible = cbFilterBy.Text == "التاريخ";
            if (cbFilterBy.Text == "التاريخ")
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
                _SyrianBoxDataTable.DefaultView.RowFilter = "";

            Sum = dgvSyrianBox.Rows
                         .Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow && row.Cells["AddedValue"].Value != DBNull.Value)
                         .Sum(row => Convert.ToInt32(row.Cells["AddedValue"].Value));
            lblBalance.Text = Sum.ToString();
        }

        private void txtfilter_TextChanged_1(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "الرقم التسلسلي":
                    FilterColumn = "ID";
                    break;
                case "التاريخ":
                    FilterColumn = "RecordDate";
                    break;

                case "القيمة المضافة":
                    FilterColumn = "AddedValue";
                    break;


                case "رقم الدفعة":
                    FilterColumn = "PaymentID";
                    break;

                case "رقم القبضة":
                    FilterColumn = "ID";
                    break;

                case "الملاحظات":
                    FilterColumn = "Notes";
                    break;
                default:
                    FilterColumn = "لاشيء";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtfilter.Text.Trim() == "" || FilterColumn == "لاشيء")
            {
                _SyrianBoxDataTable.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvSyrianBox.Rows.Count.ToString();
                Sum = dgvSyrianBox.Rows
                          .Cast<DataGridViewRow>()
                          .Where(row => !row.IsNewRow && row.Cells["AddedValue"].Value != DBNull.Value)
                          .Sum(row => Convert.ToInt32(row.Cells["AddedValue"].Value));
                lblBalance.Text = Sum.ToString();
                return;
            }

            if (FilterColumn == "ID" || FilterColumn == "PaymentID" || FilterColumn == "DeliveryID" || FilterColumn == "AddedValue")
            {
                _SyrianBoxDataTable.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtfilter.Text.Trim());
            }
            else if (FilterColumn == "RecordDate")
            {
                _SyrianBoxDataTable.DefaultView.RowFilter = string.Format("[{0}] = #{1}#", FilterColumn, dtpFilter.Value.ToString("MM/dd/yyyy"));
            }
            else
            {
                _SyrianBoxDataTable.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtfilter.Text.Trim());
            }


            lblRecordsCount.Text = dgvSyrianBox.Rows.Count.ToString();
            Sum = dgvSyrianBox.Rows
                                     .Cast<DataGridViewRow>()
                                     .Where(row => !row.IsNewRow && row.Cells["AddedValue"].Value != DBNull.Value)
                                     .Sum(row => Convert.ToInt32(row.Cells["AddedValue"].Value));
            lblBalance.Text = Sum.ToString();
        }

        private void dtpFilter_ValueChanged_1(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpFilter.Value.Date;

            _SyrianBoxDataTable.DefaultView.RowFilter = string.Format(
                "[{0}] >= #{1}# AND [{0}] < #{2}#",
                "RecordDate",
                selectedDate.ToString("MM/dd/yyyy"),
                selectedDate.AddDays(1).ToString("MM/dd/yyyy")
            );

            Sum = dgvSyrianBox.Rows
                         .Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow && row.Cells["AddedValue"].Value != DBNull.Value)
                         .Sum(row => Convert.ToInt32(row.Cells["AddedValue"].Value));
            lblBalance.Text = Sum.ToString();
        }

        private void txtfilter_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "الرقم التسلسلي" || cbFilterBy.Text == "القيمة المضافة" || cbFilterBy.Text == "رقم الدفعة" ||
    cbFilterBy.Text == "رقم القبضة")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
