using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Newtonsoft.Json.Linq;

namespace YektamakDesktop.CustomControls
{
    public partial class CustomTextBox : UserControl
    {

        private Color borderColor = Color.Silver;
        private int borderSize = 1;
        private bool underlinedStyle = false;
        private Color borderFocusColor = Color.HotPink;
        private bool isFocused = false;

        private int borderRadius = 5;
        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = string.Empty;
        private bool _isPlaceholder = false;
        public bool isPlaceHolder { get => _isPlaceholder; set => _isPlaceholder = value; }
        private bool isPasswordChar = false;
        private string watermarkText = string.Empty;
        public bool isMandatory=false;
        public CustomTextBox()
        {
            InitializeComponent();
        }


        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }


        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        public Color BorderColor { get => borderColor; set { borderColor = value; this.Invalidate(); } }
        public int BorderSize { get => borderSize; set { borderSize = value; this.Invalidate(); } }
        public bool UnderlinedStyle { get => underlinedStyle; set { underlinedStyle = value; this.Invalidate(); } }

        public bool ReadOnly
        {
            get => textBox.ReadOnly;
            set
            {
                textBox.ReadOnly = value;
                if (value)
                {
                    this.BackColor = Color.WhiteSmoke;
                    this.ForeColor = Color.Black;
                }
                else
                {
                    this.BackColor = Color.White;
                    this.ForeColor = Color.Black;
                }
            }
        }
        public bool PasswordChar
        {
            get { return isPasswordChar; }
            set
            {
                isPasswordChar = value;
                textBox.UseSystemPasswordChar = value;
            }
        }

