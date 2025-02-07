using netDxf;
using netDxf.Entities;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Ortak
{
    public partial class DxfViewer : Form
    {
        private DxfDocument dxfDoc;
        public string fileName { get; set; }
        public DxfViewer()
        {
            InitializeComponent();
        }

        private void DxfViewer_Load(object sender, EventArgs e)
        {
            dxfDoc = DxfDocument.Load(fileName);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (dxfDoc == null) return;

            int x0;
            int y0;

            Graphics g = e.Graphics;
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black, 1);

            // DXF içindeki tüm çizgi varlıklarını al ve çiz
            foreach (Line line in dxfDoc.Entities.Lines)
            {
                float x1 = (float)line.StartPoint.X;
                float y1 = (float)line.StartPoint.Y;
                float x2 = (float)line.EndPoint.X;
                float y2 = (float)line.EndPoint.Y;

                g.DrawLine(pen, x1, y1, x2, y2);
            }
            foreach (Circle circle in dxfDoc.Entities.Circles)
            {
                float x = (float)circle.Center.X;
                float y = (float)circle.Center.Y;
                float radius = (float)circle.Radius;

                // Çemberin dikdörtgensel çerçevesini hesapla
                float topLeftX = x - radius;
                float topLeftY = y - radius;
                float diameter = 2 * radius;

                g.DrawEllipse(pen, topLeftX, topLeftY, diameter, diameter);
            }
            foreach (Arc arc in dxfDoc.Entities.Arcs)
            {
                float x = (float)arc.Center.X + 200;
                float y = (float)arc.Center.Y + 200;
                float radius = (float)arc.Radius;
                float startAngle = (float)arc.StartAngle;
                float endAngle = (float)arc.EndAngle;

                // Açıyı saat yönüne çevirme
                float sweepAngle = endAngle - startAngle;
                if (sweepAngle < 0)
                    sweepAngle += 360;

                // Dikdörtgensel çerçeveyi hesapla
                float topLeftX = x - radius;
                float topLeftY = y - radius;
                float diameter = 2 * radius;

                g.DrawArc(pen, topLeftX, topLeftY, diameter, diameter, startAngle, sweepAngle);
            }
        }
    }
}
