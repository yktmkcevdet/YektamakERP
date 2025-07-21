using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace YektamakDesktop.CustomControls
{
    public class RoundedButton:Button
    {
        public int CornerRadius { get; set; } = 20;
        public int BorderSize { get; set; } = 0;
        public Color BorderColor { get; set; } = Color.Black;

        public Color GradientColor1 { get; set; } = Color.DodgerBlue;
        public Color GradientColor2 { get; set; } = Color.MidnightBlue;
        public Color BackgroundColor { get; set; } = Color.Firebrick;
        public Color TextColor { get; set; } = Color.White;

        public Color HoverColor1 { get; set; } = Color.RoyalBlue;
        public Color HoverColor2 { get; set; } = Color.Navy;

        public Image? Icon { get; set; } = null;
        public ContentAlignment IconAlign { get; set; } = ContentAlignment.MiddleLeft;

        private bool _mouseOver = false;
        private bool _mouseDown = false;

        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.ForeColor = Color.White;
            this.Size = new Size(150, 40);
            this.DoubleBuffered = true;
            this.Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using var path = GetRoundedPath(ClientRectangle, CornerRadius);
            Region = new Region(path);

            // Renk geçişi
            Color c1 = _mouseDown ? HoverColor2 : (_mouseOver ? HoverColor1 : GradientColor1);
            Color c2 = _mouseDown ? HoverColor1 : (_mouseOver ? HoverColor2 : GradientColor2);

            using var brush = new LinearGradientBrush(ClientRectangle, c1, c2, LinearGradientMode.Vertical);
            using var pen = new Pen(BorderColor, BorderSize);

            e.Graphics.FillPath(brush, path);
            if (BorderSize > 0)
                e.Graphics.DrawPath(pen, path);

            // İkon varsa çiz
            int iconSize = Height - 10;
            int padding = 5;
            Rectangle iconRect = new Rectangle(padding, padding, iconSize, iconSize);

            if (Icon != null)
            {
                e.Graphics.DrawImage(Icon, iconRect);
            }

            // Yazı çizimi
            Rectangle textRect = Icon != null
                ? new Rectangle(iconRect.Right + 5, 0, Width - iconRect.Right - 10, Height)
                : ClientRectangle;

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), textRect, sf);
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

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
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