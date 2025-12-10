using Models;
using Models.DTO;
using NPOI.SS.Formula.Functions;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;

public class MalzemeTalepRaporu : IDocument
{
    public SatinalmaTalep Model { get; }

    public MalzemeTalepRaporu(SatinalmaTalep model)
    {
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
                c.RelativeColumn(5);
                c.RelativeColumn(5);
                c.RelativeColumn(5);
            });
            table.Cell().Row(1).Column(1).Element(e => calibri_12_bold(e, "Satın Alma Şekli :"));
            table.Cell().Row(1).Column(2).Element(e => calibri_12_bold(e, "Satın alma Komisyonu ile : ☐"));
            table.Cell().Row(1).Column(3).Element(e => calibri_12_bold(e, "Doğrudan Satınalma ile: ☐"));
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
        container
            .Padding(3)
            .Width(120)      // TAM SABİT GENİŞLİK
            .Height(60)      // TAM SABİT YÜKSEKLİK
            .Image("logo.png", ImageScaling.FitArea);
    }
    private void calibri_12_bold(IContainer container, string text)
    {
        container
        .Background("#FAFAFA")
        .Border(0.5f)
        .Padding(4)
        .AlignMiddle()
        .AlignLeft()
        .Text(text)
        .FontSize(12)
        .FontFamily("Calibri")
        .Bold()
        .LineHeight(1)
        .ClampLines(1);
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
