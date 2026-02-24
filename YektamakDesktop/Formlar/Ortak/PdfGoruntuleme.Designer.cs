namespace YektamakDesktop.Formlar.Ortak
{
    partial class PdfGoruntuleme
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
            pdfViewer1 = new PdfiumViewer.PdfViewer();
            SuspendLayout();
            // 
            // pdfViewer1
            // 
            pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            pdfViewer1.Location = new System.Drawing.Point(0, 0);
            pdfViewer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pdfViewer1.Name = "pdfViewer1";
            pdfViewer1.ShowBookmarks = false;
            pdfViewer1.ShowToolbar = false;
            pdfViewer1.Size = new System.Drawing.Size(948, 678);
            pdfViewer1.TabIndex = 0;
            // 
            // PdfGoruntuleme
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(948, 678);
            Controls.Add(pdfViewer1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "PdfGoruntuleme";
            Text = "PdfGoruntuleme";
            ResumeLayout(false);
        }

        #endregion

        private PdfiumViewer.PdfViewer pdfViewer1;
    }
}