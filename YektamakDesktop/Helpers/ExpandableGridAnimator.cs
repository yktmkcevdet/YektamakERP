using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
        dgv.Columns.Clear();
        dgv.Columns.Add(nameof(SatinalmaTalepForMusteri.projeKod), "Proje");
        dgv.Columns.Add(nameof(SatinalmaTalepForMusteri.satirSayisi), "Talep");
        dgv.Columns.Add(nameof(SatinalmaTalepForMusteri.teklifSayisi), "Teklif");
        dgv.Columns.Add(nameof(SatinalmaTalepForMusteri.yuzde), "%");
        dgv.Columns[nameof(SatinalmaTalepForMusteri.yuzde)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgv.Columns[nameof(SatinalmaTalepForMusteri.yuzde)].DefaultCellStyle.Format = "N2";

        dgv.Scroll += (s, e) => RepositionAll();
        dgv.SizeChanged += (s, e) => RepositionAll();
        dgv.CellPainting += dgv_CellPainting;
        dgv.CellClick += dgv_CellClick;

        animationTimer.Interval = 15;
        animationTimer.Tick += AnimationTick;
    }

    public class ExpandInfo
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
    }
    private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == -1)
            Toggle(dgv.Rows[e.RowIndex]);
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
        exp.Row.DefaultCellStyle.Alignment=DataGridViewContentAlignment.TopLeft;
        // Modern tema: yuvarlak kenarlı mavi gölgeli panel
        var panel = new Panel
        {
            BorderStyle = BorderStyle.None,
            Padding = new Padding(5),
            BackColor = Color.FromArgb(0, 245, 250, 255),
            Width = dgv.Width - 60,
            AutoScroll = true
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
        panel.Height = sub.Rows.Count * 35 + 25;
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

        var rect = dgv.GetCellDisplayRectangle(-1, exp.Row.Index-1, true);

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
        if (e.ColumnIndex == -1 && e.RowIndex >= 0)
        {
            // Expandable row mu?
            var exp = GetExpandInfo(dgv.Rows[e.RowIndex]);
            if (exp == null) return;

            e.PaintBackground(e.CellBounds, true);

            string icon = exp.IsExpanded ? "-" : "+";

            TextRenderer.DrawText(
                e.Graphics,
                icon,
                e.CellStyle.Font,
                e.CellBounds,
                Color.Black,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );

            e.Handled = true;
        }
        // Başlık satırlarını veya boş alanları boyama
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
            return;

        // Yüzde değeri hangi sütundaysa kontrol et (örneğin "Yuzde" isimli sütun)
        if (dgv.Columns[e.ColumnIndex].Name == "yuzde")
        {
            e.Handled = true; // Varsayılan boyamayı engelle
            e.PaintBackground(e.CellBounds, true);
            e.PaintContent(e.CellBounds);

            // Hücredeki değeri al
            if (e.Value != null && double.TryParse(e.Value.ToString().Replace("%", ""), out double value))
            {
                // 0–100 aralığına çek
                value = Math.Max(0, Math.Min(100, value));

                // Dolum oranına göre genişlik hesapla
                int fillWidth = (int)(e.CellBounds.Width * (value / 100.0));

                // Renk (örneğin yeşil)
                using (Brush b = new SolidBrush(Color.LightGreen))
                {
                    Rectangle fillRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y, fillWidth, e.CellBounds.Height);
                    e.Graphics.FillRectangle(b, fillRect);
                }

                // Kenarlık ve metni yeniden çiz
                e.PaintContent(e.CellBounds);
                e.Graphics.DrawRectangle(Pens.Gray, e.CellBounds);
            }
        }
    }
    public ExpandInfo GetExpandInfo(DataGridViewRow row)
    {
        return expandList.FirstOrDefault(x => x.Row == row);
    }
    // WinAPI - yuvarlak panel
    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    private static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect, int nTopRect, int nRightRect,
        int nBottomRect, int nWidthEllipse, int nHeightEllipse
    );
}
