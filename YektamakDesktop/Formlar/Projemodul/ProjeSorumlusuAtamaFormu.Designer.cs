namespace YektamakDesktop.Formlar.Projemodul
{
    partial class ProjeSorumlusuAtamaFormu
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
            fcbProje = new YektamakDesktop.CustomControls.FilterableComboBox();
            fcbPersonel = new YektamakDesktop.CustomControls.FilterableComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            customButtonSave1 = new YektamakDesktop.CustomControls.CustomButtonSave();
            universalGrid1 = new YektamakDesktop.CustomControls.UniversalGrid();
            ctbId = new YektamakDesktop.CustomControls.CustomTextBox();
            label3 = new System.Windows.Forms.Label();
            roundedButton1 = new YektamakDesktop.CustomControls.RoundedButton();
            SuspendLayout();
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.SteelBlue;
            headerPanel1.Location = new System.Drawing.Point(-1, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(485, 32);
            headerPanel1.TabIndex = 0;
            // 
            // fcbProje
            // 
            fcbProje.Location = new System.Drawing.Point(135, 100);
            fcbProje.Name = "fcbProje";
            fcbProje.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbProje.Size = new System.Drawing.Size(204, 29);
            fcbProje.TabIndex = 1;
            // 
            // fcbPersonel
            // 
            fcbPersonel.Location = new System.Drawing.Point(135, 135);
            fcbPersonel.Name = "fcbPersonel";
            fcbPersonel.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            fcbPersonel.Size = new System.Drawing.Size(204, 29);
            fcbPersonel.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(73, 105);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(34, 15);
            label1.TabIndex = 3;
            label1.Text = "Proje";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(73, 140);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(52, 15);
            label2.TabIndex = 4;
            label2.Text = "Personel";
            // 
            // customButtonSave1
            // 
            customButtonSave1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            customButtonSave1.BackColor = System.Drawing.Color.Transparent;
            customButtonSave1.Location = new System.Drawing.Point(266, 191);
            customButtonSave1.Name = "customButtonSave1";
            customButtonSave1.Size = new System.Drawing.Size(106, 46);
            customButtonSave1.TabIndex = 5;
            // 
            // universalGrid1
            // 
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(1, 243);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(482, 369);
            universalGrid1.TabIndex = 6;
            // 
            // ctbId
            // 
            ctbId.BackColor = System.Drawing.SystemColors.Window;
            ctbId.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ctbId.ForeColor = System.Drawing.Color.DimGray;
            ctbId.Location = new System.Drawing.Point(135, 66);
            ctbId.Name = "ctbId";
            ctbId.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            ctbId.Size = new System.Drawing.Size(110, 28);
            ctbId.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(73, 72);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(17, 15);
            label3.TabIndex = 8;
            label3.Text = "Id";
            // 
            // roundedButton1
            // 
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.Location = new System.Drawing.Point(23, 191);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new System.Drawing.Size(84, 40);
            roundedButton1.TabIndex = 9;
            roundedButton1.Text = "YENİ KAYIT";
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.Click += RoundedButton1_Click;
            // 
            // ProjeSorumlusuAtamaFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(484, 614);
            Controls.Add(roundedButton1);
            Controls.Add(label3);
            Controls.Add(ctbId);
            Controls.Add(universalGrid1);
            Controls.Add(customButtonSave1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(fcbPersonel);
            Controls.Add(fcbProje);
            Controls.Add(headerPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ProjeSorumlusuAtamaFormu";
            Text = "ProjeSorumlusuAtamaFormu";
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private CustomControls.HeaderPanel headerPanel1;
        private CustomControls.FilterableComboBox fcbProje;
        private CustomControls.FilterableComboBox fcbPersonel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomControls.CustomButtonSave customButtonSave1;
        private CustomControls.UniversalGrid universalGrid1;
        private CustomControls.CustomTextBox ctbId;
        private System.Windows.Forms.Label label3;
        private CustomControls.RoundedButton roundedButton1;
    }
}