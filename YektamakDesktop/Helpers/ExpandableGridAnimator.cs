using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using YektamakDesktop.Formlar.Satinalma;

public class ExpandableGridAnimator
{
    private readonly DataGridView dgv;
    private readonly List<ExpandInfo> expandList = new();
    private readonly Timer animationTimer = new Timer();
    private const int AnimationDuration = 250; // Orta hız
    private const int TargetPanelPadding = 40;

    public ExpandableGridAnimator(DataGridView grid)
    {
        dgv = grid;

        dgv.Scroll += (s, e) => RepositionAll();
        dgv.SizeChanged += (s, e) => RepositionAll();
        dgv.CellPainting += dgv_CellPainting;

        animationTimer.Interval = 15;
        animationTimer.Tick += AnimationTick;
    }

    private class ExpandInfo
    {
        public DataGridViewRow Row;
        public object Tag;

        public Panel Panel;
        public DataGridView SubGrid;

        public bool IsExpanded = false;

        public int CollapsedHeight;
        public int ExpandedHeight;

        public double AnimationProgress = 0;
        public bool AnimOpening;   // Açılıyor mu?
        public bool AnimClosing;   // Kapanıyor mu?

        public Stopwatch Stopwatch = new Stopwatch();
    }

    // Bu satıra expand özelliği bağlanır
    public void BindRow(DataGridViewRow row, object tag)
    {
        var exp = new ExpandInfo
        {
            Row = row,
            Tag = tag,
            CollapsedHeight = row.Height
        };

        expandList.Add(exp);
        row.Cells[0].Value = "+";
    }

    // Tıklama ile aç/kapa
    public void Toggle(DataGridViewRow row)
    {
        var exp = expandList.Find(x => x.Row == row);
        if (exp == null) return;

        if (!exp.IsExpanded)
            StartExpand(exp);
        else
            StartCollapse(exp);
    }

    // ---------------- EXPAND -----------------
    private void StartExpand(ExpandInfo exp)
    {
        // Panel yoksa oluştur
        if (exp.Panel == null)
            BuildPanel(exp);

        exp.IsExpanded = true;
        exp.Row.Cells[0].Value = "-";

        exp.AnimOpening = true;
        exp.AnimClosing = false;

        exp.AnimationProgress = 0;
        exp.Stopwatch.Restart();

        animationTimer.Start();
    }

    // ---------------- COLLAPSE -----------------
    private void StartCollapse(ExpandInfo exp)
    {
        exp.IsExpanded = false;
        exp.Row.Cells[0].Value = "+";

        exp.AnimClosing = true;
        exp.AnimOpening = false;

        exp.AnimationProgress = 1;
        exp.Stopwatch.Restart();

        animationTimer.Start();
    }

    // ---------------- ANIMATION LOOP -----------------
    private void AnimationTick(object sender, EventArgs e)
    {
        bool anyRunning = false;

        foreach (var exp in expandList)
        {
            if (exp.Panel == null) continue;

            double t = exp.Stopwatch.ElapsedMilliseconds / (double)AnimationDuration;

            if (exp.AnimOpening)
            {
                if (t >= 1)
                {
                    exp.AnimationProgress = 1;
                    exp.AnimOpening = false;
                }
                else
                {
                    exp.AnimationProgress = t;
                    anyRunning = true;
                }
            }
            else if (exp.AnimClosing)
            {
                if (t >= 1)
                {
                    exp.AnimationProgress = 0;
                    exp.AnimClosing = false;

                    // Panel tamamen kapandı → gizle
                    exp.Panel.Visible = false;
                }
                else
                {
                    exp.AnimationProgress = 1 - t;
                    anyRunning = true;
                }
            }

            ApplyAnimation(exp);
        }

        if (!anyRunning)
            animationTimer.Stop();
    }

    // Animasyon hesaplaması
    private void ApplyAnimation(ExpandInfo exp)
    {
        double p = exp.AnimationProgress;

        // Fade
        exp.Panel.BackColor = Color.FromArgb(
            (int)(p * 255),
            245, 250, 255);

        // Shadow görünürlüğü
        exp.Panel.Visible = p > 0;

        // Slide: yukarıdan aşağı kayma
        int slideOffset = (int)((1 - p) * 20);
        Position(exp, slideOffset);

        // Height animasyonu
        int newHeight = (int)(exp.ExpandedHeight * p);
        exp.Row.Height = exp.CollapsedHeight + newHeight;
        exp.Panel.Height = newHeight;
    }

    // ---------------- PANEL OLUŞTURMA -----------------
    private void BuildPanel(ExpandInfo exp)
    {
        var info = (SatinalmaTalepForGrup)exp.Tag;

        // Modern tema: yuvarlak kenarlı mavi gölgeli panel
        var panel = new Panel
        {
            BorderStyle = BorderStyle.None,
            Padding = new Padding(10),
            BackColor = Color.FromArgb(0, 245, 250, 255),
            Width = dgv.Width - 60
        };

        // Mavi gölge efekti
        panel.Paint += (s, e) =>
        {
            using var shadow = new SolidBrush(Color.FromArgb(40, 0, 120, 215));
            var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            e.Graphics.FillRectangle(shadow, rect);
        };

        // Yuvarlak köşe
        panel.Region = System.Drawing.Region.FromHrgn(
            CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 12, 12));

        // SubGrid
        var sub = new DataGridView
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            RowHeadersVisible = false,
            AllowUserToAddRows = false,
            BackgroundColor = Color.White,
            BorderStyle = BorderStyle.None,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            ScrollBars = ScrollBars.None
        };

        sub.Columns.Add("Grup", "Grup");
        sub.Columns.Add("Talep", "Talep");
        sub.Columns.Add("Teklif", "Teklif");
        sub.Columns.Add("Yuzde", "%");

        foreach (var d in info.Details)
            sub.Rows.Add(d.Grup, d.satirSayisi, d.teklifSayisi, d.yuzde());

        // Panel yüksekliği
        panel.Height = sub.Rows.Count * 24 + 25;
        exp.ExpandedHeight = panel.Height;

        panel.Controls.Add(sub);
        dgv.Controls.Add(panel);

        exp.Panel = panel;
        exp.SubGrid = sub;

        panel.Visible = false;

        Position(exp);
    }

    // ---------------- KONUM -----------------
    private void Position(ExpandInfo exp, int offsetY = 0)
    {
        if (exp.Panel == null) return;

        var rect = dgv.GetCellDisplayRectangle(0, exp.Row.Index, true);

        exp.Panel.Location = new Point(
            rect.Left + TargetPanelPadding,
            rect.Bottom + offsetY
        );

        exp.Panel.Width = dgv.Width - 60;
    }

    private void RepositionAll()
    {
        foreach (var exp in expandList)
            Position(exp);
    }

    // ---------------- (+)(-) İKON ÇİZİMİ -----------------
    private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == 0 && expandList.Exists(x => x.Row.Index == e.RowIndex))
        {
            e.PaintBackground(e.CellBounds, true);

            string text = (string)e.FormattedValue;

            TextRenderer.DrawText(e.Graphics, text,
                e.CellStyle.Font, e.CellBounds, Color.Black,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter);

            e.Handled = true;
        }
    }

    // WinAPI - yuvarlak panel
    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    private static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect, int nTopRect, int nRightRect,
        int nBottomRect, int nWidthEllipse, int nHeightEllipse
    );
}
