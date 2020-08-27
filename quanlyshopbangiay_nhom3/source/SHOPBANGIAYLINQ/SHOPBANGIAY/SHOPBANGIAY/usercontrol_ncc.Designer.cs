namespace SHOPBANGIAY
{
    partial class usercontrol_ncc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_ncc = new System.Windows.Forms.GroupBox();
            this.checkBox_ht = new System.Windows.Forms.CheckBox();
            this.btnThem = new DevComponents.DotNetBar.ButtonX();
            this.btnsua = new DevComponents.DotNetBar.ButtonX();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_sdt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_dc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_mancc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_tenncc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgv_ncc = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gb_ncc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ncc)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_ncc
            // 
            this.gb_ncc.Controls.Add(this.checkBox_ht);
            this.gb_ncc.Controls.Add(this.btnThem);
            this.gb_ncc.Controls.Add(this.btnsua);
            this.gb_ncc.Controls.Add(this.txt_email);
            this.gb_ncc.Controls.Add(this.label3);
            this.gb_ncc.Controls.Add(this.txt_sdt);
            this.gb_ncc.Controls.Add(this.label2);
            this.gb_ncc.Controls.Add(this.txt_dc);
            this.gb_ncc.Controls.Add(this.label1);
            this.gb_ncc.Controls.Add(this.txt_mancc);
            this.gb_ncc.Controls.Add(this.label9);
            this.gb_ncc.Controls.Add(this.txt_tenncc);
            this.gb_ncc.Controls.Add(this.label10);
            this.gb_ncc.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_ncc.Location = new System.Drawing.Point(0, 0);
            this.gb_ncc.Name = "gb_ncc";
            this.gb_ncc.Size = new System.Drawing.Size(990, 195);
            this.gb_ncc.TabIndex = 0;
            this.gb_ncc.TabStop = false;
            this.gb_ncc.Text = "thông tin nhà cung cấp";
            // 
            // checkBox_ht
            // 
            this.checkBox_ht.AutoSize = true;
            this.checkBox_ht.Location = new System.Drawing.Point(678, 69);
            this.checkBox_ht.Name = "checkBox_ht";
            this.checkBox_ht.Size = new System.Drawing.Size(64, 17);
            this.checkBox_ht.TabIndex = 80;
            this.checkBox_ht.Text = "Hợp tác";
            this.checkBox_ht.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThem.BackColor = System.Drawing.Color.Green;
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThem.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(381, 122);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(94, 34);
            this.btnThem.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.btnThem.Symbol = "";
            this.btnThem.SymbolColor = System.Drawing.Color.SeaGreen;
            this.btnThem.TabIndex = 78;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnsua
            // 
            this.btnsua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnsua.BackColor = System.Drawing.Color.Green;
            this.btnsua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsua.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnsua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.Location = new System.Drawing.Point(504, 122);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(94, 34);
            this.btnsua.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.btnsua.Symbol = "";
            this.btnsua.SymbolColor = System.Drawing.Color.SeaGreen;
            this.btnsua.TabIndex = 77;
            this.btnsua.Text = "Sửa";
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(414, 67);
            this.txt_email.Multiline = true;
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(184, 20);
            this.txt_email.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Email";
            // 
            // txt_sdt
            // 
            this.txt_sdt.Location = new System.Drawing.Point(103, 71);
            this.txt_sdt.Multiline = true;
            this.txt_sdt.Name = "txt_sdt";
            this.txt_sdt.Size = new System.Drawing.Size(184, 20);
            this.txt_sdt.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Số điện thoại";
            // 
            // txt_dc
            // 
            this.txt_dc.Location = new System.Drawing.Point(678, 30);
            this.txt_dc.Multiline = true;
            this.txt_dc.Name = "txt_dc";
            this.txt_dc.Size = new System.Drawing.Size(184, 20);
            this.txt_dc.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(632, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Địa chỉ";
            // 
            // txt_mancc
            // 
            this.txt_mancc.Enabled = false;
            this.txt_mancc.Location = new System.Drawing.Point(103, 30);
            this.txt_mancc.Multiline = true;
            this.txt_mancc.Name = "txt_mancc";
            this.txt_mancc.Size = new System.Drawing.Size(184, 20);
            this.txt_mancc.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Mã nhà cung cấp";
            // 
            // txt_tenncc
            // 
            this.txt_tenncc.Location = new System.Drawing.Point(414, 30);
            this.txt_tenncc.Multiline = true;
            this.txt_tenncc.Name = "txt_tenncc";
            this.txt_tenncc.Size = new System.Drawing.Size(184, 20);
            this.txt_tenncc.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(313, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Tên nhà cung cấp";
            // 
            // dgv_ncc
            // 
            this.dgv_ncc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ncc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ncc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgv_ncc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ncc.Location = new System.Drawing.Point(0, 195);
            this.dgv_ncc.Name = "dgv_ncc";
            this.dgv_ncc.Size = new System.Drawing.Size(990, 173);
            this.dgv_ncc.TabIndex = 1;
            this.dgv_ncc.SelectionChanged += new System.EventHandler(this.dgv_ncc_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MANCC";
            this.Column1.HeaderText = "Mã nhà cung cấp";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TENNCC";
            this.Column2.HeaderText = "Tên nhà cung cấp";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SDTNHACC";
            this.Column3.HeaderText = "Số điện thoại nhà cung cấp";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "EMAIL";
            this.Column4.HeaderText = "Email";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DIACHINCC";
            this.Column5.HeaderText = "Địa chỉ nhà cung cấp";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "HOPTAC";
            this.Column6.HeaderText = "Hợp tác";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // usercontrol_ncc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 368);
            this.Controls.Add(this.dgv_ncc);
            this.Controls.Add(this.gb_ncc);
            this.Name = "usercontrol_ncc";
            this.Load += new System.EventHandler(this.usercontrol_ncc_Load);
            this.gb_ncc.ResumeLayout(false);
            this.gb_ncc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ncc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_ncc;
        private System.Windows.Forms.TextBox txt_dc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_mancc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_tenncc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_sdt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btnThem;
        private DevComponents.DotNetBar.ButtonX btnsua;
        private System.Windows.Forms.DataGridView dgv_ncc;
        private System.Windows.Forms.CheckBox checkBox_ht;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
    }
}
