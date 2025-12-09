using Models;
using Models.DTO;
using NPOI.SS.Formula.Functions;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;

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
                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Bu belge Yektamak ERP tarafından otomatik oluşturulmuştur. ")
                     .FontSize(8).Italic();
                });
            });
    }

    private void ComposeHeader(IContainer container)
    {
        container.Row(row =>
        {
            row.Spacing(5);

            // --- 1. Sütun (26%) - Logo ---
            row.RelativeItem(2).Column(col =>
            {
                col.Item().Height(60).Image("logo.png", ImageScaling.FitWidth);
            });

            // --- 2. Sütun (55%) - Orta Başlık ---
            row.RelativeItem(7).AlignCenter().Column(col =>
            {
                col.Item().Height(60).Text("MALZEME TALEP FORMU")
                    .FontSize(18)
                    .Bold()
                    .AlignCenter();
            });

            // --- 3. Sütun (19%) - 3 satır x 2 sütun tablo ---
            row.RelativeItem(3).Column(col =>
            {
                col.Item().Height(60).Table(table =>
                {
                    table.ColumnsDefinition(c =>
                    {
                        c.RelativeColumn();
                        c.RelativeColumn();
                    });

                    // 3 satır
                    HeaderRightCell(table, "Talep Eden:", "Berat Vayni");
                    HeaderRightCell(table, "Tarih:", DateTime.Now.ToShortDateString());
                    HeaderRightCell(table, "Talep Nedeni:", "Sarf");
                    HeaderRightCell(table, "Talep blablabla blablabla:", "Sarf");
                });
            });
        });
    }
    void HeaderRightCell(TableDescriptor table, string left, string right)
    {
        table.Cell()
             .Border(0.3f)
             .Padding(2)
             .AlignLeft()
             .Text(left).FontSize(9);

        table.Cell()
             .Border(0.3f)
             .Padding(2)
             .AlignLeft()
             .Text(right).FontSize(9);
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
