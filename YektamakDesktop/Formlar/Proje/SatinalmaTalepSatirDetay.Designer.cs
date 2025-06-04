namespace YektamakDesktop.Formlar.Proje
{
    partial class SatinalmaTalepSatirDetayForm
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
            dataGridViewSatinalmaTalepSatirDetay = new System.Windows.Forms.DataGridView();
            stokKartKod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatinalmaTalepSatirDetay).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSatinalmaTalepSatirDetay
            // 
            dataGridViewSatinalmaTalepSatirDetay.AllowUserToAddRows = false;
            dataGridViewSatinalmaTalepSatirDetay.AllowUserToDeleteRows = false;
            dataGridViewSatinalmaTalepSatirDetay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSatinalmaTalepSatirDetay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { stokKartKod, stokKartAd, miktar });
            dataGridViewSatinalmaTalepSatirDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewSatinalmaTalepSatirDetay.Location = new System.Drawing.Point(0, 0);
            dataGridViewSatinalmaTalepSatirDetay.Name = "dataGridViewSatinalmaTalepSatirDetay";
            dataGridViewSatinalmaTalepSatirDetay.ReadOnly = true;
            dataGridViewSatinalmaTalepSatirDetay.RowTemplate.Height = 25;
            dataGridViewSatinalmaTalepSatirDetay.Size = new System.Drawing.Size(538, 296);
            dataGridViewSatinalmaTalepSatirDetay.TabIndex = 0;
            // 
            // stokKartKod
            // 
            stokKartKod.HeaderText = "Stok Kodu";
            stokKartKod.Name = "stokKartKod";
            stokKartKod.ReadOnly = true;
            stokKartKod.Width = 150;
            // 
            // stokKartAd
            // 
            stokKartAd.HeaderText = "Stok Adı";
            stokKartAd.Name = "stokKartAd";
            stokKartAd.ReadOnly = true;
            stokKartAd.Width = 250;
            // 
            // miktar
            // 
            miktar.HeaderText = "Miktar";
            miktar.Name = "miktar";
            miktar.ReadOnly = true;
            miktar.Width = 50;
            // 
            // SatinalmaTalepSatirDetay
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(538, 296);
            Controls.Add(dataGridViewSatinalmaTalepSatirDetay);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTalepSatirDetay";
            Text = "SatinalmaTalepSatirDetay";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatinalmaTalepSatirDetay).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSatinalmaTalepSatirDetay;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartKod;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn miktar;
    }
}