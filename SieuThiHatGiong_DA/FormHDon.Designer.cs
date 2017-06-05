namespace SieuThiHatGiong_DA
{
    partial class FormHDon
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pkmahatgiongDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenhatgiongDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hansudungDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dongiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donvitinhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soluongDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblhatgiongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sTHGDataSet111 = new SieuThiHatGiong_DA.STHGDataSet11();
            this.sTHGDataSet11 = new SieuThiHatGiong_DA.STHGDataSet11();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbl_hatgiongTableAdapter = new SieuThiHatGiong_DA.STHGDataSet11TableAdapters.tbl_hatgiongTableAdapter();
            this.btnOK = new MetroFramework.Controls.MetroButton();
            this.btnAdd = new MetroFramework.Controls.MetroButton();
            this.btnDel = new MetroFramework.Controls.MetroButton();
            this.btnChange = new MetroFramework.Controls.MetroButton();
            this.txtSL = new MetroFramework.Controls.MetroTextBox();
            this.lblMaHD = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.col_SLM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblhatgiongBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkmahatgiongDataGridViewTextBoxColumn,
            this.tenhatgiongDataGridViewTextBoxColumn,
            this.hansudungDataGridViewTextBoxColumn,
            this.dongiaDataGridViewTextBoxColumn,
            this.donvitinhDataGridViewTextBoxColumn,
            this.soluongDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblhatgiongBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(10, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(645, 348);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // pkmahatgiongDataGridViewTextBoxColumn
            // 
            this.pkmahatgiongDataGridViewTextBoxColumn.DataPropertyName = "pk_mahatgiong";
            this.pkmahatgiongDataGridViewTextBoxColumn.HeaderText = "Mã hạt giống";
            this.pkmahatgiongDataGridViewTextBoxColumn.Name = "pkmahatgiongDataGridViewTextBoxColumn";
            // 
            // tenhatgiongDataGridViewTextBoxColumn
            // 
            this.tenhatgiongDataGridViewTextBoxColumn.DataPropertyName = "tenhatgiong";
            this.tenhatgiongDataGridViewTextBoxColumn.HeaderText = "Tên";
            this.tenhatgiongDataGridViewTextBoxColumn.Name = "tenhatgiongDataGridViewTextBoxColumn";
            // 
            // hansudungDataGridViewTextBoxColumn
            // 
            this.hansudungDataGridViewTextBoxColumn.DataPropertyName = "hansudung";
            this.hansudungDataGridViewTextBoxColumn.HeaderText = "Hạn sử dụng";
            this.hansudungDataGridViewTextBoxColumn.Name = "hansudungDataGridViewTextBoxColumn";
            // 
            // dongiaDataGridViewTextBoxColumn
            // 
            this.dongiaDataGridViewTextBoxColumn.DataPropertyName = "dongia";
            this.dongiaDataGridViewTextBoxColumn.HeaderText = "Đơn giá";
            this.dongiaDataGridViewTextBoxColumn.Name = "dongiaDataGridViewTextBoxColumn";
            // 
            // donvitinhDataGridViewTextBoxColumn
            // 
            this.donvitinhDataGridViewTextBoxColumn.DataPropertyName = "donvitinh";
            this.donvitinhDataGridViewTextBoxColumn.HeaderText = "Đơn vị tính";
            this.donvitinhDataGridViewTextBoxColumn.Name = "donvitinhDataGridViewTextBoxColumn";
            // 
            // soluongDataGridViewTextBoxColumn
            // 
            this.soluongDataGridViewTextBoxColumn.DataPropertyName = "soluong";
            this.soluongDataGridViewTextBoxColumn.HeaderText = "số lượng hiện có";
            this.soluongDataGridViewTextBoxColumn.Name = "soluongDataGridViewTextBoxColumn";
            // 
            // tblhatgiongBindingSource
            // 
            this.tblhatgiongBindingSource.DataMember = "tbl_hatgiong";
            this.tblhatgiongBindingSource.DataSource = this.sTHGDataSet111;
            // 
            // sTHGDataSet111
            // 
            this.sTHGDataSet111.DataSetName = "STHGDataSet11";
            this.sTHGDataSet111.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sTHGDataSet11
            // 
            this.sTHGDataSet11.DataSetName = "STHGDataSet11";
            this.sTHGDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID,
            this.col_Name,
            this.col_SL,
            this.col_gia,
            this.col_SLM});
            this.dataGridView2.Location = new System.Drawing.Point(712, 73);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(345, 348);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // col_ID
            // 
            this.col_ID.HeaderText = "Mã hạt giống";
            this.col_ID.Name = "col_ID";
            this.col_ID.ReadOnly = true;
            // 
            // col_Name
            // 
            this.col_Name.HeaderText = "Tên hạt giống";
            this.col_Name.Name = "col_Name";
            this.col_Name.ReadOnly = true;
            // 
            // col_SL
            // 
            this.col_SL.HeaderText = "Số lượng lấy";
            this.col_SL.Name = "col_SL";
            this.col_SL.ReadOnly = true;
            // 
            // col_gia
            // 
            this.col_gia.HeaderText = "đơn giá";
            this.col_gia.Name = "col_gia";
            this.col_gia.ReadOnly = true;
            this.col_gia.Visible = false;
            // 
            // tbl_hatgiongTableAdapter
            // 
            this.tbl_hatgiongTableAdapter.ClearBeforeFill = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(712, 459);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(345, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Xác nhận";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(661, 117);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(45, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(661, 165);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(45, 23);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "xóa";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(23, 459);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 5;
            this.btnChange.Text = "Đặt số lượng";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(104, 459);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(71, 23);
            this.txtSL.TabIndex = 6;
            this.txtSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Location = new System.Drawing.Point(447, 462);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(0, 0);
            this.lblMaHD.TabIndex = 8;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(358, 463);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(84, 19);
            this.metroLabel2.TabIndex = 9;
            this.metroLabel2.Text = "Mã hóa đơn:";
            // 
            // col_SLM
            // 
            this.col_SLM.HeaderText = "Số lượng mượn";
            this.col_SLM.Name = "col_SLM";
            this.col_SLM.ReadOnly = true;
            this.col_SLM.Visible = false;
            // 
            // FormHDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 520);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.lblMaHD);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormHDon";
            this.Text = "CHI TIẾT HÓA ĐƠN";
            this.Load += new System.EventHandler(this.FormHDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblhatgiongBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHGDataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private STHGDataSet11 sTHGDataSet11;
        private STHGDataSet11TableAdapters.tbl_hatgiongTableAdapter tbl_hatgiongTableAdapter;
        private MetroFramework.Controls.MetroButton btnOK;
        private MetroFramework.Controls.MetroButton btnAdd;
        private MetroFramework.Controls.MetroButton btnDel;
        private MetroFramework.Controls.MetroButton btnChange;
        private MetroFramework.Controls.MetroTextBox txtSL;
        private MetroFramework.Controls.MetroLabel lblMaHD;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SL;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gia;
        private STHGDataSet11 sTHGDataSet111;
        private System.Windows.Forms.BindingSource tblhatgiongBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkmahatgiongDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenhatgiongDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hansudungDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dongiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn donvitinhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluongDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SLM;
    }
}