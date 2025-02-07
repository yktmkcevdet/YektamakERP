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
            comboListBoxRol = new CustomControls.CustomComboListBox();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            menuEkle = new System.Windows.Forms.ToolStripMenuItem();
            menuSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panelHeader = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            buttonClose = new CustomControls.RoundedButton();
            buttonHelp = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            contextMenuStrip1.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.CheckBoxes = true;
            treeView1.Location = new System.Drawing.Point(37, 121);
            treeView1.Name = "treeView1";
            treeView1.Size = new System.Drawing.Size(277, 381);
            treeView1.TabIndex = 1;
            treeView1.AfterCheck += treeView1_AfterCheck;
            treeView1.MouseClick += treeView1_MouseClick;
            // 
            // comboListBoxRol
            // 
            comboListBoxRol.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboListBoxRol.ListBoxVisualSize = 5;
            comboListBoxRol.Location = new System.Drawing.Point(37, 81);
            comboListBoxRol.Margin = new System.Windows.Forms.Padding(1);
            comboListBoxRol.Name = "comboListBoxRol";
            comboListBoxRol.Padding = new System.Windows.Forms.Padding(1);
            comboListBoxRol.Size = new System.Drawing.Size(277, 36);
            comboListBoxRol.TabIndex = 52;
            comboListBoxRol.SelectedIndexChanged += comboListBoxRol_SelectedIndexChanged;
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
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Red;
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttonHelp);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(674, 54);
            panelHeader.TabIndex = 53;
            panelHeader.MouseClick += treeView1_MouseClick;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Red;
            label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            label1.Location = new System.Drawing.Point(19, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(157, 30);
            label1.TabIndex = 101;
            label1.Text = "Yetki Tanımları";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            buttonClose.Location = new System.Drawing.Point(627, 8);
            buttonClose.Margin = new System.Windows.Forms.Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonClose.Size = new System.Drawing.Size(40, 38);
            buttonClose.TabIndex = 100;
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
            buttonHelp.Location = new System.Drawing.Point(547, 8);
            buttonHelp.Margin = new System.Windows.Forms.Padding(0);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonHelp.Size = new System.Drawing.Size(40, 38);
            buttonHelp.TabIndex = 99;
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
            buttomMinimize.Location = new System.Drawing.Point(587, 8);
            buttomMinimize.Margin = new System.Windows.Forms.Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttomMinimize.Size = new System.Drawing.Size(40, 38);
            buttomMinimize.TabIndex = 98;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = System.Drawing.Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            buttomMinimize.Click += buttomMinimize_Click;
            // 
            // labelHeader
            // 
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            labelHeader.Location = new System.Drawing.Point(19, -13);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(0, 30);
            labelHeader.TabIndex = 0;
            // 
            // YetkiTanimlari
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(674, 612);
            Controls.Add(panelHeader);
            Controls.Add(comboListBoxRol);
            Controls.Add(treeView1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "YetkiTanimlari";
            Text = "YetkiTanimlari";
            contextMenuStrip1.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TreeView treeView1;
        private CustomControls.CustomComboListBox comboListBoxRol;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuEkle;
        private System.Windows.Forms.Panel panelHeader;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttonHelp;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem menuSilToolStripMenuItem;
    }
}