        public bool Multiline
        {
            get { return textBox.Multiline; }
            set { textBox.Multiline = value; }
        }
        public override Color BackColor
        {
            get => base.BackColor;
            set { base.BackColor = value; textBox.BackColor = value; }
        }
        public override Color ForeColor
        {
            get => base.ForeColor;
            set { base.ForeColor = value; textBox.ForeColor = value; }
        }
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                textBox.Font = value;
                if (this.DesignMode)
                {
                    UpdateControlHeight();
                }
            }
        }
        public string TextCustom
        {
            get
            {
                if (_isPlaceholder) return "";
                else return textBox.Text;
            }
            set
            {
                textBox.Text = value;
                SetPlaceHolder();
            }
        }

        public HorizontalAlignment TextAlignment
        {
            get => textBox.TextAlign;
            set
            {
                textBox.TextAlign = value;
            }
        }

        private void SetPlaceHolder()
        {
            if (string.IsNullOrWhiteSpace(textBox.Text) && placeholderText != "")
            {
                _isPlaceholder = true;
                textBox.Text = placeholderText;
                textBox.ForeColor = placeholderColor;
                if (isPasswordChar)
                    textBox.UseSystemPasswordChar = false;
            }
            else if (!_isPlaceholder) 
            {
                textBox.ForeColor = this.ForeColor;
            }
        }

        private void RemovePlaceHolder()
        {
            if (_isPlaceholder && placeholderText != "")
            {
                _isPlaceholder = false;
                textBox.Text = "";
                textBox.ForeColor = this.ForeColor;
                if (isPasswordChar)
                    textBox.UseSystemPasswordChar = true;
            }
        }

        public Color BorderFocusColor { get => borderFocusColor; set => borderFocusColor = value; }
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }

        public Color PlaceholderColor
        {
            get => placeholderColor;
            set
            {
                placeholderColor = value;
                if (_isPlaceholder)
                {
                    textBox.ForeColor = value;
                }
            }
        }
        public string PlaceholderText
        {
            get => placeholderText;
            set
            {
                placeholderText = value;
                textBox.Text = "";
                SetPlaceHolder();
            }
        }
        public int SelectionStart
        {
            get => textBox.SelectionStart;
            set { textBox.SelectionStart = value; }
        }


        [Browsable(true)]
        [Category("Property Changed")]
        [Description("Event is raised when the value of the Text property is changed on Control.")]
        public new event EventHandler TextChanged;

        [Browsable(true)]
        [Category("Key")]
        [Description("Occurs when the control has focus and the user presses and releases a key.")]
        public new event KeyPressEventHandler KeyPress;

        [Browsable(true)]
        [Category("Key")]
        [Description("Occurs when a key is released.")]
        public event KeyEventHandler Key_Up;

        [Browsable(true)]
        [Category("Key")]
        [Description("Occurs when a key is down.")]
        public event KeyEventHandler KeyDown;

        [Browsable(true)]
        [Category("Focus")]
        [Description("Occurs when the control becomes the active control of the form.")]
        public event EventHandler CustomEnter;

        [Browsable(true)]
        [Category("Focus")]
        [Description("Occurs when the control no longer the active control of the form.")]
        public event EventHandler CustomLeave;

        [Browsable(true)]
        [Category("Action")]
        [Description("Occurs when the click on the control.")]
        public new event EventHandler Click;

        [Browsable(true)]
        [Category("Focus")]
        [Description("Occurs when the control is left.")]
        public new event EventHandler Leave;

        [Browsable(true)]
        [Category("Focus")]
        [Description("Occurs when the control loses focus.")]
        public new event EventHandler LostFocus;

        [Browsable(true)]
        [Category("Focus")]
        [Description("Occurs when the control is mouse left")]
        public new event EventHandler MouseLeave;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (borderRadius > 1)//Rounded TextBox
            {
                Rectangle rectBorderSmooth = this.ClientRectangle;
                Rectangle rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);//Orjinal çerçevenin borderSize kadar küçültülmüş hali
                int smoothSize = borderSize > 0 ? borderSize : 1;//Negatif borderSize olmasın diye
                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    //Drawing
                    this.Region = new Region(pathBorderSmooth);//Set the rounded region of UserControl
                    if (borderRadius > 15) SetTextBoxRoundedRegion();//Set the rounded region of TextBox component
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                    if (isFocused) penBorder.Color = borderFocusColor;

                    if (underlinedStyle)
                    {
                        //Draw border smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        //Draw border
                        graph.SmoothingMode = SmoothingMode.None;
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else//NormalStyle
                    {
                        //Draw border smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        //Draw border
                        graph.DrawPath(penBorder, pathBorder);
                    }

                }
            }
            else
            {
                //Draw border
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                    if (isFocused)
                        penBorder.Color = borderFocusColor;

                    if (underlinedStyle)//Line Style
                    {
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else//Normal Style
                    {
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                    }
                }
            }
        }

        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;
            if (Multiline)
            {
                pathTxt = GetFigurePath(textBox.ClientRectangle, borderRadius - borderSize);
                textBox.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurePath(textBox.ClientRectangle, borderSize * 2);
                textBox.Region = new Region(pathTxt);
            }
        }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
            {
                UpdateControlHeight();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        private void UpdateControlHeight()
        {
            if (textBox.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                //Bizim kontrolümüz textBox1'in parent control'ü
                //textBox.Multiline özelliği false olduğu zamanlarda textbox'ın minimumSize özelliği aktif olmuyor(tek satıra göre otomatik ayarlanıyor)
                //textBox1'e MinimumSize özelliği atayabilmek için Multiline'ı önce true sonra false yapıyoruz
                textBox.Multiline = true;
                textBox.MinimumSize = new Size(0, txtHeight);
                textBox.Multiline = false;

                this.Height = textBox.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
            RemovePlaceHolder();
            if (this.CustomEnter != null)
            {
                this.CustomEnter(this, e);
            }
            this.BackColor = Color.LightCyan;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            SetPlaceHolder();

            if (this.Leave != null)
                this.Leave(this, e);
            if (ReadOnly)
            {
                this.BackColor = Color.WhiteSmoke;
            }
            else
            {
                this.BackColor = Color.White;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.TextChanged != null)
            {
                this.TextChanged(this, e);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.KeyPress != null)
            {
                this.KeyPress(this, e);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.Key_Up != null)
            {
                this.Key_Up(this, e);
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.KeyDown != null)
            {
                this.KeyDown(this, e);
            }
        }

        private void CustomTextBox_Enter(object sender, EventArgs e)
        {

        }

        private void CustomTextBox_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            SetPlaceHolder();

            if (this.CustomLeave != null)
                this.CustomLeave(this, e);
        }
        private void textBox_Click(object sender, EventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, e);
            }
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            if (this.Leave != null)
            {
                this.Leave(this, e);
            }
        }
        private void textBox_LostFocus(object sender, EventArgs e)
        {
            if (this.LostFocus != null)
            {
                this.LostFocus(this, e);
            }
        }
        private void textBox_MouseLeave(object sender, EventArgs e)
        {
            if (MouseLeave != null)
            {
                MouseLeave(this, e);
            }
        }
    }
}
