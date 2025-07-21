using System;
using System.Windows.Forms;

namespace YektamakDesktop.CustomControls
{
    partial class UniversalGrid
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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            columnMenu = new ContextMenuStrip(components);
            lblToplamKayitSayisi = new Label();
            lblSecilenKayitSayisi = new Label();
            lblGosterilenKayitSayisi = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(819, 453);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            dataGridView1.MouseClick += dataGridView1_MouseClick;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // columnMenu
            // 
            columnMenu.Name = "columnMenu";
            columnMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // lblToplamKayitSayisi
            // 
            lblToplamKayitSayisi.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblToplamKayitSayisi.AutoSize = true;
            lblToplamKayitSayisi.Location = new System.Drawing.Point(71, 470);
            lblToplamKayitSayisi.Name = "lblToplamKayitSayisi";
            lblToplamKayitSayisi.Size = new System.Drawing.Size(0, 15);
            lblToplamKayitSayisi.TabIndex = 1;
            // 
            // lblSecilenKayitSayisi
            // 
            lblSecilenKayitSayisi.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSecilenKayitSayisi.AutoSize = true;
            lblSecilenKayitSayisi.Location = new System.Drawing.Point(232, 470);
            lblSecilenKayitSayisi.Name = "lblSecilenKayitSayisi";
            lblSecilenKayitSayisi.Size = new System.Drawing.Size(0, 15);
            lblSecilenKayitSayisi.TabIndex = 2;
            // 
            // lblGosterilenKayitSayisi
            // 
            lblGosterilenKayitSayisi.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblGosterilenKayitSayisi.AutoSize = true;
            lblGosterilenKayitSayisi.Location = new System.Drawing.Point(412, 470);
            lblGosterilenKayitSayisi.Name = "lblGosterilenKayitSayisi";
            lblGosterilenKayitSayisi.Size = new System.Drawing.Size(0, 15);
            lblGosterilenKayitSayisi.TabIndex = 3;
            // 
            // UniversalGrid
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblGosterilenKayitSayisi);
            Controls.Add(lblSecilenKayitSayisi);
            Controls.Add(lblToplamKayitSayisi);
            Controls.Add(dataGridView1);
            Name = "UniversalGrid";
            Size = new System.Drawing.Size(819, 498);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip columnMenu;
        private System.Windows.Forms.Label lblToplamKayitSayisi;
        private System.Windows.Forms.Label lblSecilenKayitSayisi;
        private System.Windows.Forms.Label lblGosterilenKayitSayisi;
    }
}
