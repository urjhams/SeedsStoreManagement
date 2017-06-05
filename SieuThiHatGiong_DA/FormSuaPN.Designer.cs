namespace SieuThiHatGiong_DA
{
    partial class FormSuaPN
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
            this.lblMPN = new MetroFramework.Controls.MetroLabel();
            this.lblMaPN = new MetroFramework.Controls.MetroLabel();
            this.grdvw = new System.Windows.Forms.DataGridView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.vhgBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sTHGDataSet15BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sTHGDataSet15 = new SieuThiHatGiong_DA.STHGDataSet15();
            this.v_hgTableAdapter = new SieuThiHatGiong_DA.STHGDataSet15TableAdapters.v_hgTableAdapter();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtGia = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtSL = new MetroFramework.Controls.MetroTextBox();
            this.btnThem = new MetroFramework.Controls.MetroButton();
            this.btnSua = new MetroFramework.Controls.MetroButton();
            this.btnXoa = new MetroFramework.Controls.MetroButton();
            this.btnCl = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdvw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vhgBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet15BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet15)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMPN
            // 
            this.lblMPN.AutoSize = true;
            this.lblMPN.Location = new System.Drawing.Point(24, 81);
            this.lblMPN.Name = "lblMPN";
            this.lblMPN.Size = new System.Drawing.Size(97, 19);
            this.lblMPN.TabIndex = 0;
            this.lblMPN.Text = "Mã phiếu nhập";
            // 
            // lblMaPN
            // 
            this.lblMaPN.AutoSize = true;
            this.lblMaPN.Location = new System.Drawing.Point(147, 80);
            this.lblMaPN.Name = "lblMaPN";
            this.lblMaPN.Size = new System.Drawing.Size(0, 0);
            this.lblMaPN.TabIndex = 1;
            // 
            // grdvw
            // 
            this.grdvw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdvw.Location = new System.Drawing.Point(23, 123);
            this.grdvw.Name = "grdvw";
            this.grdvw.Size = new System.Drawing.Size(445, 161);
            this.grdvw.TabIndex = 2;
            this.grdvw.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdvw_CellContentClick);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 385);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(88, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Tên hạt giống";
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.DataSource = this.vhgBindingSource;
            this.metroComboBox1.DisplayMember = "tenhatgiong";
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Location = new System.Drawing.Point(147, 385);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(159, 29);
            this.metroComboBox1.TabIndex = 4;
            this.metroComboBox1.ValueMember = "pk_mahatgiong";
            // 
            // vhgBindingSource
            // 
            this.vhgBindingSource.DataMember = "v_hg";
            this.vhgBindingSource.DataSource = this.sTHGDataSet15BindingSource;
            // 
            // sTHGDataSet15BindingSource
            // 
            this.sTHGDataSet15BindingSource.DataSource = this.sTHGDataSet15;
            this.sTHGDataSet15BindingSource.Position = 0;
            // 
            // sTHGDataSet15
            // 
            this.sTHGDataSet15.DataSetName = "STHGDataSet15";
            this.sTHGDataSet15.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_hgTableAdapter
            // 
            this.v_hgTableAdapter.ClearBeforeFill = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(24, 339);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(79, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Giá đầu vào";
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(147, 335);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(159, 23);
            this.txtGia.TabIndex = 6;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(24, 307);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(62, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Số lượng";
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(147, 303);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(159, 23);
            this.txtSL.TabIndex = 8;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(169, 429);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(159, 23);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(328, 303);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(328, 335);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCl
            // 
            this.btnCl.Location = new System.Drawing.Point(328, 385);
            this.btnCl.Name = "btnCl";
            this.btnCl.Size = new System.Drawing.Size(75, 23);
            this.btnCl.TabIndex = 13;
            this.btnCl.Text = "Clear";
            this.btnCl.Click += new System.EventHandler(this.btnCl_Click);
            // 
            // FormSuaPN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 468);
            this.Controls.Add(this.btnCl);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.grdvw);
            this.Controls.Add(this.lblMaPN);
            this.Controls.Add(this.lblMPN);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSuaPN";
            this.Text = "CHI TIẾT PHIẾU NHẬP";
            this.Load += new System.EventHandler(this.FormSuaPN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdvw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vhgBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet15BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet15)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblMPN;
        private MetroFramework.Controls.MetroLabel lblMaPN;
        private System.Windows.Forms.DataGridView grdvw;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private System.Windows.Forms.BindingSource sTHGDataSet15BindingSource;
        private STHGDataSet15 sTHGDataSet15;
        private System.Windows.Forms.BindingSource vhgBindingSource;
        private STHGDataSet15TableAdapters.v_hgTableAdapter v_hgTableAdapter;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtGia;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtSL;
        private MetroFramework.Controls.MetroButton btnThem;
        private MetroFramework.Controls.MetroButton btnSua;
        private MetroFramework.Controls.MetroButton btnXoa;
        private MetroFramework.Controls.MetroButton btnCl;
    }
}