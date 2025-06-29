using Models;
using Models.Attributes;
using Models.DTO;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using YektamakDesktop.Helpers;

namespace YektamakDesktop.CustomControls
{
    public partial class UniversalGrid : UserControl
    {
        public BindingSource binding = new BindingSource();
        List<object> changedItems = new List<object>();
        string settingsFile = "grid.settings.json";
        [Browsable(true)]
        [Category("Behavior")]
        public event MouseEventHandler MouseDown1;
        public Kullanici kullanici { get; set; }


        public UniversalGrid()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }
        // DataGrid'e dışarıdan erişim de istersen:
        public DataGridView Grid => dataGridView1;
        private List<object> list1;
        public async void SetData<T>(List<T> list, string formName, bool isGuncelle = false, bool isDelete = false, bool isCheck = false) where T : IEntity
        {
            await ConfigureColumns<T>(formName, isGuncelle, isDelete, isCheck);
            binding.DataSource = list;
            dataGridView1.DataSource = binding;
            list1= list.Cast<object>().ToList();
            LoadSettings(formName);
        }
        public void AddRow<T>(List<T> list) where T : IEntity, new()
        {
            list.Add(new T());
            binding.DataSource = list;
        }
        private static readonly ConcurrentDictionary<Type, IEnumerable<PropertyAttributePair>> _propertyCache = new();
        private static readonly Bitmap _updateIcon = Properties.Resources.data_update_icon1;
        private static readonly Bitmap _deleteIcon = Properties.Resources.sil1;


