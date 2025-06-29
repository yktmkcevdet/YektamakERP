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
            roundedIconButton1 = new RoundedIconButton();
            SuspendLayout();
            // 
            // roundedIconButton1
            // 
            roundedIconButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            roundedIconButton1.AutoSize = true;
            roundedIconButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            roundedIconButton1.BackColor = System.Drawing.Color.Cyan;
            roundedIconButton1.CornerRadius = 20;
            roundedIconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            roundedIconButton1.FlatAppearance.BorderSize = 0;
            roundedIconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            roundedIconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedIconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            roundedIconButton1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedIconButton1.ForeColor = System.Drawing.Color.Purple;
            roundedIconButton1.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            roundedIconButton1.IconColor = System.Drawing.Color.Purple;
            roundedIconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            roundedIconButton1.IconSize = 40;
            roundedIconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            roundedIconButton1.Location = new System.Drawing.Point(0, -1);
            roundedIconButton1.Name = "roundedIconButton1";
            roundedIconButton1.Size = new System.Drawing.Size(104, 46);
            roundedIconButton1.TabIndex = 0;
            roundedIconButton1.Text = "KAYDET";
            roundedIconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            roundedIconButton1.UseVisualStyleBackColor = false;
            roundedIconButton1.Click += roundedIconButton1_Click;
            // 
            // CustomButtonSave
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(roundedIconButton1);
            Name = "CustomButtonSave";
            Size = new System.Drawing.Size(106, 46);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundedIconButton roundedIconButton1;
    }
}
