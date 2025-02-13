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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            panelFiltreler = new System.Windows.Forms.Panel();
            buttonVarsayilanProjeAsamalari = new System.Windows.Forms.Button();
            buttonSafhaEkle = new System.Windows.Forms.Button();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonKaydet = new CustomControls.RoundedButton();
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
            panelHeader = new System.Windows.Forms.Panel();
            rButtonCikis = new CustomControls.RoundedButton();
            roundedButton5 = new CustomControls.RoundedButton();
            roundedButton6 = new CustomControls.RoundedButton();
            roundedButton3 = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            roundedButton1 = new CustomControls.RoundedButton();
            roundedButton2 = new CustomControls.RoundedButton();
            panelFiltreler.SuspendLayout();
            panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatisProjeSafha).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelFiltreler
            // 
            panelFiltreler.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelFiltreler.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelFiltreler.BackColor = System.Drawing.Color.Silver;
            panelFiltreler.Controls.Add(buttonVarsayilanProjeAsamalari);
            panelFiltreler.Controls.Add(buttonSafhaEkle);
            panelFiltreler.ForeColor = System.Drawing.SystemColors.ControlText;
            panelFiltreler.Location = new System.Drawing.Point(0, 32);
            panelFiltreler.Name = "panelFiltreler";
            panelFiltreler.Size = new System.Drawing.Size(1085, 80);
            panelFiltreler.TabIndex = 2;
            // 
            // buttonVarsayilanProjeAsamalari
            // 
            buttonVarsayilanProjeAsamalari.BackColor = System.Drawing.Color.Transparent;
            buttonVarsayilanProjeAsamalari.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonVarsayilanProjeAsamalari.BackgroundImage");
            buttonVarsayilanProjeAsamalari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonVarsayilanProjeAsamalari.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonVarsayilanProjeAsamalari.ForeColor = System.Drawing.Color.Transparent;
            buttonVarsayilanProjeAsamalari.Location = new System.Drawing.Point(964, 24);
            buttonVarsayilanProjeAsamalari.Name = "buttonVarsayilanProjeAsamalari";
            buttonVarsayilanProjeAsamalari.Size = new System.Drawing.Size(35, 35);
            buttonVarsayilanProjeAsamalari.TabIndex = 12;
            buttonVarsayilanProjeAsamalari.UseVisualStyleBackColor = false;
            buttonVarsayilanProjeAsamalari.Click += buttonVarsayilanProjeAsamalari_Click;
            // 
            // buttonSafhaEkle
            // 
            buttonSafhaEkle.BackColor = System.Drawing.Color.Transparent;
            buttonSafhaEkle.BackgroundImage = Properties.Resources.Plus_Symbol_PNG_Image_HD;
            buttonSafhaEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonSafhaEkle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonSafhaEkle.ForeColor = System.Drawing.Color.Transparent;
            buttonSafhaEkle.Location = new System.Drawing.Point(1027, 24);
            buttonSafhaEkle.Name = "buttonSafhaEkle";
            buttonSafhaEkle.Size = new System.Drawing.Size(35, 35);
            buttonSafhaEkle.TabIndex = 11;
            buttonSafhaEkle.UseVisualStyleBackColor = false;
            buttonSafhaEkle.Click += buttonSafhaEkle_Click;
            // 
            // panelFooter
            // 
            panelFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            panelFooter.Controls.Add(rButtonKaydet);
            panelFooter.Location = new System.Drawing.Point(0, 689);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1085, 66);
            panelFooter.TabIndex = 1;
            // 
            // rButtonKaydet
            // 
            rButtonKaydet.BackColor = System.Drawing.Color.Transparent;
            rButtonKaydet.BackgroundColor = System.Drawing.Color.Transparent;
            rButtonKaydet.BorderColor = System.Drawing.Color.MediumSeaGreen;
            rButtonKaydet.BorderRadius = 20;
            rButtonKaydet.BorderSize = 2;
            rButtonKaydet.FlatAppearance.BorderSize = 0;
            rButtonKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonKaydet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonKaydet.ForeColor = System.Drawing.Color.White;
            rButtonKaydet.Image = Properties.Resources.kaydet;
            rButtonKaydet.Location = new System.Drawing.Point(1008, 5);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new System.Drawing.Size(47, 49);
            rButtonKaydet.TabIndex = 1;
            rButtonKaydet.TextColor = System.Drawing.Color.White;
            rButtonKaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            rButtonKaydet.UseCompatibleTextRendering = true;
            rButtonKaydet.UseVisualStyleBackColor = false;
            rButtonKaydet.Click += rButtonKaydet_Click;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            HedefTarih.DefaultCellStyle = dataGridViewCellStyle5;
            HedefTarih.HeaderText = "Hedef Tarih";
            HedefTarih.Name = "HedefTarih";
            HedefTarih.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            HedefTarih.Width = 130;
            // 
            // GerceklesmeTarihi
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            GerceklesmeTarihi.DefaultCellStyle = dataGridViewCellStyle6;
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
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Firebrick;
            panelHeader.Controls.Add(rButtonCikis);
            panelHeader.Controls.Add(roundedButton5);
            panelHeader.Controls.Add(roundedButton6);
            panelHeader.Controls.Add(roundedButton3);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Controls.Add(roundedButton1);
            panelHeader.Controls.Add(roundedButton2);
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Margin = new System.Windows.Forms.Padding(0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1085, 32);
            panelHeader.TabIndex = 8;
            // 
            // rButtonCikis
            // 
            rButtonCikis.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            rButtonCikis.BackColor = System.Drawing.Color.Firebrick;
            rButtonCikis.BackgroundColor = System.Drawing.Color.Firebrick;
            rButtonCikis.BorderColor = System.Drawing.Color.Firebrick;
            rButtonCikis.BorderRadius = 10;
            rButtonCikis.BorderSize = 2;
            rButtonCikis.FlatAppearance.BorderSize = 0;
            rButtonCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            rButtonCikis.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            rButtonCikis.ForeColor = System.Drawing.Color.White;
            rButtonCikis.Location = new System.Drawing.Point(1051, 2);
            rButtonCikis.Margin = new System.Windows.Forms.Padding(0);
            rButtonCikis.Name = "rButtonCikis";
            rButtonCikis.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            rButtonCikis.Size = new System.Drawing.Size(29, 27);
            rButtonCikis.TabIndex = 103;
            rButtonCikis.Text = "X";
            rButtonCikis.TextColor = System.Drawing.Color.White;
            rButtonCikis.UseVisualStyleBackColor = false;
            rButtonCikis.Click += roundedButton4_Click;
            // 
            // roundedButton5
            // 
            roundedButton5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton5.BackColor = System.Drawing.Color.Firebrick;
            roundedButton5.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton5.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton5.BorderRadius = 10;
            roundedButton5.BorderSize = 2;
            roundedButton5.FlatAppearance.BorderSize = 0;
            roundedButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton5.ForeColor = System.Drawing.Color.White;
            roundedButton5.Location = new System.Drawing.Point(1011, 2);
            roundedButton5.Margin = new System.Windows.Forms.Padding(0);
            roundedButton5.Name = "roundedButton5";
            roundedButton5.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton5.Size = new System.Drawing.Size(29, 27);
            roundedButton5.TabIndex = 101;
            roundedButton5.Text = "-";
            roundedButton5.TextColor = System.Drawing.Color.White;
            roundedButton5.UseVisualStyleBackColor = false;
            roundedButton5.Click += roundedButton5_Click;
            // 
            // roundedButton6
            // 
            roundedButton6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton6.BackColor = System.Drawing.Color.Firebrick;
            roundedButton6.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton6.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton6.BorderRadius = 10;
            roundedButton6.BorderSize = 2;
            roundedButton6.FlatAppearance.BorderSize = 0;
            roundedButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton6.ForeColor = System.Drawing.Color.White;
            roundedButton6.Location = new System.Drawing.Point(972, 3);
            roundedButton6.Margin = new System.Windows.Forms.Padding(0);
            roundedButton6.Name = "roundedButton6";
            roundedButton6.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton6.Size = new System.Drawing.Size(29, 27);
            roundedButton6.TabIndex = 102;
            roundedButton6.Text = "?";
            roundedButton6.TextColor = System.Drawing.Color.White;
            roundedButton6.UseVisualStyleBackColor = false;
            // 
            // roundedButton3
            // 
            roundedButton3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton3.BackColor = System.Drawing.Color.Firebrick;
            roundedButton3.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton3.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton3.BorderRadius = 0;
            roundedButton3.BorderSize = 2;
            roundedButton3.FlatAppearance.BorderSize = 0;
            roundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton3.ForeColor = System.Drawing.Color.White;
            roundedButton3.Location = new System.Drawing.Point(1702, 1);
            roundedButton3.Margin = new System.Windows.Forms.Padding(0);
            roundedButton3.Name = "roundedButton3";
            roundedButton3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton3.Size = new System.Drawing.Size(29, 0);
            roundedButton3.TabIndex = 100;
            roundedButton3.Text = "X";
            roundedButton3.TextColor = System.Drawing.Color.White;
            roundedButton3.UseVisualStyleBackColor = false;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(12, 6);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(98, 17);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Proje Safhaları";
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton1.BackColor = System.Drawing.Color.Firebrick;
            roundedButton1.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderRadius = 0;
            roundedButton1.BorderSize = 2;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.Location = new System.Drawing.Point(1662, 1);
            roundedButton1.Margin = new System.Windows.Forms.Padding(0);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton1.Size = new System.Drawing.Size(29, 0);
            roundedButton1.TabIndex = 98;
            roundedButton1.Text = "-";
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = false;
            // 
            // roundedButton2
            // 
            roundedButton2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton2.BackColor = System.Drawing.Color.Firebrick;
            roundedButton2.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton2.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton2.BorderRadius = 0;
            roundedButton2.BorderSize = 2;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton2.ForeColor = System.Drawing.Color.White;
            roundedButton2.Location = new System.Drawing.Point(1623, 2);
            roundedButton2.Margin = new System.Windows.Forms.Padding(0);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton2.Size = new System.Drawing.Size(29, 0);
            roundedButton2.TabIndex = 99;
            roundedButton2.Text = "?";
            roundedButton2.TextColor = System.Drawing.Color.White;
            roundedButton2.UseVisualStyleBackColor = false;
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
            panelFiltreler.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatisProjeSafha).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panelFooter;
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
        private System.Windows.Forms.Panel panelHeader;
        private CustomControls.RoundedButton roundedButton3;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.RoundedButton roundedButton1;
        private CustomControls.RoundedButton roundedButton2;
        private CustomControls.RoundedButton rButtonCikis;
        private CustomControls.RoundedButton roundedButton5;
        private CustomControls.RoundedButton roundedButton6;
    }
}