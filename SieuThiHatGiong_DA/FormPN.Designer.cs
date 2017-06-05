namespace SieuThiHatGiong_DA
{
    partial class FormPN
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
            this.tblhatgiongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sTHGDataSet11 = new SieuThiHatGiong_DA.STHGDataSet11();
            this.btnAdd = new MetroFramework.Controls.MetroButton();
            this.btnDel = new MetroFramework.Controls.MetroButton();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.maHat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSL = new MetroFramework.Controls.MetroButton();
            this.txtsl = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnOk = new MetroFramework.Controls.MetroButton();
            this.tbl_hatgiongTableAdapter = new SieuThiHatGiong_DA.STHGDataSet11TableAdapters.tbl_hatgiongTableAdapter();
            this.lblMaPN = new MetroFramework.Controls.MetroLabel();
            this.comboHat = new MetroFramework.Controls.MetroComboBox();
            this.col_gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGia = new MetroFramework.Controls.MetroTextBox();
            this.btnGia = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.tblhatgiongBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tblhatgiongBindingSource
            // 
            this.tblhatgiongBindingSource.DataMember = "tbl_hatgiong";
            this.tblhatgiongBindingSource.DataSource = this.sTHGDataSet11;
            // 
            // sTHGDataSet11
            // 
            this.sTHGDataSet11.DataSetName = "STHGDataSet11";
            this.sTHGDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(366, 91);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(354, 377);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(104, 23);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "xóa";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maHat,
            this.SL,
            this.name,
            this.col_gia});
            this.dataGridView2.Location = new System.Drawing.Point(23, 126);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(443, 245);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // maHat
            // 
            this.maHat.HeaderText = "Mã hạt giống";
            this.maHat.Name = "maHat";
            this.maHat.ReadOnly = true;
            // 
            // SL
            // 
            this.SL.HeaderText = "Số lượng thêm";
            this.SL.Name = "SL";
            this.SL.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Tên hạt giống";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // btnSL
            // 
            this.btnSL.Location = new System.Drawing.Point(126, 406);
            this.btnSL.Name = "btnSL";
            this.btnSL.Size = new System.Drawing.Size(80, 23);
            this.btnSL.TabIndex = 4;
            this.btnSL.Text = "Đặt số lượng";
            this.btnSL.Click += new System.EventHandler(this.btnSL_Click);
            // 
            // txtsl
            // 
            this.txtsl.Location = new System.Drawing.Point(23, 406);
            this.txtsl.Name = "txtsl";
            this.txtsl.Size = new System.Drawing.Size(97, 23);
            this.txtsl.TabIndex = 5;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(104, 19);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Mã phiếu nhập: ";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(69, 446);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(344, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Xác nhận";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tbl_hatgiongTableAdapter
            // 
            this.tbl_hatgiongTableAdapter.ClearBeforeFill = true;
            // 
            // lblMaPN
            // 
            this.lblMaPN.AutoSize = true;
            this.lblMaPN.Location = new System.Drawing.Point(147, 59);
            this.lblMaPN.Name = "lblMaPN";
            this.lblMaPN.Size = new System.Drawing.Size(0, 0);
            this.lblMaPN.TabIndex = 8;
            // 
            // comboHat
            // 
            this.comboHat.DataSource = this.tblhatgiongBindingSource;
            this.comboHat.DisplayMember = "tenhatgiong";
            this.comboHat.FormattingEnabled = true;
            this.comboHat.ItemHeight = 23;
            this.comboHat.Location = new System.Drawing.Point(23, 91);
            this.comboHat.Name = "comboHat";
            this.comboHat.Size = new System.Drawing.Size(315, 29);
            this.comboHat.TabIndex = 9;
            this.comboHat.ValueMember = "pk_mahatgiong";
            // 
            // col_gia
            // 
            this.col_gia.HeaderText = "Giá đầu vào";
            this.col_gia.Name = "col_gia";
            this.col_gia.ReadOnly = true;
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(23, 377);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(183, 23);
            this.txtGia.TabIndex = 10;
            // 
            // btnGia
            // 
            this.btnGia.Location = new System.Drawing.Point(212, 377);
            this.btnGia.Name = "btnGia";
            this.btnGia.Size = new System.Drawing.Size(80, 23);
            this.btnGia.TabIndex = 11;
            this.btnGia.Text = "Giá đầu vào";
            this.btnGia.Click += new System.EventHandler(this.btnGia_Click);
            // 
            // FormPN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 492);
            this.Controls.Add(this.btnGia);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.comboHat);
            this.Controls.Add(this.lblMaPN);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtsl);
            this.Controls.Add(this.btnSL);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "FormPN";
            this.Resizable = false;
            this.Text = "CHI TIẾT PHIẾU NHẬP";
            this.Load += new System.EventHandler(this.FormPN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblhatgiongBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnAdd;
        private MetroFramework.Controls.MetroButton btnDel;
        private System.Windows.Forms.DataGridView dataGridView2;
        private MetroFramework.Controls.MetroButton btnSL;
        private MetroFramework.Controls.MetroTextBox txtsl;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnOk;
        private STHGDataSet11 sTHGDataSet11;
        private System.Windows.Forms.BindingSource tblhatgiongBindingSource;
        private STHGDataSet11TableAdapters.tbl_hatgiongTableAdapter tbl_hatgiongTableAdapter;
        private MetroFramework.Controls.MetroLabel lblMaPN;
        private MetroFramework.Controls.MetroComboBox comboHat;
        private System.Windows.Forms.DataGridViewTextBoxColumn maHat;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gia;
        private MetroFramework.Controls.MetroTextBox txtGia;
        private MetroFramework.Controls.MetroButton btnGia;
    }
}