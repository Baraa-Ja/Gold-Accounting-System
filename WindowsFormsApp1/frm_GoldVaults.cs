using Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frm_GoldVaults : Form
    {
        public frm_GoldVaults()
        {
            InitializeComponent();
        }
        private decimal TotalAmount = 0;
        private DataTable _GoldVaultsDatatable = clsGoldVaults.GetAllGoldTypesMovement();

        private void _Refresh()
        {
            dgvGoldTypes.RowTemplate.Height = 40; // sets default row height
            dgvGoldTypes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;


            dgvGoldTypes.DataSource = _GoldVaultsDatatable;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvGoldTypes.Rows.Count.ToString();
            TotalAmount = dgvGoldTypes.Rows
                          .Cast<DataGridViewRow>()
                          .Where(row => !row.IsNewRow && row.Cells["EquivalentToGold21"].Value != DBNull.Value)
                          .Sum(row => Convert.ToDecimal(row.Cells["EquivalentToGold21"].Value));
            lblBalance.Text = TotalAmount.ToString("F2");

            if (dgvGoldTypes.Rows.Count > 0)
            {
                dgvGoldTypes.Columns[3].DefaultCellStyle.Format = "N2";
                dgvGoldTypes.Columns[4].DefaultCellStyle.Format = "N2";



                dgvGoldTypes.Columns[0].HeaderText = "الرقم التسلسلي";
                dgvGoldTypes.Columns[0].Width = 100;


                dgvGoldTypes.Columns[1].HeaderText = "التاريخ";
                dgvGoldTypes.Columns[1].Width = 200;


                dgvGoldTypes.Columns[2].HeaderText = "نوع الذهب";
                dgvGoldTypes.Columns[2].Width = 120;


                dgvGoldTypes.Columns[3].HeaderText = "القيمة المضافة";
                dgvGoldTypes.Columns[3].Width = 150;


                dgvGoldTypes.Columns[4].HeaderText = "القيمة المكافأة للعيار 21";
                dgvGoldTypes.Columns[4].Width = 180;


                dgvGoldTypes.Columns[5].HeaderText = "تابع للدفعة رقم";
                dgvGoldTypes.Columns[5].Width = 100;


                dgvGoldTypes.Columns[6].HeaderText = "تابع للقبضة رقم";
                dgvGoldTypes.Columns[6].Width = 100;

                dgvGoldTypes.Columns[7].HeaderText = "الملاحظات";
                dgvGoldTypes.Columns[7].Width = 400;

            }
        }

        private void dgvDollarBox_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvGoldTypes.Columns[e.ColumnIndex].Name == "AddedAmount") // <- change to your actual column name
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    if (val < 0)
                        e.CellStyle.ForeColor = Color.Red;
                    else if (val > 0)
                        e.CellStyle.ForeColor = Color.Green;
                }
            }
        }

        private void frm_GoldVaults_Load(object sender, EventArgs e)
        {
            var dgv = dgvGoldTypes;

            dgv.Font = new Font("Segoe UI", 11);
            dgv.RowTemplate.Height = 60;
            dgv.DefaultCellStyle.Padding = new Padding(0, 10, 0, 0); // Top padding

            dgv.EnableHeadersVisualStyles = false;

            // Header styling
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.ColumnHeadersHeight = 50;

            // Zebra striping
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgv.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // LightGray
            dgv.RowsDefaultCellStyle.ForeColor = Color.Black;

            // Selection style
            dgv.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Borders
            dgv.GridColor = Color.Gray;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;

            // Layout
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv.AllowUserToResizeRows = true;
            dgv.AllowUserToResizeColumns = true;
            dgv.RowHeadersVisible = false;

            // Word wrap for "ملاحظات" column
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.HeaderText.Contains("ملاحظات"))
                {
                    col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
            }

            // Apply row height manually after data is loaded
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Height = 60;
            }

            dgv.CellFormatting += dgvDollarBox_CellFormatting;
            dgv.ScrollBars = ScrollBars.Both;
            _Refresh();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
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
                _GoldVaultsDatatable.DefaultView.RowFilter = "";

            TotalAmount = dgvGoldTypes.Rows
                         .Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow && row.Cells["EquivalentToGold21"].Value != DBNull.Value)
                         .Sum(row => Convert.ToDecimal(row.Cells["EquivalentToGold21"].Value));
            lblBalance.Text = TotalAmount.ToString("F2");
        }

        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpFilter.Value.Date;

            _GoldVaultsDatatable.DefaultView.RowFilter = string.Format(
                "[{0}] >= #{1}# AND [{0}] < #{2}#",
                "RecordDate",
                selectedDate.ToString("MM/dd/yyyy"),
                selectedDate.AddDays(1).ToString("MM/dd/yyyy")
            );

            TotalAmount = dgvGoldTypes.Rows
                         .Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow && row.Cells["EquivalentToGold21"].Value != DBNull.Value)
                         .Sum(row => Convert.ToDecimal(row.Cells["EquivalentToGold21"].Value));
            lblBalance.Text = TotalAmount.ToString("F2");
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
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

                case "نوع الذهب":
                    FilterColumn = "GoldType";
                    break;

                case "القيمة المضافة":
                    FilterColumn = "AddedAmount";
                    break;

                case "رقم الدفعة":
                    FilterColumn = "PamynetID";
                    break;

                case "القيمة المكافأة للعيار 21":
                    FilterColumn = "EquivalentToGold21";
                    break;

                case "رقم القبضة":
                    FilterColumn = "DeliveryID";
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
                _GoldVaultsDatatable.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvGoldTypes.Rows.Count.ToString();
                TotalAmount = dgvGoldTypes.Rows
                          .Cast<DataGridViewRow>()
                          .Where(row => !row.IsNewRow && row.Cells["EquivalentToGold21"].Value != DBNull.Value)
                          .Sum(row => Convert.ToDecimal(row.Cells["EquivalentToGold21"].Value));
                lblBalance.Text = TotalAmount.ToString("F2");
                return;
            }

            if (FilterColumn == "ID" || FilterColumn == "PaymentID" || FilterColumn == "DeliveryID"
                || FilterColumn == "AddedAmount" || FilterColumn == "EquivalentToGold21" || FilterColumn == "GoldType")
            {
                _GoldVaultsDatatable.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtfilter.Text.Trim());
            }
            else if (FilterColumn == "RecordDate")
            {
                _GoldVaultsDatatable.DefaultView.RowFilter = string.Format("[{0}] = #{1}#", FilterColumn, dtpFilter.Value.ToString("MM/dd/yyyy"));
            }
            else
            {
                _GoldVaultsDatatable.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtfilter.Text.Trim());
            }


            lblRecordsCount.Text = dgvGoldTypes.Rows.Count.ToString();
            TotalAmount = dgvGoldTypes.Rows
                                     .Cast<DataGridViewRow>()
                                     .Where(row => !row.IsNewRow && row.Cells["EquivalentToGold21"].Value != DBNull.Value)
                                     .Sum(row => Convert.ToInt32(row.Cells["EquivalentToGold21"].Value));
            lblBalance.Text = TotalAmount.ToString("F2");
        }

        private void txtfilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "الرقم التسلسلي" || cbFilterBy.Text == "القيمة المضافة" || cbFilterBy.Text == "تابع للدفعة رقم" ||
    cbFilterBy.Text == "تابع للقبضة رقم" || cbFilterBy.Text == "القيمة المكافأة للعيار 21" || cbFilterBy.Text == "نوع الذهب")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbBalances_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbBalances.Text)
            {
                case "رصيد ذهب 14":
                    {
                        lblGoldBalance.Text = dgvGoldTypes.Rows
                                     .Cast<DataGridViewRow>()
                                     .Where(row => !row.IsNewRow && row.Cells["AddedAmount"].Value != DBNull.Value)
                                     .Sum(row => Convert.ToDecimal(row.Cells["AddedAmount"].Value)).ToString();
                    }
                    break;
                case "رصيد ذهب 18":
                    {
                        lblGoldBalance.Text = dgvGoldTypes.Rows
             .Cast<DataGridViewRow>()
             .Where(row => !row.IsNewRow && row.Cells["AddedAmount"].Value != DBNull.Value)
             .Sum(row => Convert.ToDecimal(row.Cells["AddedAmount"].Value)).ToString();
                    }
                    break;
                case "رصيد ذهب 21":
                    {
                        lblGoldBalance.Text = dgvGoldTypes.Rows
             .Cast<DataGridViewRow>()
             .Where(row => !row.IsNewRow && row.Cells["AddedAmount"].Value != DBNull.Value)
             .Sum(row => Convert.ToDecimal(row.Cells["AddedAmount"].Value)).ToString();
                    }
                    break;
                case "رصيد ذهب 22":
                    {
                        lblGoldBalance.Text = dgvGoldTypes.Rows
             .Cast<DataGridViewRow>()
             .Where(row => !row.IsNewRow && row.Cells["AddedAmount"].Value != DBNull.Value)
             .Sum(row => Convert.ToDecimal(row.Cells["AddedAmount"].Value)).ToString();
                    }
                    break;
                case "رصيد ذهب 24":
                    {
                        lblGoldBalance.Text = dgvGoldTypes.Rows
             .Cast<DataGridViewRow>()
             .Where(row => !row.IsNewRow && row.Cells["AddedAmount"].Value != DBNull.Value)
             .Sum(row => Convert.ToDecimal(row.Cells["AddedAmount"].Value)).ToString();
                    }
                    break;
            }
        }
    }
}
