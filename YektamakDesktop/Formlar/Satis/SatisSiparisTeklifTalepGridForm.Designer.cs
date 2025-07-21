namespace YektamakDesktop.Formlar.Satis
{
    partial class SatisSiparisTeklifTalepGridForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SatisSiparisTeklifTalepGridForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            panelFilter = new System.Windows.Forms.Panel();
            buttonTumKayitlariGetir = new System.Windows.Forms.Button();
            dataGridView = new System.Windows.Forms.DataGridView();
            buttonSatisSiparisTeklifTalepEkle = new System.Windows.Forms.Button();
            panelFooter = new System.Windows.Forms.Panel();
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            roundedButton3 = new CustomControls.RoundedButton();
            label1 = new System.Windows.Forms.Label();
            roundedButton1 = new CustomControls.RoundedButton();
            roundedButton2 = new CustomControls.RoundedButton();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            maliyetTalep = new System.Windows.Forms.ToolStripMenuItem();
            maliyetFormuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            teklifTalepTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            firmaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            musteriAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            teklifKonusu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            marka_MarkaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            markaAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            AltGrup_altGrupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            altGrupAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            referansKaynak_referansKaynakId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            referansKaynakAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisSorumlusuId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            satisSorumlusuAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            maliyetSorumlusu_PersonelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            maliyetSorumlusu_PersonelAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Onay = new System.Windows.Forms.DataGridViewImageColumn();
            Guncelle = new System.Windows.Forms.DataGridViewImageColumn();
            Sil = new System.Windows.Forms.DataGridViewImageColumn();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panelHeader.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelFilter
            // 
            panelFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelFilter.BackColor = System.Drawing.Color.Transparent;
            panelFilter.Controls.Add(buttonTumKayitlariGetir);
            panelFilter.Controls.Add(dataGridView);
            panelFilter.Controls.Add(buttonSatisSiparisTeklifTalepEkle);
            panelFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            panelFilter.Location = new System.Drawing.Point(0, 33);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(1239, 656);
            panelFilter.TabIndex = 2;
            // 
            // buttonTumKayitlariGetir
            // 
            buttonTumKayitlariGetir.AutoSize = true;
            buttonTumKayitlariGetir.BackColor = System.Drawing.Color.Transparent;
            buttonTumKayitlariGetir.BackgroundImage = (System.Drawing.Image)resources.GetObject("buttonTumKayitlariGetir.BackgroundImage");
            buttonTumKayitlariGetir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            buttonTumKayitlariGetir.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonTumKayitlariGetir.FlatAppearance.BorderSize = 0;
            buttonTumKayitlariGetir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonTumKayitlariGetir.ForeColor = System.Drawing.SystemColors.Window;
            buttonTumKayitlariGetir.Location = new System.Drawing.Point(1054, 17);
            buttonTumKayitlariGetir.Margin = new System.Windows.Forms.Padding(0);
            buttonTumKayitlariGetir.Name = "buttonTumKayitlariGetir";
            buttonTumKayitlariGetir.Size = new System.Drawing.Size(45, 45);
            buttonTumKayitlariGetir.TabIndex = 13;
            buttonTumKayitlariGetir.UseVisualStyleBackColor = false;
            buttonTumKayitlariGetir.Click += buttonTumKayitlariGetir_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Id, teklifTalepTarihi, firmaId, musteriAd, teklifKonusu, marka_MarkaId, markaAd, AltGrup_altGrupId, altGrupAd, referansKaynak_referansKaynakId, referansKaynakAd, satisSorumlusuId, satisSorumlusuAd, maliyetSorumlusu_PersonelId, maliyetSorumlusu_PersonelAd, Onay, Guncelle, Sil });
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.Location = new System.Drawing.Point(0, 90);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new System.Drawing.Size(1239, 566);
            dataGridView.TabIndex = 3;
            dataGridView.CellClick += dataGridViewSatisSiparis_CellClick;
            dataGridView.CellMouseMove += dataGridView_CellMouseMove;
            dataGridView.ColumnWidthChanged += dataGridViewSatisSiparisTeklifTalep_ColumnWidthChanged;
            dataGridView.Scroll += dataGridViewSatisSiparisTeklifTalep_Scroll;
            dataGridView.MouseDown += dataGridView_MouseDown;
            // 
            // buttonSatisSiparisTeklifTalepEkle
            // 
            buttonSatisSiparisTeklifTalepEkle.BackColor = System.Drawing.Color.Transparent;
            buttonSatisSiparisTeklifTalepEkle.BackgroundImage = Properties.Resources.ekle45x45;
            buttonSatisSiparisTeklifTalepEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            buttonSatisSiparisTeklifTalepEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonSatisSiparisTeklifTalepEkle.FlatAppearance.BorderSize = 0;
            buttonSatisSiparisTeklifTalepEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonSatisSiparisTeklifTalepEkle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonSatisSiparisTeklifTalepEkle.ForeColor = System.Drawing.SystemColors.Window;
            buttonSatisSiparisTeklifTalepEkle.Location = new System.Drawing.Point(1123, 16);
            buttonSatisSiparisTeklifTalepEkle.Name = "buttonSatisSiparisTeklifTalepEkle";
            buttonSatisSiparisTeklifTalepEkle.Size = new System.Drawing.Size(45, 45);
            buttonSatisSiparisTeklifTalepEkle.TabIndex = 11;
            buttonSatisSiparisTeklifTalepEkle.UseVisualStyleBackColor = false;
            buttonSatisSiparisTeklifTalepEkle.Click += buttonSatisSiparisEkle_Click;
            // 
            // panelFooter
            // 
            panelFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            panelFooter.Location = new System.Drawing.Point(0, 692);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new System.Drawing.Size(1239, 65);
            panelFooter.TabIndex = 1;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Firebrick;
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(roundedButton3);
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(roundedButton1);
            panelHeader.Controls.Add(roundedButton2);
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1239, 32);
            panelHeader.TabIndex = 12;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonClose.BackColor = System.Drawing.Color.Firebrick;
            buttonClose.BackgroundColor = System.Drawing.Color.Firebrick;
            buttonClose.BorderColor = System.Drawing.Color.Firebrick;
            buttonClose.CornerRadius = 10;
            buttonClose.BorderSize = 2;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonClose.ForeColor = System.Drawing.Color.White;
            buttonClose.Location = new System.Drawing.Point(1202, 2);
            buttonClose.Margin = new System.Windows.Forms.Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonClose.Size = new System.Drawing.Size(29, 27);
            buttonClose.TabIndex = 103;
            buttonClose.Text = "X";
            buttonClose.TextColor = System.Drawing.Color.White;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttomMinimize
            // 
            buttomMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttomMinimize.BackColor = System.Drawing.Color.Firebrick;
            buttomMinimize.BackgroundColor = System.Drawing.Color.Firebrick;
            buttomMinimize.BorderColor = System.Drawing.Color.Firebrick;
            buttomMinimize.CornerRadius = 10;
            buttomMinimize.BorderSize = 2;
            buttomMinimize.FlatAppearance.BorderSize = 0;
            buttomMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttomMinimize.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttomMinimize.ForeColor = System.Drawing.Color.White;
            buttomMinimize.Location = new System.Drawing.Point(1162, 2);
            buttomMinimize.Margin = new System.Windows.Forms.Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttomMinimize.Size = new System.Drawing.Size(29, 27);
            buttomMinimize.TabIndex = 101;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = System.Drawing.Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            buttomMinimize.Click += buttomMinimize_Click;
            // 
            // buttonHelp
            // 
            buttonHelp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonHelp.BackColor = System.Drawing.Color.Firebrick;
            buttonHelp.BackgroundColor = System.Drawing.Color.Firebrick;
            buttonHelp.BorderColor = System.Drawing.Color.Firebrick;
            buttonHelp.CornerRadius = 10;
            buttonHelp.BorderSize = 2;
            buttonHelp.FlatAppearance.BorderSize = 0;
            buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonHelp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonHelp.ForeColor = System.Drawing.Color.White;
            buttonHelp.Location = new System.Drawing.Point(1123, 3);
            buttonHelp.Margin = new System.Windows.Forms.Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonHelp.Size = new System.Drawing.Size(29, 27);
            buttonHelp.TabIndex = 102;
            buttonHelp.Text = "?";
            buttonHelp.TextColor = System.Drawing.Color.White;
            buttonHelp.UseVisualStyleBackColor = false;
            // 
            // roundedButton3
            // 
            roundedButton3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton3.BackColor = System.Drawing.Color.Firebrick;
            roundedButton3.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton3.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton3.CornerRadius = 0;
            roundedButton3.BorderSize = 2;
            roundedButton3.FlatAppearance.BorderSize = 0;
            roundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton3.ForeColor = System.Drawing.Color.White;
            roundedButton3.Location = new System.Drawing.Point(2288, 1);
            roundedButton3.Margin = new System.Windows.Forms.Padding(0);
            roundedButton3.Name = "roundedButton3";
            roundedButton3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton3.Size = new System.Drawing.Size(29, 0);
            roundedButton3.TabIndex = 100;
            roundedButton3.Text = "X";
            roundedButton3.TextColor = System.Drawing.Color.White;
            roundedButton3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label1.Location = new System.Drawing.Point(12, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(177, 17);
            label1.TabIndex = 1;
            label1.Text = "Satış Sipariş Teklif Talepleri";
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            roundedButton1.BackColor = System.Drawing.Color.Firebrick;
            roundedButton1.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton1.CornerRadius = 0;
            roundedButton1.BorderSize = 2;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.Location = new System.Drawing.Point(2248, 1);
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
            roundedButton2.CornerRadius = 0;
            roundedButton2.BorderSize = 2;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton2.ForeColor = System.Drawing.Color.White;
            roundedButton2.Location = new System.Drawing.Point(2209, 2);
            roundedButton2.Margin = new System.Windows.Forms.Padding(0);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton2.Size = new System.Drawing.Size(29, 0);
            roundedButton2.TabIndex = 99;
            roundedButton2.Text = "?";
            roundedButton2.TextColor = System.Drawing.Color.White;
            roundedButton2.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { maliyetTalep, maliyetFormuToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(157, 48);
            // 
            // maliyetTalep
            // 
            maliyetTalep.Name = "maliyetTalep";
            maliyetTalep.Size = new System.Drawing.Size(156, 22);
            maliyetTalep.Text = "Maliyet için PM";
            maliyetTalep.Click += maliyetTalep_Click;
            // 
            // maliyetFormuToolStripMenuItem
            // 
            maliyetFormuToolStripMenuItem.Name = "maliyetFormuToolStripMenuItem";
            maliyetFormuToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            maliyetFormuToolStripMenuItem.Text = "Maliyet Formu";
            maliyetFormuToolStripMenuItem.Click += maliyetFormuToolStripMenuItem_Click;
            // 
            // Id
            // 
            Id.HeaderText = "teklifTalepId";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // teklifTalepTarihi
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            teklifTalepTarihi.DefaultCellStyle = dataGridViewCellStyle2;
            teklifTalepTarihi.HeaderText = "Teklif Talep Tarihi";
            teklifTalepTarihi.Name = "teklifTalepTarihi";
            teklifTalepTarihi.ReadOnly = true;
            // 
            // firmaId
            // 
            firmaId.HeaderText = "firmaId";
            firmaId.Name = "firmaId";
            firmaId.ReadOnly = true;
            firmaId.Visible = false;
            // 
            // musteriAd
            // 
            musteriAd.HeaderText = "Müşteri";
            musteriAd.Name = "musteriAd";
            musteriAd.ReadOnly = true;
            // 
            // teklifKonusu
            // 
            teklifKonusu.HeaderText = "Teklif Konusu";
            teklifKonusu.Name = "teklifKonusu";
            teklifKonusu.ReadOnly = true;
            // 
            // marka_MarkaId
            // 
            marka_MarkaId.HeaderText = "MarkaId";
            marka_MarkaId.Name = "marka_MarkaId";
            marka_MarkaId.ReadOnly = true;
            marka_MarkaId.Visible = false;
            // 
            // markaAd
            // 
            markaAd.HeaderText = "Marka";
            markaAd.Name = "markaAd";
            markaAd.ReadOnly = true;
            // 
            // AltGrup_altGrupId
            // 
            AltGrup_altGrupId.HeaderText = "altGrupId";
            AltGrup_altGrupId.Name = "AltGrup_altGrupId";
            AltGrup_altGrupId.ReadOnly = true;
            AltGrup_altGrupId.Visible = false;
            // 
            // altGrupAd
            // 
            altGrupAd.HeaderText = "Alt Grup";
            altGrupAd.Name = "altGrupAd";
            altGrupAd.ReadOnly = true;
            // 
            // referansKaynak_referansKaynakId
            // 
            referansKaynak_referansKaynakId.HeaderText = "referansKaynakId";
            referansKaynak_referansKaynakId.Name = "referansKaynak_referansKaynakId";
            referansKaynak_referansKaynakId.ReadOnly = true;
            referansKaynak_referansKaynakId.Visible = false;
            // 
            // referansKaynakAd
            // 
            referansKaynakAd.HeaderText = "Referans Kaynağı";
            referansKaynakAd.Name = "referansKaynakAd";
            referansKaynakAd.ReadOnly = true;
            // 
            // satisSorumlusuId
            // 
            satisSorumlusuId.HeaderText = "satisSorumluId";
            satisSorumlusuId.Name = "satisSorumlusuId";
            satisSorumlusuId.ReadOnly = true;
            satisSorumlusuId.Visible = false;
            // 
            // satisSorumlusuAd
            // 
            satisSorumlusuAd.HeaderText = "Satış Sorumlusu";
            satisSorumlusuAd.Name = "satisSorumlusuAd";
            satisSorumlusuAd.ReadOnly = true;
            // 
            // maliyetSorumlusu_PersonelId
            // 
            maliyetSorumlusu_PersonelId.HeaderText = "maliyetSorumlusu_PersonelId";
            maliyetSorumlusu_PersonelId.Name = "maliyetSorumlusu_PersonelId";
            maliyetSorumlusu_PersonelId.ReadOnly = true;
            maliyetSorumlusu_PersonelId.Visible = false;
            // 
            // maliyetSorumlusu_PersonelAd
            // 
            maliyetSorumlusu_PersonelAd.HeaderText = "Maliyet Sorumlusu";
            maliyetSorumlusu_PersonelAd.Name = "maliyetSorumlusu_PersonelAd";
            maliyetSorumlusu_PersonelAd.ReadOnly = true;
            // 
            // Onay
            // 
            Onay.HeaderText = "Onay";
            Onay.Image = (System.Drawing.Image)resources.GetObject("Onay.Image");
            Onay.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Onay.Name = "Onay";
            Onay.ReadOnly = true;
            Onay.Visible = false;
            Onay.Width = 50;
            // 
            // Guncelle
            // 
            Guncelle.HeaderText = "Guncelle";
            Guncelle.Image = Properties.Resources.data_update_icon1;
            Guncelle.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Guncelle.Name = "Guncelle";
            Guncelle.ReadOnly = true;
            Guncelle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Guncelle.Width = 50;
            // 
            // Sil
            // 
            Sil.HeaderText = "Sil";
            Sil.Image = Properties.Resources.sil1;
            Sil.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            Sil.Name = "Sil";
            Sil.ReadOnly = true;
            Sil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Sil.Width = 50;
            // 
            // SatisSiparisTeklifTalepGridForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1239, 755);
            Controls.Add(panelHeader);
            Controls.Add(panelFilter);
            Controls.Add(panelFooter);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatisSiparisTeklifTalepGridForm";
            Text = "PersonelGrid";
            Load += SatisSiparisTeklifTalepGridForm_Load;
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelFilter;
        public System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonSatisSiparisTeklifTalepEkle;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.Panel panel1;
        private CustomControls.RoundedButton roundedButton3;
        private System.Windows.Forms.Label label1;
        private CustomControls.RoundedButton roundedButton1;
        private CustomControls.RoundedButton roundedButton2;
        private CustomControls.RoundedButton roundedButton4;
        private CustomControls.RoundedButton roundedButton5;
        private CustomControls.RoundedButton buttonHelp;
        private System.Windows.Forms.Button buttonTumKayitlariGetir;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem maliyetTalep;
        private System.Windows.Forms.ToolStripMenuItem maliyetFormuToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn teklifTalepTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn firmaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn musteriAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn teklifKonusu;
        private System.Windows.Forms.DataGridViewTextBoxColumn marka_MarkaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn markaAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn AltGrup_altGrupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn altGrupAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn referansKaynak_referansKaynakId;
        private System.Windows.Forms.DataGridViewTextBoxColumn referansKaynakAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisSorumlusuId;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisSorumlusuAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn maliyetSorumlusu_PersonelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn maliyetSorumlusu_PersonelAd;
        private System.Windows.Forms.DataGridViewImageColumn Onay;
        private System.Windows.Forms.DataGridViewImageColumn Guncelle;
        private System.Windows.Forms.DataGridViewImageColumn Sil;
    }
}