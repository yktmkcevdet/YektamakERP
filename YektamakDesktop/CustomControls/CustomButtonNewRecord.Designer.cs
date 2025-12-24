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
            ıconButton1 = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // ıconButton1
            // 
            ıconButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ıconButton1.BackColor = System.Drawing.Color.MediumTurquoise;
            ıconButton1.FlatAppearance.BorderSize = 0;
            ıconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ıconButton1.IconChar = FontAwesome.Sharp.IconChar.Asterisk;
            ıconButton1.IconColor = System.Drawing.Color.Yellow;
            ıconButton1.IconFont = FontAwesome.Sharp.IconFont.Brands;
            ıconButton1.IconSize = 24;
            ıconButton1.Location = new System.Drawing.Point(0, 0);
            ıconButton1.Margin = new System.Windows.Forms.Padding(0);
            ıconButton1.Name = "ıconButton1";
            ıconButton1.Size = new System.Drawing.Size(36, 36);
            ıconButton1.TabIndex = 1;
            ıconButton1.UseVisualStyleBackColor = false;
            // 
            // CustomButtonNewRecord
            // 
            Controls.Add(ıconButton1);
            Cursor = System.Windows.Forms.Cursors.Hand;
            ForeColor = System.Drawing.Color.White;
            Margin = new System.Windows.Forms.Padding(0);
            Name = "CustomButtonNewRecord";
            Size = new System.Drawing.Size(36, 36);
            ResumeLayout(false);
        }

        #endregion
        private FontAwesome.Sharp.IconButton ıconButton1;
    }
}
