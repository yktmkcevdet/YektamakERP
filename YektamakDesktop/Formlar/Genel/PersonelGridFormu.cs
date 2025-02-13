using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class PersonelGridFormu : Form, IForm, IGridForm<Personel>
    {
        private static PersonelGridFormu _personelGridFormu;
        public static PersonelGridFormu personelGridFormu
        {
            get
            {
                if (_personelGridFormu == null)
                {
                    _personelGridFormu = new PersonelGridFormu();
                    GlobalData.Yetki(ref _personelGridFormu);
                }
                return _personelGridFormu;
            }
        }

        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private DataTable _dataTable;

        public DataTable dataTable
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                    _dataTable = GlobalData.FillDataTable(WebMethods.GetPersonel, personelFilter);
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                return _dataTable;
            }
            set { _dataTable = value; }
        }


        //Personel güncelleme formundan personelgrid'e gelindiyse bu veriler kullanılacak
        private int _firmaId = GlobalData.kendiFirmaId;
        public string personelUnvan;

        public PersonelGridFormu()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>
            {
                buttonEkle,
                rButtonCikis,
                dataGridViewPersonel
            };
        }
        #region mouseMove
        bool mouseDown;
        private Point offset;
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreepPos = PointToScreen(e.Location);
                Location = new Point(currentScreepPos.X - offset.X, currentScreepPos.Y - offset.Y);
            }
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion mouseMove
        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewPersonel, personelFilter);
        }
        private void rButtonCikis_Click(object sender, EventArgs e)
        {
            CloseForm();
        }



        public void UpdateRow(Personel personel)
        {
            int i = GlobalData.IndexOfDataSet(dataTable, personel.Id);
            if (i == -1)
            {
                AddNewRow(personel);
            }
            else
            {
                GlobalData.UpdateDataRow(dataTable, personel, i);
            }
        }
        public void AddNewRow(Personel personel)
        {
            dataTable.Rows.Add(
                personel.Id,
                personel.ad,
                personel.soyad,
                personel.telefon,
                personel.mail,
                personel.firma.Id,
                personel.firma.ad,
                personel.pozisyon
                );
        }


        private void buttonPersonelEkle_Click(object sender, EventArgs e)
        {
            PersonelKayitFormu personelKayitFormu = PersonelKayitFormu.personelKayitFormu;
            if (personelKayitFormu != null)
            {
                personelKayitFormu.SaveMode();
                personelKayitFormu.Show();
            }
        }


        public void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private Personel _personelFilter;
        private Personel personelFilter
        {
            get
            {
                if (_personelFilter == null)
                {
                    _personelFilter = new();
                }

                _personelFilter = GlobalData.GridFilter<Personel>(panelFilter);
                _personelFilter.firma.Id = _firmaId;
                return _personelFilter;
            }
        }
        public void FirmaMode(Personel personel)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewPersonel, personel);
        }

        public void form_Load(object sender, EventArgs e)
        {
            GlobalData.PlaceFilterFields(dataGridViewPersonel, panelFilter);
        }

        public void buttonEkle_Click(object sender, EventArgs e)
        {
            PersonelKayitFormu personelKayitFormu = PersonelKayitFormu.personelKayitFormu;
            if (personelKayitFormu != null)
            {
                personelKayitFormu.Show();
                personelKayitFormu.SaveMode();
            }
        }

        public void CloseForm()
        {
            GlobalData.CloseForm(ref _personelGridFormu);
        }

        public void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GlobalData.DataGridViewCellClick<Personel>(ref _dataTable, dataGridViewPersonel, e);
        }

        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewPersonel, personelFilter);
        }

        public void buttonFiltre_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewPersonel, personelFilter);
        }

        public void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            GlobalData.ResizeFilterFields(dataGridViewPersonel, panelFilter);
        }
        int oldScrollOffset = 0;
        public void dataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            GlobalData.AdjustControlsOnScroll(dataGridViewPersonel, panelFilter, e, ref oldScrollOffset);
        }
    }
}
