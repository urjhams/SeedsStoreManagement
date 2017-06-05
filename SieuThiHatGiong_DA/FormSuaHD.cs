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
    public partial class FormSuaHD : MetroFramework.Forms.MetroForm
    {
        mainForm _owner;
        string maHD;
        public static String constr = ConfigurationManager.ConnectionStrings["Con"].ToString();
        public static SqlConnection con = new SqlConnection(constr);
        int currentSelectedIndex = -1;

        public FormSuaHD(mainForm main)
        {
            InitializeComponent();

            _owner = main;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSuaHD_closing);
        }

        private void FormSuaHD_closing(object sender, EventArgs e)
        {
            _owner.refreshForm();
        }

        public void loadDL(string param)
        {
            SqlCommand cmd = new SqlCommand("select tbl_hatgiong.tenhatgiong as [Tên hạt giống], tbl_chitiethoadon.soluong as [số lượng], tbl_hatgiong.dongia as [đơn giá], tbl_chitiethoadon.soluong * tbl_hatgiong.dongia as [giá bán] from tbl_chitiethoadon inner join tbl_hatgiong on tbl_hatgiong.pk_mahatgiong = tbl_chitiethoadon.fk_mahatgiong where fk_mahoadon = '" + maHD + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter dmAdapter = new SqlDataAdapter(cmd))
            {
                DataTable dmTable = new DataTable();
                dmAdapter.Fill(dmTable);
                this.grid_CTHD.DataSource = dmTable;
                this.grid_CTHD.Refresh();
            }
            con.Close();
        }
        public void setMaHD(string input)
        {
            this.lblMHDV.Text = input;
            maHD = input;
        }

        private void FormSuaHD_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sTHGDataSet15.v_hg' table. You can move, or remove it, as needed.
            this.v_hgTableAdapter.Fill(this.sTHGDataSet15.v_hg);
            loadDL(maHD);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currentSelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn một trường để sửa");
                return;
            } else
            {
                SqlCommand checkSLcmd = new SqlCommand("select soluong from tbl_hatgiong where pk_mahatgiong = '" + this.comboHat.SelectedValue.ToString() + "'", con);
                con.Open();
                int soluongkhadung = Convert.ToInt32(checkSLcmd.ExecuteScalar());
                con.Close();
                if (Convert.ToInt32(this.txtSL.Text) > soluongkhadung || Convert.ToInt32(this.txtSL.Text) < 0)
                {
                    MessageBox.Show("Vui lòng kiểm tra lại dữ liệu, có thể:\n Số lượng vượt quá số lượng có sẵn\n Số lượng không được nhỏ hơn 0","Kiểm tra lại dữ liệu nhập vào");
                    return;
                } else
                {
                    try
                    {
                        string mahatgiong = this.grid_CTHD.Rows[currentSelectedIndex].Cells[0].Value.ToString();
                        int soluonghientai = Convert.ToInt32(this.grid_CTHD.Rows[currentSelectedIndex].Cells[2].Value);
                        int hieuso = Convert.ToInt32(this.txtSL.Text) - soluonghientai;
                        SqlCommand cmd = new SqlCommand("update tbl_chitiethoadon set soluong = " + Convert.ToInt32(this.txtSL.Text) + " where fk_mahoadon = '" + this.maHD + "' and fk_mahatgiong = '" + mahatgiong  + "'",con);
                        SqlCommand cmd2 = new SqlCommand("update tbl_hatgiong set soluong = soluong + " + hieuso + " where pk_mahatgiong = '" + mahatgiong + "'", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        loadDL(maHD);
                        MessageBox.Show("Sửa thành công");
                        this.grid_CTHD.Refresh();
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show("Có lỗi xảy ra\nChi tiết lỗi: " + excep);
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSL.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ số lượng!");
                return;
            } else
            {
                SqlCommand checkcmd = new SqlCommand("select count(*) from tbl_chitiethoadon where fk_mahatgiong = '" + this.comboHat.SelectedValue.ToString() + "' and fk_mahoadon = '" + this.maHD + "'",con);
                con.Open();
                int rs = Convert.ToInt32(checkcmd.ExecuteScalar());
                con.Close();
                if (rs == 0)
                {
                    SqlCommand checkSLcmd = new SqlCommand("select soluong from tbl_hatgiong where pk_mahatgiong = '" + this.comboHat.SelectedValue.ToString() + "'",con);
                    con.Open();
                    int soluongkhadung = Convert.ToInt32(checkSLcmd.ExecuteScalar());
                    con.Close();
                    if (Convert.ToInt32(this.txtSL.Text) > soluongkhadung)
                    {
                        MessageBox.Show("Vượt quá số lượng có thể lấy!");
                        return;
                    } else
                    {
                        string mahatgiong = this.comboHat.SelectedValue.ToString();
                        int soluong = Convert.ToInt32(this.txtSL.Text);
                        string mahoadon = this.maHD;
                        SqlCommand cmd = new SqlCommand("insert into tbl_chitiethoadon values ('" + mahatgiong + "'," + soluong + "," + 0 + ",'" + mahoadon + "')", con);
                        SqlCommand cmd2 = new SqlCommand("update tbl_hatgiong set soluong = soluong - " + soluong + " where pk_mahatgiong = '" + mahatgiong + "'",con);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            con.Close();
                            loadDL(maHD);
                            MessageBox.Show("Thêm thành công");
                        }
                        catch
                        {
                            MessageBox.Show("Có lỗi xảy ra");
                            con.Close();
                        }
                    } 
                }
                else
                {
                    MessageBox.Show("Đã có hạt giống này");
                    return;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentSelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trường để thao tác");
            } else
            {
                DialogResult confirmDel = MessageBox.Show("Chắc chắn muốn xóa thao tác này chứ?", "Cảnh báo", MessageBoxButtons.YesNo);
                if (confirmDel == DialogResult.Yes)
                {
                    try
                    {
                        string mahatgiong = this.grid_CTHD.Rows[currentSelectedIndex].Cells[0].Value.ToString();
                        int soluong = Convert.ToInt32(this.grid_CTHD.Rows[currentSelectedIndex].Cells[2].Value);
                        SqlCommand cmd = new SqlCommand("update tbl_hatgiong set soluong = soluong + " + soluong + " where pk_mahatgiong = '" + mahatgiong + "'",con);
                        SqlCommand cmd2 = new SqlCommand("delete from tbl_chitiethoadon where fk_mahatgiong = '" + mahatgiong + "' and fk_mahoadon = '" + this.maHD + "'",con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        loadDL(maHD);
                        MessageBox.Show("Đã Xóa thành công");
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("có lỗi xảy ra\nChi tiết lỗi: " + exc);
                    }
                } else if (confirmDel == DialogResult.No)
                {
                    return;
                }
            }
        }

        private void btnCl_Click(object sender, EventArgs e)
        {
            currentSelectedIndex = -1;
            this.txtSL.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentSelectedIndex = e.RowIndex;
            this.txtSL.Text = this.grid_CTHD.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
