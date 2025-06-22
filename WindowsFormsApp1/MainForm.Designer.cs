namespace WindowsFormsApp1
{
    partial class frmMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SyrianBox = new System.Windows.Forms.ToolStripMenuItem();
            this.DollarBox = new System.Windows.Forms.ToolStripMenuItem();
            this.GoldVaults = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyTransactions = new System.Windows.Forms.ToolStripMenuItem();
            this.Customers = new System.Windows.Forms.ToolStripMenuItem();
            this.Analitics = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SyrianBox,
            this.DollarBox,
            this.GoldVaults,
            this.dailyTransactions,
            this.Customers,
            this.Analitics});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1264, 31);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // SyrianBox
            // 
            this.SyrianBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SyrianBox.Name = "SyrianBox";
            this.SyrianBox.Size = new System.Drawing.Size(123, 25);
            this.SyrianBox.Text = "صندوق السوري";
            this.SyrianBox.Click += new System.EventHandler(this.SyrianBox_Click);
            // 
            // DollarBox
            // 
            this.DollarBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DollarBox.Name = "DollarBox";
            this.DollarBox.Size = new System.Drawing.Size(116, 25);
            this.DollarBox.Text = "صندوق الدولار";
            this.DollarBox.Click += new System.EventHandler(this.الToolStripMenuItem_Click);
            // 
            // GoldVaults
            // 
            this.GoldVaults.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoldVaults.Name = "GoldVaults";
            this.GoldVaults.Size = new System.Drawing.Size(108, 25);
            this.GoldVaults.Text = "خزنات الذهب";
            this.GoldVaults.Click += new System.EventHandler(this.GoldVaults_Click);
            // 
            // dailyTransactions
            // 
            this.dailyTransactions.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailyTransactions.Name = "dailyTransactions";
            this.dailyTransactions.Size = new System.Drawing.Size(126, 25);
            this.dailyTransactions.Text = "العمليات اليومية";
            this.dailyTransactions.Click += new System.EventHandler(this.dailyTransactions_Click);
            // 
            // Customers
            // 
            this.Customers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customers.Name = "Customers";
            this.Customers.Size = new System.Drawing.Size(63, 25);
            this.Customers.Text = "الزبائن";
            this.Customers.Click += new System.EventHandler(this.Customers_Click);
            // 
            // Analitics
            // 
            this.Analitics.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Analitics.Name = "Analitics";
            this.Analitics.Size = new System.Drawing.Size(146, 25);
            this.Analitics.Text = "التحليلات و الارصدة";
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SyrianBox;
        private System.Windows.Forms.ToolStripMenuItem DollarBox;
        private System.Windows.Forms.ToolStripMenuItem GoldVaults;
        private System.Windows.Forms.ToolStripMenuItem dailyTransactions;
        private System.Windows.Forms.ToolStripMenuItem Customers;
        private System.Windows.Forms.ToolStripMenuItem Analitics;
    }
}

