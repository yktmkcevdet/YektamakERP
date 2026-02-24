namespace YektamakDesktop.Formlar.Yetkilendirme
{
    partial class YetkiTanimlari
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
            treeView1 = new System.Windows.Forms.TreeView();
            comboListBoxRol = new YektamakDesktop.CustomControls.FilterableComboBox();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            menuEkle = new System.Windows.Forms.ToolStripMenuItem();
            menuSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            cbxKullanici = new YektamakDesktop.CustomControls.FilterableComboBox();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
            menuChangeAuth = new System.Windows.Forms.ToolStripMenuItem();
            alanEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            yetkileriSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.CheckBoxes = true;
            treeView1.Location = new System.Drawing.Point(37, 121);
            treeView1.Name = "treeView1";
            treeView1.Size = new System.Drawing.Size(277, 381);
            treeView1.TabIndex = 1;
            treeView1.MouseClick += treeView1_MouseClick;
            // 
            // comboListBoxRol
            // 
            comboListBoxRol.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboListBoxRol.BorderColor = System.Drawing.Color.Silver;
            comboListBoxRol.BorderRadius = 8;
            comboListBoxRol.BorderSize = 1;
            comboListBoxRol.DisplayMember = "ad";
            comboListBoxRol.Font = new System.Drawing.Font("Segoe UI", 8F);
            comboListBoxRol.Location = new System.Drawing.Point(37, 92);
            comboListBoxRol.Margin = new System.Windows.Forms.Padding(1);
            comboListBoxRol.Name = "comboListBoxRol";
            comboListBoxRol.Padding = new System.Windows.Forms.Padding(1);
            comboListBoxRol.PlaceholderText = "Seçiniz...";
            comboListBoxRol.ReadOnly = false;
            comboListBoxRol.Size = new System.Drawing.Size(237, 25);
            comboListBoxRol.TabIndex = 52;
            comboListBoxRol.ValueMember = "Id";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { menuEkle, menuSilToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(164, 48);
            // 
            // menuEkle
            // 
            menuEkle.Name = "menuEkle";
            menuEkle.Size = new System.Drawing.Size(163, 22);
            menuEkle.Text = "Altına Menü Ekle";
            menuEkle.Click += menuEkle_Click;
            // 
            // menuSilToolStripMenuItem
            // 
            menuSilToolStripMenuItem.Name = "menuSilToolStripMenuItem";
            menuSilToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            menuSilToolStripMenuItem.Text = "Menu Sil";
            menuSilToolStripMenuItem.Click += menuSilToolStripMenuItem_Click;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Kullanıcı ve Rol Yetki Tanımları";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(795, 25);
            headerPanel1.TabIndex = 53;
            // 
            // cbxKullanici
            // 
            cbxKullanici.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cbxKullanici.BorderColor = System.Drawing.Color.Silver;
            cbxKullanici.BorderRadius = 8;
            cbxKullanici.BorderSize = 1;
            cbxKullanici.DisplayMember = "ad";
            cbxKullanici.Font = new System.Drawing.Font("Segoe UI", 8F);
            cbxKullanici.Location = new System.Drawing.Point(355, 96);
            cbxKullanici.Margin = new System.Windows.Forms.Padding(1);
            cbxKullanici.Name = "cbxKullanici";
            cbxKullanici.Padding = new System.Windows.Forms.Padding(1);
            cbxKullanici.PlaceholderText = "Seçiniz...";
            cbxKullanici.ReadOnly = false;
            cbxKullanici.Size = new System.Drawing.Size(214, 25);
            cbxKullanici.TabIndex = 55;
            cbxKullanici.ValueMember = "Id";
            cbxKullanici.SelectedIndexChanged += cbxKullanici_SelectedIndexChanged;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { menuChangeAuth, alanEkleToolStripMenuItem, yetkileriSilToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new System.Drawing.Size(143, 70);
            // 
            // menuChangeAuth
            // 
            menuChangeAuth.Name = "menuChangeAuth";
            menuChangeAuth.Size = new System.Drawing.Size(142, 22);
            menuChangeAuth.Text = "Yetki Değiştir";
            menuChangeAuth.Click += menuChangeAuth_Click;
            // 
            // alanEkleToolStripMenuItem
            // 
            alanEkleToolStripMenuItem.Name = "alanEkleToolStripMenuItem";
            alanEkleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            alanEkleToolStripMenuItem.Text = "Alan Ekle";
            alanEkleToolStripMenuItem.Click += alanEkleToolStripMenuItem_Click;
            // 
            // yetkileriSilToolStripMenuItem
            // 
            yetkileriSilToolStripMenuItem.Name = "yetkileriSilToolStripMenuItem";
            yetkileriSilToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            yetkileriSilToolStripMenuItem.Text = "Yetkileri Sil";
            yetkileriSilToolStripMenuItem.Click += yetkileriSilToolStripMenuItem_Click;
            // 
            // universalGrid1
            // 
            universalGrid1.Location = new System.Drawing.Point(355, 125);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(428, 421);
            universalGrid1.TabIndex = 56;
            // 
            // YetkiTanimlari
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(795, 612);
            Controls.Add(universalGrid1);
            Controls.Add(cbxKullanici);
            Controls.Add(headerPanel1);
            Controls.Add(comboListBoxRol);
            Controls.Add(treeView1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "YetkiTanimlari";
            Text = "YetkiTanimlari";
            FormClosing += YetkiTanimlari_FormClosing;
            Load += YetkiTanimlari_Load;
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TreeView treeView1;
        private CustomControls.FilterableComboBox comboListBoxRol;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuEkle;
        private System.Windows.Forms.ToolStripMenuItem menuSilToolStripMenuItem;
        public CustomControls.HeaderPanel headerPanel1;
        private CustomControls.FilterableComboBox cbxKullanici;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem menuChangeAuth;
        private System.Windows.Forms.ToolStripMenuItem alanEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yetkileriSilToolStripMenuItem;
        private CustomControls.UniversalGrid universalGrid1;
    }
}