using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace SieuThiHatGiong_DA
{
    public partial class FormHDon : MetroForm
    {
        mainForm _owner;
        public static String constr = ConfigurationManager.ConnectionStrings["Con"].ToString();
        public static SqlConnection con = new SqlConnection(constr);
        private static int currentSelectedIndex;
        private static int currentSelectedListIndex;
        private static int currentNumListIndex = 0;
        private static string nvID;
        private static string khach;

        private void FormHD_closing(object sender, EventArgs e)
        {
            _owner.refreshForm();
        }
        public void getPreInfo(string nv, string hd, string kh)
        {
            nvID = nv;
            this.lblMaHD.Text = hd;
            khach = kh;
        }
        public FormHDon(mainForm owner)
        {
            InitializeComponent();
            _owner = owner;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHD_closing);
        }

        private void FormHDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sTHGDataSet111.tbl_hatgiong' table. You can move, or remove it, as needed.
            this.tbl_hatgiongTableAdapter.Fill(this.sTHGDataSet111.tbl_hatgiong);
            // TODO: This line of code loads data into the 'sTHGDataSet11.tbl_hatgiong' table. You can move, or remove it, as needed.
            this.tbl_hatgiongTableAdapter.Fill(this.sTHGDataSet11.tbl_hatgiong);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)this.dataGridView2.Rows[currentNumListIndex].Clone();
            row.Cells[0].Value = this.dataGridView1.Rows[currentSelectedIndex].Cells[0].Value.ToString();   // mã
            row.Cells[1].Value = this.dataGridView1.Rows[currentSelectedIndex].Cells[1].Value.ToString();   //tên
            row.Cells[2].Value = null;  // số lượng mượn (đang đển null)
            row.Cells[3].Value = this.dataGridView1.Rows[currentSelectedIndex].Cells[3].Value.ToString();   //đơn giá (ẩn)
            row.Cells[4].Value = this.dataGridView1.Rows[currentSelectedIndex].Cells[5].Value.ToString();   //số lượng hiện có
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

        private void btnChange_Click(object sender, EventArgs e)
        {
            int soluongmax = Convert.ToInt32(this.dataGridView1.Rows[currentSelectedIndex].Cells[5].Value);
            if (Convert.ToInt32(this.txtSL.Text) <= soluongmax)
            {
                this.dataGridView2.Rows[currentSelectedListIndex].Cells[2].Value = this.txtSL.Text;
            } else
            {
                MessageBox.Show("Vượt quá số lượng hiện có của hạt giống này!");
                this.txtSL.Text = "";
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //check 
            foreach (DataGridViewRow row in this.dataGridView2.Rows)
            {
                if (row.Index != dataGridView2.Rows.Count - 1)  //vì có 1 blank row ở cuối cùng
                {
                    if (row.Cells[2].Value == null)
                    {
                        MessageBox.Show("Nhập đầy đủ số lượng!!!");
                        return;
                    }
                }
            }
            //tao hoa don
            con.Open();
            SqlCommand cmdx = new SqlCommand("sp_themhoadon", con);
            cmdx.CommandType = CommandType.StoredProcedure;
            cmdx.Parameters.AddWithValue("@pk_mahoadon", lblMaHD.Text);
            cmdx.Parameters.Add(new SqlParameter("@ngayban", SqlDbType.Date)).Value = System.DateTime.Today.ToShortDateString();
            cmdx.Parameters.AddWithValue("@fk_manv", nvID.ToString());
            cmdx.Parameters.AddWithValue("@fk_makhachhang", khach.ToString());
            cmdx.ExecuteNonQuery();
            con.Close();

            //tao chi tiet va update so luong
            string querry = "insert into tbl_chitiethoadon values ";
            string values = "";
            con.Open();
            foreach (DataGridViewRow row in this.dataGridView2.Rows)
            {
                if (row.Index != dataGridView2.Rows.Count - 1)  //vì có 1 blank row ở cuối cùng
                {
                    string mahatgiong = row.Cells[0].Value.ToString();
                    string tenhatgiong = row.Cells[1].Value.ToString();
                    string soluonglay = row.Cells[2].Value.ToString();
                    string soluongco = row.Cells[4].Value.ToString();
                    if (values == "")
                    {
                        values = "('" + mahatgiong + "',"
                            + soluonglay + ","
                            + row.Cells[3].Value.ToString() + ",'"
                            + this.lblMaHD.Text + "')";
                        updateSL(mahatgiong, Convert.ToInt32(soluongco), Convert.ToInt32(soluonglay));
                    }
                    else
                    {
                        values += ", ('" + mahatgiong + "',"
                            + soluonglay + ","
                            + row.Cells[3].Value.ToString() + ",'"
                            + this.lblMaHD.Text + "')";
                        updateSL(mahatgiong, Convert.ToInt32(soluongco), Convert.ToInt32(soluonglay));
                    }
                } 
            }
            querry += values;
            SqlCommand cmd = new SqlCommand(querry, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Tạo hóa đơn thành công");
            this.Close();

        }
        private void updateSL(string mahat,int soluong, int soluongmuon)
        {
            string querry = "update tbl_hatgiong set soluong = " + (soluong - soluongmuon) + " where pk_mahatgiong = '" + mahat +"'";
            SqlCommand cmd = new SqlCommand(querry, con);
            cmd.ExecuteNonQuery();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentSelectedIndex = e.RowIndex;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentSelectedListIndex = e.RowIndex;
            if (this.dataGridView2.Rows[currentSelectedListIndex].Cells[2].Value == null)
            {
                this.txtSL.Text = "0";
            }
            else
            {
                this.txtSL.Text = this.dataGridView2.Rows[currentSelectedListIndex].Cells[2].Value.ToString();
            }
        }
    }
}
