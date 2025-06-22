using Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class frm_Transactions : Form
    {

        public frm_Transactions()
        {
            InitializeComponent();

        }

        decimal TotalBalance = 0;

        private DataTable _TransactionsTable = clsTransactions.GetAllTransactionsFiltered();
        //private void _Refresh()
        //{
        //    {

        //        dgvTransactions.RowTemplate.Height = 40; // sets default row height

        //        _TransactionsTable = clsTransactions.GetAllTransactionsFiltered();
        //        dgvTransactions.DataSource = _TransactionsTable.DefaultView;
        //        //dgvTransactions.DataSource = _TransactionsTable.DefaultView.ToTable(false, "TransactionID", "TransactionDate",
        //        //    "TransactionType", "CustomerName", "Currency", "Quantity", "EquivalentInGold21", "CurrencyToGive", "UnitPrice",
        //        //    "TotalAmount", "StatusType", "Notes");

        //        cbFilterBy.SelectedIndex = 0;
        //        lblRecordsCount.Text = dgvTransactions.Rows.Count.ToString();

        //        if (dgvTransactions.Rows.Count > 0)
        //        {

        //            dgvTransactions.Columns[5].DefaultCellStyle.Format = "N2";
        //            dgvTransactions.Columns[6].DefaultCellStyle.Format = "N2";
        //            dgvTransactions.Columns[8].DefaultCellStyle.Format = "N2";
        //            dgvTransactions.Columns[9].DefaultCellStyle.Format = "N2";

        //            dgvTransactions.Columns[0].HeaderText = "الرقم التسلسلي";
        //            dgvTransactions.Columns[0].Width = 100;


        //            dgvTransactions.Columns[1].HeaderText = "التاريخ";
        //            dgvTransactions.Columns[1].Width = 180;


        //            dgvTransactions.Columns[2].HeaderText = "نوع العملية";
        //            dgvTransactions.Columns[2].Width = 80;


        //            dgvTransactions.Columns[3].HeaderText = "اسم الزبون";
        //            dgvTransactions.Columns[3].Width = 150;


        //            dgvTransactions.Columns[4].HeaderText = "العملة او العيار";
        //            dgvTransactions.Columns[4].Width = 65;


        //            dgvTransactions.Columns[5].HeaderText = "الكمية";
        //            dgvTransactions.Columns[5].Width = 150;


        //            dgvTransactions.Columns[6].HeaderText = "كمية الذهب المكافئة للعيار 21";
        //            dgvTransactions.Columns[6].Width = 150;

        //            dgvTransactions.Columns[7].HeaderText = "العملة المقابلة";
        //            dgvTransactions.Columns[7].Width = 80;

        //            dgvTransactions.Columns[8].HeaderText = "سعر الوحدة";
        //            dgvTransactions.Columns[8].Width = 120;

        //            dgvTransactions.Columns[9].HeaderText = "المجموع الكلي";
        //            dgvTransactions.Columns[9].Width = 180;

        //            dgvTransactions.Columns[10].HeaderText = "حالة العملية";
        //            dgvTransactions.Columns[10].Width = 100;

        //            dgvTransactions.Columns[11].HeaderText = "الملاحظات";
        //            dgvTransactions.Columns[11].Width = 300;

        //        }

        //        //if (dgvTransactions.CurrentRow.Cells[2].Value.ToString() == "purchase")
        //        //    dgvTransactions.CurrentRow.Cells[2].Value = "شراء";
        //    }
        //}

        //private void frm_Transactions_Load(object sender, EventArgs e)
        //{
        //    var dgv = dgvTransactions;

        //    dgv.Font = new Font("Segoe UI", 11);
        //    dgv.RowTemplate.Height = 60;
        //    dgv.DefaultCellStyle.Padding = new Padding(0, 10, 0, 0); // Top padding

        //    dgv.EnableHeadersVisualStyles = false;

        //    // Header styling
        //    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
        //    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        //    dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
        //    dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
        //    dgv.ColumnHeadersHeight = 50;

        //    // Zebra striping
        //    dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        //    dgv.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // LightGray
        //    dgv.RowsDefaultCellStyle.ForeColor = Color.Black;

        //    // Selection style
        //    dgv.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
        //    dgv.DefaultCellStyle.SelectionForeColor = Color.White;

        //    // Borders
        //    dgv.GridColor = Color.Gray;
        //    dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        //    dgv.BorderStyle = BorderStyle.Fixed3D;
        //    dgv.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;

        //    // Layout
        //    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        //    dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        //    dgv.AllowUserToResizeRows = true;
        //    dgv.AllowUserToResizeColumns = true;
        //    dgv.RowHeadersVisible = false;

        //    // Word wrap for "ملاحظات" column
        //    foreach (DataGridViewColumn col in dgv.Columns)
        //    {
        //        if (col.HeaderText.Contains("ملاحظات"))
        //        {
        //            col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //        }
        //    }

        //    // Apply row height manually after data is loaded
        //    foreach (DataGridViewRow row in dgv.Rows)
        //    {
        //        row.Height = 60;
        //    }

        //    //dgv.ScrollBars = ScrollBars.Both;

        //    _Refresh();

        //    //string fromDate = dtpDateFrom.Value.ToString("MM/dd/yyyy");
        //    //string toDate = dtpdateTo.Value.ToString("MM/dd/yyyy");

        //    //string filterExpression = string.Format("[TransactionDate] >= #{0}# AND [TransactionDate] <= #{1}#", fromDate, toDate);

        //    //_TransactionsTable.DefaultView.RowFilter = filterExpression;

        //    //_TransactionsTable.DefaultView.RowFilter = string.Format("[{0}] = #{1}#", "TransactionDate", dtpDateFrom.Value.ToString("MM/dd/yyyy"));
        //    cbFilterBy.Text = "التاريخ";
        //    dtpDateFrom.Value = Convert.ToDateTime("01/01/2025");
        //}


        // File: TransactionsForm.cs

        private void _Refresh()
        {
            dgvTransactions.RowTemplate.Height = 40;

            _TransactionsTable = clsTransactions.GetAllTransactionsFiltered();
            dgvTransactions.DataSource = _TransactionsTable.DefaultView;

            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvTransactions.Rows.Count.ToString();

            if (dgvTransactions.Rows.Count == 0) return;

            FormatTransactionGrid();
        }

        private void frm_Transactions_Load(object sender, EventArgs e)
        {
            SetupGridVisualStyle();
            _Refresh();

            cbFilterBy.Text = "التاريخ";
            dtpDateFrom.Value = new DateTime(2025, 1, 1);
        }

        private void SetupGridVisualStyle()
        {
            var dgv = dgvTransactions;

            dgv.Font = new Font("Segoe UI", 11);
            dgv.RowTemplate.Height = 60;
            dgv.DefaultCellStyle.Padding = new Padding(0, 10, 0, 0);

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.ColumnHeadersHeight = 50;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgv.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv.RowsDefaultCellStyle.ForeColor = Color.Black;

            dgv.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.GridColor = Color.Gray;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv.AllowUserToResizeRows = true;
            dgv.AllowUserToResizeColumns = true;
            dgv.RowHeadersVisible = false;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.HeaderText.Contains("ملاحظات"))
                {
                    col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Height = 60;
            }

            dgv.EnableDoubleBuffering(true);
        }

        private void FormatTransactionGrid()
        {
            var columns = dgvTransactions.Columns;

            columns[5].DefaultCellStyle.Format = "N2";
            columns[6].DefaultCellStyle.Format = "N2";
            columns[8].DefaultCellStyle.Format = "N2";
            columns[9].DefaultCellStyle.Format = "N2";

            var headers = new[]
            {
        ("الرقم التسلسلي", 75),
        ("التاريخ", 170),
        ("نوع العملية", 80),
        ("اسم الزبون", 120),
        ("العملة او العيار", 65),
        ("الكمية", 140),
        ("كمية الذهب المكافئة للعيار 21", 150),
        ("العملة المقابلة", 80),
        ("سعر الوحدة", 120),
        ("المجموع الكلي", 180),
        ("حالة العملية", 100),
        ("الملاحظات", 300)
    };

            for (int i = 0; i < headers.Length; i++)
            {
                columns[i].HeaderText = headers[i].Item1;
                columns[i].Width = headers[i].Item2;
            }
        }


        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtfilter.Visible = cbFilterBy.Text != "لاشيء";
            //dtpFilter.Visible = cbFilterBy.Text == "التاريخ";
            //if (cbFilterBy.Text == "التاريخ")
            //{
            //    txtfilter.Visible = false;
            //    dtpFilter.Visible = true;
            //}

            //if (txtfilter.Visible)
            //{
            //    txtfilter.Text = "";
            //    txtfilter.Focus();
            //}

            //if (dtpFilter.Visible == false)
            //    _TransactionsTable.DefaultView.RowFilter = "";
        }

        private string _filter1 = "";
        private string _filter2 = "";
        private string _filter3 = "";

        private void ApplyCombinedFilter()
        {
            List<string> filters = new List<string>();

            if (!string.IsNullOrWhiteSpace(_filter1)) filters.Add(_filter1);
            if (!string.IsNullOrWhiteSpace(_filter2)) filters.Add(_filter2);
            if (!string.IsNullOrWhiteSpace(_filter3)) filters.Add(_filter3);

            _TransactionsTable.DefaultView.RowFilter = string.Join(" AND ", filters);
            lblRecordsCount.Text = dgvTransactions.Rows.Count.ToString();
        }

        private string BuildFilter(string selectedText, string inputText, DateTimePicker datePicker)
        {
            if (string.IsNullOrWhiteSpace(inputText)) return "";

            string column = "";
            switch (selectedText)
            {
                case "الرقم التسلسلي":
                    column = "TransactionID";
                    break;

                case "اسم الزبون":
                    column = "CustomerName";
                    break;

                case "التاريخ":
                    column = "TransactionDate";
                    break;

                case "نوع العملية":
                    column = "TransactionType";
                    break;

                case "العملةأوالعيار":
                    column = "Currency";
                    break;

                case "الحالة":
                    column = "StatusType";
                    break;

                default:
                    column = "لاشيء";
                    break;

            }

            if (string.IsNullOrEmpty(column)) return "";

            if (column == "CustomerName")
            {
                clsCustomers customer = clsCustomers.GetCustmerInfoByName(inputText);
                return string.Format("[{0}] LIKE '{1}%'", column, customer?.CustomerName ?? inputText);
            }
            else if (column == "TransactionDate" && datePicker != null)
            {
                return string.Format("[{0}] = #{1}#", column, datePicker.Value.ToString("MM/dd/yyyy"));
            }
            else
            {
                return string.Format("Convert([{0}], 'System.String') LIKE '{1}%'", column, inputText.Trim());
            }
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
                //_TransactionsTable.DefaultView.RowFilter = string.Format("[{0}] = #{1}#", "TransactionDate", dtpFilter.Value.ToString("MM/dd/yyyy"));
        }

        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            //DateTime selectedDate = dtpDateFrom.Value.Date;

            //_TransactionsTable.DefaultView.RowFilter = string.Format(
            //    "[{0}] >= #{1}# AND [{0}] < #{2}#",
            //    "TransactionDate",
            //    selectedDate.ToString("MM/dd/yyyy"),
            //    selectedDate.AddDays(1).ToString("MM/dd/yyyy")
            //);
        }

        private void btnAddNewTransaction_Click(object sender, EventArgs e)
        {
            frm_AddNewTransaction frm = new frm_AddNewTransaction();
            frm.ShowDialog();

            _Refresh();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (groupBox2.Visible == true)
            { groupBox2.Visible = false;

            }
            else if (groupBox2.Visible == false)
            { groupBox2.Visible = true; }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //if(groupBox1.Visible == true)
            //    { groupBox1.Visible = false; }
            //else if(groupBox1.Visible == false)
            //    { groupBox1.Visible = true; }
            //picbFilter2.Visible = true;
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cmsPayment_Click(object sender, EventArgs e)
        {
            frmAddPayment frm = new frmAddPayment((int)dgvTransactions.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _Refresh();
        }

        private void cmsDelivery_Click(object sender, EventArgs e)
        {
            frm_AddDelivery frm = new frm_AddDelivery((int)dgvTransactions.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _Refresh();
        }

        private void cbBalances_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch(cbBalances.Text)
            //{
            //    case "رصيد سوري":
            //        {
            //            TotalBalance = dgvTransactions.Rows
            //             .Cast<DataGridViewRow>()
            //             .Where(row => !row.IsNewRow && row.Cells["AddedValue"].Value != DBNull.Value)
            //             .Sum(row => Convert.ToInt32(row.Cells["AddedValue"].Value));
            //        }
            //}
        }

        private void txtfilter2_TextChanged(object sender, EventArgs e)
        {
            _filter2 = BuildFilter(cbFilter2By.Text, txtfilter2.Text, null);
            ApplyCombinedFilter();
        }

        private void cbFilter3By_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbFilter2By_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtfilter3_TextChanged(object sender, EventArgs e)
        {
            _filter3 = BuildFilter(cbFilter3By.Text, txtfilter3.Text, null);
            ApplyCombinedFilter();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void btnfilter_Click(object sender, EventArgs e)
        {

            DateTime fromDateTime = dtpDateFrom.Value.Date; // start of day
            DateTime toDateTime = dtpdateTo.Value.Date.AddDays(1).AddSeconds(-1); // end of day

            string fromDate = fromDateTime.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            string toDate = toDateTime.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            string filterExpression = string.Format(
                "[TransactionDate] >= #{0}# AND [TransactionDate] <= #{1}#",
                fromDate,
                toDate
            );
            _TransactionsTable.DefaultView.RowFilter = filterExpression;
        }

        private void فاتورةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_TransactionBills frm = new frm_TransactionBills((int)dgvTransactions.CurrentRow.Cells[0].Value,(string)dgvTransactions.CurrentRow.Cells[3].Value);
            frm.ShowDialog();
        }
    }
}


public static class DataGridViewExtensions
{
    public static void EnableDoubleBuffering(this DataGridView dgv, bool setting)
    {
        typeof(DataGridView)
            .InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { setting });
    }
}
