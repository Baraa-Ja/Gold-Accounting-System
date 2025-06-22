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
    public partial class frmAddEditCustomer : Form
    {
        int cusomterId = 0;
        private clsCustomers cusomter;
        public frmAddEditCustomer()
        {
            InitializeComponent();
            cusomter = new clsCustomers();
        }

        public frmAddEditCustomer(int cusomterId)
        {
            InitializeComponent();
            this.cusomterId = cusomterId;
        }
        private void frmAddEditCustomer_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cusomter.CustomerName = txtCustomerName.Text;


            if (cusomter.AddNewCustomer())
            {
                
                MessageBox.Show("تم اضافة عملية بنجاح.", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblCustomerID.Text = cusomter.CustomerID.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("لم يتم حقظ العملية", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }
    }
}
