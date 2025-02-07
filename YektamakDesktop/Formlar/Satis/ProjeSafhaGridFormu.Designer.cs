namespace YektamakDesktop.Formlar.Satis
{
    partial class ProjeSafhaGridForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjeSafhaGridForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            panelFiltreler = new System.Windows.Forms.Panel();
            buttonVarsayilanProjeAsamalari = new System.Windows.Forms.Button();
            buttonSafhaEkle = new System.Windows.Forms.Button();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonKaydet = new CustomControls.RoundedButton();
            rButtonCikis = new CustomControls.RoundedButton();
            dataGridViewSatisProjeSafha = new System.Windows.Forms.DataGridView();
            ProjeSafhaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ProjeSafhaAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            HedefTarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            GerceklesmeTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            isProjeSafha = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            isSatisSafha = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            IsSafhaGerceklesti = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ButtonSil = new System.Windows.Forms.DataGridViewButtonColumn();
            monthCalendar = new System.Windows.Forms.MonthCalendar();
            panelHeader.SuspendLayout();
            panelFiltreler.SuspendLayout();
            panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatisProjeSafha).BeginInit();
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
            panelHeader.Size = new System.Drawing.Size(1085, 56);
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
            buttonClose.Location = new System.Drawing.Point(1038, 9);
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
            buttonHelp.Location = new System.Drawing.Point(958, 9);
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
            buttomMinimize.Location = new System.Drawing.Point(998, 9);
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
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.BackColor = System.Drawing.Color.Red;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(3, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(166, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Proje Aşamaları";
            labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFiltreler
            // 
            panelFiltreler.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelFiltreler.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelFiltreler.BackColor = System.Drawing.Color.Silver;
            panelFiltreler.Controls.Add(buttonVarsayilanProjeAsamalari);
            panelFiltreler.Controls.Add(buttonSafhaEkle);
            panelFiltreler.ForeColor = System.Drawing.SystemColors.ControlText;
            panelFiltreler.Location = new System.Drawing.Point(0, 53);
            panelFiltreler.Name = "panelFiltreler";
            panelFiltreler.Size = new System.Drawing.Size(1085, 52);
            panelFiltreler.TabIndex = 2;
            // 
            // buttonVarsayilanProjeAsamalari
            // 
            buttonVarsayilanProjeAsamalari.BackColor = System.Drawing.Color.Silver;
            buttonVarsayilanProjeAsamalari.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonVarsayilanProjeAsamalari.BackgroundImage");
            buttonVarsayilanProjeAsamalari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonVarsayilanProjeAsamalari.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonVarsayilanProjeAsamalari.ForeColor = System.Drawing.Color.Transparent;
            buttonVarsayilanProjeAsamalari.Location = new System.Drawing.Point(941, 0);
            buttonVarsayilanProjeAsamalari.Name = "buttonVarsayilanProjeAsamalari";
            buttonVarsayilanProjeAsamalari.Size = new System.Drawing.Size(58, 52);
            buttonVarsayilanProjeAsamalari.TabIndex = 12;
            buttonVarsayilanProjeAsamalari.UseVisualStyleBackColor = false;
            buttonVarsayilanProjeAsamalari.Click += buttonVarsayilanProjeAsamalari_Click;
            // 
            // buttonSafhaEkle
            // 
            buttonSafhaEkle.BackColor = System.Drawing.Color.Silver;
            buttonSafhaEkle.BackgroundImage = Properties.Resources.Plus_Symbol_PNG_Image_HD;
            buttonSafhaEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonSafhaEkle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonSafhaEkle.ForeColor = System.Drawing.Color.Transparent;
            buttonSafhaEkle.Location = new System.Drawing.Point(1024, 0);
            buttonSafhaEkle.Name = "buttonSafhaEkle";
            buttonSafhaEkle.Size = new System.Drawing.Size(58, 52);
            buttonSafhaEkle.TabIndex = 11;
            buttonSafhaEkle.UseVisualStyleBackColor = false;
            buttonSafhaEkle.Click += buttonSafhaEkle_Click;
            // 
            // panelFooter
            // 
            panelFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            panelFooter.Controls.Add(rButtonKaydet);
            panelFooter.Controls.Add(rButtonCikis);
            panelFooter.Location = new System.Drawing.Point(0, 692);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1085, 65);
            panelFooter.TabIndex = 1;
            // 
            // rButtonKaydet
            // 
            rButtonKaydet.BackColor = System.Drawing.Color.LimeGreen;
            rButtonKaydet.BackgroundColor = System.Drawing.Color.LimeGreen;
            rButtonKaydet.BorderColor = System.Drawing.Color.MediumSeaGreen;
            rButtonKaydet.BorderRadius = 40;
            rButtonKaydet.BorderSize = 5;
            rButtonKaydet.FlatAppearance.BorderSize = 0;
            rButtonKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonKaydet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonKaydet.ForeColor = System.Drawing.Color.White;
            rButtonKaydet.Location = new System.Drawing.Point(217, 0);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new System.Drawing.Size(152, 59);
            rButtonKaydet.TabIndex = 1;
            rButtonKaydet.Text = "DEĞİŞİKLİKLERİ KAYDET";
            rButtonKaydet.TextColor = System.Drawing.Color.White;
            rButtonKaydet.UseVisualStyleBackColor = false;
            rButtonKaydet.Click += rButtonKaydet_Click;
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
            // dataGridViewSatisProjeSafha
            // 
            dataGridViewSatisProjeSafha.AllowUserToAddRows = false;
            dataGridViewSatisProjeSafha.AllowUserToDeleteRows = false;
            dataGridViewSatisProjeSafha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSatisProjeSafha.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ProjeSafhaId, ProjeSafhaAdi, HedefTarih, GerceklesmeTarihi, isProjeSafha, isSatisSafha, IsSafhaGerceklesti, ButtonSil });
            dataGridViewSatisProjeSafha.Location = new System.Drawing.Point(0, 111);
            dataGridViewSatisProjeSafha.Name = "dataGridViewSatisProjeSafha";
            dataGridViewSatisProjeSafha.RowTemplate.Height = 25;
            dataGridViewSatisProjeSafha.Size = new System.Drawing.Size(1085, 578);
            dataGridViewSatisProjeSafha.TabIndex = 3;
            dataGridViewSatisProjeSafha.CellClick += dataGridViewSatisProjeSafha_CellClick;
            dataGridViewSatisProjeSafha.CellPainting += dataGridViewSatisProjeSafha_CellPainting;
            // 
            // ProjeSafhaId
            // 
            ProjeSafhaId.HeaderText = "ProjeSafhaId";
            ProjeSafhaId.Name = "ProjeSafhaId";
            ProjeSafhaId.Visible = false;
            // 
            // ProjeSafhaAdi
            // 
            ProjeSafhaAdi.HeaderText = "Aşama";
            ProjeSafhaAdi.Name = "ProjeSafhaAdi";
            ProjeSafhaAdi.Width = 200;
            // 
            // HedefTarih
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            HedefTarih.DefaultCellStyle = dataGridViewCellStyle1;
            HedefTarih.HeaderText = "Hedef Tarih";
            HedefTarih.Name = "HedefTarih";
            HedefTarih.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            HedefTarih.Width = 130;
            // 
            // GerceklesmeTarihi
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            GerceklesmeTarihi.DefaultCellStyle = dataGridViewCellStyle2;
            GerceklesmeTarihi.HeaderText = "Gerçekleşen Tarih";
            GerceklesmeTarihi.Name = "GerceklesmeTarihi";
            GerceklesmeTarihi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            GerceklesmeTarihi.Width = 130;
            // 
            // isProjeSafha
            // 
            isProjeSafha.HeaderText = "Proje Aşaması";
            isProjeSafha.Name = "isProjeSafha";
            isProjeSafha.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            isProjeSafha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // isSatisSafha
            // 
            isSatisSafha.HeaderText = "Satış Aşaması";
            isSatisSafha.Name = "isSatisSafha";
            isSatisSafha.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            isSatisSafha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IsSafhaGerceklesti
            // 
            IsSafhaGerceklesti.HeaderText = "Gerçekleşti";
            IsSafhaGerceklesti.Name = "IsSafhaGerceklesti";
            IsSafhaGerceklesti.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            IsSafhaGerceklesti.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            IsSafhaGerceklesti.Width = 120;
            // 
            // ButtonSil
            // 
            ButtonSil.HeaderText = "Sil";
            ButtonSil.Name = "ButtonSil";
            ButtonSil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            ButtonSil.Width = 30;
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new System.Drawing.Point(715, 243);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 4;
            monthCalendar.DateSelected += monthCalendar_DateSelected;
            monthCalendar.MouseDown += monthCalendar_MouseDown;
            monthCalendar.MouseMove += monthCalendar_MouseMove;
            monthCalendar.MouseUp += monthCalendar_MouseUp;
            // 
            // ProjeSafhaGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1085, 755);
            Controls.Add(monthCalendar);
            Controls.Add(dataGridViewSatisProjeSafha);
            Controls.Add(panelFiltreler);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ProjeSafhaGridForm";
            Text = "PersonelGrid";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFiltreler.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatisProjeSafha).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private CustomControls.RoundedButton rButtonCikis;
        private System.Windows.Forms.Panel panelFiltreler;
        public System.Windows.Forms.DataGridView dataGridViewSatisProjeSafha;
        private System.Windows.Forms.Button buttonSafhaEkle;
        private CustomControls.RoundedButton rButtonKaydet;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjeSafhaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjeSafhaAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HedefTarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn GerceklesmeTarihi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isProjeSafha;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSatisSafha;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSafhaGerceklesti;
        private System.Windows.Forms.DataGridViewButtonColumn ButtonSil;
        private System.Windows.Forms.Button buttonVarsayilanProjeAsamalari;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
    }
}