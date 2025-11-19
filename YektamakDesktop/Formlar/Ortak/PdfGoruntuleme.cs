using Spire.Pdf; 
using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Ortak
{
    public partial class PdfGoruntuleme : Form
    {
        private readonly IFileHelper _fileHelper;
        private PdfDocument pdfViewer = new PdfDocument();

        public PdfGoruntuleme(IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
            InitializeComponent();

            this.Width = 800;
            this.Height = 600;

            
        }
        public void GetInstance(byte[] base64Pdf)
        {
            pdfViewer.LoadFromBytes(_fileHelper.Decompress(base64Pdf));
            Image img = pdfViewer.SaveAsImage(0);
            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                
        }
        //private PdfGoruntuleme _instance;
        //public PdfGoruntuleme GetInstance(byte[] base64Pdf)
        //{
        //    if (_instance == null || _instance.IsDisposed)
        //    {
        //        _instance = new PdfGoruntuleme(base64Pdf, _fileHelper);
        //        //byte[] pdfBytes = Convert.FromBase64String(base64Pdf);
        //        MemoryStream stream = new MemoryStream(base64Pdf);
        //        pdfViewer.LoadFromBytes(_fileHelper.Decompress(base64Pdf));
        //        Image img = pdfViewer.SaveAsImage(0);
        //        pictureBox1.Image = img;
        //        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        //        return _instance;
        //    }
        //    else
        //    {
        //        //byte[] pdfBytes = Convert.FromBase64String(base64Pdf);
        //        //MemoryStream stream = new MemoryStream(pdfBytes);
        //        pdfViewer.LoadFromBytes(_fileHelper.Decompress(base64Pdf));
        //        Image img = pdfViewer.SaveAsImage(0);
        //        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        //        pictureBox1.Image = img;

        //        return _instance;
        //    }
        //}

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
