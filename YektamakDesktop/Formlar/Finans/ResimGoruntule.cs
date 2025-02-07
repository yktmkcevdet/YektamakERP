using YektamakDesktop.Temp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Finans
{
    public partial class ResimGoruntule : Form, IForm
    {
        private static ResimGoruntule _cekResimGoster;
        public static ResimGoruntule cekResimGoster
        {
            get
            {
                if (_cekResimGoster == null)
                {
                    _cekResimGoster = new ResimGoruntule();
                    GlobalData.Yetki(ref _cekResimGoster);
                }
                return _cekResimGoster;
            }
            set
            {
                _cekResimGoster = value;
            }
        }

        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable
        {
            get
            {
                if (_controlsToDisable == null)
                    _controlsToDisable = new List<Control>();
                return _controlsToDisable;
            }
            set
            {
                _controlsToDisable = value;
            }
        }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        public byte[] _imageBytes;
        public string _headerText;
        public ResimGoruntule()
        {
            InitializeComponent();
        }
        #region mouseDrag
        bool mouseDown;
        private Point offset;
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreepPos = PointToScreen(e.Location);
                Location = new Point(currentScreepPos.X - offset.X, currentScreepPos.Y - offset.Y);
            }
        }
        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion mouseDrag

        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            this.Close();
            _cekResimGoster = null;
            GlobalData.RemoveLastForm();
        }
        /// <summary>
        /// Resmi pictureBox'a yükler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CekResimGoster_Load(object sender, EventArgs e)
        {
            labelHeader.Text = _headerText;
            if (_imageBytes != null && _imageBytes.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(_imageBytes))
                    pictureBox1.Image = ScaleImageToFitPictureBox(Image.FromStream(ms), pictureBox1.Size);
            }

        }
        /// <summary>
        /// Resim boyutunu pictureBox boyutuna uyacak şekilde ölçeklendirir.
        /// </summary>
        /// <param name="resim"></param>
        /// <param name="pictureBoxBoyutu"></param>
        /// <returns></returns>
        private Image ScaleImageToFitPictureBox(Image resim, Size pictureBoxBoyutu)
        {
            int yeniGenislik, yeniYukseklik;
            double oran = (double)resim.Width / resim.Height;

            if (oran > 1)
            {
                yeniGenislik = pictureBoxBoyutu.Width;
                yeniYukseklik = (int)(pictureBoxBoyutu.Width / oran);
            }
            else
            {
                yeniGenislik = (int)(pictureBoxBoyutu.Height * oran);
                yeniYukseklik = pictureBoxBoyutu.Height;
            }

            Bitmap yeniResim = new Bitmap(pictureBoxBoyutu.Width, pictureBoxBoyutu.Height);

            using (Graphics g = Graphics.FromImage(yeniResim))
            {
                // Yüksek kaliteli çizim ayarları
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                // Resmi çiz
                g.DrawImage(resim, new Rectangle(0, 0, yeniGenislik, yeniYukseklik));
            }

            return yeniResim;
        }

        private void CloseForm()
        {
            this.Close();
            GlobalData.RemoveLastForm();
            _cekResimGoster = null;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X + panel1.Location.X;
            offset.Y = e.Y + panel1.Location.Y;

            mouseDown = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point clientPoint = PointToClient(MousePosition);
                pictureBox1.Location = new Point(clientPoint.X - offset.X, clientPoint.Y - offset.Y);

                Debug.WriteLine($"OffsetX: {clientPoint.X}, OffsetY: {clientPoint.Y}");
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void ZoomImage(double factor)
        {
            PictureBox pictureBox = new PictureBox();
            // Yeni genişlik ve yükseklik hesapla
            int newWidth = (int)(pictureBox1.Width * factor);
            int newHeight = (int)(pictureBox1.Height * factor);

            pictureBox1.Size = new Size(newWidth, newHeight);
            using (MemoryStream ms = new MemoryStream(_imageBytes))
                pictureBox1.Image = ScaleImageToFitPictureBox(Image.FromStream(ms), pictureBox1.Size);
        }
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            ZoomImage(1.1);
        }
        private void roundedButton2_Click(object sender, EventArgs e)
        {
            ZoomImage(0.9); // Resmi 0.9 kat küçült
        }
    }
}
