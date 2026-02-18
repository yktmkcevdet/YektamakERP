using netDxf;
using netDxf.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YektamakDesktop.Formlar.Projemodul;

namespace YektamakDesktop.Common
{
    public static class DxfDrawHelper
    {
        private static List<List<PointF>> splineSegments = new();
        public static void BuildSplineCache(DxfDocument dxfDoc)
        {
            splineSegments.Clear();

            foreach (var spline in dxfDoc.Entities.Splines)
            {
                splineSegments.Add(SampleSpline(spline, 40));
            }
        }
        private static List<PointF> SampleSpline(Spline spline, int segments = 50)
        {
            var ctrl = spline.ControlPoints
                .Select(p => new Vector2((float)p.X, (float)p.Y))
                .ToList();

            var U = spline.Knots.ToList();
            int p = spline.Degree;
            int n = ctrl.Count - 1;

            // t aralığı: [U[p], U[n+1]]
            double t0 = U[p];
            double t1 = U[n + 1];

            var pts = new List<PointF>(segments + 1);

            for (int i = 0; i <= segments; i++)
            {
                double t = (i == segments) ? t1 : (t0 + (t1 - t0) * i / segments);

                int k = FindKnotSpan(t, U, p, n);   // ✅ doğru aralıkta k
                var v = DeBoor(k, p, t, ctrl, U);

                pts.Add(new PointF((float)v.X, (float)v.Y));
            }

            return pts;
        }
        static int FindKnotSpan(double t, List<double> U, int degree, int n)
        {
            // U: knot vector, n: last control point index (ctrl.Count - 1)

            // t en sondaysa span = n
            if (t >= U[n + 1]) return n;
            if (t <= U[degree]) return degree;

            int low = degree;
            int high = n + 1;
            int mid = (low + high) / 2;

            // U[mid] <= t < U[mid+1] arıyoruz
            while (t < U[mid] || t >= U[mid + 1])
            {
                if (t < U[mid]) high = mid;
                else low = mid;
                mid = (low + high) / 2;
            }
            return mid;
        }
        static Vector2 DeBoor(int k, int degree, double t, List<Vector2> ctrl, List<double> knots)
        {
            var d = new Vector2[degree + 1];

            for (int j = 0; j <= degree; j++)
                d[j] = ctrl[k - degree + j];

            for (int r = 1; r <= degree; r++)
            {
                for (int j = degree; j >= r; j--)
                {
                    int idx = k - degree + j;
                    double denom = (knots[idx + degree - r + 1] - knots[idx]);
                    double alpha = denom == 0 ? 0 : (t - knots[idx]) / denom;

                    d[j] = (1 - alpha) * d[j - 1] + alpha * d[j];
                }
            }
            return d[degree];
        }

        static float scale = 1f;
        static PointF pan = new PointF(0, 0);
        public static void FitToScreen(DxfDocument dxfDoc, Panel panel1)
        {
            var bounds = GetDxfBounds(dxfDoc);

            float scaleX = panel1.Width / bounds.Width;
            float scaleY = panel1.Height / bounds.Height;
            scale = Math.Min(scaleX, scaleY) * 0.9f;

            pan.X = panel1.Width / 2 - (bounds.Left + bounds.Width / 2) * scale;
            pan.Y = panel1.Height / 2 + (bounds.Top + bounds.Height / 2) * scale;

            panel1.Invalidate();
        }
        static RectangleF GetDxfBounds(DxfDocument dxfDoc)
        {
            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            void Include(PointF p)
            {
                minX = Math.Min(minX, p.X);
                minY = Math.Min(minY, p.Y);
                maxX = Math.Max(maxX, p.X);
                maxY = Math.Max(maxY, p.Y);
            }

            foreach (var l in dxfDoc.Entities.Lines)
            {
                Include(new PointF((float)l.StartPoint.X, (float)l.StartPoint.Y));
                Include(new PointF((float)l.EndPoint.X, (float)l.EndPoint.Y));
            }

            foreach (var c in dxfDoc.Entities.Circles)
            {
                Include(new PointF((float)(c.Center.X - c.Radius), (float)(c.Center.Y - c.Radius)));
                Include(new PointF((float)(c.Center.X + c.Radius), (float)(c.Center.Y + c.Radius)));
            }

            foreach (var arc in dxfDoc.Entities.Arcs)
            {
                double start = arc.StartAngle;
                double end = arc.EndAngle;
                if (end < start) end += 360;

                // Start & End noktaları
                Include(ArcPoint(arc, arc.StartAngle));
                Include(ArcPoint(arc, arc.EndAngle));

                // Kritik açılar
                double[] criticalAngles = { 0, 90, 180, 270 };
                foreach (var a in criticalAngles)
                {
                    if (AngleInArc(a, start, end))
                        Include(ArcPoint(arc, a));
                }
            }
            foreach (var pts in splineSegments)
            {
                foreach (var p in pts)
                    Include(p);
            }
            return RectangleF.FromLTRB(minX, minY, maxX, maxY);
        }
        static bool AngleInArc(double angle, double start, double end)
        {
            if (end < start)
                end += 360;

            if (angle < start)
                angle += 360;

            return angle >= start && angle <= end;
        }
        static PointF ArcPoint(Arc arc, double angleDeg)
        {
            double rad = angleDeg * Math.PI / 180.0;
            return new PointF(
                (float)(arc.Center.X + arc.Radius * Math.Cos(rad)),
                (float)(arc.Center.Y + arc.Radius * Math.Sin(rad))
            );
        }

