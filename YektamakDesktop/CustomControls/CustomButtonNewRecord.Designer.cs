namespace YektamakDesktop.CustomControls
{
    partial class CustomButtonNewRecord
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            roundedIconButton1 = new RoundedIconButton();
            SuspendLayout();
            // 
            // roundedIconButton1
            // 
            roundedIconButton1.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            roundedIconButton1.FlatAppearance.BorderSize = 0;
            roundedIconButton1.CornerRadius = 6;
            roundedIconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedIconButton1.ForeColor = System.Drawing.Color.FromArgb(255, 255, 192);
            roundedIconButton1.IconChar = FontAwesome.Sharp.IconChar.StarOfLife;
            roundedIconButton1.IconColor = System.Drawing.Color.Green;
            roundedIconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            roundedIconButton1.IconSize = 24;
            roundedIconButton1.Location = new System.Drawing.Point(0, 0);
            roundedIconButton1.Name = "roundedIconButton1";
            roundedIconButton1.Size = new System.Drawing.Size(36, 36);
            roundedIconButton1.TabIndex = 0;
            roundedIconButton1.UseVisualStyleBackColor = false;
            // 
            // CustomButtonNewRecord
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(roundedIconButton1);
            Name = "CustomButtonNewRecord";
            Size = new System.Drawing.Size(36, 36);
            Load += CustomButtonNewRecord_Load;
            ResumeLayout(false);
        }

        #endregion

        private RoundedIconButton roundedIconButton1;
    }
}
