using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace SieuThiHatGiong_DA
{
    public partial class FormDMK : MetroFramework.Forms.MetroForm
    {
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ToString());
        private string currentPass ="";
        private string currentAcc = "";
        public FormDMK()
        {
            InitializeComponent();
        }
        public void getPwd(string input, string tk)
        {
            this.currentPass = input;
            this.currentAcc = tk;
        }
        private void btnok_Click(object sender, EventArgs e)
        {
            if (this.txtConfirm.Text == "" || this.txtNew.Text == "" || this.txtOld.Text == "")
            {
                MessageBox.Show("Nhập đầy  đủ các trường!");
                return;
            }
            if (this.txtNew.Text.Length < 4)
            {
                MessageBox.Show("Mật khẩu phải có nhiều hơn 4 ký tự");
                return;
            }
            if (currentPass == "")
            {
                MessageBox.Show("Không tải được dữ liệu, xin truy cập lại chức năng này");
                return;
            }
            if (this.txtConfirm.Text != txtNew.Text)
            {
                MessageBox.Show("Mật khẩu mới phải trùng với xác nhận");
                return;
            }
            if (this.txtOld.Text != currentPass)
            {
                MessageBox.Show("Nhập lại mật khẩu cũ chính xác");
                return;
            }
            SqlCommand cmd = new SqlCommand("update tbl_taikhoan set matkhau = '" + this.txtNew.Text.ToString() + "' where pk_tendangnhap = '" + this.currentAcc + "'", con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đổi mật khẩu thành công");
            }catch
            {
                MessageBox.Show("Có lỗi xảy ra");
                return;
            }

            con.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDMK_Load(object sender, EventArgs e)
        {
            lbltk.Text = currentAcc;
        }
    }
}
