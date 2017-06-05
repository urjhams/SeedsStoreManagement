using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace SieuThiHatGiong_DA
{
    public partial class FormRPHT : MetroFramework.Forms.MetroForm
    {
        public FormRPHT()
        {
            InitializeComponent();
        }
        public void loadReport(ReportDocument rpdoc)
        {
            string dirPath = "D:\\SieuThiHatGiong_DA\\SieuThiHatGiong_DA\\CRPHT.rpt";
            rpdoc.Load(dirPath);
            this.crystalReportViewer1.ReportSource = rpdoc;
        }
    }
}
