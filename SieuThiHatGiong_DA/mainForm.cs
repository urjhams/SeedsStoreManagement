using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Animation;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SieuThiHatGiong_DA
{
    public partial class mainForm : MetroFramework.Forms.MetroForm
    {
        public DataTable dt;
        public static SqlConnection con;
        public static String constr = ConfigurationManager.ConnectionStrings["Con"].ToString();
        
        public mainForm()
        {
            InitializeComponent();

            this.tileLogout.Visible = false;
            this.tileDoiMK.Visible = false;

            this.radioSName.Checked = true;
            this.radioSBoth.Checked = true;
            this.radioSnameKH.Checked = true;
            this.radioSBothKH.Checked = true;
            this.radioSnameHat.Checked = true;
        }
        public void onlyForAdmin()
        {
            this.metroTabPage1.Controls.Clear();
            this.metroTabPage6.Controls.Clear();
            MetroFramework.Controls.MetroLabel warningNV = new MetroFramework.Controls.MetroLabel();
            MetroFramework.Controls.MetroLabel warningTK = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage1.Controls.Add(warningNV);
            this.metroTabPage6.Controls.Add(warningTK);
            warningNV.AutoSize = true;
            warningNV.Location = new System.Drawing.Point(350,200);
            warningNV.Name = "warningNV";
            warningNV.Size = new System.Drawing.Size(86, 19);
            warningNV.TabIndex = 30;
            warningNV.Text = "Chức năng chỉ hỗ trợ cho tài khoản quản trị";
            warningTK.AutoSize = true;
            warningTK.Location = new System.Drawing.Point(350, 200);
            warningTK.Name = "warningNV";
            warningTK.Size = new System.Drawing.Size(86, 19);
            warningTK.TabIndex = 30;
            warningTK.Text = "Chức năng chỉ hỗ trợ cho tài khoản quản trị";
        }
        public void setCurrentUserAcc(string account)
        {
            tileAcc.Text = account;
        }
        private void mainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sTHGDataSet14.v_loaihatgiong' table. You can move, or remove it, as needed.
            this.v_loaihatgiongTableAdapter2.Fill(this.sTHGDataSet14.v_loaihatgiong);
            // TODO: This line of code loads data into the 'sTHGDataSet13.v_nhacungcap' table. You can move, or remove it, as needed.
            this.v_nhacungcapTableAdapter2.Fill(this.sTHGDataSet13.v_nhacungcap);
            // TODO: This line of code loads data into the 'sTHGDataSet12.v_phieunhap' table. You can move, or remove it, as needed.
            this.v_phieunhapTableAdapter.Fill(this.sTHGDataSet12.v_phieunhap);
            this.txtSearchHat.Text = "Tìm kiếm hạt giống";
            this.txtSearchKH.Text = "Tìm kiếm khách hàng";
            this.txtSearchNV.Text = "Tìm kiếm nhân viên";
            this.txtMaNCC.ReadOnly = true;
            this.txtmaLoaiHat.ReadOnly = true;
            // TODO: This line of code loads data into the 'sTHGDataSet10.v_hoadon' table. You can move, or remove it, as needed.
            this.v_hoadonTableAdapter.Fill(this.sTHGDataSet10.v_hoadon);
            // TODO: This line of code loads data into the 'sTHGDataSet9.v_quyen' table. You can move, or remove it, as needed.
            this.v_quyenTableAdapter.Fill(this.sTHGDataSet9.v_quyen);
            // TODO: This line of code loads data into the 'sTHGDataSet8.v_nhacungcap' table. You can move, or remove it, as needed.
            this.v_nhacungcapTableAdapter2.Fill(this.sTHGDataSet13.v_nhacungcap);
            // TODO: This line of code loads data into the 'sTHGDataSet7.v_loaihatgiong' table. You can move, or remove it, as needed.
            this.v_loaihatgiongTableAdapter2.Fill(this.sTHGDataSet14.v_loaihatgiong);
            // TODO: This line of code loads data into the 'sTHGDataSet6.v_tk' table. You can move, or remove it, as needed.
            this.v_tkTableAdapter.Fill(this.sTHGDataSet6.v_tk);
            // TODO: This line of code loads data into the 'sTHGDataSet5.v_loaihatgiong' table. You can move, or remove it, as needed.
            this.v_loaihatgiongTableAdapter2.Fill(this.sTHGDataSet14.v_loaihatgiong);
            // TODO: This line of code loads data into the 'sTHGDataSet4.v_nhacungcap' table. You can move, or remove it, as needed.
            this.v_nhacungcapTableAdapter2.Fill(this.sTHGDataSet13.v_nhacungcap);
            // TODO: This line of code loads data into the 'sTHGDataSet3.v_taikhoan' table. You can move, or remove it, as needed.
            this.v_taikhoanTableAdapter.Fill(this.sTHGDataSet3.v_taikhoan);
            // TODO: This line of code loads data into the 'sTHGDataSet2.v_hatgiong' table. You can move, or remove it, as needed.
            this.v_hatgiongTableAdapter.Fill(this.sTHGDataSet2.v_hatgiong);
            // TODO: This line of code loads data into the 'sTHGDataSet1.v_khachhang' table. You can move, or remove it, as needed.
            this.v_khachhangTableAdapter.Fill(this.sTHGDataSet1.v_khachhang);
            // TODO: This line of code loads data into the 'sTHGDataSet.v_nhanvien' table. You can move, or remove it, as needed.
            this.v_nhanvienTableAdapter.Fill(this.sTHGDataSet.v_nhanvien);
            comboNVID.SelectedIndex = -1;
            //comboNhacungcapHat.SelectedIndex = -1;
            comboNhomHat.SelectedIndex = -1;
            comboQuyen.SelectedIndex = -1;
            //dtp.Format = DateTimePickerFormat.Custom;
            //dtp.CustomFormat = "yyyy/MM/dd";
        }

        public void refreshForm()
        {
            this.gw_HD.DataSource = loadHD();
            this.gw_HatGiong.DataSource = loadHG();
            this.grid_Phieunhap.DataSource = loadPhieu();
            this.grid_Phieunhap.Refresh();
            this.gw_HD.Refresh();
            this.gw_HatGiong.Refresh();
        }



        //-------------------------tab nhân viên-------------------------
        private void btn_themNV_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_themnhanvien", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pk_manv", comboNVID.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@tennhanvien", txtTenNV.Text);
                cmd.Parameters.Add(new SqlParameter("@ngaysinh", SqlDbType.Date)).Value = datePickNgaysinhNV.Value.ToShortDateString();
                string gt = "";
                if (radioNam.Checked)
                {
                    gt = "Nam";
                }    
                else if (radioNu.Checked)
                {
                    gt = "Nữ";
                }
                cmd.Parameters.AddWithValue("@gioitinh", gt);
                cmd.Parameters.AddWithValue("@diachi", txtDiachiNV.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSdtNV.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                this.gw_NV.DataSource = loadNV();
                clearNVProgess();
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("tài khoản đã được sử dụng\n" + ex.Message);
            }
            
        }
        // nút sửa
        private void btn_suaNV_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_suanhanvien", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pk_manv", comboNVID.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@tennhanvien", txtTenNV.Text);
                cmd.Parameters.Add(new SqlParameter("@ngaysinh", SqlDbType.Date)).Value = datePickNgaysinhNV.Value.ToShortDateString();
                string gt = "";
                if (radioNam.Checked)
                {
                    gt = "Nam";
                }
                else if (radioNu.Checked)
                {
                    gt = "Nữ";
                }
                cmd.Parameters.AddWithValue("@gioitinh", gt);
                cmd.Parameters.AddWithValue("@diachi", txtDiachiNV.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSdtNV.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                this.gw_NV.DataSource = loadNV();
                this.gw_NV.Refresh();
                clearNVProgess();
                MessageBox.Show("Sửa thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rowenternv(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            comboNVID.SelectedValue = gw_NV.Rows[dong].Cells[0].Value.ToString();
            txtTenNV.Text = gw_NV.Rows[dong].Cells[1].Value.ToString();
            datePickNgaysinhNV.Value = Convert.ToDateTime(gw_NV.Rows[dong].Cells[2].Value.ToString());
            if (gw_NV.Rows[dong].Cells[3].Value.ToString() == "Nam")
            {
                radioNam.Checked = true;
            }
            else if (gw_NV.Rows[dong].Cells[3].Value.ToString() == "Nữ")
            {
                radioNu.Checked = true;
            }
            txtDiachiNV.Text = gw_NV.Rows[dong].Cells[4].Value.ToString();
            txtSdtNV.Text = gw_NV.Rows[dong].Cells[5].Value.ToString();
            datePickNgaysinhNV.Format = DateTimePickerFormat.Custom;
            datePickNgaysinhNV.CustomFormat = "dd/MM/yyyy";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearNVProgess();
            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = " ";
        }

        private void clearNVProgess()
        {
            comboNVID.SelectedIndex = -1;
            comboNVID.Refresh();
            radioNam.Checked = false;
            radioNu.Checked = false;
            txtTenNV.Text = "";
            txtDiachiNV.Text = "";
            txtSdtNV.Text = "";
        }


        //------------------------- tab khách hàng -------------------------
        private void btn_ThemKH_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_themkhachhang", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pk_makhachhang", txtmaKH.Text);
                cmd.Parameters.AddWithValue("@tenkhachhang", txtHotenKH.Text);
                cmd.Parameters.Add(new SqlParameter("@ngaysinh", SqlDbType.Date)).Value = dateTimePicker2.Value.ToShortDateString();
                if (radioNamKH.Checked)
                    cmd.Parameters.AddWithValue("@gioitinh", "Nam");
                else if (radioNuKH.Checked)
                    cmd.Parameters.AddWithValue("@gioitinh", "Nữ");
                cmd.Parameters.AddWithValue("@diachi", txtDiachiKH.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSdtKH.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                this.gw_KH.DataSource = loadKH();
                clearKHProgess();
                MessageBox.Show("Thêm thành công", "Đã thêm thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_suaKH_Click(object sender, EventArgs e)
        {
           try
            {
                con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_suakhachhang", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pk_makhachhang", txtmaKH.Text);
                cmd.Parameters.AddWithValue("@tenkhachhang", txtHotenKH.Text);
                cmd.Parameters.Add(new SqlParameter("@ngaysinh", SqlDbType.Date)).Value = dateTimePicker2.Value.ToShortDateString();
                if (radioNamKH.Checked)
                    cmd.Parameters.AddWithValue("@gioitinh", "Nam");
                else if (radioNuKH.Checked)
                    cmd.Parameters.AddWithValue("@gioitinh", "Nữ");
                cmd.Parameters.AddWithValue("@diachi", txtDiachiKH.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSdtKH.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                this.gw_KH.DataSource = loadKH();
                MessageBox.Show("Đã sửa thành công", "Thành công");
                clearKHProgess();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaKH_Click(object sender, EventArgs e)
        {
            DialogResult confirm_xoa = MessageBox.Show("Thao tác này sẽ xóa cả các hóa đơn của khách hàng, chắc chắn xóa chứ?","Cảnh báo",MessageBoxButtons.YesNo);
            if (confirm_xoa == DialogResult.Yes)
            {
                try
                {
                    con = new SqlConnection(constr);
                    SqlCommand cmd = new SqlCommand("sp_del_HDnKH",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pk_makhachhang", txtmaKH.Text);

                    SqlCommand cmd0 = new SqlCommand("sp_get_CTHD_fromKH",con); // B1: lấy & xóa các chi tiết hóa đơn của khách hàng
                    cmd0.CommandType = CommandType.StoredProcedure;
                    cmd0.Parameters.AddWithValue("@maKH", txtmaKH.Text);

                    con.Open();
                    using (var result = cmd0.ExecuteReader())
                    {
                        foreach(IDataRecord record in result)
                        {
                            SqlCommand cmd1 = new SqlCommand("sp_del_CTHD", con);
                            cmd1.Parameters.AddWithValue("@maCTHD", record.ToString());
                            cmd1.ExecuteNonQuery();
                        }
                    }
                    cmd.ExecuteNonQuery();  //B2: xóa hóa đơn và khách hàng
                    con.Close();
                    MessageBox.Show("Đã xóa thông tin khách hàng và các thông tin hóa đơn liên quan","Xóa thành công");
                    this.gw_KH.DataSource = loadKH();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (confirm_xoa == DialogResult.No)
            {

            }
        }

        private void rowenterkh(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtmaKH.Text = gw_KH.Rows[dong].Cells[0].Value.ToString();
            txtHotenKH.Text = gw_KH.Rows[dong].Cells[1].Value.ToString();
            dateTimePicker2.Value = Convert.ToDateTime(gw_KH.Rows[dong].Cells[2].Value.ToString());
            if (gw_KH.Rows[dong].Cells[3].Value.ToString() == "Nam")
            {
                radioNamKH.Checked = true;
            }
            else if (gw_KH.Rows[dong].Cells[3].Value.ToString() == "Nữ")
            {
                radioNuKH.Checked = true;
            }
            txtDiachiKH.Text = gw_KH.Rows[dong].Cells[4].Value.ToString();
            txtSdtKH.Text = gw_KH.Rows[dong].Cells[5].Value.ToString();
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void btn_clearKH_Click(object sender, EventArgs e)
        {
            clearKHProgess();
        }

        private void clearKHProgess()
        {
            txtmaKH.Text = "";
            radioNamKH.Checked = false;
            radioNuKH.Checked = false;
            txtHotenKH.Text = "";
            txtDiachiKH.Text = "";
            txtSdtKH.Text = "";
        }



        //--------------------------- tab hạt giống ----------------------------
        private void btn_addHat_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_themhatgiong", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pk_mahatgiong", txtMaHat.Text);
                cmd.Parameters.AddWithValue("@tenhatgiong", txtTenHat.Text);
                cmd.Parameters.AddWithValue("@mota", txtMotaHat.Text);
                cmd.Parameters.Add(new SqlParameter("@ngaysanxuat", SqlDbType.Date)).Value = datePickNSXHat.Value.ToShortDateString();
                cmd.Parameters.Add(new SqlParameter("@hansudung", SqlDbType.Date)).Value = datePickHSDHat.Value.ToShortDateString();
                cmd.Parameters.AddWithValue("@dongia", txtGiaHat.Text);
                cmd.Parameters.AddWithValue("@donvitinh", txtDonviHat.Text);
                cmd.Parameters.AddWithValue("@fk_maloaihatgiong", comboNhomHat.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@sl", "");
                cmd.ExecuteNonQuery();
                con.Close();
                this.gw_HatGiong.DataSource = loadHat();
                MessageBox.Show("Thêm thành công");
                clearHatProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_suaHat_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_suahatgiong", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pk_mahatgiong", txtMaHat.Text);
                cmd.Parameters.AddWithValue("@tenhatgiong", txtTenHat.Text);
                cmd.Parameters.AddWithValue("@mota", txtMotaHat.Text);
                cmd.Parameters.Add(new SqlParameter("@ngaysanxuat", SqlDbType.Date)).Value = datePickNSXHat.Value.ToShortDateString();
                cmd.Parameters.Add(new SqlParameter("@hansudung", SqlDbType.Date)).Value = datePickHSDHat.Value.ToShortDateString();
                cmd.Parameters.AddWithValue("@dongia", txtGiaHat.Text);
                cmd.Parameters.AddWithValue("@donvitinh", txtDonviHat.Text);
                cmd.Parameters.AddWithValue("@fk_maloaihatgiong", comboNhomHat.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@sl","");
                cmd.ExecuteNonQuery();
                con.Close();
                this.gw_HatGiong.DataSource = loadHat();
                MessageBox.Show("Sửa thành công");
                clearHatProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        private void rowenterhg(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtMaHat.Text = gw_HatGiong.Rows[dong].Cells[0].Value.ToString();
            txtTenHat.Text = gw_HatGiong.Rows[dong].Cells[1].Value.ToString();
            txtMotaHat.Text = gw_HatGiong.Rows[dong].Cells[2].Value.ToString();
            datePickNSXHat.Value = Convert.ToDateTime(gw_HatGiong.Rows[dong].Cells[3].Value.ToString());
            datePickHSDHat.Value = Convert.ToDateTime(gw_HatGiong.Rows[dong].Cells[4].Value.ToString());
            txtGiaHat.Text = gw_HatGiong.Rows[dong].Cells[5].Value.ToString();
            txtDonviHat.Text = gw_HatGiong.Rows[dong].Cells[6].Value.ToString();
            string test = gw_HatGiong.Rows[dong].Cells[7].Value.ToString();
            this.comboNhomHat.Text = gw_HatGiong.Rows[dong].Cells[7].Value.ToString();
            //this.txtSLHat.Text = gw_HatGiong.Rows[dong].Cells[8].Value.ToString();
            datePickNSXHat.Format = DateTimePickerFormat.Custom;
            datePickNSXHat.CustomFormat = "dd/MM/yyyy";
            datePickHSDHat.Format = DateTimePickerFormat.Custom;
            datePickHSDHat.CustomFormat = "dd/MM/yyyy";
        }

        private void btn_clearHat_Click(object sender, EventArgs e)
        {
            clearHatProgress();
        }
        private void clearHatProgress()
        {
            txtMaHat.Text = "";
            comboNhomHat.SelectedIndex = -1;
            comboNhomHat.Refresh();
            txtTenHat.Text = "";
            txtMotaHat.Text = "";
            txtGiaHat.Text = "";
            txtDonviHat.Text = "";
        }


        //----------------------------- -------------------------------
        private void btn_addNCC_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_themnhacungcap", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pk_manhacungcap", txtMaNCC.Text);
                cmd.Parameters.AddWithValue("@tennhacungcap", txtTenNCC.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                this.v_nhacungcapTableAdapter1.Fill(this.sTHGDataSet8.v_nhacungcap);
                clearNCCProgess();
                MessageBox.Show("Thêm thành cống");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_suaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_suanhacungcap", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pk_manhacungcap", txtMaNCC.Text);
                cmd.Parameters.AddWithValue("@tennhacungcap", txtTenNCC.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                this.v_nhacungcapTableAdapter1.Fill(this.sTHGDataSet8.v_nhacungcap);
                clearNCCProgess();
                MessageBox.Show("Sửa thành cống");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void rowenterncc(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtMaNCC.Text = gw_NCC.Rows[dong].Cells[0].Value.ToString();
            txtTenNCC.Text = gw_NCC.Rows[dong].Cells[1].Value.ToString();
        }

        private void btn_clearNCC_Click(object sender, EventArgs e)
        {
            clearNCCProgess();
        }
        private void clearNCCProgess()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
        }

        //------------------------- ----------------------------
        private void btn_addLoaiHat_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_themloaihatgiong", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pk_maloaihatgiong", txtmaLoaiHat.Text);
                cmd.Parameters.AddWithValue("@nhomloaihatgiong", txtNhonHat.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                this.v_loaihatgiongTableAdapter1.Fill(this.sTHGDataSet7.v_loaihatgiong);
                clearLoaiHatProgress();
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void btn_suaLoaiHat_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_sualoaihatgiong", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pk_maloaihatgiong", txtmaLoaiHat.Text);
                cmd.Parameters.AddWithValue("@nhomloaihatgiong", txtNhonHat.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                this.v_loaihatgiongTableAdapter1.Fill(this.sTHGDataSet7.v_loaihatgiong);
                clearLoaiHatProgress();
                MessageBox.Show("Sửa thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void rowenterlhg(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtmaLoaiHat.Text = gw_LoaiHat.Rows[dong].Cells[0].Value.ToString();
            txtNhonHat.Text = gw_LoaiHat.Rows[dong].Cells[1].Value.ToString();
        }

        private void btn_clearLoaiHat_Click(object sender, EventArgs e)
        {
            clearLoaiHatProgress();
        }
        private void clearLoaiHatProgress()
        {
            txtmaLoaiHat.Text = "";
            txtNhonHat.Text = "";
        }


        //------------------------- tab tài khoản -------------------------
        private void btn_addTK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtTK.Text.ToString().Length <= 15)
                {
                    con = new SqlConnection(constr);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_themtaikhoan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tendangnhap", txtTK.Text);
                    cmd.Parameters.AddWithValue("@matkhau", txtMK.Text);
                    cmd.Parameters.AddWithValue("@quyen", comboQuyen.SelectedValue.ToString());
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand("select pk_tendangnhap from tbl_taikhoan", con);
                    SqlDataAdapter tkAdapter = new SqlDataAdapter();
                    tkAdapter.SelectCommand = cmd1;
                    DataTable listTK = new DataTable();
                    tkAdapter.Fill(listTK);
                    this.comboNVID.DataSource = listTK;
                    this.comboNVID.Refresh();
                    con.Close();
                    this.v_tkTableAdapter.Fill(this.sTHGDataSet6.v_tk);
                    clearTKProgess();
                }
                else
                {
                    MessageBox.Show("Tài khoản chỉ giới hạn từ 0 tới 15 ký tự");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_suaTK_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_suataikhoan", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tendangnhap", txtTK.Text.ToString());
                cmd.Parameters.AddWithValue("@matkhau", txtMK.Text.ToString());
                cmd.Parameters.AddWithValue("@quyen", comboQuyen.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công");
                con.Close();
                this.v_tkTableAdapter.Fill(this.sTHGDataSet6.v_tk);
                clearTKProgess();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void rowentertk(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtTK.Text = s.Rows[dong].Cells[0].Value.ToString();
            txtMK.Text = s.Rows[dong].Cells[1].Value.ToString();
            comboQuyen.SelectedValue = s.Rows[dong].Cells[2].Value.ToString();
        }

        private void btn_clearTK_Click(object sender, EventArgs e)
        {
            clearTKProgess();
        }
        private void clearTKProgess()
        {
            txtTK.Text = "";
            txtMK.Text = "";
            comboQuyen.SelectedIndex = -1;
            comboQuyen.Refresh();
        }


        //------------------------- tab hóa đơn -------------------------
        private void metroButton25_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(constr);
                SqlCommand cmd0 = new SqlCommand("select count(*) from tbl_nhanvien inner join tbl_taikhoan on tbl_nhanvien.pk_manv = tbl_taikhoan.pk_tendangnhap where pk_tendangnhap = '"+ this.tileAcc.Text.ToString() +"'", con);
                con.Open();
                int rs = Convert.ToInt32(cmd0.ExecuteScalar());
                con.Close();
                if (rs == 1)
                {
                    SqlCommand cmd00 = new SqlCommand("select count(*) from tbl_hoadon where pk_mahoadon = '" + txtmaHD.Text + "'", con);
                    con.Open();
                    int result = Convert.ToInt32(cmd00.ExecuteScalar());
                    con.Close();
                    if (result == 1)
                    {
                        MessageBox.Show("Đã tồn tại mã hóa đơn này rồi");
                        return;
                    } else
                    {
                        FormHDon formhd = new FormHDon(this);
                        formhd.getPreInfo(tileAcc.Text, txtmaHD.Text, comboKH.SelectedValue.ToString());
                        formhd.Show();
                    }
                }
                else if (rs == 0)
                {
                    MessageBox.Show("Chưa có nhân viên nào được gán với tài khoản này \nKhông thể tạo hóa đơn","Chưa có nhân viên");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.v_hoadonTableAdapter.Fill(this.sTHGDataSet10.v_hoadon);
        }
        private int dongHD;
        private void gwhdclick(object sender, DataGridViewCellEventArgs e)
        {
            dongHD = e.RowIndex;
            this.txtmaHD.Text = this.gw_HD.Rows[dongHD].Cells[0].Value.ToString();
            this.comboKH.Text = this.gw_HD.Rows[dongHD].Cells[3].Value.ToString();
        }
        //----------------------------------- chức năng tìm kiếm -------------------------------------
        private void txtSearchNV_Enter(object sender, EventArgs e)
        {
            if(this.txtSearchNV.Text == "Tìm kiếm nhân viên")
            {
                this.txtSearchNV.Text = "";
            }
        }

        private void txtSearchNV_Leave(object sender, EventArgs e)
        {
            if (this.txtSearchNV.Text == "")
            {
                this.txtSearchNV.Text = "Tìm kiếm nhân viên";
            }
        }
            
        private void txtSearchHat_Enter(object sender, EventArgs e)
        {
            if(this.txtSearchHat.Text == "Tìm kiếm hạt giống")
            {
                this.txtSearchHat.Text = "";
            }
            
        }

        private void txtSearchHat_Leave(object sender, EventArgs e)
        {
            if (this.txtSearchHat.Text == "")
            {
                this.txtSearchHat.Text = "Tìm kiếm hạt giống";
            }
        }

        private void txtSearchKH_Enter(object sender, EventArgs e)
        {
            if (this.txtSearchKH.Text == "Tìm kiếm khách hàng")
            {
                this.txtSearchKH.Text = "";
            }
        }

        private void txtSearchKH_Leave(object sender, EventArgs e)
        {
            if (this.txtSearchKH.Text == "")
            {
                this.txtSearchKH.Text = "Tìm kiếm khách hàng";
            }
        }


        private DataTable LoadData(string procName)
        {
            con = new SqlConnection(constr);
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        private DataTable loadNV()
        {
            DataTable dt = LoadData("xem_all_NV");
            return dt;
        }
        private DataTable kq_Search_NV(string input)
        {
            
            con = new SqlConnection(constr);
            DataTable ketQua = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_searchnv_nameOrdc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (this.radioSName.Checked == true)
            {
                cmd.Parameters.AddWithValue("@ten", input);
                cmd.Parameters.AddWithValue("@dc", "");
            }
            else if (this.radioSdc.Checked == true)
            {
                cmd.Parameters.AddWithValue("@ten", "");
                cmd.Parameters.AddWithValue("@dc", input);
            }
            if (this.radioSBoth.Checked == true)
            {
                cmd.Parameters.AddWithValue("@gt", "");
            } else if (this.radioSNam.Checked == true)
            {
                cmd.Parameters.AddWithValue("@gt", "Nam");
            } else if (this.radioSNu.Checked == true) {
                cmd.Parameters.AddWithValue("@gt", "Nữ");
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ketQua);
            con.Close();
            return ketQua;
        }
        private DataTable loadHat()
        {
            DataTable dt = LoadData("xem_all_Hat");
            return dt;
        }

        private DataTable kq_Search_hat(string input)
        {
            con = new SqlConnection(constr);
            DataTable ketQua = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_searchHat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (this.radioSnameHat.Checked == true)
            {
                cmd.Parameters.AddWithValue("@ten", input);
            } else
            {
                cmd.Parameters.AddWithValue("@ten", "");
            }
            if (this.radioSgroupHat.Checked == true)
            {
                cmd.Parameters.AddWithValue("@nhomloai", input);
            } else
            {
                cmd.Parameters.AddWithValue("@nhomloai", "");
            }
            /*if (this.radioSprovideHat.Checked == true)
            {
                cmd.Parameters.AddWithValue("@nhacungcap", input);
            } else
            {
                cmd.Parameters.AddWithValue("@nhacungcap", "");
            }*/
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ketQua);
            con.Close();
            return ketQua;
        }

        private DataTable loadKH()
        {
            DataTable dt = LoadData("xem_all_KH");
            return dt;
        }

        private DataTable kq_Search_KH(string input)
        {
            con = new SqlConnection(constr);
            DataTable ketQua = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_searchKH", con);
            cmd.CommandType = CommandType.StoredProcedure;
            // parameter @ten, @dc, @sdt
            if (this.radioSnameKH.Checked == true)
            {
                cmd.Parameters.AddWithValue("@ten", input);
                cmd.Parameters.AddWithValue("@dc", "");
                cmd.Parameters.AddWithValue("@sdt", "");
            }
            else if (this.radioSdcKH.Checked == true)
            {
                cmd.Parameters.AddWithValue("@ten", "");
                cmd.Parameters.AddWithValue("@dc", input);
                cmd.Parameters.AddWithValue("@sdt", "");
            }
            else if (this.radioSsdtKH.Checked == true)
            {
                cmd.Parameters.AddWithValue("@ten", "");
                cmd.Parameters.AddWithValue("@dc", "");
                cmd.Parameters.AddWithValue("@sdt", input);
            }
            // parameter @gt
            if (this.radioSNamKH.Checked == true)
            {
                cmd.Parameters.AddWithValue("@gt", "Nam");
            }
            else if (this.radioSNuKH.Checked == true)
            {
                cmd.Parameters.AddWithValue("@gt", "Nữ");
            }
            else if (this.radioSBothKH.Checked == true)
            {
                cmd.Parameters.AddWithValue("@gt", "");
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ketQua);
            con.Close();
            return ketQua;
        }

        private DataTable loadHD()
        {
            DataTable dt = LoadData("xem_all_HD");
            return dt;
        }
        private DataTable loadPhieu()
        {
            DataTable dt = LoadData("xem_all_Phieunhap");
            return dt;
        }
        private DataTable loadHG()
        {
            DataTable dt = LoadData("xem_all_Hatgiong");
            return dt;
        }
        private void tileAcc_Click(object sender, EventArgs e)
        {
            if (this.tileDoiMK.Visible == true && this.tileLogout.Visible == true) {
                this.tileDoiMK.Visible = false;
                this.tileLogout.Visible = false;
            } else if (this.tileDoiMK.Visible == false && this.tileLogout.Visible == false)
            {
                this.tileDoiMK.Visible = true;
                this.tileLogout.Visible = true;
            } else
            {
                this.tileDoiMK.Visible = false;
                this.tileLogout.Visible = false;
            }
        }

        private void tileDoiMK_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(constr);
            FormDMK form = new FormDMK();
            SqlCommand cmd = new SqlCommand("select matkhau from tbl_taikhoan where pk_tendangnhap = '" + this.tileAcc.Text.ToString() + "'", con);
            con.Open();
            form.getPwd(cmd.ExecuteScalar().ToString(), this.tileAcc.Text.ToString());
            con.Close();
            form.ShowDialog();
        }

        private void tileLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Đăng xuất?","" , MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Form1 form = new Form1();
                this.Hide();
                this.Close();
                form.ShowDialog();
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (this.txtSearchNV.Text.ToString() == "Tìm kiếm nhân viên")
            {
                this.gw_NV.DataSource = loadNV();
                this.gw_NV.Refresh();
            }
            else
            {
                string keyword = txtSearchNV.Text;
                this.gw_NV.DataSource = kq_Search_NV(keyword);
            }
        }

        private void tileSKH_Click(object sender, EventArgs e)
        {
            if (this.txtSearchKH.Text.ToString() == "Tìm kiếm khách hàng")
            {
                this.gw_KH.DataSource = loadKH();
                this.gw_KH.Refresh();
            }
            else
            {
                string keyword = txtSearchKH.Text;
                this.gw_KH.DataSource = kq_Search_KH(keyword);
            }
        }

        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            if (this.txtSearchHat.Text.ToString() == "Tìm kiếm hạt giống")
            {
                this.gw_HatGiong.DataSource = loadHat();
                this.gw_HatGiong.Refresh();
            }
            else
            {
                string keyword = txtSearchHat.Text;
                this.gw_HatGiong.DataSource = kq_Search_hat(keyword);
            }
        }

        //private void btnPhieuNhap_Click(object sender, EventArgs e)
        //{
        //    con = new SqlConnection(constr);
        //    SqlCommand cmd = new SqlCommand("sp_newest_PN", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    con.Open();
        //    string rs = cmd.ExecuteScalar().ToString();
        //    con.Close();
        //    FormPN newF = new FormPN();
        //    newF.LastID(rs,this.tileAcc.Text);
        //    newF.ShowDialog();
        //}

        //hiện report của hóa đơn
        private void btnReportHD_Click(object sender, EventArgs e)
        {
            ReportDocument reportDocument = new ReportDocument();
            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            paramField.Name = "@mahd";
            paramDiscreteValue.Value = gw_HD.Rows[dongHD].Cells[0].Value;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            FormRPHD rphd = new FormRPHD();
            rphd.loadReport(paramFields, reportDocument);
            rphd.Show();
        }

        private void btnThemPN_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(constr);
                SqlCommand cmd0 = new SqlCommand("select count(*) from tbl_nhanvien inner join tbl_taikhoan on tbl_nhanvien.pk_manv = tbl_taikhoan.pk_tendangnhap where pk_tendangnhap = '" + this.tileAcc.Text.ToString() + "'", con);
                con.Open();
                int rs = Convert.ToInt32(cmd0.ExecuteScalar());
                con.Close();
                if (rs == 1)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select count(*) from tbl_phieunhap where pk_maphieunhap = '" + txtmaPN.Text + "'",con);
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    if (result == 1)
                    {
                        MessageBox.Show("Đã tồn tại mã phiếu nhập này rồi!");
                    } else
                    {
                        FormPN formpn = new FormPN(this);
                        formpn.getNV(this.tileAcc.Text);
                        formpn.getNCC(this.comboNCC.SelectedValue.ToString());
                        formpn.setMaPN(txtmaPN.Text);
                        formpn.Show();
                    }
                }
                else if (rs == 0)
                {
                    MessageBox.Show("Chưa có nhân viên nào được gán với tài khoản này \nKhông thể tạo hóa đơn", "Chưa có nhân viên");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.v_hoadonTableAdapter.Fill(this.sTHGDataSet10.v_hoadon);
        }

        private void btnSuaPN_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhieu = grid_Phieunhap.Rows[dongPN].Cells[0].Value.ToString();
                FormSuaPN dmForm = new FormSuaPN(this);
                dmForm.setMaPhieu(this.grid_Phieunhap.Rows[dongPN].Cells[0].Value.ToString());
                //dmForm.loadDL(this.grid_Phieunhap.Rows[dongPN].Cells[0].Value.ToString());
                dmForm.ShowDialog();
            } catch
            {

            }
            
                //gw_NV.Rows[dong].Cells[0].Value.ToString()
        }
        private int dongPN;
        private void grid_Phieunhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dongPN = e.RowIndex;
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            FormSuaHD form = new FormSuaHD(this);
            string currentHD = this.gw_HD.Rows[dongHD].Cells[0].Value.ToString();
            form.setMaHD(currentHD);
            form.ShowDialog();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            ReportDocument reportDocument = new ReportDocument();
            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            paramField.Name = "@ngayban";
            paramDiscreteValue.Value = dtp.Value;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            FormRPHB rphb = new FormRPHB();
            rphb.loadReport(paramFields, reportDocument);
            rphb.Show();
        }

        private void btnRPPN_Click(object sender, EventArgs e)
        {
            ReportDocument reportDocument = new ReportDocument();
            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            paramField.Name = "@mapn";
            paramDiscreteValue.Value = grid_Phieunhap.Rows[dongPN].Cells[0].Value;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            FormRPPN rppn = new FormRPPN();
            rppn.loadReport(paramFields, reportDocument);
            rppn.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            ReportDocument reportDocument = new ReportDocument();
            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            paramField.Name = "@ngaynhap";
            paramDiscreteValue.Value = dtp.Value;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            FormRPHN rphn = new FormRPHN();
            rphn.loadReport(paramFields, reportDocument);
            rphn.Show();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.v_hatgiongTableAdapter.FillBy(this.sTHGDataSet2.v_hatgiong);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            ReportDocument reportDocument = new ReportDocument();
            FormRPHT rpht = new FormRPHT();
            rpht.loadReport(reportDocument);
            rpht.Show();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            ReportDocument reportDocument = new ReportDocument();
            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            paramField.Name = "@ngay";
            paramDiscreteValue.Value = dtp.Value;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            FormRPDT rpdt = new FormRPDT();
            rpdt.loadReport(paramFields, reportDocument);
            rpdt.Show();
        }
    }
}
