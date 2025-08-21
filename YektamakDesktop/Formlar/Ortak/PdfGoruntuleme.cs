using System;
using System.Windows.Forms;
using Microsoft.Win32;
using Spire.Pdf;
using System.ComponentModel;

namespace YektamakDesktop.Formlar.Ortak
{
    public partial class PdfGoruntuleme : Form
    {
        private string _pdfFilePath;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string pdfFilePath 
        { 
            get { return _pdfFilePath; } 
            set 
            {
                _pdfFilePath = value;
                InitializePdfViewer();

            }
        }
        public PdfGoruntuleme()
        {
            InitializeComponent();
        }
        private static PdfGoruntuleme _pdfGoruntuleme;
        public static PdfGoruntuleme pdfGoruntuleme { get { if (_pdfGoruntuleme == null) _pdfGoruntuleme = new PdfGoruntuleme(); return _pdfGoruntuleme; } }
        
        private void InitializePdfViewer()
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Dock = DockStyle.Fill;
            this.Controls.Add(webBrowser);
            webBrowser.Navigate(_pdfFilePath);
            //PdfViewer pdfViewer = new PdfViewer
            //{
            //    Dock = DockStyle.Fill
            //};
            //using (var pdfDocument = PdfDocument.Load(_pdfFilePath))
            //{
            //    pdfViewer.Document = pdfDocument;
            //}
            //Controls.Add(pdfViewer);
        }   

        private void OpenPdfButton_Click(string pdfFilePath)
        {
            //try
            //{
            //    //pdfViewer.LoadFromFile(Path.Combine(Application.StartupPath, pdfFilePath));
            //    pdfViewer.LoadFromFile(pdfFilePath);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error opening PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void CloseForm()
        {
            Close();
            _pdfGoruntuleme = null;
        }

        private void PdfGoruntuleme_FormClosing(object sender, FormClosingEventArgs e)
        {
            _pdfGoruntuleme = null;
        }

        private void PdfGoruntuleme_Load(object sender, EventArgs e)
        {
            OpenPdfButton_Click(_pdfFilePath);
        }
    }
}
