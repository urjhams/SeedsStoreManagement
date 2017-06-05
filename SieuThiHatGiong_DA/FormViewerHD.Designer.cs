namespace SieuThiHatGiong_DA
{
    partial class FormViewerHD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rpViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rpViewer
            // 
            this.rpViewer.ActiveViewIndex = -1;
            this.rpViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rpViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.rpViewer.Location = new System.Drawing.Point(23, 134);
            this.rpViewer.Name = "rpViewer";
            this.rpViewer.Size = new System.Drawing.Size(911, 389);
            this.rpViewer.TabIndex = 0;
            // 
            // FormViewerHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 546);
            this.Controls.Add(this.rpViewer);
            this.Name = "FormViewerHD";
            this.Text = "FormViewerHD";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rpViewer;
    }
}