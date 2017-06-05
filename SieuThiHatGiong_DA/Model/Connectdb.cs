using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace SieuThiHatGiong_DA.Model
{
    class Connectdb
    {
        public static SqlConnection conn;
        public DataTable dt;
        public static String conStr = ConfigurationManager.ConnectionStrings["Conn"].ToString();

        public SqlConnection OpenConnect()
        {
            conn = new SqlConnection(conStr);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            return conn;
        }

        public SqlConnection CloseConnect()
        {
            conn = new SqlConnection(conStr);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            return conn;
        }

        public DataTable searchID(string proc, String id)
        {
            dt = new DataTable();
            OpenConnect();
            SqlCommand cmd = new SqlCommand(proc, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tennhanvien", id));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            CloseConnect();
            return dt;
        }
    }
}
