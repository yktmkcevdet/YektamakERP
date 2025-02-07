using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace YektamakDesktop.CustomControls
{
    public class RoundedIconButton : FontAwesome.Sharp.IconButton
    {
        // Yarıçap değeri
        private int _cornerRadius = 10;

        // Yarıçap için özellik
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); }
        }

        // Paint olayını yeniden oluşturarak köşeleri yuvarlama
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (GraphicsPath path = new GraphicsPath())
            {
                // Köşeleri yuvarlatılmış bir dikdörtgen oluştur
                path.AddArc(new Rectangle(0, 0, CornerRadius * 2, CornerRadius * 2), 180, 90);
                path.AddArc(new Rectangle(Width - CornerRadius * 2, 0, CornerRadius * 2, CornerRadius * 2), 270, 90);
                path.AddArc(new Rectangle(Width - CornerRadius * 2, Height - CornerRadius * 2, CornerRadius * 2, CornerRadius * 2), 0, 90);
                path.AddArc(new Rectangle(0, Height - CornerRadius * 2, CornerRadius * 2, CornerRadius * 2), 90, 90);
                path.CloseFigure();

                // Dikdörtgenin içine icon ve text'i yerleştir
                this.Region = new Region(path);
            }
        }
    }
}