        static List<PointF[]> splineScreenCache = new();
        public static void RebuildScreenCache()
        {
            splineScreenCache.Clear();

            foreach (var pts in splineSegments)
            {
                var arr = new PointF[pts.Count];
                for (int i = 0; i < pts.Count; i++)
                    arr[i] = ToScreen(pts[i].X, pts[i].Y);

                splineScreenCache.Add(arr);
            }
        }
        public static PointF ToScreen(double x, double y)
        {
            return new PointF(
                (float)(x * scale + pan.X),
                (float)(-y * scale + pan.Y)
            );
        }
        public static PointF ScreenToWorld(System.Drawing.Point p)
        {
            return new PointF(
                (p.X - pan.X) / scale,
                -(p.Y - pan.Y) / scale
            );
        }
        public static PointF? GetSnapPoint(PointF mouseWorld, DxfDocument dxfDoc)
        {
            float tol = 5f / scale;

            foreach (var line in dxfDoc.Entities.Lines)
            {
                var p1 = new PointF((float)line.StartPoint.X, (float)line.StartPoint.Y);
                var p2 = new PointF((float)line.EndPoint.X, (float)line.EndPoint.Y);

                if (Distance(mouseWorld, p1) < tol) return p1;
                if (Distance(mouseWorld, p2) < tol) return p2;
            }
            return null;
        }
        static float Distance(PointF p1, PointF p2)
        {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
        static PointF? activeSnapPoint = null;
        static SnapType activeSnapType = SnapType.None;
        public static void DrawSnap(Graphics g)
        {
            if (activeSnapPoint == null) return;

            PointF s = ToScreen(activeSnapPoint.Value.X, activeSnapPoint.Value.Y);
            float r = 6;

            switch (activeSnapType)
            {
                case SnapType.MidPoint:
                    g.DrawRectangle(Pens.Green, s.X - r, s.Y - r, r * 2, r * 2);
                    break;

                case SnapType.Center:
                    g.DrawEllipse(Pens.Blue, s.X - r, s.Y - r, r * 2, r * 2);
                    g.DrawLine(Pens.Blue, s.X - r, s.Y, s.X + r, s.Y);
                    g.DrawLine(Pens.Blue, s.X, s.Y - r, s.X, s.Y + r);
                    break;

                case SnapType.Intersection:
                    g.DrawLine(Pens.Red, s.X - r, s.Y - r, s.X + r, s.Y + r);
                    g.DrawLine(Pens.Red, s.X - r, s.Y + r, s.X + r, s.Y - r);
                    break;
            }
        }
        public static void DrawMeasurement(Graphics g, PointF a, PointF b)
        {
            var sa = ToScreen(a.X, a.Y);
            var sb = ToScreen(b.X, b.Y);

            using var pen = new Pen(Color.Blue, 1) { DashStyle = DashStyle.Dash };
            g.DrawLine(pen, sa, sb);

            float dist = Distance(a, b);

            // orta nokta
            var mid = new PointF((sa.X + sb.X) / 2, (sa.Y + sb.Y) / 2);

            string text = $"{dist:0.##}";

            g.FillRectangle(Brushes.White, mid.X - 20, mid.Y - 10, 40, 20);
            g.DrawString(text, SystemFonts.DefaultFont, Brushes.Blue, mid);
        }
        public static float DistancePointToSegment(PointF p, PointF a, PointF b)
        {
            float dx = b.X - a.X;
            float dy = b.Y - a.Y;

            if (dx == 0 && dy == 0)
                return Distance(p, a);

            float t = ((p.X - a.X) * dx + (p.Y - a.Y) * dy) / (dx * dx + dy * dy);
            t = Math.Max(0, Math.Min(1, t));

            PointF proj = new PointF(a.X + t * dx, a.Y + t * dy);
            return Distance(p, proj);
        }
        
    }
}
