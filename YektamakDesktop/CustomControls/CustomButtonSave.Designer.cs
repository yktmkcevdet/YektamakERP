namespace YektamakDesktop.CustomControls
{
    partial class CustomButtonSave
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
            ıconButton1.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
            ıconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            ıconButton1.FlatAppearance.BorderSize = 0;
            ıconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ıconButton1.IconChar = FontAwesome.Sharp.IconChar.Save;
            ıconButton1.IconColor = System.Drawing.Color.White;
            ıconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconButton1.IconSize = 36;
            ıconButton1.Location = new System.Drawing.Point(0, 0);
            ıconButton1.Margin = new System.Windows.Forms.Padding(0);
            ıconButton1.Name = "ıconButton1";
            ıconButton1.Size = new System.Drawing.Size(36, 36);
            ıconButton1.TabIndex = 0;
            ıconButton1.UseVisualStyleBackColor = false;
            ıconButton1.Click += roundedIconButton1_Click;
            // 
            // CustomButtonSave
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(ıconButton1);
            Name = "CustomButtonSave";
            Size = new System.Drawing.Size(36, 36);
            Load += CustomButtonSave_Load;
            Click += roundedIconButton1_Click;
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconButton ıconButton1;
    }
}
