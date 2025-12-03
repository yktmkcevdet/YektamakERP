using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using YektamakDesktop.Formlar.Satinalma;

public class ExpandableGridManager
{
    private readonly DataGridView dgv;
    private readonly List<ExpandInfo> expandList = new();

    public ExpandableGridManager(DataGridView grid)
    {
        dgv = grid;
        dgv.Scroll += (s, e) => RepositionAll();
        dgv.SizeChanged += (s, e) => RepositionAll();
        dgv.CellPainting += dgv_CellPainting;
    }

    // Her grup satırı için bilgi tutuyor
    private class ExpandInfo
    {
        public DataGridViewRow Row;
        public Panel Panel;
        public DataGridView SubGrid;
        public bool IsExpanded;
        public int CollapsedHeight;
        public object Tag;
    }

    // Satıra info bağlama
    public void BindRow(DataGridViewRow row, SatinalmaTalepForGrup info)
    {
        var expand = new ExpandInfo
        {
            Row = row,
            Tag = info,
            CollapsedHeight = row.Height
        };

        expandList.Add(expand);
        row.Cells[0].Value = "+";
    }

    // Row’a tıklanınca çağır
    public void Toggle(DataGridViewRow row)
    {
        var exp = expandList.Find(x => x.Row == row);
        if (exp == null) return;

        if (!exp.IsExpanded)
            Expand(exp);
        else
            Collapse(exp);
    }

    // ---------------- EXPAND -----------------
    private void Expand(ExpandInfo exp)
    {
        var info = (SatinalmaTalepForGrup)exp.Tag;

        // Panel oluştur
        var panel = new Panel
        {
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.White,
            Width = dgv.Width - 60,
            AutoScroll = false
        };

        // SubGrid oluştur
        var sub = new DataGridView
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            RowHeadersVisible = false,
            AllowUserToAddRows = false,
            BorderStyle = BorderStyle.None,
            BackgroundColor = Color.White,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            ScrollBars = ScrollBars.None
        };

        sub.Columns.Add("Grup", "Grup");
        sub.Columns.Add("Talep", "Talep");
        sub.Columns.Add("Teklif", "Teklif");
        sub.Columns.Add("Yuzde", "%");

        foreach (var d in info.Details)
            sub.Rows.Add(d.Grup, d.satirSayisi, d.teklifSayisi, d.yuzde());

        // Yükseklik hesapla
        panel.Height = sub.Rows.Count * 24 + 25;

        panel.Controls.Add(sub);
        dgv.Controls.Add(panel);

        exp.Panel = panel;
        exp.SubGrid = sub;

        exp.IsExpanded = true;
        exp.Row.Cells[0].Value = "-";

        // Satır yüksekliği
        exp.Row.Height = exp.Panel.Height + 5;

        Position(exp);
    }

    // ---------------- COLLAPSE -----------------
    private void Collapse(ExpandInfo exp)
    {
        exp.IsExpanded = false;
        exp.Row.Height = exp.CollapsedHeight;
        exp.Row.Cells[0].Value = "+";

        if (exp.Panel != null)
        {
            dgv.Controls.Remove(exp.Panel);
            exp.Panel.Dispose();
        }

        exp.Panel = null;
        exp.SubGrid = null;
    }

    // ---------------- POSITION -----------------
    private void Position(ExpandInfo exp)
    {
        if (!exp.IsExpanded || exp.Panel == null) return;

        var rect = dgv.GetCellDisplayRectangle(0, exp.Row.Index, true);
        exp.Panel.Location = new Point(rect.Left + 40, rect.Bottom);
        exp.Panel.Width = dgv.Width - 60;
        exp.Panel.BringToFront();
    }

    // Tümünü yeniden konumlandır
    private void RepositionAll()
    {
        foreach (var x in expandList)
            Position(x);
    }

    // [+] eksi ikonunu çizmek istenirse (opsiyonel)
    private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == 0 && expandList.Exists(x => x.Row.Index == e.RowIndex))
        {
            e.PaintBackground(e.CellBounds, true);
            TextRenderer.DrawText(e.Graphics, e.FormattedValue?.ToString() ?? "",
                e.CellStyle.Font, e.CellBounds, Color.Black,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            e.Handled = true;
        }
    }
}
