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

namespace YektamakDesktop.Formlar.Projemodul
{
    public partial class ExcelVeriAlmaCakisanOnayFormu : Form
    {
        public ExcelVeriAlmaCakisanOnayFormu()
        {
            InitializeComponent();
        }

        public void UpdateMode(ProjeStokKart projeStokKartNew, ProjeStokKart projeStokKartOld)
        {
            ctbNoNew.TextCustom = projeStokKartNew.no;
            ctbNoOld.TextCustom = projeStokKartOld.no;
            ctbKodNew.TextCustom = projeStokKartNew.stokKart.kod;
            ctbKodOld.TextCustom = projeStokKartOld.stokKart.kod;
            ctbParcaAdiNew.TextCustom = projeStokKartNew.stokKart.ad;
            ctbParcaAdiOld.TextCustom = projeStokKartOld.stokKart.ad;
            ctbMiktarNew.TextCustom = projeStokKartNew.miktar.ToString();
            ctbMiktarOld.TextCustom = projeStokKartOld.miktar.ToString();
            ctbBoyutNew.TextCustom = projeStokKartNew.stokKart.boyut;
            ctbBoyutOld.TextCustom = projeStokKartOld.stokKart.boyut;
            ctbUzunlukNew.TextCustom = projeStokKartNew.stokKart.uzunluk.ToString();
            ctbUzunlukOld.TextCustom = projeStokKartOld.stokKart.uzunluk.ToString();
            ctbMalzemeNew.TextCustom = projeStokKartNew.stokKart.malzeme;
            ctbMalzemeOld.TextCustom = projeStokKartOld.stokKart.malzeme;
            ctbAciklamaNew.TextCustom = projeStokKartNew.stokKart.aciklama;
            ctbAciklamaOld.TextCustom = projeStokKartOld.stokKart.aciklama;
            ctbAgirlikNew.TextCustom = projeStokKartNew.stokKart.agirlik.ToString();
            ctbAgirlikOld.TextCustom = projeStokKartOld.stokKart.agirlik.ToString();
        }
    }
}
