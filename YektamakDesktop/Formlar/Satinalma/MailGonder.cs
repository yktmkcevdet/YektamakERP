using ApiService.Interfaces;
using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Helpers;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class MailGonder : Form, IForm
    {
        private static ISatinalmaTeklifService _satinalmaTeklifService;
        private static IJsonConverter _jsonConverter;
        public MailGonder()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>();
        }
        public MailGonder(ISatinalmaTeklifService satinalmaTeklifService, IJsonConverter jsonConverter)
        {
            _satinalmaTeklifService = satinalmaTeklifService;
            _jsonConverter = jsonConverter;
        }
        private static MailGonder _mailgonder;
        private List<SatinalmaTeklifBaslik> _satinalmaTeklifBaslikList;
        public List<SatinalmaTeklifBaslik> satinalmaTeklifBaslikList
        {
            get 
            {
                if (_satinalmaTeklifBaslikList == null) { _satinalmaTeklifBaslikList = new(); }
                return _satinalmaTeklifBaslikList;
            }
            set 
            {
                _satinalmaTeklifBaslikList = value;
            }
        }


        private void tsItalic_Click(object sender, EventArgs e)
        {
            if (rtbBody.SelectionFont != null)
            {
                Font currentFont = rtbBody.SelectionFont;
                FontStyle style = currentFont.Style;

                // Toggle Bold flag
                style = currentFont.Italic ? (style & ~FontStyle.Italic) : (style | FontStyle.Italic);

                rtbBody.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, style);
            }
        }

        private void tsUnderLine_Click(object sender, EventArgs e)
        {
            if (rtbBody.SelectionFont != null)
            {
                Font currentFont = rtbBody.SelectionFont;
                FontStyle style = currentFont.Style;

                // Toggle Bold flag
                style = currentFont.Underline ? (style & ~FontStyle.Underline) : (style | FontStyle.Underline);

                rtbBody.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, style);
            }
        }

        private void tscFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            float newSize = float.Parse(tscFontSize.SelectedItem.ToString());
            Font currentFont = rtbBody.SelectionFont;
            rtbBody.SelectionFont = new Font(currentFont.FontFamily, newSize, currentFont.Style);
        }

        public static MailGonder mailGonder
        {
            get
            {
                if (_mailgonder == null || _mailgonder.IsDisposed)
                {
                    _mailgonder = new MailGonder();
                    GlobalData.Yetki(ref _mailgonder);
                }
                return _mailgonder;
            }
        }
        public List<Control> controlsToDisable { get; set; }
        public bool activeForm { get; set; }
        private Mail _mail;
        public Mail mail
        {
            get
            {
                if (_mail == null)
                {
                    _mail = new Mail();
                }
                return _mail;
            }
            set
            {
                _mail = value;
            }
        }
        private void FillFields(Mail mail)
        {
            tbxMailTo.TextCustom = mail.To;
            tbxKonu.TextCustom = mail.Subject;
            rtbBody.Text = mail.Body;
            foreach (var dosya in mail.attachmentData)
            {
                var atch = new PictureBox();
                atch.Image = Properties.Resources.icons8_attachment_24;
                atch.Tag = dosya.fileName;
                atch.Text = dosya.fileName;
                atch.Click += (s, e) =>
                {
                    var fileName = atch.Tag.ToString();
                    var fileData = dosya.fileData;
                    using (MemoryStream ms = new MemoryStream(fileData))
                    {
                        using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                        {
                            ms.WriteTo(fs);
                        }
                    }
                    MessageBox.Show($"Dosya {fileName} olarak kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                atch.Size = new Size(25, 25);
                atch.Location = new Point(10, 190 + (mail.attachmentData.IndexOf(dosya) * 30));
                var lbl = new Label();
                lbl.Text = dosya.fileName;
                lbl.Size = new Size(325, 25);
                lbl.Location = new Point(40, 190 + (mail.attachmentData.IndexOf(dosya) * 30));
                this.Controls.Add(lbl);
                this.Controls.Add(atch);
            }
        }

        private async void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                mail.To = tbxMailTo.TextCustom;
                mail.Subject = tbxKonu.TextCustom;
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // rtf'yi html'e döndürmek için gerekli
                mail.Body = RtfPipe.Rtf.ToHtml(rtbBody.Rtf);
                string jsonResult = await _satinalmaTeklifService.SaveSatinalmaTeklif(satinalmaTeklifBaslikList);
                Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult)[0];
                if (result.result.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(result.result);
                }
                else
                {
                    MailHelper.SendMail(mail.To, mail.Subject, mail.Body, mail.attachmentData);
                    MessageBox.Show("Mail başarıyla gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GlobalData.CloseForm(ref _mailgonder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void UpdateMode(SatinalmaTeklifBaslik satinalmaTeklifBaslik)
        {
            satinalmaTeklifBaslikList.Add(satinalmaTeklifBaslik);
        }
        private void MailGonder_Load(object sender, EventArgs e)
        {
            FillFields(mail);
        }
        bool isBold = false;
        bool isItalic = false;
        bool isUnderline = false;
        string fontName = "Segoe UI";
        float fontSize = 12f;
        Color fontColor = Color.Black;
        void UpdateSelectionStyle()
        {
            FontStyle style = FontStyle.Regular;
            if (isBold) style |= FontStyle.Bold;
            if (isItalic) style |= FontStyle.Italic;
            if (isUnderline) style |= FontStyle.Underline;

            rtbBody.SelectionFont = new Font(fontName, fontSize, style);
            rtbBody.SelectionColor = fontColor;
        }

        private void tsBold_Click(object sender, EventArgs e)
        {
            if (rtbBody.SelectionFont != null)
            {
                Font currentFont = rtbBody.SelectionFont;
                FontStyle style = currentFont.Style;

                // Toggle Bold flag
                style = currentFont.Bold ? (style & ~FontStyle.Bold) : (style | FontStyle.Bold);

                rtbBody.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, style);
            }

        }

        private void tsbForeColor_Click(object sender, EventArgs e)
        {
            var button = (ToolStripButton)sender;
            var menuLocation = tsMain.PointToScreen(new Point(button.Bounds.Left, button.Bounds.Bottom));
            cmsColors.Show(menuLocation);
        }

        private void redItem_Click(object sender, EventArgs e)
        {
            rtbBody.SelectionColor = Color.Red;
        }

        private void blueItem_Click(object sender, EventArgs e)
        {

            rtbBody.SelectionColor = Color.Blue;
        }

        private void yellowItem_Click(object sender, EventArgs e)
        {
            
            rtbBody.SelectionColor = Color.Yellow;
        }
    }
}
