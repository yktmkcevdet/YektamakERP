using YektamakDesktop.CustomControls;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Finans
{
    public partial class TaksitliIslemOtomatikTaksitlendirme : Form, IForm
    {
        private static TaksitliIslemOtomatikTaksitlendirme _taksitliIslemOtomatikTaksitlendirme;
        public static TaksitliIslemOtomatikTaksitlendirme taksitliIslemOtomatikTaksitlendirme
        {
            get
            {
                if (_taksitliIslemOtomatikTaksitlendirme == null)
                {
                    _taksitliIslemOtomatikTaksitlendirme = new TaksitliIslemOtomatikTaksitlendirme();
                    GlobalData.Yetki(ref _taksitliIslemOtomatikTaksitlendirme);
                }
                return _taksitliIslemOtomatikTaksitlendirme;
            }
        }
        private bool _activeForm;
        public bool activeForm
        {
            get
            {
                return _activeForm;
            }
            set
            {
                _activeForm = value;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable
        {
            get
            {
                return _controlsToDisable;
            }
            set
            {
                _controlsToDisable = value;
            }
        }
        public TaksitliIslemOtomatikTaksitlendirme()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>();
            //foreach (DovizCinsi dovizCinsi in GlobalData.dovizList)
            //{
            //    customComboListBoxTaksitTutariDovizId.AddDataRow(dovizCinsi.id, dovizCinsi.sembol);
            //    customComboListBoxToplamTutarDovizId.AddDataRow(dovizCinsi.id, dovizCinsi.sembol);
            //}
        }
        #region mouseDrag
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
        #endregion mouseDrag

        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void CloseForm()
        {
            this.Close();
            GlobalData.RemoveLastForm();
            _taksitliIslemOtomatikTaksitlendirme = null;
        }

        private void rButtonTaksitlendir_Click(object sender, EventArgs e)
        {
            int taksitAdedi = int.Parse(customTextBoxTaksitAdedi.TextCustom.ToString());
            List<TaksitOdemesi> taksitOdemesiList = new();
            DateTime sonOdemeTarihi = DateTime.Parse(customTextBoxIlkTaksitTarihi.TextCustom.ToString());
            for (int i = 1; i <= taksitAdedi; i++)
            {
                TaksitOdemesi taksitOdemesi = new();
                taksitOdemesi.tutar = new Tutar();
                taksitOdemesi.tutar.tutar = float.Parse(customTextBoxTaksitTutari.TextCustom.ToString());
                taksitOdemesi.tutar.dovizCinsi.id = customComboListBoxToplamTutarDovizId.selectedDataRowId;
                taksitOdemesi.sonOdemeTarihi = sonOdemeTarihi;
                sonOdemeTarihi = sonOdemeTarihi.AddMonths(int.Parse(customTextBoxAy.TextCustom)).AddDays(int.Parse(customTextBoxGun.TextCustom));
                taksitOdemesi.taksitNo = i;
                taksitOdemesi.aciklama = customTextBoxAciklama.TextCustom;
                taksitOdemesiList.Add(taksitOdemesi);
            }
            TaksitliOdemeKayitFormu.taksitliOdemeKayitFormu.Taksitlendir(taksitOdemesiList);
        }
        public void UpdateMode(TaksitliOdeme taksitliOdeme)
        {
            customComboListBoxTaksitTutariDovizId.SelectDataRowId(taksitliOdeme.toplamTutar.dovizCinsi.id);
            customComboListBoxToplamTutarDovizId.SelectDataRowId(taksitliOdeme.toplamTutar.dovizCinsi.id);
            customTextBoxToplamTutar.TextCustom = taksitliOdeme.toplamTutar.tutar.ToString("N2");
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
