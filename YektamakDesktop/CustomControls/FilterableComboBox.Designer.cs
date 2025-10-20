namespace YektamakDesktop.CustomControls
{
    partial class FilterableComboBox
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
            comboBox1 = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(3, 2);
            comboBox1.Margin = new System.Windows.Forms.Padding(0);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(152, 21);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // FilterableComboBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(comboBox1);
            Font = new System.Drawing.Font("Segoe UI", 8F);
            Margin = new System.Windows.Forms.Padding(1);
            Name = "FilterableComboBox";
            Padding = new System.Windows.Forms.Padding(3);
            Size = new System.Drawing.Size(156, 25);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
    }
}
