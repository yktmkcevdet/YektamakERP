using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar;
using FontAwesome.Sharp;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Models.DTO;
using Utilities.Interfaces;
using Patagames.Pdf.Net.Controls.WinForms;
using YektamakDesktop.Formlar.ProjeModul;

namespace YektamakDesktop
{
    public partial class MainWindow : Form
    {
        private readonly ICache _cache;
        private ToolTip buttonFiltreToolTip;
        private DateTime _oturumBaslangicZamani;
        private DataSet _dataSet;
        public DataSet dataSet
        {
            get => _dataSet ??= new DataSet();
            set => _dataSet = value;
        }
        private int buttonX = 10;
        public MainWindow(ICache cache)
        {
            _cache = cache;
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelAnaMenu.Controls.Add(leftBorderBtn);
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            _oturumBaslangicZamani = DateTime.Now;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan oturumSuresi = DateTime.Now - _oturumBaslangicZamani;
            lblOturumSuresi.Text = "Oturum Süresi: " + oturumSuresi.ToString(@"hh\:mm\:ss");
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            
            lblKullanici.Text = _cache.kullanici.personel.ad;
            this.Enabled = true;

            int y = 6; //Menu butonlarının ana menu panelindeki y koordinatını gösterir..
            foreach (AnaMenuDTO anaMenu in _cache.anaMenuList.OrderBy(a=>a.siraNo))
            {
                MenuButtonOlustur(anaMenu.ad, anaMenu.icon, 6, y); //Girişi yapan kullanıcının yetkisi dahilinde olan menü öğelerinin butonlarını oluşturur.
                y += 51;
            }
            IconButton exitButton = new IconButton()
            {
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Gainsboro,
                IconChar = IconChar.PersonThroughWindow,
                IconColor = Color.Gainsboro,
                IconFont = IconFont.Auto,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                IconSize = 32,
                ImageAlign = ContentAlignment.MiddleLeft,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Padding = new Padding(10, 0, 20, 10),
                AutoSizeMode= AutoSizeMode.GrowAndShrink,
                AutoSize = true,
                Text = "ÇIKIŞ",
                TextAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                UseVisualStyleBackColor = true,
                Dock = DockStyle.Bottom
            };
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.Cursor = Cursors.Hand;
            exitButton.Click += buttonCikis_Click;
            exitButton.BringToFront();
            this.panelExit.Controls.Add(exitButton);
        }
        /// <summary>
        /// Ana menünün butonlarını sol panele yerleştirir.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void MenuButtonOlustur(string text, string icon, int x, int y)
        {
            IconChar iconChar = (IconChar)Enum.Parse(typeof(IconChar), icon);
            IconButton button = new IconButton()
            {
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Gainsboro,
                IconChar = iconChar,
                IconColor = Color.Gainsboro,
                IconFont = IconFont.Auto,
                IconSize = 20,
                ImageAlign = ContentAlignment.MiddleLeft,
                Location = new Point(x, y),
                Padding = new Padding(10, 0, 20, 0),
                Size = new Size(166, 50),
                Text = text,
                TextAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                UseVisualStyleBackColor = true,
            };
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.Click += menuButton_Click;
            button.BringToFront();
            this.panelAnaMenu.Controls.Add(button);
        }
        /// <summary>
        /// Menu öğelerini panele yerleştrir.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void ButtonOlustur(string text, int x, int y)
        {
            this.panelMenu.Controls.Clear();
            foreach (Yetki yetki in _cache.yetkiList.OrderBy(y=>y.ekran.Id))
            {
                IconChar iconChar = (IconChar)Enum.Parse(typeof(IconChar), yetki.menu.icon);
                if (yetki.menu.ad.ToString() == text)
                {
                    RoundedIconButton button = new()
                    {
                        Name = yetki.ekran.formAd.ToString(),
                        Text = yetki.ekran.ekranAdi.ToString(),
                        BackColor = Color.SteelBlue,
                        IconColor = Color.Gainsboro,
                        Location = new Point(x, y),
                        Size = new Size(125, 60),
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        IconChar = iconChar,
                        TextAlign = ContentAlignment.MiddleCenter,
                        TextImageRelation = TextImageRelation.ImageBeforeText,
                        Padding = new Padding(10, 0, 0, 0),
                        IconSize = 30,
                        CornerRadius = 15,
                    };
                    button.Click += button_Click;
                    button.BringToFront();
                    this.panelMenu.Controls.Add(button);
                    x += button.Width + 10;
                    if (x > panelMenu.Width - button.Width)
                    {
                        x = buttonX;
                        y += button.Height + 10;
                    }
                }
            }
        }
        /// <summary>
        /// Menu butonlarına tıklanınca ilgili menuye bağlı formu açar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                var form = FormFactory.CreateFormByName(button.Name);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
        /// <summary>
        /// Retrieves the <see cref="Type"/> of a form with the specified name from the currently loaded assemblies.
        /// </summary>
        /// <remarks>This method searches all assemblies loaded in the current application domain for a
        /// class that inherits from <see cref="Form"/> and matches the specified name. If multiple assemblies contain
        /// forms with the same name, the first match is returned.</remarks>
        /// <param name="formName">The name of the form to locate. This is case-sensitive and must match the name of a class that inherits from
        /// <see cref="Form"/>.</param>
        /// <returns>The <see cref="Type"/> of the form if found; otherwise, <see langword="null"/>.</returns>
        private static Type GetFormInstance(string formName)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Type targetType = null;
            foreach (var assembly in assemblies)
            {
                targetType = assembly.GetTypes()
                    .Where(type => typeof(Form).IsAssignableFrom(type) && type.Name == formName)
                    .FirstOrDefault();

                if (targetType != null)
                    break;
            }
            return targetType;
        }


        /// <summary>
        /// Ana menu butonlarına tıklanınc alt menulerin butonlarını oluşturur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuButton_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;
            ButtonOlustur(button.Text, buttonX, 10);
            ButtonSecim(sender);
            ActivateButton(sender, Color.SteelBlue);
        }

        /// <summary>
        /// Ana menu öğesi tıklandığında butonun renk ayarlamalarını yapar.
        /// </summary>
        /// <param name="sender"></param>
        private void ButtonSecim(object sender)
        {

            foreach (Control control in panelAnaMenu.Controls)
            {
                if (control is Button)
                {
                    //control.BackColor = Color.DodgerBlue;
                    control.ForeColor = Color.Gainsboro;
                }
            }
            Control control1 = (Control)sender;
            control1.BackColor = Color.Transparent;
            control1.ForeColor = Color.SteelBlue;
        }



        /// <summary>
        /// Buttona tıklandığında uygulamayı kapatır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 41);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.DodgerBlue;
                currentBtn.ForeColor = Color.Gold;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.Gold;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.SteelBlue;
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }

        }

        private void lblKullanici_Click(object sender, EventArgs e)
        {

        }
    }
}
