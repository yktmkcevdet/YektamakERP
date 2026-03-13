using Models;
using netDxf;
using netDxf.Blocks;
using netDxf.Collections;
using netDxf.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace YektamakDesktop.Common
{
    public static class DxfDrawHelper
    {
        public static DxfDocument dxfDoc;
        public class Spl
        {
            public List<PointF> points { get; set; }
            public Color color { get; set; }
        }

        public static List<Spl> splineSegments { get; set; } = new();
        public static void BuildSplineCache()
        {
            splineSegments.Clear();

            foreach (var spline in dxfDoc.Entities.Splines)
            {
                Spl spline1 = new Spl();
                spline1.points = SampleSpline(spline);
                spline1.color = ResolveColor(spline);
                splineSegments.Add(spline1);
            }
        }
        private static List<PointF> SampleSpline(Spline spline, int segments = 60)
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

        public static float pickTolerance = 5f / scale; // ekranda ~5px
        public static float scale = 1f;
        public static PointF pan = new PointF(0, 0);
        public static void FitToScreen(Panel panel1)
        {
            var bounds = GetDxfBounds();

            float scaleX = panel1.Width / bounds.Width;
            float scaleY = panel1.Height / bounds.Height;
            scale = Math.Min(scaleX, scaleY) * 0.9f;

            pan.X = panel1.Width / 2 - (bounds.Left + bounds.Width / 2) * scale;
            pan.Y = panel1.Height / 2 + (bounds.Top + bounds.Height / 2) * scale;

            panel1.Invalidate();
        }
        static RectangleF GetDxfBounds()
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
            foreach (var spl in splineSegments)
            {
                foreach (var p in spl.points)
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
        public class SpCache
        {
            public PointF[] arr { get; set; }
            public Color color { get; set; }
        }
        public static List<SpCache> splineScreenCache { get; set; } = new();
        public static void RebuildScreenCache()
        {
            splineScreenCache.Clear();

            foreach (var spl in splineSegments)
            {
                var arr = new PointF[spl.points.Count];
                for (int i = 0; i < spl.points.Count; i++)
                    arr[i] = ToScreen(spl.points[i].X, spl.points[i].Y);
                SpCache spCache = new SpCache();
                spCache.arr = arr;
                spCache.color = spl.color;
                splineScreenCache.Add(spCache);
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
        public static PointF? GetSnapPoint(PointF mouseWorld)
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
        public static PointF? activeSnapPoint = null;
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
                case SnapType.EndPoint:
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


        public static bool isMeasuring = false;
        public static PointF? measureStart = null;
        public static PointF? measureEnd = null;
        static float SnapToleranceWorld => 6f / scale;
        public static void StartMeasure()
        {
            isMeasuring = true;
            measureStart = null;
            measureEnd = null;
        }
        public static void CancelMeasure(Panel panel)
        {
            isMeasuring = false;
            measureStart = null;
            measureEnd = null;
            panel.Invalidate();
        }
        public static List<(PointF A, PointF B)> measurements = new();



        public static bool isPanning = false;
        public static System.Drawing.Point lastMouse;
        enum SnapType
        {
            None,
            EndPoint,
            MidPoint,
            Center,
            Intersection
        }
        public static void UpdateSnap(PointF mouseWorld)
        {
            activeSnapPoint = null;
            activeSnapType = SnapType.None;

            CheckMidpointSnap(mouseWorld);
            if (activeSnapPoint != null) return;

            CheckCenterSnap(mouseWorld);
            if (activeSnapPoint != null) return;

            CheckIntersectionSnap(mouseWorld);
        }
        static void CheckMidpointSnap(PointF mouseWorld)
        {
            foreach (var line in dxfDoc.Entities.Lines)
            {
                PointF a = new((float)line.StartPoint.X, (float)line.StartPoint.Y);
                PointF b = new((float)line.EndPoint.X, (float)line.EndPoint.Y);

                PointF mid = new((a.X + b.X) / 2, (a.Y + b.Y) / 2);

                if (Distance(mouseWorld, mid) < SnapToleranceWorld)
                {
                    activeSnapPoint = mid;
                    activeSnapType = SnapType.MidPoint;
                    return;
                }
            }
        }
        static void CheckCenterSnap(PointF mouseWorld)
        {
            foreach (var c in dxfDoc.Entities.Circles)
            {
                PointF center = new((float)c.Center.X, (float)c.Center.Y);

                if (Distance(mouseWorld, center) < SnapToleranceWorld)
                {
                    activeSnapPoint = center;
                    activeSnapType = SnapType.Center;
                    return;
                }
            }

            foreach (var a in dxfDoc.Entities.Arcs)
            {
                PointF center = new((float)a.Center.X, (float)a.Center.Y);

                if (Distance(mouseWorld, center) < SnapToleranceWorld)
                {
                    activeSnapPoint = center;
                    activeSnapType = SnapType.Center;
                    return;
                }
            }
        }
        static void CheckIntersectionSnap(PointF mouseWorld)
        {
            var lines = dxfDoc.Entities.Lines.ToList();
            var arcs = dxfDoc.Entities.Arcs.ToList();
            for (int i = 0; i < lines.Count; i++) 
            { 
                for (int j = i + 1; j < lines.Count; j++) 
                { 
                    PointF a1 = new((float)lines[i].StartPoint.X, (float)lines[i].StartPoint.Y); 
                    PointF a2 = new((float)lines[i].EndPoint.X, (float)lines[i].EndPoint.Y); 
                    PointF b1 = new((float)lines[j].StartPoint.X, (float)lines[j].StartPoint.Y); 
                    PointF b2 = new((float)lines[j].EndPoint.X, (float)lines[j].EndPoint.Y); 
                    if (!TryLineIntersection(a1, a2, b1, b2, out var ip)) continue; 
                    if (Distance(mouseWorld, ip) < SnapToleranceWorld) 
                    { 
                        activeSnapPoint = ip; 
                        activeSnapType = SnapType.Intersection; 
                        return; 
                    } 
                } 
            }
            foreach (var line in lines)
            {
                foreach (var arc in arcs)
                {
                    PointF p1 = new((float)line.StartPoint.X, (float)line.StartPoint.Y);
                    PointF p2 = new((float)line.EndPoint.X, (float)line.EndPoint.Y);

                    if (TryLineArcIntersection(p1, p2, arc, out var points))
                    {
                        foreach (var ip in points)
                        {
                            if (Distance(mouseWorld, ip) < SnapToleranceWorld)
                            {
                                activeSnapPoint = ip;
                                activeSnapType = SnapType.Intersection;
                                return;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < arcs.Count; i++)
            {
                for (int j = i + 1; j < arcs.Count; j++)
                {
                    if (TryArcArcIntersection(arcs[i], arcs[j], out var points))
                    {
                        foreach (var ip in points)
                        {
                            if (Distance(mouseWorld, ip) < SnapToleranceWorld)
                            {
                                activeSnapPoint = ip;
                                activeSnapType = SnapType.Intersection;
                                return;
                            }
                        }
                    }
                }
            }
        }
        static bool TryLineIntersection(PointF a1, PointF a2, PointF b1, PointF b2, out PointF p)
        {
            p = default;

            float d = (a1.X - a2.X) * (b1.Y - b2.Y) -
                      (a1.Y - a2.Y) * (b1.X - b2.X);

            if (Math.Abs(d) < 0.0001f) return false;

            float xi = ((b1.X - b2.X) * (a1.X * a2.Y - a1.Y * a2.X) -
                        (a1.X - a2.X) * (b1.X * b2.Y - b1.Y * b2.X)) / d;

            float yi = ((b1.Y - b2.Y) * (a1.X * a2.Y - a1.Y * a2.X) -
                        (a1.Y - a2.Y) * (b1.X * b2.Y - b1.Y * b2.X)) / d;

            p = new PointF(xi, yi);
            return true;
        }
        static bool TryLineArcIntersection(PointF p1, PointF p2, netDxf.Entities.Arc arc, out List<PointF> result)
        {
            result = new List<PointF>();

            float cx = (float)arc.Center.X;
            float cy = (float)arc.Center.Y;
            float r = (float)arc.Radius;

            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;

            float fx = p1.X - cx;
            float fy = p1.Y - cy;

            float a = dx * dx + dy * dy;
            float b = 2 * (fx * dx + fy * dy);
            float c = fx * fx + fy * fy - r * r;

            float discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
                return false;

            discriminant = (float)Math.Sqrt(discriminant);

            float t1 = (-b - discriminant) / (2 * a);
            float t2 = (-b + discriminant) / (2 * a);

            if (t1 >= 0 && t1 <= 1)
            {
                var p = new PointF(p1.X + t1 * dx, p1.Y + t1 * dy);
                if (PointOnArc(p, arc))
                    result.Add(p);
            }

            if (t2 >= 0 && t2 <= 1)
            {
                var p = new PointF(p1.X + t2 * dx, p1.Y + t2 * dy);
                if (PointOnArc(p, arc))
                    result.Add(p);
            }

            return result.Count > 0;
        }
        static bool TryArcArcIntersection(Arc a1, Arc a2, out List<PointF> result)
        {
            result = new List<PointF>();

            float x0 = (float)a1.Center.X;
            float y0 = (float)a1.Center.Y;
            float r0 = (float)a1.Radius;

            float x1 = (float)a2.Center.X;
            float y1 = (float)a2.Center.Y;
            float r1 = (float)a2.Radius;

            float dx = x1 - x0;
            float dy = y1 - y0;
            float d = (float)Math.Sqrt(dx * dx + dy * dy);

            if (d > r0 + r1) return false;          // ayrı
            if (d < Math.Abs(r0 - r1)) return false; // biri diğerinin içinde
            if (d == 0 && r0 == r1) return false;    // sonsuz kesişim

            float a = (r0 * r0 - r1 * r1 + d * d) / (2 * d);
            float h = (float)Math.Sqrt(r0 * r0 - a * a);

            float xm = x0 + a * dx / d;
            float ym = y0 + a * dy / d;

            float xs1 = xm + h * dy / d;
            float ys1 = ym - h * dx / d;

            float xs2 = xm - h * dy / d;
            float ys2 = ym + h * dx / d;

            var p1 = new PointF(xs1, ys1);
            var p2 = new PointF(xs2, ys2);

            if (PointOnArc(p1, a1) && PointOnArc(p1, a2))
                result.Add(p1);

            if (PointOnArc(p2, a1) && PointOnArc(p2, a2))
                result.Add(p2);

            return result.Count > 0;
        }
        static bool PointOnArc(PointF p, netDxf.Entities.Arc arc)
        {
            double angle = Math.Atan2(
                p.Y - arc.Center.Y,
                p.X - arc.Center.X) * 180 / Math.PI;

            if (angle < 0)
                angle += 360;

            double start = arc.StartAngle;
            double end = arc.EndAngle;

            if (start < end)
                return angle >= start && angle <= end;

            return angle >= start || angle <= end;
        }
        public static void DrawBlock(Graphics g, Insert ins)
        {
            foreach (var entity in ins.Block.Entities)
            {
                if (entity is netDxf.Entities.Line line)
                {
                    // local block koordinatı
                    var p1 = TransformPoint(line.StartPoint, ins);
                    var p2 = TransformPoint(line.EndPoint, ins);

                    var s1 = ToScreen(p1.X, p1.Y);
                    var s2 = ToScreen(p2.X, p2.Y);

                    using var pen = new Pen(Color.Blue, 1);
                    g.DrawLine(pen, s1, s2);
                }

                if (entity is netDxf.Entities.Circle c)
                {
                    var center = TransformPoint(c.Center, ins);
                    var sc = ToScreen(center.X, center.Y);

                    float r = (float)(c.Radius * scale * ins.Scale.X);

                    using var pen = new Pen(Color.Blue, 1);
                    g.DrawEllipse(pen, sc.X - r, sc.Y - r, r * 2, r * 2);
                }
            }
        }
        static PointF TransformPoint(netDxf.Vector3 p, Insert ins)
        {
            double x = p.X * ins.Scale.X;
            double y = p.Y * ins.Scale.Y;

            // rotation varsa
            double angle = ins.Rotation * Math.PI / 180.0;

            double xr = x * Math.Cos(angle) - y * Math.Sin(angle);
            double yr = x * Math.Sin(angle) + y * Math.Cos(angle);

            return new PointF(
                (float)(xr + ins.Position.X),
                (float)(yr + ins.Position.Y)
            );
        }
        public static void DrawEntity(Graphics g, EntityObject e)
        {
            switch (e)
            {
                case Line line:
                    DrawLine(g, line);
                    break;

                case Circle circle:
                    DrawCircle(g, circle);
                    break;

                case Arc arc:
                    DrawArc(g, arc);
                    break;

                

                case Insert insert:
                    DrawInsert(g, insert);
                    break;
            }
        }
        static void DrawLine(Graphics g, Line line)
        {
            var p1 = ToScreen(line.StartPoint.X, line.StartPoint.Y);
            var p2 = ToScreen(line.EndPoint.X, line.EndPoint.Y);
            Color color = ResolveColor(line);
            double width = line.Thickness;
            using var pen = new Pen(color,1);
            g.DrawLine(pen, p1, p2);
                //if (line == selectedLine)
                //    g.DrawLine(Pens.Red, p1, p2);
                //else
                //    g.DrawLine(Pens.Black, p1, p2);
        }
        static void DrawArc(Graphics g, Arc arc)
        {
            var c = DxfDrawHelper.ToScreen(arc.Center.X, arc.Center.Y);
            float r = (float)(arc.Radius * DxfDrawHelper.scale);

            // DXF CCW: start -> end
            float a0 = (float)arc.StartAngle;
            float a1 = (float)arc.EndAngle;

            // CCW sweep'i [0,360) aralığına al
            float ccw = a1 - a0;
            if (ccw < 0) ccw += 360f;

            // Ekranda Y aşağı olduğu için yön tersine döner:
            // start'ı negate et, sweep'i de negate et (CW çizsin)
            float start = -a0;
            float sweep = -ccw;

            Color color = ResolveColor(arc);
            double width = arc.Thickness;
            using var pen = new Pen(color, (float)width);
            g.DrawArc(pen, c.X - r, c.Y - r, r * 2, r * 2, start, sweep);
        }
        public static void DrawSplines(Graphics g)
        {
            //var pts = SampleSpline(spline); // 60 segment yeterince pürüzsüz
            foreach (var spl in splineSegments)
            {


                if (spl.points.Count < 2)
                    return;

                using var pen = new Pen(spl.color, 1);

                for (int i = 0; i < spl.points.Count - 1; i++)
                {
                    var s1 = ToScreen(spl.points[i].X, spl.points[i].Y);
                    var s2 = ToScreen(spl.points[i + 1].X, spl.points[i + 1].Y);

                    g.DrawLine(pen, s1, s2);
                }
            }
            //var poly = spline.ToPolyline2D(60);

            //var verts = poly.Vertexes;

            //for (int i = 0; i < verts.Count - 1; i++)
            //{
            //    var p1 = ToScreen(verts[i].Position.X, verts[i].Position.Y);
            //    var p2 = ToScreen(verts[i + 1].Position.X, verts[i + 1].Position.Y);
            //    g.DrawLine(Pens.Black, p1, p2);
            //}
        }
        static void DrawCircle(Graphics g, Circle circle)
        {
            var c = DxfDrawHelper.ToScreen(circle.Center.X, circle.Center.Y);
            float r = (float)(circle.Radius * DxfDrawHelper.scale);

            Color color = ResolveColor(circle);
            double width = circle.Thickness;
            using var pen = new Pen(color, (float)width);
            g.DrawEllipse(pen, c.X - r, c.Y - r, r * 2, r * 2);
        }
        static void DrawInsert(Graphics g, Insert ins)
        {
            foreach (var entity in ins.Block.Entities)
            {
                DrawEntityTransformed(g, entity, ins);
            }
        }
        static void DrawEntityTransformed(Graphics g, EntityObject e, Insert ins)
        {
            switch (e)
            {
                case Line line:
                    var p1 = TransformPoint(line.StartPoint, ins);
                    var p2 = TransformPoint(line.EndPoint, ins);
                    Color color = ResolveColor(line, ins);
                    double width = line.Thickness;
                    DrawWorldLine(g, p1, p2,color,width);
                    break;

                case Circle c:
                    var center = TransformPoint(c.Center, ins);
                    float r = (float)(c.Radius * ins.Scale.X);
                    Color ccolor = c.Color.IsByLayer
                        ? GetLayerColor(c.Layer)
                        : AciToColor(c.Color);
                    double cwidth = c.Thickness;
                    DrawWorldCircle(g, center, r,ccolor, cwidth);
                    break;

                case Insert nested:
                    // block içinde block
                    var nestedInsert = CombineInsert(ins, nested);
                    DrawInsert(g, nestedInsert);
                    break;
            }
        }
        static void DrawWorldLine(Graphics g, PointF a, PointF b, Color color, double width)
        {

            var s1 = ToScreen(a.X, a.Y);
            var s2 = ToScreen(b.X, b.Y);
            using var pen = new Pen(color, (float)width);
            g.DrawLine(pen, s1, s2);
        }

        static void DrawWorldCircle(Graphics g, PointF center, float radius,Color color , double width)
        {
            var sc = ToScreen(center.X, center.Y);
            float r = radius * scale;
            using var pen = new Pen(color, (float)width);
            g.DrawEllipse(pen, sc.X - r, sc.Y - r, r * 2, r * 2);
        }
        static Insert CombineInsert(Insert parent, Insert child)
        {
            var combined = (Insert)child.Clone();

            combined.Position = new Vector3(
                parent.Position.X + child.Position.X,
                parent.Position.Y + child.Position.Y,
                0);

            combined.Scale = new Vector3(
                parent.Scale.X * child.Scale.X,
                parent.Scale.Y * child.Scale.Y,
                1);

            combined.Rotation = parent.Rotation + child.Rotation;

            return combined;
        }
        static Color AciToColor(AciColor aci)
        {
            if (aci == null)
                return Color.Black;

            // TrueColor varsa onu kullan
            if (aci.UseTrueColor)
                return Color.FromArgb(aci.R, aci.G, aci.B);

            return aci.Index switch
            {
                1 => Color.Red,
                2 => Color.Yellow,
                3 => Color.Green,
                4 => Color.Cyan,
                5 => Color.Blue,
                6 => Color.Magenta,
                //7 => Color.White,
                _ => Color.Black
            };
        }
        static Color ResolveColor(EntityObject entity, Insert parentInsert = null)
        {
            var aci = entity.Color;

            // 1️⃣ TrueColor varsa direkt kullan
            if (aci != null && aci.UseTrueColor)
                return Color.FromArgb(aci.R, aci.G, aci.B);

            // 2️⃣ ByBlock ise insert'ten al
            if (aci != null && aci.IsByBlock && parentInsert != null)
                return ResolveColor(parentInsert);

            // 3️⃣ ByLayer ise layer'dan al
            if (aci != null && aci.IsByLayer)
                return GetLayerColor(entity.Layer);

            // 4️⃣ Normal ACI
            if (aci != null)
                return AciToColor(aci);

            return Color.Black;
        }
        static Color GetLayerColor(netDxf.Tables.Layer layer)
        {
            if (layer == null)
                return Color.Black;

            var aci = layer.Color;

            if (aci.UseTrueColor)
                return Color.FromArgb(aci.R, aci.G, aci.B);

            return AciToColor(aci);
        }
        public static Circle FindCircleAt(PointF worldPoint)
        {
            double tolerance = 5.0 / scale; // zoom'a bağlı tolerans

            foreach (var c in dxfDoc.Entities.Circles)
            {
                var dx = worldPoint.X - c.Center.X;
                var dy = worldPoint.Y - c.Center.Y;

                var distance = Math.Sqrt(dx * dx + dy * dy);

                if (Math.Abs(distance - c.Radius) < tolerance)
                    return c;
            }

            return null;
        }
        public static List<PointF> ExtractCircleMarkupCenters()
        {
            var list = new List<PointF>();

            foreach (var c in dxfDoc.Entities.Circles)
            {
                // Örnek filtre (istersen layer / renk koyabilirsin)
                var color = ResolveColor(c);
                if (color != Color.Blue)
                    continue;

                list.Add(new PointF((float)c.Center.X, (float)c.Center.Y));
            }

            return list;
        }
        public static void DrawPlusMarkup(Graphics g, Circle c)
        {
            var screen = ToScreen(c.Center.X, c.Center.Y);

            float worldSize = 5f / scale;

            using var pen = new Pen(Color.Red, 2);

            g.DrawLine(pen,
                screen.X - worldSize, screen.Y,
                screen.X + worldSize, screen.Y);

            g.DrawLine(pen,
                screen.X, screen.Y - worldSize,
                screen.X, screen.Y + worldSize);
            var block = new Block("U_MARKUP");

            float size = 5f;
            Line line = new Line(
                new Vector3(c.Center.X - size, c.Center.Y, 0),
                new Vector3(c.Center.X + size, c.Center.Y, 0));
            line.Color = AciColor.Blue;
            dxfDoc.Entities.Add(line);
            Line line2 = new Line(
                new Vector3(c.Center.X, c.Center.Y - size, 0),
                new Vector3(c.Center.X, c.Center.Y + size, 0));
            line2.Color = AciColor.Blue;
            dxfDoc.Entities.Add(line2);
            dxfDoc.Entities.Remove(c);

            dxfDoc.Save("output.dxf");
        }
    }
    enum SnapType
    {
        None,
        Endpoint,
        Midpoint,
        Intersection,
        Center,
        Nearest
    }
    class SnapResult
    {
        public SnapType Type;
        public PointF Point;
        public double Distance;
    }
    class SnapEngine
    {
        public float ToleranceWorld = 5f;
        public DxfDocument dxfDoc;

        public SnapResult FindSnap(PointF mouseWorld)
        {
            var snaps = new List<SnapResult>();

            snaps.AddRange(CheckEndpoint(mouseWorld));
            snaps.AddRange(CheckMidpoint(mouseWorld));
            snaps.AddRange(CheckIntersection(mouseWorld));
            snaps.AddRange(CheckCenter(mouseWorld));

            return snaps
                .OrderBy(s => s.Distance)
                .FirstOrDefault();
        }
        List<SnapResult> CheckEndpoint(PointF mouse)
        {
            var result = new List<SnapResult>();

            foreach (var line in dxfDoc.Entities.Lines)
            {
                var p1 = new PointF((float)line.StartPoint.X, (float)line.StartPoint.Y);
                var p2 = new PointF((float)line.EndPoint.X, (float)line.EndPoint.Y);

                AddIfClose(result, p1, mouse, SnapType.Endpoint);
                AddIfClose(result, p2, mouse, SnapType.Endpoint);
            }

            return result;
        }
        List<SnapResult> CheckMidpoint(PointF mouse)
        {
            var result = new List<SnapResult>();

            foreach (var line in dxfDoc.Entities.Lines)
            {
                var mid = new PointF(
                    (float)((line.StartPoint.X + line.EndPoint.X) / 2),
                    (float)((line.StartPoint.Y + line.EndPoint.Y) / 2));

                AddIfClose(result, mid, mouse, SnapType.Midpoint);
            }

            return result;
        }
        List<SnapResult> CheckCenter(PointF mouse)
        {
            var result = new List<SnapResult>();

            foreach (var circle in dxfDoc.Entities.Circles)
            {
                var center = new PointF(
                    (float)circle.Center.X,
                    (float)circle.Center.Y);

                AddIfClose(result, center, mouse, SnapType.Center);
            }

            foreach (var arc in dxfDoc.Entities.Arcs)
            {
                var center = new PointF(
                    (float)arc.Center.X,
                    (float)arc.Center.Y);

                AddIfClose(result, center, mouse, SnapType.Center);
            }

            return result;
        }
        List<SnapResult> CheckIntersection(PointF mouse)
        {
            var result = new List<SnapResult>();

            foreach (var ip in FindAllIntersections())
                AddIfClose(result, ip, mouse, SnapType.Intersection);

            return result;
        }
        List<PointF> FindAllIntersections()
        {
            var result = new List<PointF>();

            var lines = dxfDoc.Entities.Lines.ToList();
            var arcs = dxfDoc.Entities.Arcs.ToList();

            result.AddRange(LineLineIntersections(lines));
            result.AddRange(LineArcIntersections(lines, arcs));
            result.AddRange(ArcArcIntersections(arcs));

            return result;
        }
        IEnumerable<PointF> LineLineIntersections(List<Line> lines)
        {
            var result = new List<PointF>();

            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = i + 1; j < lines.Count; j++)
                {
                    PointF a1 = new((float)lines[i].StartPoint.X, (float)lines[i].StartPoint.Y);
                    PointF a2 = new((float)lines[i].EndPoint.X, (float)lines[i].EndPoint.Y);

                    PointF b1 = new((float)lines[j].StartPoint.X, (float)lines[j].StartPoint.Y);
                    PointF b2 = new((float)lines[j].EndPoint.X, (float)lines[j].EndPoint.Y);

                    if (TryLineIntersection(a1, a2, b1, b2, out var ip))
                        result.Add(ip);
                }
            }

            return result;
        }
        IEnumerable<PointF> LineArcIntersections(List<Line> lines, List<Arc> arcs)
        {
            var result = new List<PointF>();

            foreach (var line in lines)
            {
                var p1 = new PointF((float)line.StartPoint.X, (float)line.StartPoint.Y);
                var p2 = new PointF((float)line.EndPoint.X, (float)line.EndPoint.Y);

                foreach (var arc in arcs)
                {
                    if (TryLineArcIntersection(p1, p2, arc, out var points))
                        result.AddRange(points);
                }
            }

            return result;
        }
        IEnumerable<PointF> ArcArcIntersections(List<Arc> arcs)
        {
            var result = new List<PointF>();

            for (int i = 0; i < arcs.Count; i++)
            {
                for (int j = i + 1; j < arcs.Count; j++)
                {
                    if (TryArcArcIntersection(arcs[i], arcs[j], out var points))
                        result.AddRange(points);
                }
            }

            return result;
        }
        bool TryLineIntersection(PointF a1, PointF a2, PointF b1, PointF b2, out PointF p)
        {
            p = default;

            float d = (a1.X - a2.X) * (b1.Y - b2.Y) -
                      (a1.Y - a2.Y) * (b1.X - b2.X);

            if (Math.Abs(d) < 0.0001f) return false;

            float xi = ((b1.X - b2.X) * (a1.X * a2.Y - a1.Y * a2.X) -
                        (a1.X - a2.X) * (b1.X * b2.Y - b1.Y * b2.X)) / d;

            float yi = ((b1.Y - b2.Y) * (a1.X * a2.Y - a1.Y * a2.X) -
                        (a1.Y - a2.Y) * (b1.X * b2.Y - b1.Y * b2.X)) / d;

            p = new PointF(xi, yi);
            return true;
        }
        bool TryLineArcIntersection(PointF p1, PointF p2, netDxf.Entities.Arc arc, out List<PointF> result)
        {
            result = new List<PointF>();

            float cx = (float)arc.Center.X;
            float cy = (float)arc.Center.Y;
            float r = (float)arc.Radius;

            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;

            float fx = p1.X - cx;
            float fy = p1.Y - cy;

            float a = dx * dx + dy * dy;
            float b = 2 * (fx * dx + fy * dy);
            float c = fx * fx + fy * fy - r * r;

            float discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
                return false;

            discriminant = (float)Math.Sqrt(discriminant);

            float t1 = (-b - discriminant) / (2 * a);
            float t2 = (-b + discriminant) / (2 * a);

            if (t1 >= 0 && t1 <= 1)
            {
                var p = new PointF(p1.X + t1 * dx, p1.Y + t1 * dy);
                if (PointOnArc(p, arc))
                    result.Add(p);
            }

            if (t2 >= 0 && t2 <= 1)
            {
                var p = new PointF(p1.X + t2 * dx, p1.Y + t2 * dy);
                if (PointOnArc(p, arc))
                    result.Add(p);
            }

            return result.Count > 0;
        }
        bool TryArcArcIntersection(Arc a1, Arc a2, out List<PointF> result)
        {
            result = new List<PointF>();

            float x0 = (float)a1.Center.X;
            float y0 = (float)a1.Center.Y;
            float r0 = (float)a1.Radius;

            float x1 = (float)a2.Center.X;
            float y1 = (float)a2.Center.Y;
            float r1 = (float)a2.Radius;

            float dx = x1 - x0;
            float dy = y1 - y0;
            float d = (float)Math.Sqrt(dx * dx + dy * dy);

            if (d > r0 + r1) return false;          // ayrı
            if (d < Math.Abs(r0 - r1)) return false; // biri diğerinin içinde
            if (d == 0 && r0 == r1) return false;    // sonsuz kesişim

            float a = (r0 * r0 - r1 * r1 + d * d) / (2 * d);
            float h = (float)Math.Sqrt(r0 * r0 - a * a);

            float xm = x0 + a * dx / d;
            float ym = y0 + a * dy / d;

            float xs1 = xm + h * dy / d;
            float ys1 = ym - h * dx / d;

            float xs2 = xm - h * dy / d;
            float ys2 = ym + h * dx / d;

            var p1 = new PointF(xs1, ys1);
            var p2 = new PointF(xs2, ys2);

            if (PointOnArc(p1, a1) && PointOnArc(p1, a2))
                result.Add(p1);

            if (PointOnArc(p2, a1) && PointOnArc(p2, a2))
                result.Add(p2);

            return result.Count > 0;
        }
        bool PointOnArc(PointF p, netDxf.Entities.Arc arc)
        {
            double angle = Math.Atan2(
                p.Y - arc.Center.Y,
                p.X - arc.Center.X) * 180 / Math.PI;

            if (angle < 0)
                angle += 360;

            double start = arc.StartAngle;
            double end = arc.EndAngle;

            if (start < end)
                return angle >= start && angle <= end;

            return angle >= start || angle <= end;
        }
        void AddIfClose(List<SnapResult> list, PointF p, PointF mouse, SnapType type)
        {
            double d = Distance(p, mouse);

            if (d < ToleranceWorld)
            {
                list.Add(new SnapResult
                {
                    Type = type,
                    Point = p,
                    Distance = d
                });
            }
        }
        float Distance(PointF p1, PointF p2)
        {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
