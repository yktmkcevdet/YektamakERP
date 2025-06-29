using Microsoft.AspNetCore.Components;
using Models;
using System.Data;
using Utilities.Implementations;
using Utilities.Interfaces;
using ApiService.Interfaces;

namespace YektamakWeb.Pages
{
    partial class ProjeDosyalari
    {
        [Inject]
        private IStokService _stokService { get; set; }
        [Inject]
        IDataTableMapper _dataTableMapper { get; set; }
        public List<StokKart> stokKarts = new List<StokKart>();
        private string message;
        private int selectedProjeId;
        [Inject]
        private NavigationManager? navigation { get; set; }
        private async Task GetProjeDosyalari()
        {
            try
            {
                // API çağrısı yap
                StokKart stokKart = new StokKart();
                stokKart.proje.Id = selectedProjeId;
                string serializeString = _stokService.GetStokKart(stokKart).Result;
                IJsonConverter jsonConvertHelper = new JsonConverter();
                DataSet dataSet = jsonConvertHelper.DeserializeToDataSet(serializeString);
                if (dataSet != null)
                {
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        stokKart = _dataTableMapper.MapToEntity<StokKart>(dataRow);
                        stokKarts.Add(stokKart);
                    }
                }
            }
            catch (Exception ex)
            {
                message = $"Veri çekme hatası: {ex.Message}";
            }
        }

        public void PdfGoster(StokKart stokKart)
        {
            message = stokKart.ad;
            navigation?.NavigateTo($"/PdfViewer/{stokKart.Id}");
        }
    }
}
