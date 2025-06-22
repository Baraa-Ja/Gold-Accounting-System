namespace WindowsFormsApp1
{
    partial class frm_Transactions
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Transactions));
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDelivery = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtfilter = new System.Windows.Forms.TextBox();
            this.btnAddNewTransaction = new System.Windows.Forms.Button();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter2By = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfilter2 = new System.Windows.Forms.TextBox();
            this.cbFilter3By = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtfilter3 = new System.Windows.Forms.TextBox();
            this.picbFilter3 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbBalances = new System.Windows.Forms.ComboBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.dtpdateTo = new System.Windows.Forms.DateTimePicker();
            this.btnfilter = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.فاتورةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbFilter3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.NullValue = "-";
            this.dgvTransactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTransactions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.NullValue = "-";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.NullValue = "-";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransactions.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTransactions.Location = new System.Drawing.Point(12, 102);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.NullValue = "-";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactions.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = "-";
            this.dgvTransactions.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTransactions.Size = new System.Drawing.Size(1330, 578);
            this.dgvTransactions.TabIndex = 27;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfoToolStripMenuItem,
            this.cmsPayment,
            this.cmsDelivery,
            this.فاتورةToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(249, 146);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(248, 30);
            this.showInfoToolStripMenuItem.Text = "اظهار التفاصيل";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.showInfoToolStripMenuItem_Click);
            // 
            // cmsPayment
            // 
            this.cmsPayment.Name = "cmsPayment";
            this.cmsPayment.Size = new System.Drawing.Size(248, 30);
            this.cmsPayment.Text = "اجراء عملية دفع (لكم)";
            this.cmsPayment.Click += new System.EventHandler(this.cmsPayment_Click);
            // 
            // cmsDelivery
            // 
            this.cmsDelivery.Name = "cmsDelivery";
            this.cmsDelivery.Size = new System.Drawing.Size(248, 30);
            this.cmsDelivery.Text = "اجراء عملية قبض (لنا)";
            this.cmsDelivery.Click += new System.EventHandler(this.cmsDelivery_Click);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(277, 71);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(101, 22);
            this.dtpDateFrom.TabIndex = 31;
            this.dtpDateFrom.ValueChanged += new System.EventHandler(this.dtpFilter_ValueChanged);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Enabled = false;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "الرقم التسلسلي",
            "اسم الزبون",
            "نوع العملية",
            "العملةأوالعيار",
            "التاريخ",
            "الحالة",
            "لاشيء"});
            this.cbFilterBy.Location = new System.Drawing.Point(88, 72);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(121, 24);
            this.cbFilterBy.TabIndex = 30;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Filter By: ";
            // 
            // txtfilter
            // 
            this.txtfilter.Location = new System.Drawing.Point(215, 71);
            this.txtfilter.Multiline = true;
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.Size = new System.Drawing.Size(139, 25);
            this.txtfilter.TabIndex = 28;
            this.txtfilter.Visible = false;
            this.txtfilter.TextChanged += new System.EventHandler(this.txtfilter_TextChanged);
            // 
            // btnAddNewTransaction
            // 
            this.btnAddNewTransaction.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnAddNewTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewTransaction.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewTransaction.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewTransaction.Image")));
            this.btnAddNewTransaction.Location = new System.Drawing.Point(1235, 47);
            this.btnAddNewTransaction.Name = "btnAddNewTransaction";
            this.btnAddNewTransaction.Size = new System.Drawing.Size(107, 49);
            this.btnAddNewTransaction.TabIndex = 32;
            this.btnAddNewTransaction.UseVisualStyleBackColor = true;
            this.btnAddNewTransaction.Click += new System.EventHandler(this.btnAddNewTransaction_Click);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(87, 690);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(46, 16);
            this.lblRecordsCount.TabIndex = 34;
            this.lblRecordsCount.Text = "Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 690);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Records:  ";
            // 
            // cbFilter2By
            // 
            this.cbFilter2By.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter2By.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter2By.FormattingEnabled = true;
            this.cbFilter2By.Items.AddRange(new object[] {
            "الرقم التسلسلي",
            "اسم الزبون",
            "نوع العملية",
            "العملةأوالعيار",
            "الحالة",
            "لاشيء"});
            this.cbFilter2By.Location = new System.Drawing.Point(75, 5);
            this.cbFilter2By.Name = "cbFilter2By";
            this.cbFilter2By.Size = new System.Drawing.Size(121, 24);
            this.cbFilter2By.TabIndex = 37;
            this.cbFilter2By.SelectedIndexChanged += new System.EventHandler(this.cbFilter2By_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = "Filter By: ";
            // 
            // txtfilter2
            // 
            this.txtfilter2.Location = new System.Drawing.Point(202, 4);
            this.txtfilter2.Multiline = true;
            this.txtfilter2.Name = "txtfilter2";
            this.txtfilter2.Size = new System.Drawing.Size(139, 25);
            this.txtfilter2.TabIndex = 35;
            this.txtfilter2.TextChanged += new System.EventHandler(this.txtfilter2_TextChanged);
            // 
            // cbFilter3By
            // 
            this.cbFilter3By.AutoCompleteCustomSource.AddRange(new string[] {
            "الرقم التسلسلي",
            "اسم الزبون",
            "نوع العملية",
            "العملةأوالعيار",
            "الحالة",
            "لاشيء"});
            this.cbFilter3By.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter3By.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter3By.FormattingEnabled = true;
            this.cbFilter3By.Items.AddRange(new object[] {
            "الرقم التسلسلي",
            "اسم الزبون",
            "نوع العملية",
            "العملةأوالعيار",
            "الحالة",
            "لاشيء"});
            this.cbFilter3By.Location = new System.Drawing.Point(73, 5);
            this.cbFilter3By.Name = "cbFilter3By";
            this.cbFilter3By.Size = new System.Drawing.Size(121, 24);
            this.cbFilter3By.TabIndex = 41;
            this.cbFilter3By.SelectedIndexChanged += new System.EventHandler(this.cbFilter3By_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-3, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 40;
            this.label4.Text = "Filter By: ";
            // 
            // txtfilter3
            // 
            this.txtfilter3.Location = new System.Drawing.Point(200, 7);
            this.txtfilter3.Multiline = true;
            this.txtfilter3.Name = "txtfilter3";
            this.txtfilter3.Size = new System.Drawing.Size(139, 25);
            this.txtfilter3.TabIndex = 39;
            this.txtfilter3.TextChanged += new System.EventHandler(this.txtfilter3_TextChanged);
            // 
            // picbFilter3
            // 
            this.picbFilter3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picbFilter3.Image = ((System.Drawing.Image)(resources.GetObject("picbFilter3.Image")));
            this.picbFilter3.InitialImage = null;
            this.picbFilter3.Location = new System.Drawing.Point(359, 48);
            this.picbFilter3.Name = "picbFilter3";
            this.picbFilter3.Size = new System.Drawing.Size(21, 23);
            this.picbFilter3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbFilter3.TabIndex = 44;
            this.picbFilter3.TabStop = false;
            this.picbFilter3.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbFilter2By);
            this.groupBox1.Controls.Add(this.txtfilter2);
            this.groupBox1.Location = new System.Drawing.Point(13, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 29);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbFilter3By);
            this.groupBox2.Controls.Add(this.txtfilter3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(15, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 33);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // cbBalances
            // 
            this.cbBalances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBalances.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBalances.FormattingEnabled = true;
            this.cbBalances.Items.AddRange(new object[] {
            "رصيد سوري",
            "رصيد دولار",
            "رصيد ذهب 14",
            "رصيد ذهب 18",
            "رصيد ذهب 21",
            "رصيد ذهب 22",
            "رصيد ذهب 24",
            "رصيد مكافئ 21",
            "رصيد عملات اخرى"});
            this.cbBalances.Location = new System.Drawing.Point(233, 686);
            this.cbBalances.Name = "cbBalances";
            this.cbBalances.Size = new System.Drawing.Size(121, 24);
            this.cbBalances.TabIndex = 48;
            this.cbBalances.Visible = false;
            this.cbBalances.SelectedIndexChanged += new System.EventHandler(this.cbBalances_SelectedIndexChanged);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(374, 689);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(64, 16);
            this.lblBalance.TabIndex = 47;
            this.lblBalance.Text = "Balance";
            this.lblBalance.Visible = false;
            // 
            // dtpdateTo
            // 
            this.dtpdateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpdateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdateTo.Location = new System.Drawing.Point(444, 71);
            this.dtpdateTo.Name = "dtpdateTo";
            this.dtpdateTo.Size = new System.Drawing.Size(100, 22);
            this.dtpdateTo.TabIndex = 49;
            // 
            // btnfilter
            // 
            this.btnfilter.Location = new System.Drawing.Point(564, 72);
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.Size = new System.Drawing.Size(75, 23);
            this.btnfilter.TabIndex = 50;
            this.btnfilter.Text = "Filter";
            this.btnfilter.UseVisualStyleBackColor = true;
            this.btnfilter.Click += new System.EventHandler(this.btnfilter_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(220, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 42;
            this.label5.Text = "تاريخ من";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(384, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 51;
            this.label6.Text = "تاريخ الى";
            // 
            // فاتورةToolStripMenuItem
            // 
            this.فاتورةToolStripMenuItem.Name = "فاتورةToolStripMenuItem";
            this.فاتورةToolStripMenuItem.Size = new System.Drawing.Size(248, 30);
            this.فاتورةToolStripMenuItem.Text = "فاتورة";
            this.فاتورةToolStripMenuItem.Click += new System.EventHandler(this.فاتورةToolStripMenuItem_Click);
            // 
            // frm_Transactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 718);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnfilter);
            this.Controls.Add(this.dtpdateTo);
            this.Controls.Add(this.cbBalances);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picbFilter3);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddNewTransaction);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtfilter);
            this.Controls.Add(this.dgvTransactions);
            this.Name = "frm_Transactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Transactions";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Transactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbFilter3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtfilter;
        private System.Windows.Forms.Button btnAddNewTransaction;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilter2By;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtfilter2;
        private System.Windows.Forms.ComboBox cbFilter3By;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtfilter3;
        private System.Windows.Forms.PictureBox picbFilter3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsPayment;
        private System.Windows.Forms.ToolStripMenuItem cmsDelivery;
        private System.Windows.Forms.ComboBox cbBalances;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.DateTimePicker dtpdateTo;
        private System.Windows.Forms.Button btnfilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem فاتورةToolStripMenuItem;
    }
}