namespace YektamakDesktop.Formlar.Satinalma.İrsaliye
{
    partial class MalzemeGirisFormu
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
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            fcbFirma = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbProjeKodu = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbStokGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            ctbIrsaliyeNo = new YektamakDesktop.CustomControls.CustomTextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ctbTarih = new YektamakDesktop.CustomControls.CustomTextBoxTarih();
            label5 = new System.Windows.Forms.Label();
            fcbMalzemeGrup = new YektamakDesktop.CustomControls.FilterableComboBox();
            label6 = new System.Windows.Forms.Label();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            ctbId = new YektamakDesktop.CustomControls.CustomTextBox();
            label7 = new System.Windows.Forms.Label();
            btnSiparisleriGetir = new YektamakDesktop.CustomControls.RoundedButton();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Malzeme Giriş Formu";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(1013, 25);
            headerPanel1.TabIndex = 0;
            // 
            // fcbFirma
            // 
            fcbFirma.BorderColor = System.Drawing.Color.Silver;
            fcbFirma.BorderRadius = 8;
            fcbFirma.BorderSize = 1;
            fcbFirma.DisplayMember = "ad";
            fcbFirma.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbFirma.Location = new System.Drawing.Point(179, 156);
            fcbFirma.Margin = new System.Windows.Forms.Padding(1);
            fcbFirma.Name = "fcbFirma";
            fcbFirma.Padding = new System.Windows.Forms.Padding(3);
            fcbFirma.PlaceholderText = "Seçiniz...";
            fcbFirma.ReadOnly = false;
            fcbFirma.Size = new System.Drawing.Size(213, 25);
            fcbFirma.TabIndex = 4;
            fcbFirma.ValueMember = "Id";
            fcbFirma.SelectedItemChanged += fcbFirma_SelectedValueChanged;
            // 
            // fcbProjeKodu
            // 
            fcbProjeKodu.BorderColor = System.Drawing.Color.Silver;
            fcbProjeKodu.BorderRadius = 8;
            fcbProjeKodu.BorderSize = 1;
            fcbProjeKodu.DisplayMember = "kod";
            fcbProjeKodu.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbProjeKodu.Location = new System.Drawing.Point(179, 129);
            fcbProjeKodu.Margin = new System.Windows.Forms.Padding(1);
            fcbProjeKodu.Name = "fcbProjeKodu";
            fcbProjeKodu.Padding = new System.Windows.Forms.Padding(3);
            fcbProjeKodu.PlaceholderText = "Seçiniz...";
            fcbProjeKodu.ReadOnly = false;
            fcbProjeKodu.Size = new System.Drawing.Size(213, 25);
            fcbProjeKodu.TabIndex = 3;
            fcbProjeKodu.ValueMember = "Id";
            // 
            // fcbStokGrup
            // 
            fcbStokGrup.BorderColor = System.Drawing.Color.Silver;
            fcbStokGrup.BorderRadius = 8;
            fcbStokGrup.BorderSize = 1;
            fcbStokGrup.DisplayMember = "ad";
            fcbStokGrup.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbStokGrup.Location = new System.Drawing.Point(179, 183);
            fcbStokGrup.Margin = new System.Windows.Forms.Padding(1);
            fcbStokGrup.Name = "fcbStokGrup";
            fcbStokGrup.Padding = new System.Windows.Forms.Padding(3);
            fcbStokGrup.PlaceholderText = "Seçiniz...";
            fcbStokGrup.ReadOnly = false;
            fcbStokGrup.Size = new System.Drawing.Size(213, 25);
            fcbStokGrup.TabIndex = 5;
            fcbStokGrup.ValueMember = "Id";
            fcbStokGrup.SelectedIndexChanged += fcbStokGrup_SelectedIndexChanged;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(12, 305);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(989, 288);
            universalGrid1.TabIndex = 13;
            // 
            // ctbIrsaliyeNo
            // 
            ctbIrsaliyeNo.BackColor = System.Drawing.Color.White;
            ctbIrsaliyeNo.BorderColor = System.Drawing.Color.Silver;
            ctbIrsaliyeNo.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbIrsaliyeNo.BorderSize = 1;
            ctbIrsaliyeNo.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbIrsaliyeNo.ForeColor = System.Drawing.Color.Black;
            ctbIrsaliyeNo.Location = new System.Drawing.Point(179, 75);
            ctbIrsaliyeNo.Margin = new System.Windows.Forms.Padding(1);
            ctbIrsaliyeNo.Multiline = false;
            ctbIrsaliyeNo.Name = "ctbIrsaliyeNo";
            ctbIrsaliyeNo.Padding = new System.Windows.Forms.Padding(3);
            ctbIrsaliyeNo.PasswordChar = false;
            ctbIrsaliyeNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbIrsaliyeNo.PlaceholderText = "";
            ctbIrsaliyeNo.ReadOnly = false;
            ctbIrsaliyeNo.SelectionStart = 0;
            ctbIrsaliyeNo.Size = new System.Drawing.Size(91, 25);
            ctbIrsaliyeNo.TabIndex = 1;
            ctbIrsaliyeNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbIrsaliyeNo.TextCustom = "";
            ctbIrsaliyeNo.UnderlinedStyle = false;
            ctbIrsaliyeNo.KeyDown += ctbIrsaliyeNo_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(79, 85);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(65, 15);
            label1.TabIndex = 7;
            label1.Text = "İrsaliye No";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(79, 166);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(38, 15);
            label2.TabIndex = 10;
            label2.Text = "Firma";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(79, 139);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(68, 15);
            label3.TabIndex = 9;
            label3.Text = "Proje Kodu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(79, 193);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(71, 15);
            label4.TabIndex = 11;
            label4.Text = "Stok Grubu";
            // 
            // ctbTarih
            // 
            ctbTarih.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ctbTarih.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbTarih.Location = new System.Drawing.Point(179, 102);
            ctbTarih.Margin = new System.Windows.Forms.Padding(1);
            ctbTarih.Name = "ctbTarih";
            ctbTarih.Padding = new System.Windows.Forms.Padding(3);
            ctbTarih.Size = new System.Drawing.Size(91, 25);
            ctbTarih.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(79, 112);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(34, 15);
            label5.TabIndex = 8;
            label5.Text = "Tarih";
            // 
            // fcbMalzemeGrup
            // 
            fcbMalzemeGrup.BorderColor = System.Drawing.Color.Silver;
            fcbMalzemeGrup.BorderRadius = 8;
            fcbMalzemeGrup.BorderSize = 1;
            fcbMalzemeGrup.DisplayMember = "ad";
            fcbMalzemeGrup.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbMalzemeGrup.Location = new System.Drawing.Point(179, 210);
            fcbMalzemeGrup.Margin = new System.Windows.Forms.Padding(1);
            fcbMalzemeGrup.Name = "fcbMalzemeGrup";
            fcbMalzemeGrup.Padding = new System.Windows.Forms.Padding(3);
            fcbMalzemeGrup.PlaceholderText = "Seçiniz...";
            fcbMalzemeGrup.ReadOnly = false;
            fcbMalzemeGrup.Size = new System.Drawing.Size(213, 25);
            fcbMalzemeGrup.TabIndex = 6;
            fcbMalzemeGrup.ValueMember = "Id";
            fcbMalzemeGrup.SelectedValueChanged += fcbMalzemeGrup_SelectedValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(79, 220);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(96, 15);
            label6.TabIndex = 12;
            label6.Text = "Malzeme Grubu";
            // 
            // customButtonSave1
            // 
            customButtonSave1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.BorderColor = System.Drawing.Color.Black;
            customButtonSave1.BorderSize = 0;
            customButtonSave1.CornerRadius = 6;
            customButtonSave1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            customButtonSave1.GradientColor2 = System.Drawing.Color.MidnightBlue;
            customButtonSave1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            customButtonSave1.HoverColor2 = System.Drawing.Color.Navy;
            customButtonSave1.Location = new System.Drawing.Point(892, 609);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(36, 36);
            customButtonSave1.TabIndex = 14;
            customButtonSave1.SaveButtonClick += customButtonSave1_Click;
            // 
            // ctbId
            // 
            ctbId.BackColor = System.Drawing.Color.White;
            ctbId.BorderColor = System.Drawing.Color.Silver;
            ctbId.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbId.BorderSize = 1;
            ctbId.Enabled = false;
            ctbId.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbId.ForeColor = System.Drawing.Color.Black;
            ctbId.Location = new System.Drawing.Point(179, 48);
            ctbId.Margin = new System.Windows.Forms.Padding(1);
            ctbId.Multiline = false;
            ctbId.Name = "ctbId";
            ctbId.Padding = new System.Windows.Forms.Padding(3);
            ctbId.PasswordChar = false;
            ctbId.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbId.PlaceholderText = "";
            ctbId.ReadOnly = false;
            ctbId.SelectionStart = 0;
            ctbId.Size = new System.Drawing.Size(91, 25);
            ctbId.TabIndex = 15;
            ctbId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbId.TextCustom = "";
            ctbId.UnderlinedStyle = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label7.Location = new System.Drawing.Point(79, 58);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(18, 15);
            label7.TabIndex = 16;
            label7.Text = "Id";
            // 
            // btnSiparisleriGetir
            // 
            btnSiparisleriGetir.BackgroundColor = System.Drawing.Color.Firebrick;
            btnSiparisleriGetir.BorderColor = System.Drawing.Color.Black;
            btnSiparisleriGetir.BorderSize = 0;
            btnSiparisleriGetir.CornerRadius = 10;
            btnSiparisleriGetir.FlatAppearance.BorderSize = 0;
            btnSiparisleriGetir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSiparisleriGetir.ForeColor = System.Drawing.Color.White;
            btnSiparisleriGetir.GradientColor1 = System.Drawing.Color.DodgerBlue;
            btnSiparisleriGetir.GradientColor2 = System.Drawing.Color.MidnightBlue;
            btnSiparisleriGetir.HoverColor1 = System.Drawing.Color.RoyalBlue;
            btnSiparisleriGetir.HoverColor2 = System.Drawing.Color.Navy;
            btnSiparisleriGetir.Icon = null;
            btnSiparisleriGetir.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSiparisleriGetir.Location = new System.Drawing.Point(537, 220);
            btnSiparisleriGetir.Name = "btnSiparisleriGetir";
            btnSiparisleriGetir.Size = new System.Drawing.Size(88, 40);
            btnSiparisleriGetir.TabIndex = 17;
            btnSiparisleriGetir.Text = "Siparişleri Getir";
            btnSiparisleriGetir.TextColor = System.Drawing.Color.White;
            btnSiparisleriGetir.UseVisualStyleBackColor = true;
            btnSiparisleriGetir.Click += btnSiparisleriGetir_Click;
            // 
            // MalzemeGirisFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1013, 657);
            Controls.Add(btnSiparisleriGetir);
            Controls.Add(label7);
            Controls.Add(ctbId);
            Controls.Add(customButtonSave1);
            Controls.Add(label6);
            Controls.Add(fcbMalzemeGrup);
            Controls.Add(label5);
            Controls.Add(ctbTarih);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ctbIrsaliyeNo);
            Controls.Add(universalGrid1);
            Controls.Add(fcbStokGrup);
            Controls.Add(fcbProjeKodu);
            Controls.Add(fcbFirma);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "MalzemeGirisFormu";
            Text = "MalzemeGirisFormu";
            FormClosing += MalzemeGirisFormu_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.FilterableComboBox fcbFirma;
        private CustomControls.FilterableComboBox fcbProjeKodu;
        private CustomControls.FilterableComboBox fcbStokGrup;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.CustomTextBox ctbIrsaliyeNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomTextBoxTarih ctbTarih;
        private System.Windows.Forms.Label label5;
        private CustomControls.FilterableComboBox fcbMalzemeGrup;
        private System.Windows.Forms.Label label6;
        private CustomControls.CustomButtonSave customButtonSave1;
        private CustomControls.CustomTextBox ctbId;
        private System.Windows.Forms.Label label7;
        private CustomControls.RoundedButton btnSiparisleriGetir;
    }
}