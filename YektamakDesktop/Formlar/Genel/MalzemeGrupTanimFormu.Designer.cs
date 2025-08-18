namespace YektamakDesktop.Formlar.Genel
{
    partial class MalzemeGrupTanimFormu
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
            ctbMalzemeGrupId = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ctbMalzemeGrupAd = new YektamakDesktop.CustomControls.CustomTextBox();
            label2 = new System.Windows.Forms.Label();
            ctbMalzemeGrupKod = new YektamakDesktop.CustomControls.CustomTextBox();
            fcbStokGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            label4 = new System.Windows.Forms.Label();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            SuspendLayout();
            // 
            // ctbMalzemeGrupId
            // 
            ctbMalzemeGrupId.BackColor = System.Drawing.Color.White;
            ctbMalzemeGrupId.BorderColor = System.Drawing.Color.Silver;
            ctbMalzemeGrupId.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbMalzemeGrupId.BorderRadius = 5;
            ctbMalzemeGrupId.BorderSize = 1;
            ctbMalzemeGrupId.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbMalzemeGrupId.ForeColor = System.Drawing.Color.Black;
            ctbMalzemeGrupId.Location = new System.Drawing.Point(153, 43);
            ctbMalzemeGrupId.Multiline = false;
            ctbMalzemeGrupId.Name = "ctbMalzemeGrupId";
            ctbMalzemeGrupId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbMalzemeGrupId.PasswordChar = false;
            ctbMalzemeGrupId.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbMalzemeGrupId.PlaceholderText = "";
            ctbMalzemeGrupId.ReadOnly = false;
            ctbMalzemeGrupId.SelectionStart = 0;
            ctbMalzemeGrupId.Size = new System.Drawing.Size(63, 28);
            ctbMalzemeGrupId.TabIndex = 1;
            ctbMalzemeGrupId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbMalzemeGrupId.TextCustom = "";
            ctbMalzemeGrupId.UnderlinedStyle = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(33, 49);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(18, 15);
            label3.TabIndex = 2;
            label3.Text = "ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(33, 83);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(105, 15);
            label1.TabIndex = 5;
            label1.Text = "Malzeme Grup Adı";
            // 
            // ctbMalzemeGrupAd
            // 
            ctbMalzemeGrupAd.BackColor = System.Drawing.Color.White;
            ctbMalzemeGrupAd.BorderColor = System.Drawing.Color.Silver;
            ctbMalzemeGrupAd.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbMalzemeGrupAd.BorderRadius = 5;
            ctbMalzemeGrupAd.BorderSize = 1;
            ctbMalzemeGrupAd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbMalzemeGrupAd.ForeColor = System.Drawing.Color.Black;
            ctbMalzemeGrupAd.isPlaceHolder = false;
            ctbMalzemeGrupAd.Location = new System.Drawing.Point(153, 77);
            ctbMalzemeGrupAd.Multiline = false;
            ctbMalzemeGrupAd.Name = "ctbMalzemeGrupAd";
            ctbMalzemeGrupAd.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbMalzemeGrupAd.PasswordChar = false;
            ctbMalzemeGrupAd.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbMalzemeGrupAd.PlaceholderText = "";
            ctbMalzemeGrupAd.ReadOnly = false;
            ctbMalzemeGrupAd.SelectionStart = 0;
            ctbMalzemeGrupAd.Size = new System.Drawing.Size(262, 28);
            ctbMalzemeGrupAd.TabIndex = 4;
            ctbMalzemeGrupAd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbMalzemeGrupAd.TextCustom = "";
            ctbMalzemeGrupAd.UnderlinedStyle = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(33, 117);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(115, 15);
            label2.TabIndex = 7;
            label2.Text = "Malzeme Grup Kodu";
            // 
            // ctbMalzemeGrupKod
            // 
            ctbMalzemeGrupKod.BackColor = System.Drawing.Color.White;
            ctbMalzemeGrupKod.BorderColor = System.Drawing.Color.Silver;
            ctbMalzemeGrupKod.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbMalzemeGrupKod.BorderRadius = 5;
            ctbMalzemeGrupKod.BorderSize = 1;
            ctbMalzemeGrupKod.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ctbMalzemeGrupKod.ForeColor = System.Drawing.Color.Black;
            ctbMalzemeGrupKod.isPlaceHolder = false;
            ctbMalzemeGrupKod.Location = new System.Drawing.Point(153, 111);
            ctbMalzemeGrupKod.Multiline = false;
            ctbMalzemeGrupKod.Name = "ctbMalzemeGrupKod";
            ctbMalzemeGrupKod.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbMalzemeGrupKod.PasswordChar = false;
            ctbMalzemeGrupKod.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbMalzemeGrupKod.PlaceholderText = "";
            ctbMalzemeGrupKod.ReadOnly = false;
            ctbMalzemeGrupKod.SelectionStart = 0;
            ctbMalzemeGrupKod.Size = new System.Drawing.Size(134, 28);
            ctbMalzemeGrupKod.TabIndex = 6;
            ctbMalzemeGrupKod.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbMalzemeGrupKod.TextCustom = "";
            ctbMalzemeGrupKod.UnderlinedStyle = false;
            // 
            // fcbStokGrup
            // 
            fcbStokGrup.BorderColor = System.Drawing.Color.Silver;
            fcbStokGrup.BorderSize = 1;
            fcbStokGrup.DataSource = null;
            fcbStokGrup.DisplayMember = "ad";
            fcbStokGrup.Location = new System.Drawing.Point(153, 145);
            fcbStokGrup.Name = "fcbStokGrup";
            fcbStokGrup.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbStokGrup.PlaceholderText = "Seçiniz...";
            fcbStokGrup.SelectedDisplayValue = "Seçiniz...";
            fcbStokGrup.SelectedIndex = -1;
            fcbStokGrup.SelectedItem = null;
            fcbStokGrup.SelectedValue = null;
            fcbStokGrup.Size = new System.Drawing.Size(262, 29);
            fcbStokGrup.TabIndex = 8;
            fcbStokGrup.UnderlinedStyle = false;
            fcbStokGrup.ValueMember = "Id";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(33, 152);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(66, 15);
            label4.TabIndex = 9;
            label4.Text = "Stok Grubu";
            // 
            // customButtonSave1
            // 
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.Location = new System.Drawing.Point(309, 202);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(106, 46);
            customButtonSave1.TabIndex = 10;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
            // 
            // MalzemeGrupTanimFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(468, 287);
            Controls.Add(customButtonSave1);
            Controls.Add(label4);
            Controls.Add(fcbStokGrup);
            Controls.Add(label2);
            Controls.Add(ctbMalzemeGrupKod);
            Controls.Add(label1);
            Controls.Add(ctbMalzemeGrupAd);
            Controls.Add(label3);
            Controls.Add(ctbMalzemeGrupId);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "MalzemeGrupTanimFormu";
            Text = "StokGrupTanimFormu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomTextBoxSayisal ctbMalzemeGrupId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomTextBox ctbMalzemeGrupAd;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomTextBox ctbMalzemeGrupKod;
        private CustomControls.FilterableComboBox fcbStokGrup;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomButtonSave customButtonSave1;
    }
}