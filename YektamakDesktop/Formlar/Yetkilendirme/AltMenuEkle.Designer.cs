namespace YektamakDesktop.Formlar.Yetkilendirme
{
    partial class AltMenuEkleForm
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
            labelUyariAnaMenu = new System.Windows.Forms.Label();
            labelUyariFormAdi = new System.Windows.Forms.Label();
            labelUyariMenuAdi = new System.Windows.Forms.Label();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            clbAnaMenu = new YektamakDesktop.CustomControls.CustomComboListBox();
            label2 = new System.Windows.Forms.Label();
            clbForm = new YektamakDesktop.CustomControls.CustomComboListBox();
            label1 = new System.Windows.Forms.Label();
            rButtonKaydet = new YektamakDesktop.CustomControls.CustomButtonSave();
            SuspendLayout();
            // 
            // labelUyariAnaMenu
            // 
            labelUyariAnaMenu.AutoSize = true;
            labelUyariAnaMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariAnaMenu.ForeColor = System.Drawing.Color.Red;
            labelUyariAnaMenu.Location = new System.Drawing.Point(482, 93);
            labelUyariAnaMenu.Name = "labelUyariAnaMenu";
            labelUyariAnaMenu.Size = new System.Drawing.Size(0, 15);
            labelUyariAnaMenu.TabIndex = 91;
            // 
            // labelUyariFormAdi
            // 
            labelUyariFormAdi.AutoSize = true;
            labelUyariFormAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariFormAdi.ForeColor = System.Drawing.Color.Red;
            labelUyariFormAdi.Location = new System.Drawing.Point(482, 135);
            labelUyariFormAdi.Name = "labelUyariFormAdi";
            labelUyariFormAdi.Size = new System.Drawing.Size(0, 15);
            labelUyariFormAdi.TabIndex = 92;
            // 
            // labelUyariMenuAdi
            // 
            labelUyariMenuAdi.AutoSize = true;
            labelUyariMenuAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUyariMenuAdi.ForeColor = System.Drawing.Color.Red;
            labelUyariMenuAdi.Location = new System.Drawing.Point(482, 172);
            labelUyariMenuAdi.Name = "labelUyariMenuAdi";
            labelUyariMenuAdi.Size = new System.Drawing.Size(0, 15);
            labelUyariMenuAdi.TabIndex = 93;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "Menu Tanımla";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(412, 32);
            headerPanel1.TabIndex = 94;
            // 
            // clbAnaMenu
            // 
            clbAnaMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbAnaMenu.ListBoxVisualSize = 5;
            clbAnaMenu.Location = new System.Drawing.Point(114, 68);
            clbAnaMenu.Margin = new System.Windows.Forms.Padding(1);
            clbAnaMenu.Name = "clbAnaMenu";
            clbAnaMenu.Padding = new System.Windows.Forms.Padding(1);
            clbAnaMenu.selectedDataRowId = null;
            clbAnaMenu.selectedDataRowValue = null;
            clbAnaMenu.Size = new System.Drawing.Size(250, 36);
            clbAnaMenu.TabIndex = 95;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(27, 73);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(58, 15);
            label2.TabIndex = 96;
            label2.Text = "Üst Menü";
            // 
            // clbForm
            // 
            clbForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clbForm.ListBoxVisualSize = 5;
            clbForm.Location = new System.Drawing.Point(114, 108);
            clbForm.Margin = new System.Windows.Forms.Padding(1);
            clbForm.Name = "clbForm";
            clbForm.Padding = new System.Windows.Forms.Padding(1);
            clbForm.selectedDataRowId = null;
            clbForm.selectedDataRowValue = null;
            clbForm.Size = new System.Drawing.Size(250, 36);
            clbForm.TabIndex = 97;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(27, 117);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 15);
            label1.TabIndex = 98;
            label1.Text = "Form";
            // 
            // rButtonKaydet
            // 
            rButtonKaydet.BackColor = System.Drawing.Color.Transparent;
            rButtonKaydet.Location = new System.Drawing.Point(258, 194);
            rButtonKaydet.Name = "rButtonKaydet";
            rButtonKaydet.Size = new System.Drawing.Size(106, 46);
            rButtonKaydet.TabIndex = 101;
            rButtonKaydet.SaveButtonClick += rButtonKaydet_Click;
            // 
            // AltMenuEkleForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(412, 250);
            Controls.Add(rButtonKaydet);
            Controls.Add(label1);
            Controls.Add(clbForm);
            Controls.Add(label2);
            Controls.Add(clbAnaMenu);
            Controls.Add(headerPanel1);
            Controls.Add(labelUyariMenuAdi);
            Controls.Add(labelUyariFormAdi);
            Controls.Add(labelUyariAnaMenu);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "AltMenuEkleForm";
            Text = "AltMenuEkle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label labelUyariAnaMenu;
        private System.Windows.Forms.Label labelUyariFormAdi;
        private System.Windows.Forms.Label labelUyariMenuAdi;
        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.CustomComboListBox clbAnaMenu;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomComboListBox clbForm;
        private System.Windows.Forms.Label label1;
        private CustomControls.CustomButtonSave rButtonKaydet;
    }
}