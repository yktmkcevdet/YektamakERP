using Spire.Pdf;
using System.Drawing;
using System.Windows.Forms;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Ortak
{
    public partial class PdfGoruntuleme : Form
    {
        private PdfDocument pdfViewer = new PdfDocument();

        public PdfGoruntuleme()
        {
            InitializeComponent();

            this.Width = 800;
            this.Height = 600;
            
            
        }
        public void GetInstance(byte[] base64Pdf)
        {
            this.WindowState = FormWindowState.Normal;
            pdfViewer.LoadFromBytes(base64Pdf);
            Image img = pdfViewer.SaveAsImage(0);
            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                
        }
    }
}
