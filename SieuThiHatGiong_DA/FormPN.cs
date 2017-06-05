using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace SieuThiHatGiong_DA
{
    public partial class FormPN : MetroForm
    {
        mainForm _owner;

        public static String constr = ConfigurationManager.ConnectionStrings["Con"].ToString();
        public static SqlConnection con = new SqlConnection(constr);

        public static string NhanVien;
        public static string NhaCC;


        private static int currentSelectedListIndex;
        private static int currentNumListIndex;

        public FormPN(mainForm owner)
        {
            InitializeComponent();
            currentNumListIndex = 0;
            _owner = owner;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPN_closing);
        }
        public void getNV(string NV)
        {
            NhanVien = NV;
        }
        public void getNCC(string NCC)
        {
            NhaCC = NCC;
        }
        private void FormPN_closing(object sender, EventArgs e)
        {
            _owner.refreshForm();
        }
        //public FormPN(mainForm owner)
        //{
        //    _owner = owner;
        //    this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPN_closing);
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int num = currentNumListIndex;
            DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[currentNumListIndex].Clone();
            row.Cells[0].Value = this.comboHat.SelectedValue.ToString();
            row.Cells[1].Value = null;  // số lượng thêm (đang null)
            row.Cells[2].Value = this.comboHat.Text.ToString();
            row.Cells[3].Value = null;  //giá đầu vào (null)
            this.dataGridView2.Rows.Add(row);
            currentNumListIndex += 1;
            this.dataGridView2.CurrentCell = null;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (currentNumListIndex > 0)
            {
                this.dataGridView2.Rows.RemoveAt(currentSelectedListIndex);
                currentNumListIndex -= 1;
                int test = currentNumListIndex;
                currentSelectedListIndex = 0;
                this.dataGridView2.CurrentCell = null;
            }
        }
        public void setMaPN(string input)
        {
            this.lblMaPN.Text = input;
        }
        private void btnSL_Click(object sender, EventArgs e)
        {
            this.dataGridView2.Rows[currentSelectedListIndex].Cells[1].Value = this.txtsl.Text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string qstr = "insert into tbl_chitietphieunhap values ";
            string values = "";
            // kiểm tra xem có trường số lượng nào trống không
            foreach (DataGridViewRow row in this.dataGridView2.Rows)
            {
                if (row.Index != dataGridView2.Rows.Count - 1)  //vì có 1 blank row ở cuối cùng
                {
                    if (row.Cells[1].Value == null)
                    {
                        MessageBox.Show("Nhập đầy đủ số lượng thêm!!!");
                        return;
                    }
                    if (row.Cells[3].Value == null)
                    {
                        MessageBox.Show("Nhập đầy đủ giá đầu vào!");
                        return;
                    }
                } 
            }
            //tạo chi tiết phiếu nhập và update số lượng
            foreach (DataGridViewRow row in this.dataGridView2.Rows)
            {
                if (row.Index != dataGridView2.Rows.Count - 1)  //vì có 1 blank row ở cuối cùng
                {
                    string mahatgiong = row.Cells[0].Value.ToString();
                    int soluongthem = Convert.ToInt32(row.Cells[1].Value);
                    string maphieunhap = this.lblMaPN.Text;
                    int gia = Convert.ToInt32(row.Cells[3].Value);
                    if (values == "")
                    {
                        values = "('" + mahatgiong + "',"
                        + soluongthem + ", '"
                        + maphieunhap + "', "
                        + gia + ")";
                        updateSL(mahatgiong, soluongthem);
                    }
                    else
                    {
                        values += ", ('" + mahatgiong + "',"
                        + soluongthem + ", '"
                        + maphieunhap + "', "
                        + gia + ")";
                        updateSL(mahatgiong, soluongthem);
                    }
                    
                }
            }
            qstr += values;
            //tạo phiếu nhập
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_themphieunhap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pk_maphieunhap", lblMaPN.Text);
            Console.Write(lblMaPN.Text);
            cmd.Parameters.AddWithValue("@fk_manv", NhanVien);
            cmd.Parameters.AddWithValue("@manhacc", NhaCC);
            cmd.Parameters.Add(new SqlParameter("@ngaynhap", SqlDbType.Date)).Value = System.DateTime.Today.ToShortDateString();
            cmd.ExecuteNonQuery();
            con.Close();
            //chi tiet
            SqlCommand cmd3 = new SqlCommand(qstr, con);
            con.Open();
            cmd3.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Tạo thành công");
            this.Close();
        }
        private void updateSL(string mahat, int soluongthem)
        {
            string querry = "update tbl_hatgiong set soluong = soluong + " + soluongthem + " where pk_mahatgiong = '" + mahat + "'";
            SqlCommand cmd = new SqlCommand(querry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void FormPN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sTHGDataSet11.tbl_hatgiong' table. You can move, or remove it, as needed.
            this.tbl_hatgiongTableAdapter.Fill(this.sTHGDataSet11.tbl_hatgiong);

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //sl
            currentSelectedListIndex = e.RowIndex;
            if (this.dataGridView2.Rows[currentSelectedListIndex].Cells[1].Value == null)
            {
                this.txtsl.Text = "0";
            }
            else
            {
                this.txtsl.Text = this.dataGridView2.Rows[currentSelectedListIndex].Cells[1].Value.ToString();
            }
            //giá
            //sl
            currentSelectedListIndex = e.RowIndex;
            if (this.dataGridView2.Rows[currentSelectedListIndex].Cells[3].Value == null)
            {
                this.txtGia.Text = "0";
            }
            else
            {
                this.txtGia.Text = this.dataGridView2.Rows[currentSelectedListIndex].Cells[3].Value.ToString();
            }
        }

        private void btnGia_Click(object sender, EventArgs e)
        {
            this.dataGridView2.Rows[currentSelectedListIndex].Cells[3].Value = this.txtGia.Text;
        }
    }
}
