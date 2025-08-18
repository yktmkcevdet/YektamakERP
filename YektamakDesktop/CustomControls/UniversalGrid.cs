using FastReport.Data;
using Models;
using Models.Attributes;
using Newtonsoft.Json;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.POIFS.NIO;
using NPOI.SS.Formula.Functions;
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
using Utilities.Interfaces;
using YektamakDesktop.Common;
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
        private readonly ICache _cache;
        private readonly ConcurrentDictionary<Type, IEnumerable<PropertyAttributePair>> _propertyCache = new();
        private static readonly Bitmap _updateIcon = Properties.Resources.data_update_icon1;
        private static readonly Bitmap _deleteIcon = Properties.Resources.sil1;
        private HashSet<string> allowedFields;
        private bool _isCheck = false;
        public sealed record PropertyAttributePair(
            PropertyInfo Property,
            GridDisplayAttribute Attribute
        );
        public UniversalGrid(ICache cache)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
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
                                .Where(x => x.Attribute != null)
                                .ToList()
                        );
        }
        private async Task<HashSet<string>> GetAllowedFields(string formName, List<string> fieldNames)
        {
            using var permissionManager = new PermissionManager();
            var allowedFields = new HashSet<string>();

            foreach (var field in fieldNames)
            {
                var permission = new AlanYetki { formAd = formName, alanAd = field, kullanici = _cache.kullanici };
                if (await permissionManager.HasAccess(permission))
                {
                    allowedFields.Add(field);
                }
            }
            return allowedFields;
        }
        private DataGridViewColumn AddCheckBoxColumn()
        {
            return new DataGridViewCheckBoxColumn
            {
                Name = "Sec",
                HeaderText = "",
                Width = 30,
                DataPropertyName = "Sec",
                Visible = _isCheck,
                DisplayIndex = 0,
                ReadOnly = false
            };
        }
        //private Type customComboBoxType;

        //public void SetCustomComboBoxType(Type type)
        //{
        //    customComboBoxType = type;
        //}
        private async Task<List<DataGridViewColumn>> ConfigureColumns<T>(string formName, bool isCheck = false)
        {
            List<DataGridViewColumn> columns = new List<DataGridViewColumn>();

            IEnumerable<PropertyAttributePair> props = GetHeaderProperties<T>();
            var fieldNames = props.Select(x => x.Attribute.Header).ToList();
            allowedFields = await GetAllowedFields(formName, fieldNames);

            if (isCheck) columns.Add(AddCheckBoxColumn());

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
                            ad = x.GetType().GetProperty(pair.Attribute.ListVisibleColumnName)?.GetValue(x)?.ToString()
                        }).ToList();
                        var comboColumn = new FilterableComboBoxColumn
                        {
                            DataPropertyName = pair.Property.Name,
                            HeaderText = pair.Attribute.Header,
                            Name = pair.Attribute.Header,
                            ReadOnly = pair.Attribute.readOnly,
                            Visible = pair.Attribute.Visible,
                            DefaultCellStyle = new DataGridViewCellStyle
                            {
                                Alignment = DataGridViewContentAlignment.MiddleLeft
                            }
                        };
                        if (comboColumn.CellTemplate is FilterableComboBoxCell comboCell)
                        {
                            comboCell.DisplayMember = "ad";
                            comboCell.ValueMember = "Id";
                            comboCell.ItemsSource = dataSource.Cast<object>().ToList();
                        }
                        col = comboColumn;
                    }
                    else
                    {
                        col = new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = pair.Property.Name,
                            HeaderText = pair.Attribute.Header,
                            Name = pair.Attribute.Header,
                            ReadOnly = pair.Attribute.readOnly,
                            Visible = pair.Attribute.Visible,
                        }
                    ;
                    }
                }
                else
                {
                    col = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = pair.Property.Name,
                        HeaderText = pair.Attribute.Header,
                        Name = pair.Attribute.Header,
                        ReadOnly = pair.Attribute.readOnly,
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
                columns.Add(col);
            }
            return columns;
        }
        private string _formName;
        public async Task SetData<T>(List<T> list, string formName, bool isCheck = false)
        {
            lblSecilenKayitSayisi.Text = "";
            _isCheck = isCheck;
            _formName = formName;
            headerCheckBoxState = false;
            var liste = new SortableBindingList<T>(list);
            binding.DataSource = liste;

            list1 = list.Cast<object>().ToList();
            dataGridView1.DataSource = liste;
            await LoadSettings<T>(formName, isCheck);

            lblToplamKayitSayisi.Text = $"Toplam Kayıt Sayısı : {binding.Count.ToString()}";
        }
        public void AddRow<T>(List<T> list) where T : IEntity, new()
        {
            list.Add(new T());
            binding.DataSource = list;
        }
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty && dataGridView1.CurrentCell.ColumnIndex== 0)
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
        private async Task LoadSettings<T>(string key, bool isCheck)
        {
            var columns = await ConfigureColumns<T>(key, isCheck);
            await DIContainer.GetService<GridSettingsManager>().Load(_cache.kullanici.Id, key, columns, dataGridView1);
        }
        public async Task SaveSettings() => await DIContainer.GetService<GridSettingsManager>().Save(_cache.kullanici.Id, _formName, dataGridView1);
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0 && _isCheck)
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
            if (e.Button == MouseButtons.Left && hit.Type == DataGridViewHitTestType.ColumnHeader && dataGridView1.Columns[0].Name == "Sec")
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
                else
                {
                    string columnName = dataGridView1.Columns[hit.ColumnIndex].DataPropertyName;
                    
                    if (dataGridView1.Columns[hit.ColumnIndex].SortMode != DataGridViewColumnSortMode.Programmatic)
                    {
                        dataGridView1.Columns[hit.ColumnIndex].SortMode = DataGridViewColumnSortMode.Programmatic;
                        dataGridView1.Sort(dataGridView1.Columns[hit.ColumnIndex], ListSortDirection.Descending);
                    }
                    else 
                    {
                        if (dataGridView1.SortOrder == SortOrder.Descending)
                        {
                            dataGridView1.Sort(dataGridView1.Columns[hit.ColumnIndex], ListSortDirection.Ascending);
                        }
                        else
                        {
                            dataGridView1.Sort(dataGridView1.Columns[hit.ColumnIndex], ListSortDirection.Descending);
                        }
                    }
                }
            }
            else if (e.Button == MouseButtons.Right && hit.Type == DataGridViewHitTestType.ColumnHeader)
            {
                columnMenu.Items.Clear();
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    // Gizlenebilir olması istenmeyen kolonları atla (örneğin checkbox kolonu)
                    //if (col.Name == "chk") continue;
                    if (allowedFields.Contains(col.Name))
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
            else if (e.Button == MouseButtons.Right)
            {
                Grid.ClearSelection();
                Grid.Rows[hit.RowIndex].Selected = true;
                if(hit.ColumnIndex > -1)
                {
                    Grid.CurrentCell = Grid.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                }
                MouseDown1?.Invoke(this, e);
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
        public void SetComboColumnData(string columnName, IEnumerable<object> dataSource, string displayMember, string valueMember)
        {
            if (this.Grid.Columns[columnName] is FilterableComboBoxColumn col)
            {
                if (col.CellTemplate is FilterableComboBoxCell comboCell)
                {
                    comboCell.ItemsSource = dataSource.Cast<object>().ToList();
                }
            }
        }
        public static SortableBindingList<T> Filtrele<T>(SortableBindingList<T> list, T filter)
        {
            IEnumerable<PropertyInfo> props = typeof(T).GetProperties().ToList();
            props = props.Where(p => p.GetValue(filter) != null);
            props = props.Where(p => !typeof(IEnumerable).IsAssignableFrom(p.PropertyType) || p.PropertyType == typeof(string));

            var filtered = list.Where(item =>
            {
                foreach (var prop in props)
                {
                    var filterValue = JsonConvert.SerializeObject(prop.GetValue(filter));
                    var itemValue = JsonConvert.SerializeObject(prop.GetValue(item));
                    // Null eşleşmiyorsa filtreyi geçemez
                    if (filterValue == null) return true;
                    if (prop.PropertyType== typeof(string))
                    {
                        if (itemValue == null || !itemValue.ToString().Contains(filterValue.ToString(),StringComparison.OrdinalIgnoreCase)) return false;
                    }
                    else
                    {
                        if (itemValue == null || !itemValue.Equals(filterValue)) return false;
                    }
                }
                return true;
            }).ToList();

            return new SortableBindingList<T>(filtered);
        }
        public async Task Filtrele<T>(T filtreNesnesi) where T : IEntity
        {
            var list = (SortableBindingList<T>)binding.DataSource;
            var filtreliListe = Filtrele(list, filtreNesnesi);
            dataGridView1.DataSource = filtreliListe;
            await LoadSettings<T>(_formName, _isCheck);
            headerCheckBoxState = false;
            lblSecilenKayitSayisi.Text = $"Seçilen kayıt sayısı : 0";
            lblGosterilenKayitSayisi.Text = $"Filtrelenen kayıt sayısı : {dataGridView1.Rows.Count.ToString()}";
        }
        private void mouseDown(MouseEventArgs e)
        {
            MouseDown1?.Invoke(this, e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
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
                    return true;
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
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context) => JsonConvert.SerializeObject(SelectedValue);

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
        public FilterableComboBoxCell()
        {
            this.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
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
                    try
                    {
                        dynamic dynItem = x;
                        var val = GetPropValue(dynItem, this.ValueMember);
                        return val != null && val.Equals(value);
                    }
                    catch
                    {
                        return false;
                    }
                });

                if (item != null)
                {
                    var dispProp = item.GetType().GetProperty(this.DisplayMember);
                    return dispProp?.GetValue(item)?.ToString() ?? base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
                }
            }

            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }
        private object GetPropValue(dynamic obj, string propName)
        {
            if (obj is IDictionary<string, object> dict && dict.ContainsKey(propName))
                return dict[propName];
            else
                return obj.GetType().GetProperty(propName)?.GetValue(obj);
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
