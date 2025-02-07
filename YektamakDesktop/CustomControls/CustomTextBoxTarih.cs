using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace YektamakDesktop.CustomControls
{
    /// <summary>
    /// Tarih seçimi yapabilen textbox
    /// </summary>
    public partial class CustomTextBoxTarih : UserControl
    {
        

        private bool _focusOnTextBox = false;
        private bool focusOnTextBox
        {
            get => _focusOnTextBox;
            set
            {
                _focusOnTextBox = value;
                if (!value)
                {
                    CheckFocusOnControl();
                }
            }
        }
        private bool _focusOnPanel = false;
        private bool focusOnPanel
        {
            get => _focusOnPanel;
            set
            {
                _focusOnPanel = value;
                if (!value)
                {
                    CheckFocusOnControl();
                }
            }
        }
        private bool _focusOnMonthCalendar = false;
        private bool focusOnMonthCalendar
        {
            get => _focusOnMonthCalendar;
            set
            {
                _focusOnMonthCalendar = value;
                if (!value)
                {
                    CheckFocusOnControl();
                }
            }
        }
        private string placeholderText = string.Empty;
        private Color placeholderColor = Color.DarkGray;
        private void SetPlaceHolder()
        {
            if (string.IsNullOrWhiteSpace(textBox.TextCustom) && placeholderText != "")
            {
                textBox.TextCustom = placeholderText;
                textBox.ForeColor = placeholderColor;
            }
        }
        public string TextCustom
        {
            get
            {
                return textBox.TextCustom;
            }
            set
            {
                textBox.TextCustom = value;
                SetPlaceHolder();
            }
        }

        private bool isTextBoxClickEventEnabled = true;
        private bool isTextBoxEnterEventEnabled = true;
        public CustomTextBoxTarih()
        {
            InitializeComponent();
            Resize_MonthCalendar();
        }
        [Browsable(true)]
        [Category("Property Changed")]
        [Description("Event is raised when the value of the Text property is changed on Control.")]
        public new event EventHandler TextChanged;

        [Browsable(true)]
        [Category("Key")]
        [Description("Occurs when the control has focus and the user presses and releases a key.")]
        public event EventHandler Key_Press;

        [Browsable(true)]
        [Category("Key")]
        [Description("Occurs when a key is released.")]
        public event KeyEventHandler Key_Up;

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Occurs when the value of the SelectedIndex property changes.")]


        private void textBox_Enter(object sender, EventArgs e)
        {
            if (focusOnTextBox == false && isTextBoxEnterEventEnabled == false)
            {
                monthCalendar.SelectionEnd = string.IsNullOrWhiteSpace(textBox.TextCustom) ? DateTime.Now : DateTime.Parse(textBox.TextCustom.ToString());
                monthCalendar.SelectionEnd = monthCalendar.SelectionStart;
                focusOnTextBox = true;
                Resize_MonthCalendar();
                isTextBoxClickEventEnabled = false;
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            Point mouseLocation = textBox.PointToClient(Control.MousePosition);

            if (!monthCalendar.Bounds.Contains(mouseLocation))
            {
                focusOnTextBox = false;
                Resize_MonthCalendar();
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.TextChanged != null)
            {
                this.TextChanged(this, e);
            }

        }
        /// <summary>
        /// Bu olayla birlikte textBox KeyPress event'i bu kontrolün Key_Press eventini tetiklemiş oluyor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_Key_Press(object sender, KeyPressEventArgs e)
        {
            if (this.Key_Press != null)
            {
                this.Key_Press(this, e);
            }
        }

        private void textBox_Key_Up(object sender, KeyEventArgs e)
        {
            if (this.Key_Up != null)
            {
                this.Key_Up(this, e);
            }
        }

        private void textBox_CustomLeave(object sender, EventArgs e)
        {
            textBox.TextCustom = "";
            focusOnTextBox = false;
        }

        private void panelDropDownButton_Enter(object sender, EventArgs e)
        {
            focusOnPanel = true;
        }

        private void panelDropDownButton_Leave(object sender, EventArgs e)
        {
            focusOnPanel = false;
        }

        /// <summary>
        /// Eğer bu custom control üzerindeki hiçbir şey üzerinde focus kalmamışsa listbox'ı kapat
        /// </summary>
        private void CheckFocusOnControl()
        {
            if (!focusOnTextBox && !focusOnMonthCalendar)
            {
                //CloseListBox();
            }
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            if (isTextBoxClickEventEnabled)
            {
                if (focusOnTextBox == false)
                {
                    focusOnTextBox = true;
                }
                else
                {
                    focusOnTextBox = false;
                }
                monthCalendar.SelectionStart = string.IsNullOrWhiteSpace(textBox.TextCustom) ? DateTime.Now : (DateTime.TryParse(textBox.TextCustom.ToString(),out DateTime date)?date: monthCalendar.SelectionStart);
                monthCalendar.SelectionEnd = monthCalendar.SelectionStart;
                Resize_MonthCalendar();
            }
            else
            {
                isTextBoxClickEventEnabled = true;
            }
        }
        private void Resize_MonthCalendar()
        {
            if (focusOnTextBox == false)
            {
                this.Height = 32;
                this.Width = 145;
                monthCalendar.Visible = false;
            }
            else
            {
                this.Height = 198;
                this.Width = 237;
                monthCalendar.Visible = true;
                this.BringToFront();
            }
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBox.TextCustom = monthCalendar.SelectionEnd.ToShortDateString();
            focusOnTextBox = false;
            isTextBoxClickEventEnabled = true;
            isTextBoxEnterEventEnabled = true;
            Resize_MonthCalendar();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                textBox.TextCustom = "";
            }
        }

        private void monthCalendar_Leave(object sender, EventArgs e)
        {

        }
        private void TariheDonustur()
        {
            string girilenTarih = textBox.TextCustom.Trim();

            // Tarih formatları
            string[] tarihFormatlari = { "d.M.yyyy", "d/M/yyyy", "d-M-yyyy", "d.M", "d/M", "d M" };

            // Tarih dönüştürme
            DateTime tarih;
            if (DateTime.TryParseExact(girilenTarih, tarihFormatlari, CultureInfo.InvariantCulture, DateTimeStyles.None, out tarih))
            {
                // Başarılı dönüşüm
                string formatliTarih = tarih.ToString("dd.MM.yyyy");
                textBox.TextCustom = formatliTarih;
            }
            else
            {
                // Hatalı giriş
                MessageBox.Show("Geçersiz tarih formatı. Lütfen doğru bir tarih formatı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TariheDonustur();
                focusOnTextBox = false;
                Resize_MonthCalendar();
            }
        }

        private void CustomTextBoxTarih_Load(object sender, EventArgs e)
        {
            
        }
    }
}