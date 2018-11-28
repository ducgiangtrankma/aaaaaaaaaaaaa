namespace DoAnQuanCaFe
{
    partial class frm_ThaoTacBan
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
            this.lstTableFrom = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstTableTo = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxTableFrom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBillFrom = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbxTableTo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBillTo = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNextAll = new System.Windows.Forms.Button();
            this.btnPreviousAll = new System.Windows.Forms.Button();
            this.btnNextOne = new System.Windows.Forms.Button();
            this.btnPreviousOne = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTableFrom
            // 
            this.lstTableFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstTableFrom.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader9});
            this.lstTableFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lstTableFrom.FullRowSelect = true;
            this.lstTableFrom.GridLines = true;
            this.lstTableFrom.Location = new System.Drawing.Point(14, 131);
            this.lstTableFrom.Margin = new System.Windows.Forms.Padding(5);
            this.lstTableFrom.Name = "lstTableFrom";
            this.lstTableFrom.Size = new System.Drawing.Size(647, 373);
            this.lstTableFrom.TabIndex = 1;
            this.lstTableFrom.UseCompatibleStateImageBehavior = false;
            this.lstTableFrom.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 1;
            this.columnHeader1.Text = "Tên sản phẩm";
            this.columnHeader1.Width = 123;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 2;
            this.columnHeader2.Text = "SL";
            this.columnHeader2.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 3;
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 118;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 4;
            this.columnHeader4.Text = "Tổng tiền";
            this.columnHeader4.Width = 108;
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 0;
            this.columnHeader9.Text = "STT";
            // 
            // lstTableTo
            // 
            this.lstTableTo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTableTo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader10});
            this.lstTableTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lstTableTo.FullRowSelect = true;
            this.lstTableTo.GridLines = true;
            this.lstTableTo.Location = new System.Drawing.Point(776, 134);
            this.lstTableTo.Margin = new System.Windows.Forms.Padding(5);
            this.lstTableTo.Name = "lstTableTo";
            this.lstTableTo.Size = new System.Drawing.Size(436, 373);
            this.lstTableTo.TabIndex = 2;
            this.lstTableTo.UseCompatibleStateImageBehavior = false;
            this.lstTableTo.View = System.Windows.Forms.View.Details;
            this.lstTableTo.SelectedIndexChanged += new System.EventHandler(this.lstTableTo_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 1;
            this.columnHeader5.Text = "Tên sản phẩm";
            this.columnHeader5.Width = 123;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "SL";
            this.columnHeader6.Width = 40;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Đơn giá";
            this.columnHeader7.Width = 118;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Tổng tiền";
            this.columnHeader8.Width = 108;
            // 
            // columnHeader10
            // 
            this.columnHeader10.DisplayIndex = 0;
            this.columnHeader10.Text = "STT";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxTableFrom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtBillFrom);
            this.panel1.Location = new System.Drawing.Point(14, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 88);
            this.panel1.TabIndex = 5;
            // 
            // cbxTableFrom
            // 
            this.cbxTableFrom.FormattingEnabled = true;
            this.cbxTableFrom.Location = new System.Drawing.Point(172, 52);
            this.cbxTableFrom.Name = "cbxTableFrom";
            this.cbxTableFrom.Size = new System.Drawing.Size(231, 28);
            this.cbxTableFrom.TabIndex = 4;
            this.cbxTableFrom.SelectedIndexChanged += new System.EventHandler(this.cbxIDFromTable_SelectedIndexChanged);
            this.cbxTableFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxTableFrom_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bàn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã hóa đơn:";
            // 
            // txtBillFrom
            // 
            this.txtBillFrom.Enabled = false;
            this.txtBillFrom.Location = new System.Drawing.Point(172, 15);
            this.txtBillFrom.Name = "txtBillFrom";
            this.txtBillFrom.Size = new System.Drawing.Size(231, 27);
            this.txtBillFrom.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbxTableTo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtBillTo);
            this.panel2.Location = new System.Drawing.Point(774, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(497, 88);
            this.panel2.TabIndex = 6;
            // 
            // cbxTableTo
            // 
            this.cbxTableTo.FormattingEnabled = true;
            this.cbxTableTo.Location = new System.Drawing.Point(181, 51);
            this.cbxTableTo.Name = "cbxTableTo";
            this.cbxTableTo.Size = new System.Drawing.Size(231, 28);
            this.cbxTableTo.TabIndex = 8;
            this.cbxTableTo.SelectedIndexChanged += new System.EventHandler(this.cbxIDNextTable_SelectedIndexChanged);
            this.cbxTableTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxTableFrom_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Bàn:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Mã hóa đơn:";
            // 
            // txtBillTo
            // 
            this.txtBillTo.Enabled = false;
            this.txtBillTo.Location = new System.Drawing.Point(181, 15);
            this.txtBillTo.Name = "txtBillTo";
            this.txtBillTo.Size = new System.Drawing.Size(231, 27);
            this.txtBillTo.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnNextAll);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnPreviousAll);
            this.panel3.Controls.Add(this.btnNextOne);
            this.panel3.Controls.Add(this.btnPreviousOne);
            this.panel3.Location = new System.Drawing.Point(669, 134);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(103, 370);
            this.panel3.TabIndex = 7;
            // 
            // btnNextAll
            // 
            this.btnNextAll.Location = new System.Drawing.Point(10, 247);
            this.btnNextAll.Name = "btnNextAll";
            this.btnNextAll.Size = new System.Drawing.Size(86, 38);
            this.btnNextAll.TabIndex = 3;
            this.btnNextAll.Text = ">>";
            this.btnNextAll.UseVisualStyleBackColor = true;
            this.btnNextAll.Click += new System.EventHandler(this.btnNextAll_Click);
            // 
            // btnPreviousAll
            // 
            this.btnPreviousAll.Location = new System.Drawing.Point(10, 94);
            this.btnPreviousAll.Name = "btnPreviousAll";
            this.btnPreviousAll.Size = new System.Drawing.Size(86, 41);
            this.btnPreviousAll.TabIndex = 2;
            this.btnPreviousAll.Text = "<<";
            this.btnPreviousAll.UseVisualStyleBackColor = true;
            this.btnPreviousAll.Click += new System.EventHandler(this.btnPreviousAll_Click);
            // 
            // btnNextOne
            // 
            this.btnNextOne.Location = new System.Drawing.Point(10, 190);
            this.btnNextOne.Name = "btnNextOne";
            this.btnNextOne.Size = new System.Drawing.Size(86, 42);
            this.btnNextOne.TabIndex = 1;
            this.btnNextOne.Text = ">";
            this.btnNextOne.UseVisualStyleBackColor = true;
            this.btnNextOne.Click += new System.EventHandler(this.btnNextOne_Click);
            // 
            // btnPreviousOne
            // 
            this.btnPreviousOne.Location = new System.Drawing.Point(10, 42);
            this.btnPreviousOne.Name = "btnPreviousOne";
            this.btnPreviousOne.Size = new System.Drawing.Size(86, 37);
            this.btnPreviousOne.TabIndex = 0;
            this.btnPreviousOne.Text = "<";
            this.btnPreviousOne.UseVisualStyleBackColor = true;
            this.btnPreviousOne.Click += new System.EventHandler(this.btnPreviousOne_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 38);
            this.button1.TabIndex = 9;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.LightPink;
            this.label23.Dock = System.Windows.Forms.DockStyle.Top;
            this.label23.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label23.ForeColor = System.Drawing.Color.Maroon;
            this.label23.Location = new System.Drawing.Point(0, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(1016, 35);
            this.label23.TabIndex = 10;
            this.label23.Text = "QUẢN LÝ SẢN PHẨM TRONG DANH MỤC GỌI SẢN PHẨM";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_ThaoTacBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1016, 518);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstTableTo);
            this.Controls.Add(this.lstTableFrom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frm_ThaoTacBan";
            this.Text = "Quản lý sản phẩm trong danh mục gọi sản phẩm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_ThaoTacBan_FormClosing);
            this.Load += new System.EventHandler(this.frm_ThaoTacBan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstTableFrom;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lstTableTo;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxTableFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBillFrom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbxTableTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBillTo;
        private System.Windows.Forms.Button btnNextAll;
        private System.Windows.Forms.Button btnPreviousAll;
        private System.Windows.Forms.Button btnNextOne;
        private System.Windows.Forms.Button btnPreviousOne;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;

    }
}