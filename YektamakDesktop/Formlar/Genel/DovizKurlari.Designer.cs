namespace YektamakDesktop.Formlar.Genel
{
    partial class DovizKurlari
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
            roundedButton1 = new CustomControls.RoundedButton();
            SuspendLayout();
            // 
            // roundedButton1
            // 
            roundedButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            roundedButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            roundedButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            roundedButton1.BorderRadius = 8;
            roundedButton1.BorderSize = 0;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.Location = new System.Drawing.Point(111, 321);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new System.Drawing.Size(110, 80);
            roundedButton1.TabIndex = 0;
            roundedButton1.Text = "roundedButton1";
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = false;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // DovizKurlari
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(roundedButton1);
            Name = "DovizKurlari";
            Text = "DovizKurlari";
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.RoundedButton roundedButton1;
    }
}