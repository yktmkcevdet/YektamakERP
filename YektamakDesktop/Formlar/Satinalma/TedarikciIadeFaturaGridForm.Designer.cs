namespace YektamakDesktop.Formlar.Genel
{
    partial class TedarikciIadeFaturaGridForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            textBoxProjeKodFiltre = new System.Windows.Forms.TextBox();
            textBoxFirmaFiltre = new System.Windows.Forms.TextBox();
            textBoxTarihFiltre = new System.Windows.Forms.TextBox();
            textBoxFaturaNoFiltre = new System.Windows.Forms.TextBox();
            buttonTedarikciIadeFaturaEkle = new System.Windows.Forms.Button();
            buttonTumKayitlariGetir = new System.Windows.Forms.Button();
            buttonFiltre = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            rButtonCikis = new CustomControls.RoundedButton();
            dataGridViewTedarikciIadeFatura = new System.Windows.Forms.DataGridView();
            monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            TedarikciIadeFaturaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ProjeKod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TedarikciIadeFaturaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TedarikciIadeFaturaTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            FaturaTutari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CariKartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CariAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Sil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panelHeader.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTedarikciIadeFatura).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Red;
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1177, 56);
            panelHeader.TabIndex = 0;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = System.Drawing.Color.Red;
            buttonClose.BackgroundColor = System.Drawing.Color.Red;
            buttonClose.BorderColor = System.Drawing.Color.LavenderBlush;
            buttonClose.BorderRadius = 10;
            buttonClose.BorderSize = 2;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonClose.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonClose.ForeColor = System.Drawing.Color.White;
            buttonClose.Location = new System.Drawing.Point(1129, 9);
            buttonClose.Margin = new System.Windows.Forms.Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonClose.Size = new System.Drawing.Size(40, 38);
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
            buttonHelp.BorderRadius = 10;
            buttonHelp.BorderSize = 2;
            buttonHelp.FlatAppearance.BorderSize = 0;
            buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonHelp.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonHelp.ForeColor = System.Drawing.Color.White;
            buttonHelp.Location = new System.Drawing.Point(1049, 9);
            buttonHelp.Margin = new System.Windows.Forms.Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonHelp.Size = new System.Drawing.Size(40, 38);
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
            buttomMinimize.BorderRadius = 10;
            buttomMinimize.BorderSize = 2;
            buttomMinimize.FlatAppearance.BorderSize = 0;
            buttomMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttomMinimize.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttomMinimize.ForeColor = System.Drawing.Color.White;
            buttomMinimize.Location = new System.Drawing.Point(1089, 9);
            buttomMinimize.Margin = new System.Windows.Forms.Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttomMinimize.Size = new System.Drawing.Size(40, 38);
            buttomMinimize.TabIndex = 104;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = System.Drawing.Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            buttomMinimize.Click += buttomMinimize_Click;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(3, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(246, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Tedarikçi İade Faturaları";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Silver;
            panel1.Controls.Add(textBoxProjeKodFiltre);
            panel1.Controls.Add(textBoxFirmaFiltre);
            panel1.Controls.Add(textBoxTarihFiltre);
            panel1.Controls.Add(textBoxFaturaNoFiltre);
            panel1.Controls.Add(buttonTedarikciIadeFaturaEkle);
            panel1.Controls.Add(buttonTumKayitlariGetir);
            panel1.Controls.Add(buttonFiltre);
            panel1.Location = new System.Drawing.Point(0, 53);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1177, 52);
            panel1.TabIndex = 1;
            // 
            // textBoxProjeKodFiltre
            // 
            textBoxProjeKodFiltre.Location = new System.Drawing.Point(49, 21);
            textBoxProjeKodFiltre.Name = "textBoxProjeKodFiltre";
            textBoxProjeKodFiltre.Size = new System.Drawing.Size(141, 23);
            textBoxProjeKodFiltre.TabIndex = 16;
            // 
            // textBoxFirmaFiltre
            // 
            textBoxFirmaFiltre.Location = new System.Drawing.Point(493, 21);
            textBoxFirmaFiltre.Name = "textBoxFirmaFiltre";
            textBoxFirmaFiltre.Size = new System.Drawing.Size(201, 23);
            textBoxFirmaFiltre.TabIndex = 15;
            // 
            // textBoxTarihFiltre
            // 
            textBoxTarihFiltre.Location = new System.Drawing.Point(301, 21);
            textBoxTarihFiltre.Name = "textBoxTarihFiltre";
            textBoxTarihFiltre.ReadOnly = true;
            textBoxTarihFiltre.Size = new System.Drawing.Size(94, 23);
            textBoxTarihFiltre.TabIndex = 14;
            textBoxTarihFiltre.Click += ViewMonthCalendar;
            textBoxTarihFiltre.Enter += ViewMonthCalendar;
            textBoxTarihFiltre.KeyPress += textBoxTarihFiltre_KeyPress;
            // 
            // textBoxFaturaNoFiltre
            // 
            textBoxFaturaNoFiltre.Location = new System.Drawing.Point(198, 21);
            textBoxFaturaNoFiltre.Name = "textBoxFaturaNoFiltre";
            textBoxFaturaNoFiltre.Size = new System.Drawing.Size(100, 23);
            textBoxFaturaNoFiltre.TabIndex = 13;
            // 
            // buttonTedarikciIadeFaturaEkle
            // 
            buttonTedarikciIadeFaturaEkle.BackColor = System.Drawing.Color.Silver;
            buttonTedarikciIadeFaturaEkle.BackgroundImage = Properties.Resources.Plus_Symbol_PNG_Image_HD;
            buttonTedarikciIadeFaturaEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonTedarikciIadeFaturaEkle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonTedarikciIadeFaturaEkle.ForeColor = System.Drawing.Color.Transparent;
            buttonTedarikciIadeFaturaEkle.Location = new System.Drawing.Point(1113, 0);
            buttonTedarikciIadeFaturaEkle.Name = "buttonTedarikciIadeFaturaEkle";
            buttonTedarikciIadeFaturaEkle.Size = new System.Drawing.Size(58, 52);
            buttonTedarikciIadeFaturaEkle.TabIndex = 12;
            buttonTedarikciIadeFaturaEkle.UseVisualStyleBackColor = false;
            buttonTedarikciIadeFaturaEkle.Click += buttonTedarikciIadeFaturaEkle_Click;
            // 
            // buttonTumKayitlariGetir
            // 
            buttonTumKayitlariGetir.BackColor = System.Drawing.Color.Tomato;
            buttonTumKayitlariGetir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonTumKayitlariGetir.ForeColor = System.Drawing.Color.Transparent;
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(991, 0);
            buttonTumKayitlariGetir.Name = "buttonTumKayitlariGetir";
            buttonTumKayitlariGetir.Size = new System.Drawing.Size(103, 52);
            buttonTumKayitlariGetir.TabIndex = 11;
            buttonTumKayitlariGetir.Text = "Tüm Kayıtları Getir";
            buttonTumKayitlariGetir.UseVisualStyleBackColor = false;
            //buttonTumKayitlariGetir.Click += buttonTumKayitlariGetir_Click;
            // 
            // buttonFiltre
            // 
            buttonFiltre.BackgroundImage = Properties.Resources.DataReviewWithMagnifier5;
            buttonFiltre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            buttonFiltre.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonFiltre.ForeColor = System.Drawing.Color.Blue;
            buttonFiltre.Location = new System.Drawing.Point(878, 0);
            buttonFiltre.Name = "buttonFiltre";
            buttonFiltre.Size = new System.Drawing.Size(107, 52);
            buttonFiltre.TabIndex = 10;
            buttonFiltre.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            buttonFiltre.UseVisualStyleBackColor = true;
            buttonFiltre.Click += buttonFiltre_Click;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            panel2.Controls.Add(rButtonCikis);
            panel2.Location = new System.Drawing.Point(0, 692);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1177, 65);
            panel2.TabIndex = 2;
            // 
            // rButtonCikis
            // 
            rButtonCikis.BackColor = System.Drawing.Color.Brown;
            rButtonCikis.BackgroundColor = System.Drawing.Color.Brown;
            rButtonCikis.BorderColor = System.Drawing.Color.Crimson;
            rButtonCikis.BorderRadius = 40;
            rButtonCikis.BorderSize = 5;
            rButtonCikis.FlatAppearance.BorderSize = 0;
            rButtonCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonCikis.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonCikis.ForeColor = System.Drawing.Color.White;
            rButtonCikis.Location = new System.Drawing.Point(3, 3);
            rButtonCikis.Name = "rButtonCikis";
            rButtonCikis.Size = new System.Drawing.Size(152, 59);
            rButtonCikis.TabIndex = 0;
            rButtonCikis.Text = "KAPAT";
            rButtonCikis.TextColor = System.Drawing.Color.White;
            rButtonCikis.UseVisualStyleBackColor = false;
            rButtonCikis.Click += rButtonCikis_Click;
            // 
            // dataGridViewTedarikciIadeFatura
            // 
            dataGridViewTedarikciIadeFatura.AllowUserToAddRows = false;
            dataGridViewTedarikciIadeFatura.AllowUserToDeleteRows = false;
            dataGridViewTedarikciIadeFatura.AllowUserToOrderColumns = true;
            dataGridViewTedarikciIadeFatura.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewTedarikciIadeFatura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTedarikciIadeFatura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { TedarikciIadeFaturaId, ProjeKod, TedarikciIadeFaturaNo, TedarikciIadeFaturaTarihi, FaturaTutari, CariKartId, CariAdi, Guncelle, Sil });
            dataGridViewTedarikciIadeFatura.Location = new System.Drawing.Point(3, 111);
            dataGridViewTedarikciIadeFatura.Name = "dataGridViewTedarikciIadeFatura";
            dataGridViewTedarikciIadeFatura.ReadOnly = true;
            dataGridViewTedarikciIadeFatura.RowTemplate.Height = 25;
            dataGridViewTedarikciIadeFatura.Size = new System.Drawing.Size(1174, 575);
            dataGridViewTedarikciIadeFatura.TabIndex = 3;
            dataGridViewTedarikciIadeFatura.CellClick += dataGridViewTedarikciIadeFatura_CellClick;
            dataGridViewTedarikciIadeFatura.CellPainting += dataGridViewTedarikciIadeFatura_CellPainting;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new System.Drawing.Point(605, 171);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 16;
            monthCalendar1.Visible = false;
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            monthCalendar1.MouseLeave += monthCalendar1_MouseLeave;
            // 
            // TedarikciIadeFaturaId
            // 
            TedarikciIadeFaturaId.HeaderText = "TedarikciIadeFaturaId";
            TedarikciIadeFaturaId.Name = "TedarikciIadeFaturaId";
            TedarikciIadeFaturaId.ReadOnly = true;
            TedarikciIadeFaturaId.Visible = false;
            // 
            // ProjeKod
            // 
            ProjeKod.HeaderText = "Proje Kodu";
            ProjeKod.Name = "ProjeKod";
            ProjeKod.ReadOnly = true;
            ProjeKod.Width = 150;
            // 
            // TedarikciIadeFaturaNo
            // 
            TedarikciIadeFaturaNo.HeaderText = "FaturaNo";
            TedarikciIadeFaturaNo.Name = "TedarikciIadeFaturaNo";
            TedarikciIadeFaturaNo.ReadOnly = true;
            // 
            // TedarikciIadeFaturaTarihi
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            TedarikciIadeFaturaTarihi.DefaultCellStyle = dataGridViewCellStyle1;
            TedarikciIadeFaturaTarihi.HeaderText = "Fatura Tarihi";
            TedarikciIadeFaturaTarihi.Name = "TedarikciIadeFaturaTarihi";
            TedarikciIadeFaturaTarihi.ReadOnly = true;
            // 
            // FaturaTutari
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            FaturaTutari.DefaultCellStyle = dataGridViewCellStyle2;
            FaturaTutari.HeaderText = "Tutar";
            FaturaTutari.Name = "FaturaTutari";
            FaturaTutari.ReadOnly = true;
            // 
            // CariKartId
            // 
            CariKartId.HeaderText = "CariKartId";
            CariKartId.Name = "CariKartId";
            CariKartId.ReadOnly = true;
            CariKartId.Visible = false;
            // 
            // CariAdi
            // 
            CariAdi.HeaderText = "Cari Adı";
            CariAdi.Name = "CariAdi";
            CariAdi.ReadOnly = true;
            CariAdi.Width = 200;
            // 
            // Guncelle
            // 
            Guncelle.HeaderText = "Güncelle";
            Guncelle.Name = "Guncelle";
            Guncelle.ReadOnly = true;
            Guncelle.Width = 60;
            // 
            // Sil
            // 
            Sil.HeaderText = "Sil";
            Sil.Name = "Sil";
            Sil.ReadOnly = true;
            Sil.Width = 30;
            // 
            // TedarikciIadeFaturaGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1176, 755);
            Controls.Add(monthCalendar1);
            Controls.Add(dataGridViewTedarikciIadeFatura);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "TedarikciIadeFaturaGridForm";
            Text = "TedarikciIadeFaturaGridFormu";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTedarikciIadeFatura).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Button buttonFiltre;
        private System.Windows.Forms.Button buttonTumKayitlariGetir;
        private System.Windows.Forms.Button buttonTedarikciIadeFaturaEkle;
        private System.Windows.Forms.DataGridView dataGridViewTedarikciIadeFatura;
        private CustomControls.RoundedButton rButtonCikis;
        private System.Windows.Forms.TextBox textBoxFaturaNoFiltre;
        private System.Windows.Forms.TextBox textBoxTarihFiltre;
        private System.Windows.Forms.TextBox textBoxFirmaFiltre;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox textBoxProjeKodFiltre;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.DataGridViewTextBoxColumn TedarikciIadeFaturaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjeKod;
        private System.Windows.Forms.DataGridViewTextBoxColumn TedarikciIadeFaturaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TedarikciIadeFaturaTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaturaTutari;
        private System.Windows.Forms.DataGridViewTextBoxColumn CariKartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CariAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Guncelle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sil;
    }
}