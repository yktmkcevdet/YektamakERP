using Models;

namespace Utilities.Interfaces
{
    public interface IGridExporter
    {
       public void ExportToExcel<T>(List<T> data, Dictionary<string, string> selectedColumns);
     
    }
}
