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
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();

        }

        private void ذهبعيارToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void الToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DollarBox frm = new frm_DollarBox();
            frm.ShowDialog();
        }

        private void SyrianBox_Click(object sender, EventArgs e)
        {
            frm_SyrianBox frm = new frm_SyrianBox();
            frm.ShowDialog();
        }

        //private void ذهبToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frm_GoldVaults frm = new frm_GoldVaults();
        //    frm.ShowDialog();
        //}

        private void GoldVaults_Click(object sender, EventArgs e)
        {
            frm_GoldVaults frm = new frm_GoldVaults();
            frm.ShowDialog();
        }

        private void Customers_Click(object sender, EventArgs e)
        {
            frm_Customers frm = new frm_Customers();
            frm.ShowDialog();
        }

        private void dailyTransactions_Click(object sender, EventArgs e)
        {
            frm_Transactions frm = new frm_Transactions();
            frm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            this.Bounds = Screen.PrimaryScreen.WorkingArea;

        }
    }
}
