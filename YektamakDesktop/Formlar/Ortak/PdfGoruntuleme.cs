using PdfiumViewer;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System;
using System.IO;
using System.Windows.Forms;


namespace YektamakDesktop.Formlar.Ortak
{
    public partial class PdfGoruntuleme : Form
    {

        public PdfGoruntuleme()
        {
            InitializeComponent();

            this.Width = 800;
            this.Height = 600;
        }
        
        public void GetInstance(byte[]? base64Pdf)
        {
            pdfViewer1.Document?.Dispose();
            pdfViewer1.Document = PdfDocument.Load(new MemoryStream(base64Pdf ?? GetEmptyPdf()));

        }
        byte[] GetEmptyPdf()
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.Content()
                        .AlignMiddle()
                        .AlignCenter()
                        .Text("Gösterilecek PDF bulunamadı")
                        .FontSize(16)
                        .FontColor(Colors.Grey.Medium);
                });
            }).GeneratePdf();
        }
    }
}
