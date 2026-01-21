using ApiService.Interfaces;
using Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

public class MalzemeTalepRaporu : IDocument
{
    private readonly IFileService _fileService;
    public SatinalmaTalep Model { get; }

    public MalzemeTalepRaporu(SatinalmaTalep model,IFileService fileService)
    {
        _fileService = fileService;
        Model = model;
    }

    public DocumentMetadata GetMetadata() => new DocumentMetadata()
    {
        Title = "Malzeme Talep Formu"
    };

    //public DocumentSettings GetSettings() => new DocumentSettings
    //{
    //    Margin = 25
    //};

    public void Compose(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Margin(20);
                page.Size(PageSizes.A4);

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().Element(ComposeFooter);
            });
    }

    private void ComposeFooter(IContainer container)
    {
        container.Table(table =>
        {
            table.ColumnsDefinition(c =>
            {
                c.RelativeColumn(39) ;
                c.RelativeColumn(164.25f);
                c.RelativeColumn(57);
                c.RelativeColumn(30);
                c.RelativeColumn(48);
                c.RelativeColumn(48);
                c.RelativeColumn(25.5f);
                c.RelativeColumn(25);
                c.RelativeColumn(48);
                c.RelativeColumn(26.25f);
                c.RelativeColumn(26.25f);
                c.RelativeColumn(15.75f);
                c.RelativeColumn(39.75f);
                c.RelativeColumn(51); 
                c.RelativeColumn(39.75f);
                c.RelativeColumn(39.75f);
                c.RelativeColumn(39.75f);
                c.RelativeColumn(39.75f);
                c.RelativeColumn(39.75f);
                c.RelativeColumn(39.75f);
                c.RelativeColumn(39.75f);
                c.RelativeColumn(106.5f);
            });
            table.Cell().Row(1).Column(1).ColumnSpan(4).Height(30).Element(e => MidBold(e, "Satın Alma Şekli :","#FAFAFA",0.5f,"calibri",12,1));
            table.Cell().Row(1).Column(5).ColumnSpan(10).Height(30).Element(e => MidBold(e, "Satın alma Komisyonu ile : ☐", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(1).Column(15).ColumnSpan(8).Height(30).Element(e => MidBold(e, "Doğrudan Satınalma ile: ☐", "#FFFFFF", 0.5f, "calibri", 12, 1));
            
            table.Cell().Row(2).Column(1).ColumnSpan(8).Height(20).Element(e => MidBold(e, "Talep Sahibi", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(2).Column(9).ColumnSpan(7).Height(20).Element(e => MidBold(e, "Birim Amiri Onayı", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(2).Column(16).ColumnSpan(7).Height(20).Element(e => MidBold(e, "Yönetici Onayı", "#FFFFFF", 0.5f, "calibri", 12, 1));

            table.Cell().Row(3).Column(1).ColumnSpan(8).Height(20).Element(e => MidBold(e, "Görevi :", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(3).Column(9).ColumnSpan(7).Height(20).Element(e => MidBold(e, "", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(3).Column(16).ColumnSpan(7).Height(20).Element(e => MidBold(e, "", "#FFFFFF", 0.5f, "calibri", 12, 1));

            table.Cell().Row(4).Column(1).ColumnSpan(8).Height(20).Element(e => MidBold(e, "İmza :", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(4).Column(9).ColumnSpan(7).Height(20).Element(e => MidBold(e, "", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(4).Column(16).ColumnSpan(7).Height(20).Element(e => MidBold(e, "", "#FFFFFF", 0.5f, "calibri", 12, 1));

            table.Cell().Row(5).Column(1).ColumnSpan(22).Height(80).Element(e => MidBold(e, "Not :\r\n         *  İmzalanan formlar taranarak satın alma birimine soft copy olarak gönderilir.\r\n         *  Islak İmzalı formlar ilgili birimde arşivlenir.\r\n         *  Satın alma grubu gerekli inceleme sonrası LOGO programı üzerinden satınalma sürecini başlatır.", "#FFFFFF", 0.5f, "calibri", 12, 4));

            table.Cell().Row(6).Column(1).ColumnSpan(22).Height(20).Element(e => MidNormal(e, "Komisyon için İlgili Birimler:", "#FFFFFF", 0.5f, "calibri", 12, 1));

            table.Cell().Row(7).Column(1).ColumnSpan(3).Height(20).Element(e => MidNormal(e, "Kalite", "#FFFFFF", 0, "calibri", 12, 1));
            table.Cell().Row(7).Column(4).ColumnSpan(1).Height(20).Element(e => MidNormal(e, ":", "#FFFFFF", 0, "calibri", 12, 2));
            table.Cell().Row(7).Column(5).ColumnSpan(18).Height(20).Element(e => MidBold(e, "☐", "#FFFFFF", 0, "calibri", 12, 1));

            table.Cell().Row(8).Column(1).ColumnSpan(3).Height(20).Element(e => MidNormal(e, "Ar-Ge", "#FFFFFF", 0.5f, "calibri", 12,1));
            table.Cell().Row(8).Column(4).ColumnSpan(1).Height(20).Element(e => MidNormal(e, ":", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(8).Column(5).ColumnSpan(18).Height(20).Element(e => MidNormal(e, "☐", "#FFFFFF", 0.5f, "calibri", 12, 1));

            table.Cell().Row(9).Column(1).ColumnSpan(3).Height(20).Element(e => MidNormal(e, "Finans/Muhasebe", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(9).Column(4).ColumnSpan(1).Height(20).Element(e => MidNormal(e, ":", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(9).Column(5).ColumnSpan(18).Height(20).Element(e => MidNormal(e, "☐", "#FFFFFF", 0.5f, "calibri", 12, 1));

            table.Cell().Row(10).Column(1).ColumnSpan(3).Height(20).Element(e => MidNormal(e, "İnsan Kaynakları", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(10).Column(4).ColumnSpan(1).Height(20).Element(e => MidNormal(e, ":", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(10).Column(5).ColumnSpan(18).Height(20).Element(e => MidNormal(e, "☐", "#FFFFFF", 0.5f, "calibri", 12, 1));

            table.Cell().Row(11).Column(1).ColumnSpan(3).Height(20).Element(e => MidNormal(e, "Üretim", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(11).Column(4).ColumnSpan(1).Height(20).Element(e => MidNormal(e, ":", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(11).Column(5).ColumnSpan(18).Height(20).Element(e => MidNormal(e, "☐", "#FFFFFF", 0.5f, "calibri", 12, 1));

            table.Cell().Row(12).Column(1).ColumnSpan(3).Height(20).Element(e => MidNormal(e, "Satın Alma ", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(12).Column(4).ColumnSpan(1).Height(20).Element(e => MidNormal(e, ":", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(12).Column(5).ColumnSpan(18).Height(20).Element(e => MidNormal(e, "☐", "#FFFFFF", 0.5f, "calibri", 12, 1));

            table.Cell().Row(13).Column(1).ColumnSpan(3).Height(20).Element(e => MidNormal(e, "Genel Müdür", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(13).Column(4).ColumnSpan(1).Height(20).Element(e => MidNormal(e, ":", "#FFFFFF", 0.5f, "calibri", 12, 1));
            table.Cell().Row(13).Column(5).ColumnSpan(18).Height(20).Element(e => MidNormal(e, "☐", "#FFFFFF", 0.5f, "calibri", 12, 1));
        });

    }

    private void ComposeHeader(IContainer container)
    {
        container.Table(table =>
        {
            // 4 sütunlu sabit yapı
            table.ColumnsDefinition(c =>
            {
                c.RelativeColumn(26);   // 1. sütun (logo)
                c.RelativeColumn(27);   // 2. sütun (başlığın ilk yarısı)
                c.RelativeColumn(28);   // 3. sütun (başlığın ikinci yarısı)
                c.RelativeColumn(19);   // 4. sütun (sağ mini tablo)
            });

            // ===== 1. SATIR =====
            // 1. sütun: logo
            table.Cell().Row(1).Column(1).Element(Header_LogoCell);

            // 2+3. sütunlar: başlık (iki sütunu birleştiriyoruz)
            table.Cell().Row(1).Column(2).ColumnSpan(2).Element(Header_TitleCell);

            // 4. sütun: sağ mini tablo
            table.Cell().Row(1).Column(4).Element(Header_RightMiniTable);

            // ===== 2. SATIR (tek hücre, 4 sütunu birleştiriyoruz) =====
            table.Cell().Row(2).Column(1).ColumnSpan(4)
                .Padding(5).BorderBottom(0.5f)
                .Text("Bu alana tek satırlık açıklama veya üst bilgi yazılabilir.")
                .FontSize(10);

            // ===== 3. SATIR (4 sütun) =====
            for (uint col = 1; col <= 4; col++)
            {
                table.Cell().Row(3).Column(col)
                     .Padding(3).Border(0.5f)
                     .Text($"3. Satır – Sütun {col}")
                     .FontSize(9);
            }

            // ===== 4. SATIR (4 sütun) =====
            for (uint col = 1; col <= 4; col++)
            {
                table.Cell().Row(4).Column(col)
                     .Padding(3).Border(0.5f)
                     .Text($"4. Satır – Sütun {col}")
                     .FontSize(9);
            }
        });
    }
    private void Header_LogoCell(IContainer container)
    {
        var logoPath = Path.Combine(AppContext.BaseDirectory, "logo.png");
        container
            .Padding(3)
            .Width(120)
            .Height(60)
            .Image(logoPath);
    }
    private void MidBold(IContainer container, string text,string color,float border,string fontFamily,float fontSize,int clampLines)
    {
        container
        .Background(color)
        .Border(border).BorderRight(0).BorderTop(0)
        .Padding(4)
        .AlignMiddle()
        .Text(text)
        .FontSize(fontSize)
        .FontFamily(fontFamily)
        .Bold()
        .LineHeight(1)
        .ClampLines(clampLines);
    }
    private void MidNormal(IContainer container, string text, string color, float border, string fontFamily, float fontSize, int clampLines)
    {
        container
        .Background(color)
        .Border(border)
        .Padding(4)
        .AlignMiddle()
        .Text(text)
        .FontSize(fontSize)
        .FontFamily(fontFamily)
        .LineHeight(1)
        .ClampLines(clampLines);
    }
    private void Header_TitleCell(IContainer container)
    {
        container
            .Padding(3)
            .AlignCenter()
            .AlignMiddle()
            .Height(60)
            .Text("MALZEME TALEP FORMU")
            .FontSize(20)
            .Bold();
    }
    private void Header_RightMiniTable(IContainer container)
    {
        container.Table(t =>
        {
            t.ColumnsDefinition(c =>
            {
                c.RelativeColumn();
                c.RelativeColumn();
            });

            HeaderRightRow(t, "Döküman No:", "PR-10-F-11");
            HeaderRightRow(t, "Yürürlük Tarihi:", "20.03.2023");
            HeaderRightRow(t, "Rev. No:", "1");
            HeaderRightRow(t, "Rev. Tarihi:", "20.01.2025");
        });
    }

    private void HeaderRightRow(TableDescriptor table, string left, string right)
    {
        table.Cell().Border(0.3f).Padding(2).Text(left).FontSize(9);
        table.Cell().Border(0.3f).Padding(2).Text(right).FontSize(9);
    }
    
    private void ComposeContent(IContainer container)
    {
        BuildTable(container,Model.satinalmaTalepDetays);
        
    }
    private void BuildTable(IContainer container, List<SatinalmaTalepDetay> rows)
    {
        container
            .Table(table =>
            {
                // Tablodaki kolon sayısı
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(1);   // Sıra No
                    columns.RelativeColumn(4.5f);   // Ürün Kodu
                    columns.RelativeColumn(6);   // Ürün Özellikleri
                    columns.RelativeColumn(1.5f);   // Adet
                    columns.RelativeColumn(2);   // Birim
                    columns.RelativeColumn(8);   // Açıklama
                });


                // --- TABLO HEADER ---
                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("SIRA NO");
                    header.Cell().Element(CellStyle).Text("ÜRÜN KODU");
                    header.Cell().Element(CellStyle).Text("ÜRÜN ÖZELLİKLERİ");
                    header.Cell().Element(CellStyle).Text("ADET");
                    header.Cell().Element(CellStyle).Text("BİRİM");
                    header.Cell().Element(CellStyle).Text("AÇIKLAMA");
                });
                int i = 0;
                // --- VERİ SATIRLARI ---
                foreach (var row in rows)
                {
                    i++;
                    table.Cell().Element(CellStyle).Text(i.ToString());
                    table.Cell().Element(CellStyle).Text(row.projeStokKart.stokKart.kod);
                    table.Cell().Element(CellStyle).Text(row.projeStokKart.stokKart.ad);
                    table.Cell().Element(CellStyle).Text(row.miktar.ToString());
                    table.Cell().Element(CellStyle).Text(row.projeStokKart.stokKart.olcuBirim.ad);
                    table.Cell().Element(CellStyle).Text(row.aciklama);
                }
            });
    }

    // ----------------- HÜCRE TASARIMI -------------------

    private IContainer CellStyle(IContainer container)
    {
        return container
            .Border(0.1f)         // İnce border
            .Padding(3)           // İç boşluk
            .MinHeight(15)        // Satır yüksekliği sabit
            .AlignMiddle()        // Dikey ortalama
            .AlignLeft()
            .DefaultTextStyle(x => x.FontSize(9));   // TÜM Text için font;         // Yatay hizalama
    }
}

