namespace YektamakDesktop.Formlar.Genel
{
    partial class AdresTanimlamaFormu
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
            components = new System.ComponentModel.Container();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            ctbAdresId = new YektamakDesktop.CustomControls.CustomTextBoxSayisal();
            ctbUlke = new YektamakDesktop.CustomControls.CustomTextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ctbSehir = new YektamakDesktop.CustomControls.CustomTextBox();
            label4 = new System.Windows.Forms.Label();
            ctbIlce = new YektamakDesktop.CustomControls.CustomTextBox();
            label5 = new System.Windows.Forms.Label();
            ctbMahalle = new YektamakDesktop.CustomControls.CustomTextBox();
            label6 = new System.Windows.Forms.Label();
            ctbSokak = new YektamakDesktop.CustomControls.CustomTextBox();
            label7 = new System.Windows.Forms.Label();
            ctbAcikAdres = new YektamakDesktop.CustomControls.CustomTextBox();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            label8 = new System.Windows.Forms.Label();
            ctbPostaKodu = new YektamakDesktop.CustomControls.CustomTextBox();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            adresSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Adres Tanımları";
            headerPanel1.Location = new System.Drawing.Point(-2, -1);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(869, 25);
            headerPanel1.TabIndex = 0;
            // 
            // ctbAdresId
            // 
            ctbAdresId.BackColor = System.Drawing.SystemColors.Window;
            ctbAdresId.Enabled = false;
            ctbAdresId.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbAdresId.ForeColor = System.Drawing.Color.DimGray;
            ctbAdresId.Location = new System.Drawing.Point(141, 54);
            ctbAdresId.Margin = new System.Windows.Forms.Padding(1);
            ctbAdresId.Name = "ctbAdresId";
            ctbAdresId.OndalikBasamak = 0;
            ctbAdresId.Padding = new System.Windows.Forms.Padding(3);
            ctbAdresId.Size = new System.Drawing.Size(60, 25);
            ctbAdresId.TabIndex = 1;
            ctbAdresId.TextCustom = "0";
            // 
            // ctbUlke
            // 
            ctbUlke.BackColor = System.Drawing.Color.White;
            ctbUlke.BorderColor = System.Drawing.Color.Silver;
            ctbUlke.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbUlke.BorderSize = 1;
            ctbUlke.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbUlke.ForeColor = System.Drawing.Color.Black;
            ctbUlke.Location = new System.Drawing.Point(141, 81);
            ctbUlke.Margin = new System.Windows.Forms.Padding(1);
            ctbUlke.Multiline = false;
            ctbUlke.Name = "ctbUlke";
            ctbUlke.Padding = new System.Windows.Forms.Padding(3);
            ctbUlke.PasswordChar = false;
            ctbUlke.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbUlke.PlaceholderText = "";
            ctbUlke.ReadOnly = false;
            ctbUlke.SelectionStart = 0;
            ctbUlke.Size = new System.Drawing.Size(262, 25);
            ctbUlke.TabIndex = 2;
            ctbUlke.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbUlke.TextCustom = "";
            ctbUlke.UnderlinedStyle = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(32, 54);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(18, 15);
            label1.TabIndex = 3;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(32, 81);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(33, 15);
            label2.TabIndex = 4;
            label2.Text = "Ülke";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(32, 108);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(36, 15);
            label3.TabIndex = 6;
            label3.Text = "Şehir";
            // 
            // ctbSehir
            // 
            ctbSehir.BackColor = System.Drawing.Color.White;
            ctbSehir.BorderColor = System.Drawing.Color.Silver;
            ctbSehir.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbSehir.BorderSize = 1;
            ctbSehir.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbSehir.ForeColor = System.Drawing.Color.Black;
            ctbSehir.Location = new System.Drawing.Point(141, 108);
            ctbSehir.Margin = new System.Windows.Forms.Padding(1);
            ctbSehir.Multiline = false;
            ctbSehir.Name = "ctbSehir";
            ctbSehir.Padding = new System.Windows.Forms.Padding(3);
            ctbSehir.PasswordChar = false;
            ctbSehir.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbSehir.PlaceholderText = "";
            ctbSehir.ReadOnly = false;
            ctbSehir.SelectionStart = 0;
            ctbSehir.Size = new System.Drawing.Size(262, 25);
            ctbSehir.TabIndex = 5;
            ctbSehir.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbSehir.TextCustom = "";
            ctbSehir.UnderlinedStyle = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(32, 135);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(27, 15);
            label4.TabIndex = 8;
            label4.Text = "İlçe";
            // 
            // ctbIlce
            // 
            ctbIlce.BackColor = System.Drawing.Color.White;
            ctbIlce.BorderColor = System.Drawing.Color.Silver;
            ctbIlce.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbIlce.BorderSize = 1;
            ctbIlce.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbIlce.ForeColor = System.Drawing.Color.Black;
            ctbIlce.Location = new System.Drawing.Point(141, 135);
            ctbIlce.Margin = new System.Windows.Forms.Padding(1);
            ctbIlce.Multiline = false;
            ctbIlce.Name = "ctbIlce";
            ctbIlce.Padding = new System.Windows.Forms.Padding(3);
            ctbIlce.PasswordChar = false;
            ctbIlce.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbIlce.PlaceholderText = "";
            ctbIlce.ReadOnly = false;
            ctbIlce.SelectionStart = 0;
            ctbIlce.Size = new System.Drawing.Size(262, 25);
            ctbIlce.TabIndex = 7;
            ctbIlce.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbIlce.TextCustom = "";
            ctbIlce.UnderlinedStyle = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(32, 162);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(50, 15);
            label5.TabIndex = 10;
            label5.Text = "Mahalle";
            // 
            // ctbMahalle
            // 
            ctbMahalle.BackColor = System.Drawing.Color.White;
            ctbMahalle.BorderColor = System.Drawing.Color.Silver;
            ctbMahalle.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbMahalle.BorderSize = 1;
            ctbMahalle.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbMahalle.ForeColor = System.Drawing.Color.Black;
            ctbMahalle.Location = new System.Drawing.Point(141, 162);
            ctbMahalle.Margin = new System.Windows.Forms.Padding(1);
            ctbMahalle.Multiline = false;
            ctbMahalle.Name = "ctbMahalle";
            ctbMahalle.Padding = new System.Windows.Forms.Padding(3);
            ctbMahalle.PasswordChar = false;
            ctbMahalle.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbMahalle.PlaceholderText = "";
            ctbMahalle.ReadOnly = false;
            ctbMahalle.SelectionStart = 0;
            ctbMahalle.Size = new System.Drawing.Size(262, 25);
            ctbMahalle.TabIndex = 9;
            ctbMahalle.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbMahalle.TextCustom = "";
            ctbMahalle.UnderlinedStyle = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(32, 189);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(41, 15);
            label6.TabIndex = 12;
            label6.Text = "Sokak";
            // 
            // ctbSokak
            // 
            ctbSokak.BackColor = System.Drawing.Color.White;
            ctbSokak.BorderColor = System.Drawing.Color.Silver;
            ctbSokak.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbSokak.BorderSize = 1;
            ctbSokak.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbSokak.ForeColor = System.Drawing.Color.Black;
            ctbSokak.Location = new System.Drawing.Point(141, 189);
            ctbSokak.Margin = new System.Windows.Forms.Padding(1);
            ctbSokak.Multiline = false;
            ctbSokak.Name = "ctbSokak";
            ctbSokak.Padding = new System.Windows.Forms.Padding(3);
            ctbSokak.PasswordChar = false;
            ctbSokak.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbSokak.PlaceholderText = "";
            ctbSokak.ReadOnly = false;
            ctbSokak.SelectionStart = 0;
            ctbSokak.Size = new System.Drawing.Size(262, 25);
            ctbSokak.TabIndex = 11;
            ctbSokak.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbSokak.TextCustom = "";
            ctbSokak.UnderlinedStyle = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label7.Location = new System.Drawing.Point(32, 216);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(66, 15);
            label7.TabIndex = 14;
            label7.Text = "Açık Adres";
            // 
            // ctbAcikAdres
            // 
            ctbAcikAdres.BackColor = System.Drawing.Color.White;
            ctbAcikAdres.BorderColor = System.Drawing.Color.Silver;
            ctbAcikAdres.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbAcikAdres.BorderSize = 1;
            ctbAcikAdres.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbAcikAdres.ForeColor = System.Drawing.Color.Black;
            ctbAcikAdres.Location = new System.Drawing.Point(141, 216);
            ctbAcikAdres.Margin = new System.Windows.Forms.Padding(1);
            ctbAcikAdres.Multiline = false;
            ctbAcikAdres.Name = "ctbAcikAdres";
            ctbAcikAdres.Padding = new System.Windows.Forms.Padding(3);
            ctbAcikAdres.PasswordChar = false;
            ctbAcikAdres.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbAcikAdres.PlaceholderText = "";
            ctbAcikAdres.ReadOnly = false;
            ctbAcikAdres.SelectionStart = 0;
            ctbAcikAdres.Size = new System.Drawing.Size(262, 25);
            ctbAcikAdres.TabIndex = 13;
            ctbAcikAdres.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbAcikAdres.TextCustom = "";
            ctbAcikAdres.UnderlinedStyle = false;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(21, 315);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(819, 297);
            universalGrid1.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label8.Location = new System.Drawing.Point(32, 243);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(69, 15);
            label8.TabIndex = 17;
            label8.Text = "Posta Kodu";
            // 
            // ctbPostaKodu
            // 
            ctbPostaKodu.BackColor = System.Drawing.Color.White;
            ctbPostaKodu.BorderColor = System.Drawing.Color.Silver;
            ctbPostaKodu.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbPostaKodu.BorderSize = 1;
            ctbPostaKodu.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbPostaKodu.ForeColor = System.Drawing.Color.Black;
            ctbPostaKodu.Location = new System.Drawing.Point(141, 243);
            ctbPostaKodu.Margin = new System.Windows.Forms.Padding(1);
            ctbPostaKodu.Multiline = false;
            ctbPostaKodu.Name = "ctbPostaKodu";
            ctbPostaKodu.Padding = new System.Windows.Forms.Padding(3);
            ctbPostaKodu.PasswordChar = false;
            ctbPostaKodu.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbPostaKodu.PlaceholderText = "";
            ctbPostaKodu.ReadOnly = false;
            ctbPostaKodu.SelectionStart = 0;
            ctbPostaKodu.Size = new System.Drawing.Size(262, 25);
            ctbPostaKodu.TabIndex = 16;
            ctbPostaKodu.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbPostaKodu.TextCustom = "";
            ctbPostaKodu.UnderlinedStyle = false;
            // 
            // customButtonSave1
            // 
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.Location = new System.Drawing.Point(611, 226);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(106, 46);
            customButtonSave1.TabIndex = 18;
            customButtonSave1.SaveButtonClick += customButtonSave1_SaveButtonClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { adresSilToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(120, 26);
            // 
            // adresSilToolStripMenuItem
            // 
            adresSilToolStripMenuItem.Name = "adresSilToolStripMenuItem";
            adresSilToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            adresSilToolStripMenuItem.Text = "Adres Sil";
            adresSilToolStripMenuItem.Click += adresSilToolStripMenuItem_Click;
            // 
            // AdresTanimlamaFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(866, 662);
            Controls.Add(customButtonSave1);
            Controls.Add(label8);
            Controls.Add(ctbPostaKodu);
            Controls.Add(universalGrid1);
            Controls.Add(label7);
            Controls.Add(ctbAcikAdres);
            Controls.Add(label6);
            Controls.Add(ctbSokak);
            Controls.Add(label5);
            Controls.Add(ctbMahalle);
            Controls.Add(label4);
            Controls.Add(ctbIlce);
            Controls.Add(label3);
            Controls.Add(ctbSehir);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ctbUlke);
            Controls.Add(ctbAdresId);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "AdresTanimlamaFormu";
            Text = "AdresTanimlamaFormu";
            Load += AdresTanimlamaFormu_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomTextBoxSayisal ctbAdresId;
        private CustomControls.CustomTextBox ctbUlke;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CustomControls.CustomTextBox ctbSehir;
        private System.Windows.Forms.Label label4;
        private CustomControls.CustomTextBox ctbIlce;
        private System.Windows.Forms.Label label5;
        private CustomControls.CustomTextBox ctbMahalle;
        private System.Windows.Forms.Label label6;
        private CustomControls.CustomTextBox ctbSokak;
        private System.Windows.Forms.Label label7;
        private CustomControls.CustomTextBox ctbAcikAdres;
        private CustomControls.UniversalGrid universalGrid1;
        private System.Windows.Forms.Label label8;
        private CustomControls.CustomTextBox ctbPostaKodu;
        private CustomControls.CustomButtonSave customButtonSave1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adresSilToolStripMenuItem;
    }
}