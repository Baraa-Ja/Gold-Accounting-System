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
    public partial class frm_SerachForCustomer : Form
    {
        public frm_SerachForCustomer()
        {
            InitializeComponent();
        }

        private void frm_SerachForCustomer_Load(object sender, EventArgs e)
        {
            //DataTable customersTable;
            //customersTable = new DataTable();
            //customersTable.Columns.Add("Code", typeof(int));
            //customersTable.Columns.Add("Name", typeof(string));

            //customersTable.Rows.Add(1, "حزيفة");
            //customersTable.Rows.Add(2, "عينية");
            //customersTable.Rows.Add(3, "بول");
            //customersTable.Rows.Add(4, "رويال النشة");

            //dataGridViewCustomers.DataSource = customersTable;

            //// Setup search field options
            //cmbSearchField.Items.Add("Code");
            //cmbSearchField.Items.Add("Name");
            //cmbSearchField.SelectedIndex = 1; // Default to "Name"
        }
    }
}
