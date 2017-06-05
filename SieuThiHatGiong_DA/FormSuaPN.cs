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
    public partial class FormSuaPN : MetroFramework.Forms.MetroForm
    {
        mainForm _owner;
        string maphieu;
        public static String constr = ConfigurationManager.ConnectionStrings["Con"].ToString();
        public static SqlConnection con = new SqlConnection(constr);
        int currentSelectedIndex = -1;

        public FormSuaPN(mainForm main)
        {
            InitializeComponent();

            this.v_hgTableAdapter.Fill(this.sTHGDataSet15.v_hg);

            _owner = main;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSuaPN_closing);
        }
        private void FormSuaPN_closing(object sender, EventArgs e)
        {
            _owner.refreshForm();
        }

        public void loadDL(string param)
        {
            SqlCommand cmd = new SqlCommand("select tbl_hatgiong.pk_mahatgiong as [Mã hạt giống], tbl_hatgiong.tenhatgiong as [Tên hạt giống], soluongnhap as [Số lượng nhập], gianhap as [Giá nhập] from tbl_chitietphieunhap inner join tbl_hatgiong on tbl_hatgiong.pk_mahatgiong = tbl_chitietphieunhap.fk_mahatgiong where fk_maphieunhap = '" + this.lblMaPN.Text +"'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter dmAdapter = new SqlDataAdapter (cmd))
            {
                DataTable dmTable = new DataTable();
                dmAdapter.Fill(dmTable);
                this.grdvw.DataSource = dmTable;
                this.grdvw.Refresh();
            }
            con.Close();
        }
        public void setMaPhieu(string input)
        {
            this.lblMaPN.Text = input;
            maphieu = input;
        }
        private void FormSuaPN_Load(object sender, EventArgs e)
        {
            loadDL(maphieu);

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmdCheck = new SqlCommand("select count(*) from tbl_chitietphieunhap where fk_mahatgiong = '" + metroComboBox1.SelectedValue.ToString() + "' and fk_maphieunhap = '" + this.maphieu + "'", con);
            int dmKQ = Convert.ToInt32(cmdCheck.ExecuteScalar());
            if (dmKQ == 0)
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_chitietphieunhap values ('" + this.metroComboBox1.SelectedValue.ToString() + "', " + this.txtSL.Text + ", '" + this.lblMaPN.Text.ToString() + "'," + Convert.ToInt32(this.txtGia.Text) + ")",con);
                try
                {
                    cmd.ExecuteNonQuery();
                    themSL();
                    MessageBox.Show("Thêm thành công");
                    loadDL();
                }
                catch(Exception exc)
                {
                    MessageBox.Show("Có lỗi xảy ra\n"  + exc);
                }
            } else
            {
                MessageBox.Show("Đã có hạt giống này");
                return;
            }
            con.Close();
        }
        private void themSL()
        {
            SqlCommand cmd = new SqlCommand("update tbl_hatgiong set soluong = soluong + " + Convert.ToInt32(this.txtSL.Text) + " where pk_mahatgiong = '" + this.metroComboBox1.SelectedValue.ToString() + "'", con);
            cmd.ExecuteNonQuery();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currentSelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn một trường để sửa");
                return;
            } else
            {
                try
                {
                    con.Open();
                    int soluongold = Convert.ToInt32(this.grdvw.Rows[currentSelectedIndex].Cells[2].Value);
                    int hieuso = Convert.ToInt32(this.txtSL.Text) - soluongold;
                    SqlCommand cmd = new SqlCommand("update tbl_chitietphieunhap set soluongnhap = " + Convert.ToInt32(this.txtSL.Text) + " , gianhap = " + Convert.ToInt32(this.txtGia.Text) + " where fk_maphieunhap = '" + this.lblMaPN.Text + "' and fk_mahatgiong = '" + this.grdvw.Rows[currentSelectedIndex].Cells[0].Value + "'", con);
                    SqlCommand cmd2 = new SqlCommand("update tbl_hatgiong set soluong = soluong + " + hieuso + " where pk_mahatgiong = '" + this.grdvw.Rows[currentSelectedIndex].Cells[0].Value + "'", con);
                    cmd2.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                    loadDL();
                    con.Close();
                    MessageBox.Show("Sửa thành công");
                }
                catch (Exception excep)
                {
                    MessageBox.Show("Có lỗi xảy ra\nChi tiết lỗi: " + excep);
                }
            }         
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentSelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trường để thao tác");
            }
            else
            {
                DialogResult confirmDel = MessageBox.Show("Chắc chắn muốn xóa thao tác này chứ?", "Cảnh báo", MessageBoxButtons.YesNo);
                if (confirmDel == DialogResult.Yes)
                {
                    try
                    {
                        string mahatgiong = this.grdvw.Rows[currentSelectedIndex].Cells[0].Value.ToString();
                        con.Open();
                        SqlCommand cmd = new SqlCommand("update tbl_hatgiong set soluong = soluong - " + Convert.ToInt32(this.grdvw.Rows[currentSelectedIndex].Cells[2].Value) + " where pk_mahatgiong = '" + mahatgiong + "'", con);
                        SqlCommand cmd2 = new SqlCommand("delete from tbl_chitietphieunhap where fk_mahatgiong = '" + mahatgiong + "' and fk_maphieunhap = '" + this.maphieu + "'", con);
                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        loadDL();
                        con.Close();
                        MessageBox.Show("Đã Xóa thành công");
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("có lỗi xảy ra\nChi tiết lỗi: " + exc);
                    }
                }
                else if (confirmDel == DialogResult.No)
                {
                    return;
                }
            }        
        }

        private void btnCl_Click(object sender, EventArgs e)
        {
            currentSelectedIndex = -1;
            this.txtGia.Text = "";
            this.txtSL.Text = "";   
        }

        private void loadDL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select tbl_hatgiong.pk_mahatgiong as [Mã hạt giống], tbl_hatgiong.tenhatgiong as [Tên hạt giống], soluongnhap as [Số lượng nhập], gianhap as [Giá nhập] from tbl_chitietphieunhap inner join tbl_hatgiong on tbl_hatgiong.pk_mahatgiong = tbl_chitietphieunhap.fk_mahatgiong where fk_maphieunhap = '" + this.lblMaPN.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            this.grdvw.DataSource = dt;
            this.grdvw.Refresh();
        }

        private void grdvw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentSelectedIndex = e.RowIndex;
            this.txtSL.Text = this.grdvw.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.txtGia.Text = this.grdvw.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}
