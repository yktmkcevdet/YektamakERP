using Models;
using Models.Attributes;
using Models.DTO;
using System;
using System.Collections;
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
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.Helpers;

namespace YektamakDesktop.CustomControls
{
    public partial class UniversalGrid : UserControl
    {
        public BindingSource binding=new BindingSource();
        List<object> changedItems = new List<object>();
        string settingsFile = "grid.settings.json";
        [Browsable(true)]
        [Category("Behavior")]
        public event MouseEventHandler MouseDown1;
        public Kullanici kullanici { get; set; }
        private readonly ICache _cache;
        private readonly ConcurrentDictionary<Type, IEnumerable<PropertyAttributePair>> _propertyCache = new();
        private static readonly Bitmap _updateIcon = Properties.Resources.data_update_icon1;
        private static readonly Bitmap _deleteIcon = Properties.Resources.sil1;
        private HashSet<string> allowedFields;
        public sealed record PropertyAttributePair(
            PropertyInfo Property,
            GridDisplayAttribute Attribute
        );
        public UniversalGrid(ICache cache)
        {
            InitializeComponent();
            //dataGridView1.AutoGenerateColumns = false;
            _cache = cache;
        }
        public UniversalGrid()
        {
            InitializeComponent();
        }
        private bool headerCheckBoxState = false;
        public DataGridView Grid => dataGridView1;
        private List<object> list1;
        private IEnumerable<PropertyAttributePair> GetHeaderProperties<T>()
        {
            return _propertyCache.GetOrAdd(typeof(T), type =>
                            typeof(T).GetProperties()
                                .Select(p => new PropertyAttributePair(
                                    Property: p,
                                    Attribute: p.GetCustomAttribute<GridDisplayAttribute>()
                                ))
                                //.Where(x => x.Attribute?.Visible == true)
                                .ToList()
                        );
        }
        private async Task<HashSet<string>> GetAllowedFields(string formName, List<string> fieldNames)
        {
            using var permissionManager = new PermissionManager();
            var allowedFields = new HashSet<string>();

            foreach (var field in fieldNames)
            {
                var permission = new AlanYetkiDTO { formAd = formName, alanAd = field, kullaniciId = kullanici.Id };
                if (await permissionManager.HasAccess(permission))
                {
                    allowedFields.Add(field);
                }
            }
            return allowedFields;
        }
        private void AddCheckBoxColumn(bool isCheck)
        {
            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Sec",
                HeaderText = "",
                Width = 30,
                DataPropertyName = "Sec",
                Visible = isCheck,
            });
        }
        private void AddImageColumn(string name, string header, Bitmap image)
        {
            dataGridView1.Columns.Add(new DataGridViewImageColumn
            {
                Name = name,
                HeaderText = header,
                Image = image,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
            });
        }
        private Type customComboBoxType;

        public void SetCustomComboBoxType(Type type)
        {
            customComboBoxType = type;
        }

        private async Task ConfigureColumns<T>(string formName, bool isGuncelle = false, bool isDelete = false, bool isCheck = false)
        {
            dataGridView1.Columns.Clear();

            IEnumerable<PropertyAttributePair> props = GetHeaderProperties<T>();
            var fieldNames = props.Select(x => x.Attribute.Header).ToList();
            allowedFields = await GetAllowedFields(formName, fieldNames);

            AddCheckBoxColumn(isCheck);

            foreach (var pair in props)
            {
                if (!allowedFields.Contains(pair.Attribute.Header))
                    pair.Attribute.Visible = false;

                DataGridViewColumn col;

                if (pair.Attribute.Tip == "Liste")
                {
                    var listProperty = _cache.GetType().GetProperty(pair.Attribute.ListName);
                    var listValue = listProperty?.GetValue(_cache);
                    
                    if (listValue is IEnumerable<object> rawList)
                    {
                        var dataSource = rawList.Select(x => new
                        {
                            Id = x.GetType().GetProperty("Id")?.GetValue(x),
                            Ad = x.GetType().GetProperty(pair.Attribute.ListVisibleColumnName)?.GetValue(x)?.ToString()
                        }).ToList();
                        var comboColumn = new FilterableComboBoxColumn
                        {
                            DataPropertyName = pair.Property.Name,
                            HeaderText = pair.Attribute.Header,
                            Name = pair.Attribute.Header,
                            ReadOnly = pair.Attribute.IsRequired,
                            Visible = pair.Attribute.Visible,
                        };
                        if (comboColumn.CellTemplate is FilterableComboBoxCell comboCell)
                        {
                            comboCell.DisplayMember = "Ad";
                            comboCell.ValueMember = "Id";
                            comboCell.ItemsSource = dataSource.Cast<object>().ToList();
                        }
                        col = comboColumn;
                    }
                    else
                    {
                        col = new DataGridViewTextBoxColumn();
                    }
                }
                else
                {
                    col = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = pair.Property.Name,
                        HeaderText = pair.Attribute.Header,
                        Name = pair.Attribute.Header,
                        ReadOnly = pair.Attribute.IsRequired,
                        Visible = pair.Attribute.Visible,
                    };
                }

                // Sayısal formatlama ve hizalama
                if (Nullable.GetUnderlyingType(pair.Property.PropertyType) == typeof(decimal) ||
                    Nullable.GetUnderlyingType(pair.Property.PropertyType) == typeof(double) ||
                    Nullable.GetUnderlyingType(pair.Property.PropertyType) == typeof(float) ||
                    pair.Property.PropertyType == typeof(decimal) ||
                    pair.Property.PropertyType == typeof(double) ||
                    pair.Property.PropertyType == typeof(float))
                {
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (Nullable.GetUnderlyingType(pair.Property.PropertyType) == typeof(int) ||
                         Nullable.GetUnderlyingType(pair.Property.PropertyType) == typeof(long) ||
                         pair.Property.PropertyType == typeof(int) ||
                         pair.Property.PropertyType == typeof(long))
                {
                    col.DefaultCellStyle.Format = "N0";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (pair.Property.PropertyType == typeof(DateTime))
                {
                    col.DefaultCellStyle.Format = "dd.MM.yyyy";
                }

                dataGridView1.Columns.Add(col);
            }

            if (isGuncelle)
                AddImageColumn("guncelle", "Güncelle", _updateIcon);
            if (isDelete)
                AddImageColumn("Sil", "Sil", _deleteIcon);
        }



        private string _formName;
        public async Task SetData<T>(List<T> list, string formName, bool isGuncelle = false, bool isDelete = false, bool isCheck = false) 
        {
            _formName = formName;
            await ConfigureColumns<T>(formName, isGuncelle, isDelete, isCheck);
            var liste = new SortableBindingList<T>(list);
            binding.DataSource = liste;

            dataGridView1.DataSource = binding;
            list1 = list.Cast<object>().ToList();
            LoadSettings(formName);
            lblToplamKayitSayisi.Text=$"Toplam Kayıt Sayısı : {binding.Count.ToString()}";
        }
        public void AddRow<T>(List<T> list) where T : IEntity, new()
        {
            list.Add(new T());
            binding.DataSource = list;
        }
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void dataGridView1_CellValueChanged(object s, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Sec")
            {
                lblSecilenKayitSayisi.Text = $"Seçilen kayıt sayısı : {dataGridView1.Rows.OfType<DataGridViewRow>()
                    .Count(row => Convert.ToBoolean(row.Cells["Sec"].Value) == true)}";
            }
        }
        private void LoadSettings(string key) => DIContainer.GetService<GridSettingsManager>().Load(kullanici.Id, key, dataGridView1);
        public void SaveSettings() => DIContainer.GetService<GridSettingsManager>().Save(kullanici.Id, _formName, dataGridView1);
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
        
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Grid.Rows[e.RowIndex].Cells["Sec"].ColumnIndex)
            {
                lblSecilenKayitSayisi.Text = $"Seçilen kayıt sayısı : {dataGridView1.Rows.OfType<DataGridViewRow>() // LINQ'e uygun hale getirir
                                        .Count(row => Convert.ToBoolean(row.Cells["Sec"].Value) == true).ToString()}";
            }
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            var hit = dataGridView1.HitTest(e.X, e.Y);
            if (e.Button == MouseButtons.Left && hit.Type == DataGridViewHitTestType.ColumnHeader && dataGridView1.Columns[0].Name=="Sec")
            {
                if (dataGridView1.Columns[hit.ColumnIndex].Name == "Sec")
                {
                    Grid.ClearSelection();
                    Grid.CurrentCell = null;
                    headerCheckBoxState = !headerCheckBoxState;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Cells["Sec"].Value = headerCheckBoxState;
                    }

                    dataGridView1.InvalidateCell(hit.ColumnIndex, -1); // Sadece tıklanan header'ı yeniden çiz
                }
                else if (dataGridView1.Columns[0].Name != "Güncelle" && dataGridView1.Columns[0].Name != "Sil" && dataGridView1.Columns[0].Name != "Sec")
                {
                    // Varsayılan sıralama işlemi yap
                    string columnName = dataGridView1.Columns[hit.ColumnIndex].DataPropertyName;
                    ListSortDirection direction = ListSortDirection.Ascending;

                    // Eğer zaten sıralandıysa yönü tersine çevir
                    if (dataGridView1.SortedColumn == dataGridView1.Columns[hit.ColumnIndex] &&
                        dataGridView1.SortOrder == SortOrder.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    dataGridView1.Sort(dataGridView1.Columns[hit.ColumnIndex], direction);
                    // Sıralama sonrası headerCheckBoxState'i sıfırla
                    headerCheckBoxState = false;
                    // Tüm satırların checkbox'larını güncelle

                }
            }
            else if (e.Button == MouseButtons.Right && hit.Type == DataGridViewHitTestType.ColumnHeader)
            {
                columnMenu.Items.Clear();
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    // Gizlenebilir olması istenmeyen kolonları atla (örneğin checkbox kolonu)
                    //if (col.Name == "chk") continue;
                    if (allowedFields.Contains(col.Name) || col.Name == "Sec")
                    {
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
                }

                columnMenu.Show(dataGridView1, e.Location);
            }
            else if(e.Button == MouseButtons.Right)
            {
                MouseDown1?.Invoke(this,e);
            }

        }
        public List<T> GetCheckedRows<T>() where T : IEntity
        {
            var checkedList = new List<T>();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var row = dataGridView1.Rows[i];

                // CheckBox sütununun indexi 0 kabul edildi, gerekirse sütun adına göre alınabilir
                var cellValue = row.Cells[0].Value;

                bool isChecked = cellValue != null && (bool)cellValue;

                if (isChecked)
                {
                    // DataBoundItem, orijinal objeyi döner
                    if (row.DataBoundItem is T item)
                    {
                        checkedList.Add(item);
                    }
                }
            }

            return checkedList;
        }
        public static IEnumerable<T> Filtrele<T>(IEnumerable<T> list, T filter)
        {
            var props = typeof(T).GetProperties().Where(p => p.GetValue(filter) != null);

            return list.Where(item =>
            {
                foreach (var prop in props)
                {
                    var filterValue = prop.GetValue(filter);
                    if (filterValue == null || typeof(IEnumerable).IsAssignableFrom(prop.PropertyType)) continue;

                    var itemValue = prop.GetValue(item);
                    if (itemValue == null || !itemValue.Equals(filterValue))
                        return false;
                }
                return true;
            });
        }
        public static SortableBindingList<T> Filtrele<T>(SortableBindingList<T> list, T filter)
        {
            var props = typeof(T).GetProperties()
                                 .Where(p => p.GetValue(filter) != null);

            var filtered = list.Where(item =>
            {
                foreach (var prop in props)
                {
                    var filterValue = prop.GetValue(filter);
                    if (filterValue == null || typeof(IEnumerable).IsAssignableFrom(prop.PropertyType)) continue;

                    var itemValue = prop.GetValue(item);

                    // Null eşleşmiyorsa filtreyi geçemez
                    if (itemValue == null || !itemValue.Equals(filterValue))
                        return false;
                }
                return true;
            }).ToList();

            return new SortableBindingList<T>(filtered);
        }
        public void Filtrele<T>(T filtreNesnesi,string formName) where T : IEntity 
        {
            var list = (SortableBindingList<T>)binding.DataSource;
            var filtreliListe = Filtrele(list, filtreNesnesi);
            dataGridView1.DataSource = filtreliListe;
            LoadSettings(formName);
            lblGosterilenKayitSayisi.Text = $"Filtrelenen kayıt sayısı : {dataGridView1.Rows.Count.ToString()}";
        }
        private void mouseDown(MouseEventArgs e)
        {
            MouseDown1?.Invoke(this, e);
        }
        protected override void OnMouseDown (MouseEventArgs e)
        {
            base.OnMouseDown(e);
            mouseDown(e);
        }
        
    }
    public class SortableBindingList<T> : BindingList<T> 
    {
        public SortableBindingList() : base() { }

        public SortableBindingList(IList<T> list) : base(list) { }
        private bool _isSorted;
        private ListSortDirection _sortDirection;
        private PropertyDescriptor _sortProperty;

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => _isSorted;
        protected override ListSortDirection SortDirectionCore => _sortDirection;
        protected override PropertyDescriptor SortPropertyCore => _sortProperty;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var itemsList = (List<T>)Items;
            itemsList.Sort((x, y) =>
            {
                var valueX = prop.GetValue(x);
                var valueY = prop.GetValue(y);
                return Comparer<object>.Default.Compare(valueX, valueY) * (direction == ListSortDirection.Ascending ? 1 : -1);
            });

            _sortDirection = direction;
            _sortProperty = prop;
            _isSorted = true;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            _isSorted = false;
        }
    }
    public class FilterableComboBoxEditingControl : FilterableComboBox, IDataGridViewEditingControl
    {
        public DataGridView EditingControlDataGridView { get; set; }
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Text;
            }
            set
            {
                if (value is string s)
                    this.Text = s;
            }
        }

        public int EditingControlRowIndex { get; set; }
        public bool EditingControlValueChanged { get; set; }

        public bool RepositionEditingControlOnValueChange => false;
        public Cursor EditingPanelCursor => base.Cursor;

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
        }

        //public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey) => true;
        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context) => SelectedValue;

        public void PrepareEditingControlForEdit(bool selectAll) { }

        public FilterableComboBoxEditingControl()
        {
            this.SelectedValueChanged += FilterableComboBoxEditingControl_SelectedValueChanged;
            this.SelectedIndexChanged += FilterableComboBoxEditingControl_SelectedIndexChanged;
        }

        private void FilterableComboBoxEditingControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditingControlValueChanged = true;
            EditingControlDataGridView?.NotifyCurrentCellDirty(true);
        }

        private void FilterableComboBoxEditingControl_SelectedValueChanged(object sender, EventArgs e)
        {
            EditingControlValueChanged = true;
            EditingControlDataGridView?.NotifyCurrentCellDirty(true);
        }
    }
    public class FilterableComboBoxCell : DataGridViewTextBoxCell
    {
        public List<object> ItemsSource { get; set; }
        public string ValueMember { get; set; }
        public string DisplayMember { get; set; }
        public override Type EditType 
        {
            get 
            { 
                return typeof(FilterableComboBoxEditingControl);
            } 
        }
        public override object Clone()
        {
            var clone = base.Clone() as FilterableComboBoxCell;
            if (clone != null)
            {
                clone.ItemsSource = this.ItemsSource;
                clone.DisplayMember = this.DisplayMember;
                clone.ValueMember = this.ValueMember;
            }
            return clone;
        }
        public override Type ValueType => typeof(object); // İstersen tip belirt
        public List<object> ComboItems { get; set; }
        public override object DefaultNewRowValue => null;
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            var ctl = DataGridView.EditingControl as FilterableComboBoxEditingControl;

            if (ctl != null)
            {
                ctl.DisplayMember = this.DisplayMember;
                ctl.ValueMember = this.ValueMember;
                ctl.SetDataSource(ItemsSource);
                ctl.SelectedValue = this.Value; // Eğer hücrede bir değer varsa, göster
            }
        }
        protected override object GetFormattedValue(object value,
        int rowIndex, ref DataGridViewCellStyle cellStyle,
        TypeConverter valueTypeConverter,
        TypeConverter formattedValueTypeConverter,
        DataGridViewDataErrorContexts context)
        {
            if (this.ItemsSource != null && !string.IsNullOrEmpty(this.DisplayMember) && !string.IsNullOrEmpty(this.ValueMember))
            {
                var list = this.ItemsSource as IEnumerable<object>;
                var item = list?.FirstOrDefault(x =>
                {
                    var prop = x.GetType().GetProperty(this.ValueMember);
                    var val = prop?.GetValue(x);
                    return val != null && val.Equals(value);
                });

                if (item != null)
                {
                    var dispProp = item.GetType().GetProperty(this.DisplayMember);
                    return dispProp?.GetValue(item)?.ToString() ?? base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
                }
            }

            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }
    }
    public class FilterableComboBoxColumn : DataGridViewColumn
    {
        public FilterableComboBoxColumn()
            : base(new FilterableComboBoxCell())
        {
            CellTemplate = new FilterableComboBoxCell();
        }
    }
    public class ListItemModel
    {
        public object Id { get; set; }
        public string Ad { get; set; }
    }
}
