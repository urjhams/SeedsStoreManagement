namespace SieuThiHatGiong_DA
{
    partial class FormDMK
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lbltk = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtOld = new MetroFramework.Controls.MetroTextBox();
            this.txtNew = new MetroFramework.Controls.MetroTextBox();
            this.txtConfirm = new MetroFramework.Controls.MetroTextBox();
            this.btnok = new MetroFramework.Controls.MetroButton();
            this.btnHuy = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 101);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(63, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Tài khoản";
            // 
            // lbltk
            // 
            this.lbltk.AutoSize = true;
            this.lbltk.Location = new System.Drawing.Point(133, 100);
            this.lbltk.Name = "lbltk";
            this.lbltk.Size = new System.Drawing.Size(0, 0);
            this.lbltk.TabIndex = 1;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(24, 151);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(80, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Mật khẩu cũ";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(24, 201);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(90, 19);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "Mật khẩu mới";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(24, 251);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(62, 19);
            this.metroLabel4.TabIndex = 4;
            this.metroLabel4.Text = "Xác nhận";
            // 
            // txtOld
            // 
            this.txtOld.Location = new System.Drawing.Point(133, 146);
            this.txtOld.Name = "txtOld";
            this.txtOld.PasswordChar = '●';
            this.txtOld.Size = new System.Drawing.Size(121, 23);
            this.txtOld.TabIndex = 5;
            this.txtOld.UseSystemPasswordChar = true;
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(133, 196);
            this.txtNew.Name = "txtNew";
            this.txtNew.PasswordChar = '●';
            this.txtNew.Size = new System.Drawing.Size(121, 23);
            this.txtNew.TabIndex = 6;
            this.txtNew.UseSystemPasswordChar = true;
            // 
            // txtConfirm
            // 
            this.txtConfirm.Location = new System.Drawing.Point(133, 246);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '●';
            this.txtConfirm.Size = new System.Drawing.Size(121, 23);
            this.txtConfirm.TabIndex = 7;
            this.txtConfirm.UseSystemPasswordChar = true;
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(70, 311);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 8;
            this.btnok.Text = "Ok";
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(200, 311);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FormDMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 439);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.txtOld);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.lbltk);
            this.Controls.Add(this.metroLabel1);
            this.Movable = false;
            this.Name = "FormDMK";
            this.Resizable = false;
            this.Text = "ĐỔI MẬT KHẨU";
            this.Load += new System.EventHandler(this.FormDMK_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel lbltk;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtOld;
        private MetroFramework.Controls.MetroTextBox txtNew;
        private MetroFramework.Controls.MetroTextBox txtConfirm;
        private MetroFramework.Controls.MetroButton btnok;
        private MetroFramework.Controls.MetroButton btnHuy;
    }
}