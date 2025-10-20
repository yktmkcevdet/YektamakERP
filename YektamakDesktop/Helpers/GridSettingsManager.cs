using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
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

        public async Task Save(int? kullaniciId, string key, DataGridView dgv)
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
            await _configurationService.SaveGridSettings(gridSettings);
        }

        public async Task Load(int? kullaniciId, string key, List<DataGridViewColumn> dgv, DataGridView dataGridView)
        {
            GridSettings gridSettings = new GridSettings();
            gridSettings.grid=key;
            gridSettings.kullaniciId=kullaniciId;
            string jsonResult=await _configurationService.GetGridSettings(gridSettings);
            dataGridView.Columns.Clear();
            foreach (var col in dgv)
            {
                dataGridView.Columns.Add(col);
            }
            if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase)) return;
            gridSettings = JsonConvert.DeserializeObject<List<GridSettings>>(jsonResult).FirstOrDefault();
            var json = gridSettings.ayar;
            var columnSettings = JsonConvert.DeserializeObject<List<dynamic>>(json);
            dataGridView.SuspendLayout();
            foreach (var setting in columnSettings)
            {
                var c = dataGridView.Columns[setting.Name.ToString()];
                if (c != null)
                {
                    c.Width = (int)setting.Width;
                    c.DisplayIndex = (int)setting.DisplayIndex > dgv.Count - 1 ? dgv.Count - 1 : (int)setting.DisplayIndex;
                    c.Visible = (bool)setting.Visible;
                }
            }
            dataGridView.ResumeLayout();
        }
    }

}
