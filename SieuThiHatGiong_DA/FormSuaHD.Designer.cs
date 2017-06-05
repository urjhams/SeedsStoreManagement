namespace SieuThiHatGiong_DA
{
    partial class FormSuaHD
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
            this.lblMaHDnoNeed = new MetroFramework.Controls.MetroLabel();
            this.lblMHDV = new MetroFramework.Controls.MetroLabel();
            this.grid_CTHD = new System.Windows.Forms.DataGridView();
            this.btnThem = new MetroFramework.Controls.MetroButton();
            this.btnSua = new MetroFramework.Controls.MetroButton();
            this.btnXoa = new MetroFramework.Controls.MetroButton();
            this.btnCl = new MetroFramework.Controls.MetroButton();
            this.lblHG = new MetroFramework.Controls.MetroLabel();
            this.comboHat = new MetroFramework.Controls.MetroComboBox();
            this.vhgBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sTHGDataSet15 = new SieuThiHatGiong_DA.STHGDataSet15();
            this.sTHGDataSet2 = new SieuThiHatGiong_DA.STHGDataSet2();
            this.sTHGDataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_hgTableAdapter = new SieuThiHatGiong_DA.STHGDataSet15TableAdapters.v_hgTableAdapter();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtSL = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid_CTHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vhgBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaHDnoNeed
            // 
            this.lblMaHDnoNeed.AutoSize = true;
            this.lblMaHDnoNeed.Location = new System.Drawing.Point(24, 78);
            this.lblMaHDnoNeed.Name = "lblMaHDnoNeed";
            this.lblMaHDnoNeed.Size = new System.Drawing.Size(81, 19);
            this.lblMaHDnoNeed.TabIndex = 0;
            this.lblMaHDnoNeed.Text = "Mã hóa đơn";
            // 
            // lblMHDV
            // 
            this.lblMHDV.AutoSize = true;
            this.lblMHDV.Location = new System.Drawing.Point(140, 77);
            this.lblMHDV.Name = "lblMHDV";
            this.lblMHDV.Size = new System.Drawing.Size(0, 0);
            this.lblMHDV.TabIndex = 1;
            // 
            // grid_CTHD
            // 
            this.grid_CTHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_CTHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_CTHD.Location = new System.Drawing.Point(24, 121);
            this.grid_CTHD.Name = "grid_CTHD";
            this.grid_CTHD.Size = new System.Drawing.Size(451, 172);
            this.grid_CTHD.TabIndex = 2;
            this.grid_CTHD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(22, 406);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(147, 406);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(273, 405);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCl
            // 
            this.btnCl.Location = new System.Drawing.Point(398, 406);
            this.btnCl.Name = "btnCl";
            this.btnCl.Size = new System.Drawing.Size(75, 23);
            this.btnCl.TabIndex = 6;
            this.btnCl.Text = "Clear";
            this.btnCl.Click += new System.EventHandler(this.btnCl_Click);
            // 
            // lblHG
            // 
            this.lblHG.AutoSize = true;
            this.lblHG.Location = new System.Drawing.Point(23, 317);
            this.lblHG.Name = "lblHG";
            this.lblHG.Size = new System.Drawing.Size(88, 19);
            this.lblHG.TabIndex = 7;
            this.lblHG.Text = "Tên hạt giống";
            // 
            // comboHat
            // 
            this.comboHat.DataSource = this.vhgBindingSource;
            this.comboHat.DisplayMember = "tenhatgiong";
            this.comboHat.FormattingEnabled = true;
            this.comboHat.ItemHeight = 23;
            this.comboHat.Location = new System.Drawing.Point(140, 307);
            this.comboHat.Name = "comboHat";
            this.comboHat.Size = new System.Drawing.Size(165, 29);
            this.comboHat.TabIndex = 8;
            this.comboHat.ValueMember = "pk_mahatgiong";
            // 
            // vhgBindingSource
            // 
            this.vhgBindingSource.DataMember = "v_hg";
            this.vhgBindingSource.DataSource = this.sTHGDataSet15;
            // 
            // sTHGDataSet15
            // 
            this.sTHGDataSet15.DataSetName = "STHGDataSet15";
            this.sTHGDataSet15.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sTHGDataSet2
            // 
            this.sTHGDataSet2.DataSetName = "STHGDataSet2";
            this.sTHGDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sTHGDataSet2BindingSource
            // 
            this.sTHGDataSet2BindingSource.DataSource = this.sTHGDataSet2;
            this.sTHGDataSet2BindingSource.Position = 0;
            // 
            // v_hgTableAdapter
            // 
            this.v_hgTableAdapter.ClearBeforeFill = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 356);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(62, 19);
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "Số lượng";
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(140, 351);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(165, 23);
            this.txtSL.TabIndex = 10;
            // 
            // FormSuaHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 502);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.comboHat);
            this.Controls.Add(this.lblHG);
            this.Controls.Add(this.btnCl);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grid_CTHD);
            this.Controls.Add(this.lblMHDV);
            this.Controls.Add(this.lblMaHDnoNeed);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSuaHD";
            this.Text = "CHI TIẾT HÓA ĐƠN";
            this.Load += new System.EventHandler(this.FormSuaHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_CTHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vhgBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet2BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblMaHDnoNeed;
        private MetroFramework.Controls.MetroLabel lblMHDV;
        private System.Windows.Forms.DataGridView grid_CTHD;
        private MetroFramework.Controls.MetroButton btnThem;
        private MetroFramework.Controls.MetroButton btnSua;
        private MetroFramework.Controls.MetroButton btnXoa;
        private MetroFramework.Controls.MetroButton btnCl;
        private MetroFramework.Controls.MetroLabel lblHG;
        private MetroFramework.Controls.MetroComboBox comboHat;
        private STHGDataSet2 sTHGDataSet2;
        private System.Windows.Forms.BindingSource sTHGDataSet2BindingSource;
        private STHGDataSet15 sTHGDataSet15;
        private System.Windows.Forms.BindingSource vhgBindingSource;
        private STHGDataSet15TableAdapters.v_hgTableAdapter v_hgTableAdapter;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtSL;
    }
}