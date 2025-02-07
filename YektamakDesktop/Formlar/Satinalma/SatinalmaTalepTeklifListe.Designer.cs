namespace YektamakDesktop.Formlar.Satinalma
{
    partial class SatinalmaTalepTeklifListe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            comboListProjeKodu = new CustomControls.CustomComboListBox();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            SatinalmaTalepDetayId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SatinalmaTalepBaslikId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ProjeKodId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ProjeKod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TalepTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TalepEdenKullaniciId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            KullaniciAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TalepTipId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StokKartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StokKartKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StokKartAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SetMiktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            xSetMiktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Aciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Secim = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            PDF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            customCheckedComboBox1 = new CustomControls.CustomCheckedComboBox();
            roundedIconButton1 = new CustomControls.RoundedIconButton();
            roundedIconButton2 = new CustomControls.RoundedIconButton();
            comboListBoxFirma = new CustomControls.CustomComboListBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Red;
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1166, 38);
            panelHeader.TabIndex = 3;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = System.Drawing.Color.Red;
            buttonClose.BackgroundColor = System.Drawing.Color.Red;
            buttonClose.BorderColor = System.Drawing.Color.LavenderBlush;
            buttonClose.BorderRadius = 30;
            buttonClose.BorderSize = 2;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonClose.ForeColor = System.Drawing.Color.White;
            buttonClose.Location = new System.Drawing.Point(1112, 5);
            buttonClose.Margin = new System.Windows.Forms.Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonClose.Size = new System.Drawing.Size(30, 30);
            buttonClose.TabIndex = 106;
            buttonClose.Text = "x";
            buttonClose.TextColor = System.Drawing.Color.White;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonHelp
            // 
            buttonHelp.BackColor = System.Drawing.Color.Red;
            buttonHelp.BackgroundColor = System.Drawing.Color.Red;
            buttonHelp.BorderColor = System.Drawing.Color.LavenderBlush;
            buttonHelp.BorderRadius = 30;
            buttonHelp.BorderSize = 2;
            buttonHelp.FlatAppearance.BorderSize = 0;
            buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonHelp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonHelp.ForeColor = System.Drawing.Color.White;
            buttonHelp.Location = new System.Drawing.Point(1044, 5);
            buttonHelp.Margin = new System.Windows.Forms.Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonHelp.Size = new System.Drawing.Size(30, 30);
            buttonHelp.TabIndex = 105;
            buttonHelp.Text = "?";
            buttonHelp.TextColor = System.Drawing.Color.White;
            buttonHelp.UseVisualStyleBackColor = false;
            // 
            // buttomMinimize
            // 
            buttomMinimize.BackColor = System.Drawing.Color.Red;
            buttomMinimize.BackgroundColor = System.Drawing.Color.Red;
            buttomMinimize.BorderColor = System.Drawing.Color.LavenderBlush;
            buttomMinimize.BorderRadius = 30;
            buttomMinimize.BorderSize = 2;
            buttomMinimize.FlatAppearance.BorderSize = 0;
            buttomMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttomMinimize.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttomMinimize.ForeColor = System.Drawing.Color.White;
            buttomMinimize.Location = new System.Drawing.Point(1078, 5);
            buttomMinimize.Margin = new System.Windows.Forms.Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttomMinimize.Size = new System.Drawing.Size(30, 30);
            buttomMinimize.TabIndex = 104;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = System.Drawing.Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            buttomMinimize.Click += buttomMinimize_Click;
            // 
            // labelHeader
            // 
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.BackColor = System.Drawing.Color.Red;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(38, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(157, 21);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Satınalma Talepleri";
            labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboListProjeKodu
            // 
            comboListProjeKodu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboListProjeKodu.ListBoxVisualSize = 5;
            comboListProjeKodu.Location = new System.Drawing.Point(171, 76);
            comboListProjeKodu.Margin = new System.Windows.Forms.Padding(1);
            comboListProjeKodu.Name = "comboListProjeKodu";
            comboListProjeKodu.Padding = new System.Windows.Forms.Padding(1);
            comboListProjeKodu.Size = new System.Drawing.Size(188, 36);
            comboListProjeKodu.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { SatinalmaTalepDetayId, SatinalmaTalepBaslikId, ProjeKodId, ProjeKod, TalepTarihi, TalepEdenKullaniciId, KullaniciAdi, TalepTipId, StokKartId, StokKartKodu, StokKartAdi, SetMiktar, xSetMiktar, Aciklama, Secim, PDF });
            dataGridView1.Location = new System.Drawing.Point(38, 154);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(1104, 526);
            dataGridView1.TabIndex = 6;
            // 
            // SatinalmaTalepDetayId
            // 
            SatinalmaTalepDetayId.HeaderText = "SatinalmaTalepDetayId";
            SatinalmaTalepDetayId.Name = "SatinalmaTalepDetayId";
            SatinalmaTalepDetayId.Visible = false;
            // 
            // SatinalmaTalepBaslikId
            // 
            SatinalmaTalepBaslikId.HeaderText = "SatinalmaTalepBaslikId";
            SatinalmaTalepBaslikId.Name = "SatinalmaTalepBaslikId";
            SatinalmaTalepBaslikId.Visible = false;
            // 
            // ProjeKodId
            // 
            ProjeKodId.HeaderText = "ProjeKodId";
            ProjeKodId.Name = "ProjeKodId";
            ProjeKodId.Visible = false;
            // 
            // ProjeKod
            // 
            ProjeKod.HeaderText = "Proje Kodu";
            ProjeKod.Name = "ProjeKod";
            // 
            // TalepTarihi
            // 
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            TalepTarihi.DefaultCellStyle = dataGridViewCellStyle4;
            TalepTarihi.HeaderText = "Talep Tarihi";
            TalepTarihi.Name = "TalepTarihi";
            // 
            // TalepEdenKullaniciId
            // 
            TalepEdenKullaniciId.HeaderText = "TalepEdenKullaniciId";
            TalepEdenKullaniciId.Name = "TalepEdenKullaniciId";
            TalepEdenKullaniciId.Visible = false;
            // 
            // KullaniciAdi
            // 
            KullaniciAdi.HeaderText = "KullaniciAdi";
            KullaniciAdi.Name = "KullaniciAdi";
            // 
            // TalepTipId
            // 
            TalepTipId.HeaderText = "TalepTipId";
            TalepTipId.Name = "TalepTipId";
            TalepTipId.Visible = false;
            // 
            // StokKartId
            // 
            StokKartId.HeaderText = "StokKartId";
            StokKartId.Name = "StokKartId";
            StokKartId.Visible = false;
            // 
            // StokKartKodu
            // 
            StokKartKodu.HeaderText = "StokKartKodu";
            StokKartKodu.Name = "StokKartKodu";
            // 
            // StokKartAdi
            // 
            StokKartAdi.HeaderText = "StokKartAdi";
            StokKartAdi.Name = "StokKartAdi";
            // 
            // SetMiktar
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            SetMiktar.DefaultCellStyle = dataGridViewCellStyle5;
            SetMiktar.HeaderText = "SetMiktar";
            SetMiktar.Name = "SetMiktar";
            // 
            // xSetMiktar
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            xSetMiktar.DefaultCellStyle = dataGridViewCellStyle6;
            xSetMiktar.HeaderText = "xSetMiktar";
            xSetMiktar.Name = "xSetMiktar";
            // 
            // Aciklama
            // 
            Aciklama.HeaderText = "Aciklama";
            Aciklama.Name = "Aciklama";
            // 
            // Secim
            // 
            Secim.HeaderText = "Seçim";
            Secim.Name = "Secim";
            // 
            // PDF
            // 
            PDF.HeaderText = "PDF";
            PDF.Name = "PDF";
            PDF.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            PDF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // customCheckedComboBox1
            // 
            customCheckedComboBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            customCheckedComboBox1.ListBoxVisualSize = 5;
            customCheckedComboBox1.Location = new System.Drawing.Point(198, 114);
            customCheckedComboBox1.Margin = new System.Windows.Forms.Padding(1);
            customCheckedComboBox1.Name = "customCheckedComboBox1";
            customCheckedComboBox1.Padding = new System.Windows.Forms.Padding(1);
            customCheckedComboBox1.Size = new System.Drawing.Size(161, 36);
            customCheckedComboBox1.TabIndex = 7;
            // 
            // roundedIconButton1
            // 
            roundedIconButton1.BackColor = System.Drawing.Color.Red;
            roundedIconButton1.CornerRadius = 1;
            roundedIconButton1.FlatAppearance.BorderSize = 0;
            roundedIconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedIconButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedIconButton1.ForeColor = System.Drawing.Color.Gainsboro;
            roundedIconButton1.IconChar = FontAwesome.Sharp.IconChar.Filter;
            roundedIconButton1.IconColor = System.Drawing.Color.Gainsboro;
            roundedIconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            roundedIconButton1.IconSize = 25;
            roundedIconButton1.Location = new System.Drawing.Point(385, 89);
            roundedIconButton1.Name = "roundedIconButton1";
            roundedIconButton1.Size = new System.Drawing.Size(40, 34);
            roundedIconButton1.TabIndex = 9;
            roundedIconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            roundedIconButton1.UseVisualStyleBackColor = false;
            roundedIconButton1.Click += roundedIconButton1_Click;
            // 
            // roundedIconButton2
            // 
            roundedIconButton2.BackColor = System.Drawing.Color.Red;
            roundedIconButton2.CornerRadius = 1;
            roundedIconButton2.FlatAppearance.BorderSize = 0;
            roundedIconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedIconButton2.IconChar = FontAwesome.Sharp.IconChar.Question;
            roundedIconButton2.IconColor = System.Drawing.Color.Gainsboro;
            roundedIconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            roundedIconButton2.IconSize = 25;
            roundedIconButton2.Location = new System.Drawing.Point(945, 72);
            roundedIconButton2.Name = "roundedIconButton2";
            roundedIconButton2.Size = new System.Drawing.Size(40, 34);
            roundedIconButton2.TabIndex = 10;
            roundedIconButton2.UseVisualStyleBackColor = false;
            roundedIconButton2.Click += button1_Click;
            // 
            // comboListBoxFirma
            // 
            comboListBoxFirma.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboListBoxFirma.ListBoxVisualSize = 5;
            comboListBoxFirma.Location = new System.Drawing.Point(609, 76);
            comboListBoxFirma.Margin = new System.Windows.Forms.Padding(1);
            comboListBoxFirma.Name = "comboListBoxFirma";
            comboListBoxFirma.Padding = new System.Windows.Forms.Padding(1);
            comboListBoxFirma.Size = new System.Drawing.Size(329, 36);
            comboListBoxFirma.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(40, 76);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(112, 25);
            label1.TabIndex = 12;
            label1.Text = "Proje Kodu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(40, 114);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(154, 25);
            label2.TabIndex = 13;
            label2.Text = "Malzeme Grubu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(491, 78);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(114, 25);
            label3.TabIndex = 14;
            label3.Text = "Teklif Firma";
            // 
            // SatinalmaTalepTeklifListe
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1166, 704);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboListBoxFirma);
            Controls.Add(roundedIconButton2);
            Controls.Add(roundedIconButton1);
            Controls.Add(customCheckedComboBox1);
            Controls.Add(dataGridView1);
            Controls.Add(comboListProjeKodu);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTalepTeklifListe";
            RightToLeft = System.Windows.Forms.RightToLeft.No;
            Text = "SatinalmaTalepTeklifListe";
            Load += SatinalmaTalepTeklifListe_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.CustomComboListBox comboListProjeKodu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CustomControls.CustomCheckedComboBox customCheckedComboBox1;
        private CustomControls.RoundedIconButton roundedIconButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatinalmaTalepDetayId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatinalmaTalepBaslikId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjeKodId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjeKod;
        private System.Windows.Forms.DataGridViewTextBoxColumn TalepTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TalepEdenKullaniciId;
        private System.Windows.Forms.DataGridViewTextBoxColumn KullaniciAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TalepTipId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokKartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokKartKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokKartAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetMiktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn xSetMiktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aciklama;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Secim;
        private System.Windows.Forms.DataGridViewTextBoxColumn PDF;
        private CustomControls.RoundedIconButton roundedIconButton2;
        private CustomControls.CustomComboListBox comboListBoxFirma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}