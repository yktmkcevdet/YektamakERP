namespace YektamakDesktop.Formlar.Projemodul
{
    partial class ProjeDosyaAgacStil
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
            treeView1 = new System.Windows.Forms.TreeView();
            fcbProjeKod = new YektamakDesktop.CustomControls.FilterableComboBox();
            roundedButton1 = new YektamakDesktop.CustomControls.RoundedButton();
            roundedButton2 = new YektamakDesktop.CustomControls.RoundedButton();
            ctbParcaKodu = new YektamakDesktop.CustomControls.CustomTextBox();
            panel1 = new System.Windows.Forms.Panel();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            tabPage2 = new System.Windows.Forms.TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Baslik = "Proje Dosyaları";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(1324, 25);
            headerPanel1.TabIndex = 0;
            // 
            // treeView1
            // 
            treeView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            treeView1.CheckBoxes = true;
            treeView1.Location = new System.Drawing.Point(36, 83);
            treeView1.Name = "treeView1";
            treeView1.Size = new System.Drawing.Size(306, 607);
            treeView1.TabIndex = 1;
            treeView1.AfterCheck += treeView1_AfterCheck;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            // 
            // fcbProjeKod
            // 
            fcbProjeKod.BorderColor = System.Drawing.Color.Silver;
            fcbProjeKod.BorderRadius = 8;
            fcbProjeKod.BorderSize = 1;
            fcbProjeKod.DisplayMember = "kod";
            fcbProjeKod.Font = new System.Drawing.Font("Segoe UI", 8F);
            fcbProjeKod.Location = new System.Drawing.Point(36, 48);
            fcbProjeKod.Margin = new System.Windows.Forms.Padding(1);
            fcbProjeKod.Name = "fcbProjeKod";
            fcbProjeKod.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbProjeKod.PlaceholderText = "Proje Kodu ";
            fcbProjeKod.ReadOnly = false;
            fcbProjeKod.Size = new System.Drawing.Size(129, 25);
            fcbProjeKod.TabIndex = 2;
            fcbProjeKod.ValueMember = "Id";
            fcbProjeKod.SelectedIndexChanged += fcbProjeKod_SelectedIndexChanged;
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            roundedButton1.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderColor = System.Drawing.Color.Black;
            roundedButton1.BorderSize = 0;
            roundedButton1.CornerRadius = 10;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.GradientColor1 = System.Drawing.Color.DodgerBlue;
            roundedButton1.GradientColor2 = System.Drawing.Color.MidnightBlue;
            roundedButton1.HoverColor1 = System.Drawing.Color.RoyalBlue;
            roundedButton1.HoverColor2 = System.Drawing.Color.Navy;
            roundedButton1.Icon = null;
            roundedButton1.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            roundedButton1.Location = new System.Drawing.Point(36, 710);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new System.Drawing.Size(150, 40);
            roundedButton1.TabIndex = 3;
            roundedButton1.Text = "Teknik Resimler(PDF)";
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // roundedButton2
            // 
            roundedButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            roundedButton2.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton2.BorderColor = System.Drawing.Color.Black;
            roundedButton2.BorderSize = 0;
            roundedButton2.CornerRadius = 10;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton2.ForeColor = System.Drawing.Color.White;
            roundedButton2.GradientColor1 = System.Drawing.Color.DodgerBlue;
            roundedButton2.GradientColor2 = System.Drawing.Color.MidnightBlue;
            roundedButton2.HoverColor1 = System.Drawing.Color.RoyalBlue;
            roundedButton2.HoverColor2 = System.Drawing.Color.Navy;
            roundedButton2.Icon = null;
            roundedButton2.IconAlign = System.Drawing.ContentAlignment.MiddleLeft;
            roundedButton2.Location = new System.Drawing.Point(192, 710);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Size = new System.Drawing.Size(150, 40);
            roundedButton2.TabIndex = 4;
            roundedButton2.Text = "Dosyalar Oluştur";
            roundedButton2.TextColor = System.Drawing.Color.White;
            roundedButton2.UseVisualStyleBackColor = true;
            roundedButton2.Click += roundedButton2_Click;
            // 
            // ctbParcaKodu
            // 
            ctbParcaKodu.BackColor = System.Drawing.Color.White;
            ctbParcaKodu.BorderColor = System.Drawing.Color.Silver;
            ctbParcaKodu.BorderFocusColor = System.Drawing.Color.HotPink;
            ctbParcaKodu.BorderSize = 1;
            ctbParcaKodu.Font = new System.Drawing.Font("Segoe UI", 8F);
            ctbParcaKodu.ForeColor = System.Drawing.Color.Black;
            ctbParcaKodu.Location = new System.Drawing.Point(167, 48);
            ctbParcaKodu.Margin = new System.Windows.Forms.Padding(1);
            ctbParcaKodu.Multiline = false;
            ctbParcaKodu.Name = "ctbParcaKodu";
            ctbParcaKodu.Padding = new System.Windows.Forms.Padding(3);
            ctbParcaKodu.PasswordChar = false;
            ctbParcaKodu.PlaceholderColor = System.Drawing.Color.DarkGray;
            ctbParcaKodu.PlaceholderText = "Parça Kodu İle Ara";
            ctbParcaKodu.ReadOnly = false;
            ctbParcaKodu.SelectionStart = 0;
            ctbParcaKodu.Size = new System.Drawing.Size(175, 25);
            ctbParcaKodu.TabIndex = 5;
            ctbParcaKodu.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            ctbParcaKodu.TextCustom = "";
            ctbParcaKodu.UnderlinedStyle = false;
            ctbParcaKodu.KeyDown += ctbParcaKodu_KeyDown;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.BackColor = System.Drawing.Color.White;
            panel1.Location = new System.Drawing.Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(962, 668);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            panel1.MouseClick += panel1_MouseClick;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new System.Drawing.Point(348, 48);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(976, 702);
            tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button1);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(968, 674);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Pdf";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button2.Location = new System.Drawing.Point(926, 627);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(20, 23);
            button2.TabIndex = 1;
            button2.Text = "✗";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(899, 628);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(21, 23);
            button1.TabIndex = 0;
            button1.Text = "✓";
            button1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel1);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(968, 674);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Dxf";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // ProjeDosyaAgacStil
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1323, 782);
            Controls.Add(tabControl1);
            Controls.Add(ctbParcaKodu);
            Controls.Add(roundedButton2);
            Controls.Add(roundedButton1);
            Controls.Add(fcbProjeKod);
            Controls.Add(treeView1);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ProjeDosyaAgacStil";
            Text = "ProjeDosyaAgacStil";
            KeyDown += ProjeDosyaAgacStil_KeyDown;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public CustomControls.HeaderPanel headerPanel1;
        private System.Windows.Forms.TreeView treeView1;
        private CustomControls.FilterableComboBox fcbProjeKod;
        private CustomControls.RoundedButton roundedButton1;
        private CustomControls.RoundedButton roundedButton2;
        private CustomControls.CustomTextBox ctbParcaKodu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}