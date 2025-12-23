using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace YektamakDesktop.CustomControls
{
    public class RoundedIconButton : FontAwesome.Sharp.IconButton
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

        public RoundedIconButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.White;
            this.Size = new Size(150, 40);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.IconColor = Color.White;
            this.IconSize = 24;
            this.Cursor = Cursors.Hand;
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
