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
    class Work
    {
        Connectdb db = new Connectdb();
       // public static SqlConnection conn;
        public static String conStr = ConfigurationManager.ConnectionStrings["Con"].ToString();

        public DataTable Load_searchIDNV(String id)
        {
            DataTable dt;
            dt = db.searchID("sp_searchnv", id);
            return dt;
        }
    }
}
