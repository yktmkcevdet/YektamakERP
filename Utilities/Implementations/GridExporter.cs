using ClosedXML.Excel;
using Models;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public class GridExporter: IGridExporter
    {
        public void ExportToExcel<T>(List<T> data, Dictionary<string, string> selectedColumns)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Data");

            int i = 0;
            // 🔹 Header yaz
            foreach (var column in selectedColumns)
            {
                worksheet.Cell(1, i + 1).Value = column.Value;
                i++;
            }

            // 🔹 Data yaz
            for (int row = 0; row < data.Count; row++)
            {
                var item = data[row];
                int col = 0;
                foreach (var column in selectedColumns)
                {
                    // column burada string olduğundan PropertyName yok; doğrudan property ismini kullan
                    var prop = typeof(T).GetProperty(column.Key);
                    var value = prop?.GetValue(item);

                    if (value is DateTime dt)
                        worksheet.Cell(row + 2, col + 1).Value = dt;
                    else if (value is bool b)
                        worksheet.Cell(row + 2, col + 1).Value = b ? "Evet" : "Hayır";
                    else if (value is decimal d)
                        worksheet.Cell(row + 2, col + 1).Value = d;
                    else if (value is int ts)
                        worksheet.Cell(row + 2, col + 1).Value = ts;
                    else if (value is float f)
                        worksheet.Cell(row + 2, col + 1).Value = f;
                    else if (value is double dbl)
                        worksheet.Cell(row + 2, col + 1).Value = dbl;
                    else
                        worksheet.Cell(row + 2, col + 1).Value = value?.ToString();
                    col++;

                }
            }

            // 🔹 Autofit (mis gibi görünüm)
            worksheet.Columns().AdjustToContents();

            // 🔹 Kaydet
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Export2.xlsx");
            workbook.SaveAs(path);
        }
    }
}
