﻿using System;
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
    public partial class FormRPDT : MetroFramework.Forms.MetroForm
    {
        public FormRPDT()
        {
            InitializeComponent();
        }
        public void loadReport(ParameterFields param, ReportDocument rpdoc)
        {
            this.crystalReportViewer1.ParameterFieldInfo = param;
            string dirPath = "D:\\SieuThiHatGiong_DA\\SieuThiHatGiong_DA\\CRPDT.rpt";
            rpdoc.Load(dirPath);
            this.crystalReportViewer1.ReportSource = rpdoc;
        }
    }
}