        private async Task ConfigureColumns<T>(string formName, bool isGuncelle = false, bool isDelete = false, bool isCheck = false)
        {
            dataGridView1.Columns.Clear();

            // Önbellek yapısı: Her property için PropertyInfo ve Attribute'u sakla
            var props = _propertyCache.GetOrAdd(typeof(T), type =>
                typeof(T).GetProperties()
                    .Select(p => new PropertyAttributePair( 
                        Property: p,
                        Attribute: p.GetCustomAttribute<GridDisplayAttribute>()
                    ))
                    .Where(x => x.Attribute?.Visible == true)
                    .ToList()
            );

            // İzin kontrolü için alan adlarını topla
            var fieldNames = props.Select(x => x.Attribute.Header).ToList();
            var allowedFields = await GetAllowedFields(formName, fieldNames);

            // Checkbox sütunu
            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Sec",
                HeaderText = "",
                DataPropertyName = "Sec",
                Visible = isCheck?true:false,
            });

            // Ana sütunlar
            foreach (var pair in props)
            {
                if (!allowedFields.Contains(pair.Attribute.Header)) continue;

                var col = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = pair.Property.Name,
                    HeaderText = pair.Attribute.Header,
                    Name = pair.Attribute.Header,
                    ReadOnly = pair.Attribute.IsRequired
                };

                // SAYISAL FORMATLAMA (Bu kısım kritik)
                if (Nullable.GetUnderlyingType(pair.Property.PropertyType) == typeof(decimal) ||
                    Nullable.GetUnderlyingType(pair.Property.PropertyType) == typeof(double) ||
                    Nullable.GetUnderlyingType(pair.Property.PropertyType) == typeof(float) ||
                    pair.Property.PropertyType == typeof(decimal) ||
                    pair.Property.PropertyType == typeof(double) ||
                    pair.Property.PropertyType == typeof(float))
                {
                    col.DefaultCellStyle.Format = "N2"; // 2 ondalıklı sayı formatı
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (Nullable.GetUnderlyingType(pair.Property.PropertyType) == typeof(int) ||
                         Nullable.GetUnderlyingType(pair.Property.PropertyType) == typeof(long) ||
                         pair.Property.PropertyType == typeof(int) ||
                         pair.Property.PropertyType == typeof(long) 
                         )
                {
                    col.DefaultCellStyle.Format = "N0"; // Tam sayı formatı
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (pair.Property.PropertyType == typeof(DateTime))
                {
                    col.DefaultCellStyle.Format = "dd.MM.yyyy"; // Tarih formatı
                }

                dataGridView1.Columns.Add(col);
            }

            // Güncelleme/Silme sütunları (önceden yüklenmiş resimlerle)
            AddImageColumn("guncelle", "Güncelle", _updateIcon,isGuncelle);
            AddImageColumn("Sil", "Sil", _deleteIcon,isDelete);
        }

        // Yardımcı metod: İzin kontrolleri
        private async Task<HashSet<string>> GetAllowedFields(string formName, List<string> fieldNames)
        {
            using var permissionManager = new PermissionManager();
            var allowedFields = new HashSet<string>();

            foreach (var field in fieldNames)
            {
                var permission = new AlanYetkiDTO { formAd = formName, alanAd = field };
                if (await permissionManager.HasAccess(kullanici, permission))
                {
                    allowedFields.Add(field);
                }
            }
            return allowedFields;
        }

        // Yardımcı metod: Görsel sütun ekleme
        private void AddImageColumn(string name, string header, Bitmap image,bool isVisible)
        {
            dataGridView1.Columns.Add(new DataGridViewImageColumn
            {
                Name = name,
                HeaderText = header,
                Image = image,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Visible = isVisible
            });
        }

        // Önbellek için yardımcı sınıf
        private sealed record PropertyAttributePair(
            PropertyInfo Property,
            GridDisplayAttribute Attribute
        );

        private void DataGridView1_CellValueChanged(object s, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var item = dataGridView1.Rows[e.RowIndex].DataBoundItem;
                if (!changedItems.Contains(item))
                    changedItems.Add(item);
            }
        }

        public void SaveSettings(string key) => GridSettingsManager.Save(settingsFile, key, dataGridView1);
        public void LoadSettings(string key) => GridSettingsManager.Load(settingsFile, key, dataGridView1);
        bool headerCheckBoxState = false;
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0 )
            {
                e.PaintBackground(e.CellBounds, true);
                Point pt = new Point
                {
                    X = e.CellBounds.Left + (e.CellBounds.Width / 2) - 7,
                    Y = e.CellBounds.Top + (e.CellBounds.Height / 2) - 7
                };
                CheckBoxRenderer.DrawCheckBox(e.Graphics, pt,
                    headerCheckBoxState ? CheckBoxState.CheckedNormal
                                        : CheckBoxState.UncheckedNormal);
                e.Handled = true;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            var hit = dataGridView1.HitTest(e.X, e.Y);
            if (e.Button == MouseButtons.Left && hit.Type == DataGridViewHitTestType.ColumnHeader && dataGridView1.Columns[0].Name=="Sec")
            {
                Grid.ClearSelection();
                Grid.CurrentCell = null;
                headerCheckBoxState = !headerCheckBoxState;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["Sec"].Value = headerCheckBoxState;
                }
                dataGridView1.InvalidateCell(0, -1); // Header'ı yeniden çiz
            }
            if (e.Button == MouseButtons.Right && hit.Type == DataGridViewHitTestType.ColumnHeader)
            {
                columnMenu.Items.Clear();
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    // Gizlenebilir olması istenmeyen kolonları atla (örneğin checkbox kolonu)
                    if (col.Name == "chk") continue;

                    var item = new ToolStripMenuItem(col.HeaderText)
                    {
                        Checked = col.Visible,
                        CheckOnClick = true,
                        Tag = col
                    };

                    item.CheckedChanged += (s, args) =>
                    {
                        var mi = s as ToolStripMenuItem;
                        if (mi?.Tag is DataGridViewColumn column)
                            column.Visible = mi.Checked;
                    };

                    columnMenu.Items.Add(item);
                }

                columnMenu.Show(dataGridView1, e.Location);
            }

        }
        
        private void mouseDown(MouseEventArgs e)
        {
            MouseDown1?.Invoke(this,e);
        }
    }

}
