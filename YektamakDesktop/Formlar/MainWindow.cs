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

namespace YektamakDesktop
{
    public partial class MainWindow : Form, IForm
    {
        private readonly ICache _cache;
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private ToolTip buttonFiltreToolTip;
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
            controlsToDisable = new List<Control>
            {
            };
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
        private async void AnaSayfa_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            GlobalData.Start();
            GlobalData.AddNewForm(this);
            this.Enabled = true;

            int y = 6; //Menu butonlarının ana menu panelindeki y koordinatını gösterir..
            foreach (AnaMenu anaMenu in _cache.ananaMenuList)
            {
                MenuButtonOlustur(anaMenu.ad, anaMenu.icon, 6, y); //Girişi yapan kullanıcının yetkisi dahilinde olan menü öğelerinin butonlarını oluşturur.
                y += 67;
            }
            IconButton exitButton = new IconButton()
            {
                //Dock = DockStyle.Top,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Gainsboro,
                IconChar = IconChar.PersonThroughWindow,
                IconColor = Color.Gainsboro,
                IconFont = IconFont.Auto,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                IconSize = 32,
                ImageAlign = ContentAlignment.MiddleLeft,
                Location = new Point(6, 545),
                Padding = new Padding(10, 0, 20, 0),
                Size = new Size(166, 70),
                Text = "ÇIKIŞ",
                TextAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                UseVisualStyleBackColor = true,
            };
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.Click += buttonCikis_Click;
            exitButton.BringToFront();
            this.panelAnaMenu.Controls.Add(exitButton);
            controlsToDisable.Add(exitButton);
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
                //Dock = DockStyle.Top,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Gainsboro,
                IconChar = iconChar,
                IconColor = Color.Gainsboro,
                IconFont = IconFont.Auto,
                IconSize = 32,
                ImageAlign = ContentAlignment.MiddleLeft,
                Location = new Point(x, y),
                Padding = new Padding(10, 0, 20, 0),
                Size = new Size(166, 70),
                Text = text,
                TextAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                UseVisualStyleBackColor = true,
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += menuButton_Click;
            button.BringToFront();
            this.panelAnaMenu.Controls.Add(button);
            controlsToDisable.Add(button);
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
            foreach (Yetki yetki in _cache.yetkiList)
            {
                IconChar iconChar = (IconChar)Enum.Parse(typeof(IconChar), yetki.menu.icon);
                if (yetki.menu.ad.ToString() == text)
                {
                    RoundedIconButton button = new()
                    {
                        FlatStyle = FlatStyle.Flat,
                        Name = yetki.ekran.formAdi.ToString(),
                        Text = yetki.ekran.ekranAdi.ToString(),
                        BackColor = Color.BlueViolet,
                        IconColor = Color.Gainsboro,
                        Location = new Point(x, y),
                        ForeColor = Color.Gainsboro,
                        Size = new Size(163, 119),
                        Font = new Font("Segoe UI", 16, FontStyle.Bold),
                        IconChar = iconChar,
                        TextAlign = ContentAlignment.MiddleCenter,
                        TextImageRelation = TextImageRelation.ImageAboveText,
                        UseVisualStyleBackColor = true,
                        Padding = new Padding(10, 0, 0, 0),
                        IconSize = 32,
                        CornerRadius = 20,
                    };
                    button.Click += button_Click;
                    button.BringToFront();
                    this.panelMenu.Controls.Add(button);
                    controlsToDisable.Add(button);
                    x += button.Width + 10;
                    if (x > 143 + 3 * button.Width)
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

                // Form adını kullanarak tüm assembly'leri tarar.
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                Type targetType = null;

                foreach (var assembly in assemblies)
                {
                    // İlgili formun türünü bulmaya çalışır.

                    targetType = assembly.GetTypes()
                        .Where(type => typeof(Form).IsAssignableFrom(type) && type.Name == button.Name)
                        .FirstOrDefault();

                    if (targetType != null)
                        break;
                }

                // Form bulunduysa açar.
                if (targetType != null)
                {
                    object[] parameters = new object[] { GlobalData.kendiFirmaId };
                    MethodInfo method = targetType.GetMethod("FirmaMode", new Type[] { typeof(int) });
                    Type type = Type.GetType(targetType.ToString());

                    PropertyInfo propertyInfo = type.GetProperty(type.Name[0].ToString().ToLower() + type.Name.Substring(1), BindingFlags.Static | BindingFlags.Public);
                    object formInstance = propertyInfo.GetValue(null);
                    Form form = formInstance as Form;
                    if(form != null)
                    {
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.Show();
                        method?.Invoke(form, parameters); //method null değilse invoke eder. ? işareti null kontrolünü sağlıyor.
                    }
                }
                else
                {
                    // Form bulunamazsa hata döndürür.
                    MessageBox.Show("Form bulunamadı: " + button.Name);
                }
            }
            catch (Exception ex)
            {
                // Olası istisnaları işler.
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
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
            ActivateButton(sender, RGBColors.color6);
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
                    control.BackColor = Color.Red;
                    control.ForeColor = Color.Transparent;
                }
            }
            Control control1 = (Control)sender;
            control1.BackColor = Color.Transparent;
            control1.ForeColor = Color.Red;
        }


        /// <summary>
        /// Gloabal Data'da alınan listelerde güncelleme oldu ise programı kapatmadan güncellenebilmesini sağlar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            MessageBox.Show("GlobalData listeleri güncellendi.");
            this.Enabled = true;
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
        private void CloseForm()
        {
            this.Close();
            GlobalData.RemoveLastForm();
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
                currentBtn.BackColor = Color.FromArgb(158, 20, 20);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
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
                currentBtn.BackColor = Color.FromArgb(255, 0, 0);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }

        }
        private void btnGeneralDefinitions_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
        }
    }
}
