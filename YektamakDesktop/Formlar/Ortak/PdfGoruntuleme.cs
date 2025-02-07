using Patagames.Pdf.Net.Controls.WinForms;
using Patagames.Pdf.Net.Controls.WinForms.ToolBars;
using System;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Ortak
{
    public partial class PdfGoruntuleme : Form
    {
        private string _pdfFilePath;
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
            PdfViewer pdfViewer = new PdfViewer
            {
                Dock = DockStyle.Fill
            };
            pdfViewer.LoadDocument(_pdfFilePath);
            
            Controls.Add(pdfViewer);
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
            GlobalData.RemoveLastForm();
            _pdfGoruntuleme = null;
        }

        private void PdfGoruntuleme_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalData.RemoveLastForm();
            _pdfGoruntuleme = null;
        }

        private void PdfGoruntuleme_Load(object sender, EventArgs e)
        {
            OpenPdfButton_Click(_pdfFilePath);
        }
    }
}
