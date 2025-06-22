using Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frm_DollarBox : Form
    {
        private int Sum = 0;
        public frm_DollarBox()
        {
            InitializeComponent();

        }

        private DataTable _DollarBoxDatatable = clsDollarBox.GetDollarBoxMovement();

        private void _Refresh()
        {
            dgvDollarBox.RowTemplate.Height = 40; // sets default row height
            dgvDollarBox.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgvDollarBox.DataSource = _DollarBoxDatatable;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvDollarBox.Rows.Count.ToString();
            int Sum = dgvDollarBox.Rows
                          .Cast<DataGridViewRow>()
                          .Where(row => !row.IsNewRow && row.Cells["AddedValue"].Value != DBNull.Value)
                          .Sum(row => Convert.ToInt32(row.Cells["AddedValue"].Value));
            lblBalance.Text = Sum.ToString() + " $";

            if (dgvDollarBox.Rows.Count > 0)
            {

                dgvDollarBox.Columns[0].HeaderText = "الرقم التسلسلي";
                dgvDollarBox.Columns[0].Width = 100;


                dgvDollarBox.Columns[1].HeaderText = "التاريخ";
                dgvDollarBox.Columns[1].Width = 150;


                dgvDollarBox.Columns[2].HeaderText = "القيمة المضافة";
                dgvDollarBox.Columns[2].Width = 150;


                dgvDollarBox.Columns[3].HeaderText = "تابع للدفعة رقم";
                dgvDollarBox.Columns[3].Width = 150;


                dgvDollarBox.Columns[4].HeaderText = "تابع للقبضة رقم";
                dgvDollarBox.Columns[4].Width = 150;


                dgvDollarBox.Columns[5].HeaderText = "الملاحظات";
                dgvDollarBox.Columns[5].Width = 350;

            }
        }

        private void dgvDollarBox_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDollarBox.Columns[e.ColumnIndex].Name == "AddedValue") // <- change to your actual column name
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

        private void ctrl_BoxesTransactions_Load(object sender, EventArgs e)
        {
            var dgv = dgvDollarBox;

            dgv.Font = new Font("Segoe UI", 10);
            dgv.RowTemplate.Height = 28;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.RowsDefaultCellStyle.ForeColor = Color.Black;

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 144, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 40;

            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.GridColor = Color.FromArgb(180, 180, 180);
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.RowHeadersVisible = false;

            // 🔴 Register formatting event at the end
            dgv.CellFormatting += dgvDollarBox_CellFormatting;

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

            if (txtfilter.Visible )
            {
                txtfilter.Text = "";
                txtfilter.Focus();
            }

            if(dtpFilter.Visible == false)
                _DollarBoxDatatable.DefaultView.RowFilter = "";

            Sum = dgvDollarBox.Rows
                         .Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow && row.Cells["AddedValue"].Value != DBNull.Value)
                         .Sum(row => Convert.ToInt32(row.Cells["AddedValue"].Value));
            lblBalance.Text = Sum.ToString() + " $";

        }

        
        private void txtfilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text == "الرقم التسلسلي" || cbFilterBy.Text == "القيمة المضافة" || cbFilterBy.Text == "تابع للدفعة رقم" ||
                cbFilterBy.Text == "تابع للقبضة رقم")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
                    FilterColumn = "PamynetID";
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
                _DollarBoxDatatable.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvDollarBox.Rows.Count.ToString();
                Sum = dgvDollarBox.Rows
                          .Cast<DataGridViewRow>()
                          .Where(row => !row.IsNewRow && row.Cells["AddedValue"].Value != DBNull.Value)
                          .Sum(row => Convert.ToInt32(row.Cells["AddedValue"].Value));
                lblBalance.Text = Sum.ToString() + " $";
                return;
            }

            if (FilterColumn == "ID" || FilterColumn == "PaymentID" || FilterColumn == "DeliveryID" || FilterColumn == "AddedValue")
            {
                _DollarBoxDatatable.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtfilter.Text.Trim());
            }
            else if (FilterColumn == "RecordDate")
            {
                _DollarBoxDatatable.DefaultView.RowFilter = string.Format("[{0}] = #{1}#", FilterColumn, dtpFilter.Value.ToString("MM/dd/yyyy"));
            }
            else
            {
                _DollarBoxDatatable.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtfilter.Text.Trim());
            }


            lblRecordsCount.Text = dgvDollarBox.Rows.Count.ToString();
             Sum = dgvDollarBox.Rows
                                      .Cast<DataGridViewRow>()
                                      .Where(row => !row.IsNewRow && row.Cells["AddedValue"].Value != DBNull.Value)
                                      .Sum(row => Convert.ToInt32(row.Cells["AddedValue"].Value));
            lblBalance.Text = Sum.ToString() + " $";
        }


        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpFilter.Value.Date;

            _DollarBoxDatatable.DefaultView.RowFilter = string.Format(
                "[{0}] >= #{1}# AND [{0}] < #{2}#",
                "RecordDate",
                selectedDate.ToString("MM/dd/yyyy"),
                selectedDate.AddDays(1).ToString("MM/dd/yyyy")
            );

            Sum = dgvDollarBox.Rows
                         .Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow && row.Cells["AddedValue"].Value != DBNull.Value)
                         .Sum(row => Convert.ToInt32(row.Cells["AddedValue"].Value));
            lblBalance.Text = Sum.ToString();
        }

        private void lblBalance_Click(object sender, EventArgs e)
        {

        }
    }
}
