using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.CustomControls
{
    public partial class CustomButtonSave : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadius { get; set; } = 6;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor { get; set; } = Color.Black;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderSize { get; set; } = 0;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color GradientColor1 { get; set; } = Color.DodgerBlue;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color GradientColor2 { get; set; } = Color.MidnightBlue;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color HoverColor1 { get; set; } = Color.RoyalBlue;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color HoverColor2 { get; set; } = Color.Navy;
        private bool _mouseOver = false;
        private bool _mouseDown = false;
        [Browsable(true)]
        [Category("Behavior")]
        public event EventHandler SaveButtonClick;
        public CustomButtonSave()
        {
            InitializeComponent();
        }
        ToolTip toolTip = new ToolTip
        {
            AutoPopDelay = 1500,
            InitialDelay = 100,
            ReshowDelay = 500,
            ShowAlways = true
        };
        private void roundedIconButton1_Click(object sender, EventArgs e)
        {
            SaveButtonClick?.Invoke(this, e);
        }
        private void CustomButtonSave_Load(object sender, EventArgs e)
        {
            toolTip.SetToolTip(ıconButton1, "Kaydet");
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedRectanglePath(this.ClientRectangle, CornerRadius))
            using (Pen pen = new Pen(BorderColor, BorderSize))
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                _mouseDown ? HoverColor2 : (_mouseOver ? HoverColor1 : GradientColor1),
                _mouseDown ? HoverColor1 : (_mouseOver ? HoverColor2 : GradientColor2),
                LinearGradientMode.Vertical))
            {
                // Arka plan
                pevent.Graphics.FillPath(brush, path);

                // Kenarlık
                if (BorderSize > 0)
                    pevent.Graphics.DrawPath(pen, path);

                this.Region = new Region(path);
            }

            // Bazı durumlarda base.OnPaint arka planı bozabilir, bu yüzden base en sona alınır
            base.OnPaint(pevent);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            _mouseOver = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _mouseOver = false;
            _mouseDown = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            _mouseDown = true;
            Invalidate();
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            _mouseDown = false;
            Invalidate();
            base.OnMouseUp(mevent);
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
