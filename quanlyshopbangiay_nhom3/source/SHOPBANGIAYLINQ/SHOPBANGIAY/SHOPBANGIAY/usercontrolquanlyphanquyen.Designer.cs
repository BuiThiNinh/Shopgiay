namespace SHOPBANGIAY
{
    partial class usercontrolquanlyphanquyen
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
            this.dgv_nhomnd = new System.Windows.Forms.DataGridView();
            this.dgv_quyentruycap = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cb_danhmucmh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhomnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_quyentruycap)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_nhomnd
            // 
            this.dgv_nhomnd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_nhomnd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_nhomnd.Location = new System.Drawing.Point(31, 105);
            this.dgv_nhomnd.Name = "dgv_nhomnd";
            this.dgv_nhomnd.Size = new System.Drawing.Size(443, 246);
            this.dgv_nhomnd.TabIndex = 0;
            // 
            // dgv_quyentruycap
            // 
            this.dgv_quyentruycap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_quyentruycap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_quyentruycap.Location = new System.Drawing.Point(788, 105);
            this.dgv_quyentruycap.Name = "dgv_quyentruycap";
            this.dgv_quyentruycap.Size = new System.Drawing.Size(418, 246);
            this.dgv_quyentruycap.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(584, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(584, 241);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cb_danhmucmh
            // 
            this.cb_danhmucmh.FormattingEnabled = true;
            this.cb_danhmucmh.Location = new System.Drawing.Point(142, 25);
            this.cb_danhmucmh.Name = "cb_danhmucmh";
            this.cb_danhmucmh.Size = new System.Drawing.Size(209, 21);
            this.cb_danhmucmh.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Màn hình chức năng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cấp quyền";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(142, 63);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(70, 17);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Có quyền";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // usercontrolquanlyphanquyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_danhmucmh);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_quyentruycap);
            this.Controls.Add(this.dgv_nhomnd);
            this.Name = "usercontrolquanlyphanquyen";
            this.Size = new System.Drawing.Size(1223, 452);
            this.Load += new System.EventHandler(this.usercontrolquanlyphanquyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhomnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_quyentruycap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_nhomnd;
        private System.Windows.Forms.DataGridView dgv_quyentruycap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cb_danhmucmh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}
