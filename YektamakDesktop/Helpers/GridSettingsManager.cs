using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;

namespace YektamakDesktop.Helpers
{
    public class GridSettingsManager
    {
        private readonly IConfigurationService _configurationService;
        private readonly IJsonConverter _jsonConverter;

        public GridSettingsManager(IConfigurationService configurationService, IJsonConverter jsonConverter)
        {
            _configurationService = configurationService;
            _jsonConverter = jsonConverter;
        }

        public void Save(int? kullaniciId, string key, DataGridView dgv)
        {
            if (dgv == null || dgv.Columns.Count == 0 || string.IsNullOrEmpty(key))
                return;

            // Yeni ayarları oluştur
            var settings = dgv.Columns.Cast<DataGridViewColumn>()
                .Select(c => new
                {
                    c.Name,
                    c.Width,
                    c.DisplayIndex,
                    c.Visible
                })
                .Cast<object>()
                .ToList();

            // JSON olarak dosyaya yaz
            string updatedJson = JsonConvert.SerializeObject(settings, Formatting.Indented);
            GridSettings gridSettings=new GridSettings();
            gridSettings.grid=key;
            gridSettings.ayar=updatedJson;
            gridSettings.kullaniciId = kullaniciId;
            _configurationService.SaveGridSettings(gridSettings);
        }

        public async void Load(int? kullaniciId, string key, DataGridView dgv)
        {
            GridSettings gridSettings = new GridSettings();
            gridSettings.grid=key;
            gridSettings.kullaniciId=kullaniciId;
            string jsonResult=await _configurationService.GetGridSettings(gridSettings);
            Result result=_jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
            if (result?.result == null) return; 
            gridSettings = _jsonConverter.ToModelList<GridSettings>(result.result).FirstOrDefault();
            var json = gridSettings.ayar;
            var allGrids = JsonConvert.DeserializeObject<List<dynamic>>(json);

            var columnSettings = allGrids;

            foreach (var c in columnSettings)
            {
                var col = dgv.Columns[c.Name.ToString()];
                if (col != null)
                {
                    col.Width = (int)c.Width;
                    col.DisplayIndex = (int)c.DisplayIndex>dgv.Columns.Count -1 ? dgv.Columns.Count-1: (int)c.DisplayIndex;
                    col.Visible = (bool)c.Visible;
                }
            }
        }
    }

}
