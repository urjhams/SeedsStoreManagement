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

namespace SieuThiHatGiong_DA
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public static SqlConnection con;
        public static String constr = ConfigurationManager.ConnectionStrings["Con"].ToString();
        static System.Windows.Forms.Timer loadTime = new System.Windows.Forms.Timer();
        static bool success = false;
        public Form1()
        {
            InitializeComponent();
            this.prgLoad.Visible = false;
            this.lblLoad.Visible = false;
        }
        private void loginProgess()
        {
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_dangnhap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tendangnhap", txtAcc.Text);
            cmd.Parameters.AddWithValue("@matkhau", txtPwd.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read() == true)
            {
                if (this.lblLoad.Visible == false)
                {
                    this.lblLoad.Visible = true;
                }
                if (this.prgLoad.Visible == false)
                {
                    this.prgLoad.Visible = true;
                }

                //login thành công thì:
                loadTime.Tick += new EventHandler(loginSuccess);
                loadTime.Interval = 3000;
                loadTime.Start();
                while (success == false)
                {
                    Application.DoEvents();
                }
                this.Hide();
                mainForm mainF = new mainForm();
                //mainF.Show();
                string welcometxt = this.txtAcc.Text.ToString();

                if (rd["fk_maquyen"].ToString() == "NV")
                {
                    mainF.onlyForAdmin();
                }

                mainF.setCurrentUserAcc(welcometxt);
                mainF.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                txtAcc.Text = "";
                txtPwd.Text = "";
                txtAcc.Focus();
            }
            con.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginProgess();
        }
       
        private static void loginSuccess(Object obj, EventArgs evt)
        {
            loadTime.Stop();
            success = true;
        }

        private void hit_enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginProgess();
            }
        }
    }
}
