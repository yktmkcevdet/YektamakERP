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
            Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartkod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            stokKartad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatinalmaTalepSatirDetay).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSatinalmaTalepSatirDetay
            // 
            dataGridViewSatinalmaTalepSatirDetay.AllowUserToAddRows = false;
            dataGridViewSatinalmaTalepSatirDetay.AllowUserToDeleteRows = false;
            dataGridViewSatinalmaTalepSatirDetay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSatinalmaTalepSatirDetay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Id, stokKartkod, stokKartad, miktar });
            dataGridViewSatinalmaTalepSatirDetay.Location = new System.Drawing.Point(0, 39);
            dataGridViewSatinalmaTalepSatirDetay.Name = "dataGridViewSatinalmaTalepSatirDetay";
            dataGridViewSatinalmaTalepSatirDetay.ReadOnly = true;
            dataGridViewSatinalmaTalepSatirDetay.RowTemplate.Height = 25;
            dataGridViewSatinalmaTalepSatirDetay.Size = new System.Drawing.Size(538, 257);
            dataGridViewSatinalmaTalepSatirDetay.TabIndex = 0;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // stokKartkod
            // 
            stokKartkod.HeaderText = "Stok Kodu";
            stokKartkod.Name = "stokKartkod";
            stokKartkod.ReadOnly = true;
            stokKartkod.Width = 150;
            // 
            // stokKartad
            // 
            stokKartad.HeaderText = "Stok Adı";
            stokKartad.Name = "stokKartad";
            stokKartad.ReadOnly = true;
            stokKartad.Width = 250;
            // 
            // miktar
            // 
            miktar.HeaderText = "Miktar";
            miktar.Name = "miktar";
            miktar.ReadOnly = true;
            miktar.Width = 50;
            // 
            // headerPanel1
            // 
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = System.Drawing.Color.Firebrick;
            headerPanel1.Baslik = "";
            headerPanel1.Location = new System.Drawing.Point(0, 0);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new System.Drawing.Size(538, 32);
            headerPanel1.TabIndex = 1;
            // 
            // SatinalmaTalepSatirDetayForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(538, 296);
            Controls.Add(headerPanel1);
            Controls.Add(dataGridViewSatinalmaTalepSatirDetay);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SatinalmaTalepSatirDetayForm";
            Text = "SatinalmaTalepSatirDetay";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSatinalmaTalepSatirDetay).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSatinalmaTalepSatirDetay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartkod;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKartad;
        private System.Windows.Forms.DataGridViewTextBoxColumn miktar;
        private CustomControls.HeaderPanel headerPanel1;
    }
}