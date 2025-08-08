using ApiService.Interfaces;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satis
{
    public partial class ProjeTanimlamaFormu : Form
    {
        private readonly ICache _cache;
        private readonly IProjeService _projeService;
        public ProjeTanimlamaFormu(ICache cache, IProjeService projeService)
        {
            _cache = cache;
            _projeService = projeService;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(37, 233);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(913, 341);
            universalGrid1.TabIndex = 18;
            Controls.Add(universalGrid1);
            foreach(var proje in _cache.projes)
            {
                projeDTO.Add(ConvertHelper.ToDTO<ProjeDTO>(proje));
            }
            universalGrid1.SetData(projeDTO, this.Name);
            fcbProjeTip.SetDataSource(_cache.projeTipList);
            fcbMarka.SetDataSource(_cache.markaList);
            fcbMarkaAltGrup.SetDataSource(_cache.markaAltGrupList);
            fcbMirasProje.SetDataSource(_cache.projes);
        }
        private List<ProjeDTO> _projeDTO;
        public List<ProjeDTO> projeDTO
        {
            get
            {
                if (_projeDTO == null)
                {
                    _projeDTO = new List<ProjeDTO>();
                }
                return _projeDTO;
            }
            set
            {
                _projeDTO = value;
                Binding();
            }
        }
        private Proje _proje;
        private Proje proje
        {
            get { return _proje; }
            set
            {
                _proje = value;
                Binding();
            }
        }
        private void Binding()
        {
            BindData(ctbId, proje, "Id");
            BindData(fcbProjeTip, proje, "Id");

        }
        private void ProjeTanimlamaFormu_Load(object sender, EventArgs e)
        {

        }
        public void BindData(FilterableComboBox filterableComboBox, IEntity entity, string valueMember)
        {
            filterableComboBox.DataBindings.Clear();
            filterableComboBox.DataBindings.Add("SelectedValue", entity, valueMember, true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public void BindData(CustomTextBox customTextBox, IEntity entity, string valueMember)
        {
            customTextBox.DataBindings.Clear();
            customTextBox.DataBindings.Add("TextCustom", entity, valueMember, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void customButtonSave1_SaveButtonClick(object sender, EventArgs e)
        {
            string jsonResult = _projeService.SaveProje(proje);
        }
    }
}
