namespace YektamakDesktop.Formlar.Stok
{
    partial class StokKartGridForm
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
            labelHeader = new System.Windows.Forms.Label();
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonCikis = new CustomControls.RoundedButton();
            panelFiltreler = new System.Windows.Forms.Panel();
            textBoxMusteriFiltre = new System.Windows.Forms.TextBox();
            buttonSatisSiparisEkle = new System.Windows.Forms.Button();
            buttonTumKayitlariGetir = new System.Windows.Forms.Button();
            buttonFiltre = new System.Windows.Forms.Button();
            textBoxTarihFiltre = new System.Windows.Forms.TextBox();
            textBoxAciklamaFiltre = new System.Windows.Forms.TextBox();
            textBoxProjeKodFiltre = new System.Windows.Forms.TextBox();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            StokKartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StokKartKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StokKartAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Boyut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            MalzemeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            MalzemeKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            panelHeader.SuspendLayout();
            panelFooter.SuspendLayout();
            panelFiltreler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // labelHeader
            // 
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.BackColor = System.Drawing.Color.Red;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(3, 10);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(136, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Stok Kartları";
            labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            panelHeader.Size = new System.Drawing.Size(1086, 56);
            panelHeader.TabIndex = 1;
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
            // 
            // panelFooter
            // 
            panelFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            panelFooter.Controls.Add(rButtonCikis);
            panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelFooter.Location = new System.Drawing.Point(0, 640);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1086, 65);
            panelFooter.TabIndex = 2;
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
            // panelFiltreler
            // 
            panelFiltreler.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelFiltreler.BackColor = System.Drawing.Color.Silver;
            panelFiltreler.Controls.Add(textBoxMusteriFiltre);
            panelFiltreler.Controls.Add(buttonSatisSiparisEkle);
            panelFiltreler.Controls.Add(buttonTumKayitlariGetir);
            panelFiltreler.Controls.Add(buttonFiltre);
            panelFiltreler.Controls.Add(textBoxTarihFiltre);
            panelFiltreler.Controls.Add(textBoxAciklamaFiltre);
            panelFiltreler.Controls.Add(textBoxProjeKodFiltre);
            panelFiltreler.Dock = System.Windows.Forms.DockStyle.Top;
            panelFiltreler.ForeColor = System.Drawing.SystemColors.ControlText;
            panelFiltreler.Location = new System.Drawing.Point(0, 56);
            panelFiltreler.Name = "panelFiltreler";
            panelFiltreler.Size = new System.Drawing.Size(1086, 52);
            panelFiltreler.TabIndex = 3;
            // 
            // textBoxMusteriFiltre
            // 
            textBoxMusteriFiltre.Location = new System.Drawing.Point(266, 26);
            textBoxMusteriFiltre.Name = "textBoxMusteriFiltre";
            textBoxMusteriFiltre.Size = new System.Drawing.Size(190, 23);
            textBoxMusteriFiltre.TabIndex = 12;
            // 
            // buttonSatisSiparisEkle
            // 
            buttonSatisSiparisEkle.BackColor = System.Drawing.Color.Silver;
            buttonSatisSiparisEkle.BackgroundImage = Properties.Resources.Plus_Symbol_PNG_Image_HD;
            buttonSatisSiparisEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonSatisSiparisEkle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonSatisSiparisEkle.ForeColor = System.Drawing.Color.Transparent;
            buttonSatisSiparisEkle.Location = new System.Drawing.Point(1024, 0);
            buttonSatisSiparisEkle.Name = "buttonSatisSiparisEkle";
            buttonSatisSiparisEkle.Size = new System.Drawing.Size(58, 52);
            buttonSatisSiparisEkle.TabIndex = 11;
            buttonSatisSiparisEkle.UseVisualStyleBackColor = false;
            buttonSatisSiparisEkle.Click += buttonSatisSiparisEkle_Click;
            // 
            // buttonTumKayitlariGetir
            // 
            buttonTumKayitlariGetir.BackColor = System.Drawing.Color.Tomato;
            buttonTumKayitlariGetir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonTumKayitlariGetir.ForeColor = System.Drawing.Color.Transparent;
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(830, 0);
            buttonTumKayitlariGetir.Name = "buttonTumKayitlariGetir";
            buttonTumKayitlariGetir.Size = new System.Drawing.Size(103, 52);
            buttonTumKayitlariGetir.TabIndex = 10;
            buttonTumKayitlariGetir.Text = "Tüm Kayıtları Getir";
            buttonTumKayitlariGetir.UseVisualStyleBackColor = false;
            buttonTumKayitlariGetir.Click += buttonTumKayitlariGetir_Click;
            // 
            // buttonFiltre
            // 
            buttonFiltre.BackgroundImage = Properties.Resources.DataReviewWithMagnifier5;
            buttonFiltre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            buttonFiltre.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonFiltre.ForeColor = System.Drawing.Color.Blue;
            buttonFiltre.Location = new System.Drawing.Point(717, 0);
            buttonFiltre.Name = "buttonFiltre";
            buttonFiltre.Size = new System.Drawing.Size(107, 52);
            buttonFiltre.TabIndex = 9;
            buttonFiltre.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            buttonFiltre.UseVisualStyleBackColor = true;
            // 
            // textBoxTarihFiltre
            // 
            textBoxTarihFiltre.Location = new System.Drawing.Point(163, 26);
            textBoxTarihFiltre.Name = "textBoxTarihFiltre";
            textBoxTarihFiltre.ReadOnly = true;
            textBoxTarihFiltre.Size = new System.Drawing.Size(97, 23);
            textBoxTarihFiltre.TabIndex = 6;
            // 
            // textBoxAciklamaFiltre
            // 
            textBoxAciklamaFiltre.Location = new System.Drawing.Point(462, 26);
            textBoxAciklamaFiltre.Name = "textBoxAciklamaFiltre";
            textBoxAciklamaFiltre.Size = new System.Drawing.Size(199, 23);
            textBoxAciklamaFiltre.TabIndex = 5;
            // 
            // textBoxProjeKodFiltre
            // 
            textBoxProjeKodFiltre.Location = new System.Drawing.Point(45, 26);
            textBoxProjeKodFiltre.Name = "textBoxProjeKodFiltre";
            textBoxProjeKodFiltre.Size = new System.Drawing.Size(115, 23);
            textBoxProjeKodFiltre.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { StokKartId, StokKartKodu, StokKartAdi, Boyut, MalzemeId, MalzemeKodu, Guncelle, Sil });
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(0, 108);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(1086, 532);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // StokKartId
            // 
            StokKartId.HeaderText = "StokKartId";
            StokKartId.Name = "StokKartId";
            StokKartId.ReadOnly = true;
            StokKartId.Visible = false;
            // 
            // StokKartKodu
            // 
            StokKartKodu.HeaderText = "Stok Kodu";
            StokKartKodu.Name = "StokKartKodu";
            StokKartKodu.ReadOnly = true;
            // 
            // StokKartAdi
            // 
            StokKartAdi.HeaderText = "Stok Adı";
            StokKartAdi.Name = "StokKartAdi";
            StokKartAdi.ReadOnly = true;
            // 
            // Boyut
            // 
            Boyut.HeaderText = "Boyut";
            Boyut.Name = "Boyut";
            Boyut.ReadOnly = true;
            // 
            // MalzemeId
            // 
            MalzemeId.HeaderText = "MalzemeId";
            MalzemeId.Name = "MalzemeId";
            MalzemeId.ReadOnly = true;
            MalzemeId.Visible = false;
            // 
            // MalzemeKodu
            // 
            MalzemeKodu.HeaderText = "Malzeme";
            MalzemeKodu.Name = "MalzemeKodu";
            MalzemeKodu.ReadOnly = true;
            // 
            // Guncelle
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "System.Drawing.Bitmap";
            Guncelle.DefaultCellStyle = dataGridViewCellStyle1;
            Guncelle.HeaderText = "Güncelle";
            Guncelle.Image = Properties.Resources.update_icon;
            Guncelle.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Guncelle.Name = "Guncelle";
            Guncelle.ReadOnly = true;
            Guncelle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Guncelle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            Guncelle.Width = 70;
            // 
            // Sil
            // 
            Sil.HeaderText = "Sil";
            Sil.Image = Properties.Resources.delete_icon;
            Sil.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Sil.Name = "Sil";
            Sil.ReadOnly = true;
            Sil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Sil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            Sil.Width = 50;
            // 
            // StokKartGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1086, 705);
            Controls.Add(dataGridView1);
            Controls.Add(panelFiltreler);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "StokKartGridForm";
            Text = "SatinalmaTalepGridForm";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFooter.ResumeLayout(false);
            panelFiltreler.ResumeLayout(false);
            panelFiltreler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelHeader;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.Panel panelFooter;
        private CustomControls.RoundedButton rButtonCikis;
        private System.Windows.Forms.Panel panelFiltreler;
        private System.Windows.Forms.TextBox textBoxMusteriFiltre;
        private System.Windows.Forms.Button buttonSatisSiparisEkle;
        private System.Windows.Forms.Button buttonTumKayitlariGetir;
        private System.Windows.Forms.Button buttonFiltre;
        private System.Windows.Forms.TextBox textBoxTarihFiltre;
        private System.Windows.Forms.TextBox textBoxAciklamaFiltre;
        private System.Windows.Forms.TextBox textBoxProjeKodFiltre;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokKartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokKartKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn StokKartAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Boyut;
        private System.Windows.Forms.DataGridViewTextBoxColumn MalzemeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MalzemeKodu;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}