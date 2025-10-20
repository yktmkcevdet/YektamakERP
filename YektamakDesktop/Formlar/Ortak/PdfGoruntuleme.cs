using Spire.Pdf; 
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Ortak
{
    public partial class PdfGoruntuleme : Form
    {
        private static PdfDocument pdfViewer = new PdfDocument();

        public PdfGoruntuleme(string base64Pdf)
        {
            InitializeComponent();

            this.Width = 800;
            this.Height = 600;

            
        }
        private static PdfGoruntuleme _instance;
        public static PdfGoruntuleme GetInstance(string base64Pdf)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new PdfGoruntuleme(base64Pdf);
                byte[] pdfBytes = Convert.FromBase64String(base64Pdf);
                MemoryStream stream = new MemoryStream(pdfBytes);
                pdfViewer.LoadFromBytes(pdfBytes);
                Image img = pdfViewer.SaveAsImage(0);
                pictureBox1.Image = img;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                return _instance;
            }
            else
            {
                byte[] pdfBytes = Convert.FromBase64String(base64Pdf);
                MemoryStream stream = new MemoryStream(pdfBytes);
                pdfViewer.LoadFromBytes(pdfBytes);
                Image img = pdfViewer.SaveAsImage(0);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = img;
                
                return _instance;
            }
        }

        private void ShowPdf(string base64Pdf)
        {
            byte[] pdfBytes = Convert.FromBase64String(base64Pdf);
            MemoryStream stream = new MemoryStream(pdfBytes);
            pdfViewer.LoadFromBytes(pdfBytes);
            Image img = pdfViewer.SaveAsImage(0);
            pictureBox1.Image = img;
        }
    }
}
