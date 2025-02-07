namespace YektamakDesktop.Formlar.Temp
{
    partial class SatisSafhaGridForm
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
            panelHeader = new System.Windows.Forms.Panel();
            labelHeader = new System.Windows.Forms.Label();
            panelFiltreler = new System.Windows.Forms.Panel();
            panelFooter = new System.Windows.Forms.Panel();
            rButtonCikis = new CustomControls.RoundedButton();
            dataGridViewFirma = new System.Windows.Forms.DataGridView();
            buttonKayitEkle = new CustomControls.RoundedIconButton();
            buttonTumKayitlariGetir = new CustomControls.RoundedIconButton();
            buttonFiltre = new CustomControls.RoundedIconButton();
            firmaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Unvan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            VergiDairesi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Sehir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Sektor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            panelHeader.SuspendLayout();
            panelFiltreler.SuspendLayout();
            panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFirma).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Red;
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
            // labelHeader
            // 
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.BackColor = System.Drawing.Color.Red;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(33, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(155, 30);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Firma Kayıtları";
            labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFiltreler
            // 
            panelFiltreler.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelFiltreler.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelFiltreler.BackColor = System.Drawing.Color.Silver;
            panelFiltreler.Controls.Add(dataGridViewFirma);
            panelFiltreler.Controls.Add(buttonKayitEkle);
            panelFiltreler.Controls.Add(buttonTumKayitlariGetir);
            panelFiltreler.Controls.Add(buttonFiltre);
            panelFiltreler.ForeColor = System.Drawing.SystemColors.ControlText;
            panelFiltreler.Location = new System.Drawing.Point(0, 53);
            panelFiltreler.Name = "panelFiltreler";
            panelFiltreler.Size = new System.Drawing.Size(1085, 639);
            panelFiltreler.TabIndex = 2;
            // 
            // panelFooter
            // 
            panelFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            panelFooter.Controls.Add(rButtonCikis);
            panelFooter.Location = new System.Drawing.Point(0, 692);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1085, 65);
            panelFooter.TabIndex = 1;
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
            // dataGridViewFirma
            // 
            dataGridViewFirma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFirma.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { firmaId, Unvan, VergiDairesi, Sehir, Sektor, Guncelle, Sil });
            dataGridViewFirma.Location = new System.Drawing.Point(0, 111);
            dataGridViewFirma.Name = "dataGridViewFirma";
            dataGridViewFirma.RowTemplate.Height = 25;
            dataGridViewFirma.Size = new System.Drawing.Size(1085, 528);
            dataGridViewFirma.TabIndex = 3;
            dataGridViewFirma.CellClick += dataGridViewFirma_CellClick;
            dataGridViewFirma.CellPainting += dataGridViewFirma_CellPainting;
            // 
            // buttonKayitEkle
            // 
            buttonKayitEkle.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            buttonKayitEkle.CornerRadius = 15;
            buttonKayitEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonKayitEkle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonKayitEkle.ForeColor = System.Drawing.Color.Gainsboro;
            buttonKayitEkle.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            buttonKayitEkle.IconColor = System.Drawing.Color.Gainsboro;
            buttonKayitEkle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonKayitEkle.IconSize = 25;
            buttonKayitEkle.Location = new System.Drawing.Point(980, 3);
            buttonKayitEkle.Name = "buttonKayitEkle";
            buttonKayitEkle.Size = new System.Drawing.Size(93, 46);
            buttonKayitEkle.TabIndex = 21;
            buttonKayitEkle.Text = "Kayıt Ekle";
            buttonKayitEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonKayitEkle.UseVisualStyleBackColor = false;
            // 
            // buttonTumKayitlariGetir
            // 
            buttonTumKayitlariGetir.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            buttonTumKayitlariGetir.CornerRadius = 15;
            buttonTumKayitlariGetir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonTumKayitlariGetir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonTumKayitlariGetir.ForeColor = System.Drawing.Color.Gainsboro;
            buttonTumKayitlariGetir.IconChar = FontAwesome.Sharp.IconChar.FilterCircleXmark;
            buttonTumKayitlariGetir.IconColor = System.Drawing.Color.Gainsboro;
            buttonTumKayitlariGetir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonTumKayitlariGetir.IconSize = 25;
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(876, 3);
            buttonTumKayitlariGetir.Name = "buttonTumKayitlariGetir";
            buttonTumKayitlariGetir.Size = new System.Drawing.Size(93, 46);
            buttonTumKayitlariGetir.TabIndex = 20;
            buttonTumKayitlariGetir.Text = "Tüm Kayıtlar";
            buttonTumKayitlariGetir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonTumKayitlariGetir.UseVisualStyleBackColor = false;
            // 
            // buttonFiltre
            // 
            buttonFiltre.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            buttonFiltre.CornerRadius = 15;
            buttonFiltre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonFiltre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonFiltre.ForeColor = System.Drawing.Color.Gainsboro;
            buttonFiltre.IconChar = FontAwesome.Sharp.IconChar.Filter;
            buttonFiltre.IconColor = System.Drawing.Color.Gainsboro;
            buttonFiltre.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonFiltre.IconSize = 25;
            buttonFiltre.Location = new System.Drawing.Point(788, 3);
            buttonFiltre.Name = "buttonFiltre";
            buttonFiltre.Size = new System.Drawing.Size(82, 46);
            buttonFiltre.TabIndex = 19;
            buttonFiltre.Text = "Filtrele";
            buttonFiltre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            buttonFiltre.UseVisualStyleBackColor = false;
            // 
            // firmaId
            // 
            firmaId.HeaderText = "firmaId";
            firmaId.Name = "firmaId";
            firmaId.ReadOnly = true;
            firmaId.Visible = false;
            // 
            // Unvan
            // 
            Unvan.HeaderText = "Ünvan";
            Unvan.Name = "Unvan";
            Unvan.ReadOnly = true;
            Unvan.Width = 200;
            // 
            // VergiDairesi
            // 
            VergiDairesi.HeaderText = "Vergi Dairesi";
            VergiDairesi.Name = "VergiDairesi";
            VergiDairesi.ReadOnly = true;
            // 
            // Sehir
            // 
            Sehir.HeaderText = "Şehir";
            Sehir.Name = "Sehir";
            Sehir.ReadOnly = true;
            // 
            // Sektor
            // 
            Sektor.HeaderText = "Faaliyet Alan(lar)ı";
            Sektor.Name = "Sektor";
            Sektor.ReadOnly = true;
            Sektor.Width = 300;
            // 
            // Guncelle
            // 
            Guncelle.HeaderText = "Güncelle";
            Guncelle.Image = Properties.Resources.update_icon;
            Guncelle.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Guncelle.Name = "Guncelle";
            Guncelle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Guncelle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            Guncelle.Width = 60;
            // 
            // Sil
            // 
            Sil.HeaderText = "Sil";
            Sil.Image = Properties.Resources.delete_icon;
            Sil.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Sil.Name = "Sil";
            Sil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Sil.Width = 30;
            // 
            // SatisSafhaGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1085, 755);
            Controls.Add(panelFiltreler);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatisSafhaGridForm";
            Text = "PersonelGrid";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFiltreler.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewFirma).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private CustomControls.RoundedButton rButtonCikis;
        private System.Windows.Forms.Panel panelFiltreler;
        public System.Windows.Forms.DataGridView dataGridViewFirma;
        private System.Windows.Forms.DataGridViewTextBoxColumn firmaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unvan;
        private System.Windows.Forms.DataGridViewTextBoxColumn VergiDairesi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sehir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sektor;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
        private CustomControls.RoundedIconButton buttonKayitEkle;
        private CustomControls.RoundedIconButton buttonTumKayitlariGetir;
        private CustomControls.RoundedIconButton buttonFiltre;
    }
}