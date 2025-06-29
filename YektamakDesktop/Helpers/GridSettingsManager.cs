using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.Helpers
{
    public static class GridSettingsManager
    {
        public static void Save(string file, string key, DataGridView dgv)
        {
            // Daha önce kayıtlı tüm ayarları oku (varsa)
            Dictionary<string, List<object>> allSettings = new();

            if (File.Exists(file))
            {
                string json = File.ReadAllText(file);
                allSettings = JsonConvert.DeserializeObject<Dictionary<string, List<object>>>(json)
                              ?? new Dictionary<string, List<object>>();
            }

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

            // Mevcut key'i güncelle
            allSettings[key] = settings;

            // JSON olarak dosyaya yaz
            string updatedJson = JsonConvert.SerializeObject(allSettings, Formatting.Indented);
            File.WriteAllText(file, updatedJson);
        }

        public static void Load(string file, string key, DataGridView dgv)
        {
            if (!File.Exists(file)) return;

            var json = File.ReadAllText(file);
            var allGrids = JsonConvert.DeserializeObject<Dictionary<string, List<dynamic>>>(json);

            if (!allGrids.ContainsKey(key)) return;

            var columnSettings = allGrids[key];

            foreach (var c in columnSettings)
            {
                var col = dgv.Columns[c.Name.ToString()];
                if (col != null)
                {
                    col.Width = (int)c.Width;
                    col.DisplayIndex = (int)c.DisplayIndex;
                    col.Visible = (bool)c.Visible;
                }
            }
        }
    }

}
