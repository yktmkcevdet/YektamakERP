using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Abstracts;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satinalma.Talep
{
    public partial class SatinalmaTalepOlusturmaAltForm : Form,IAltForm,IUstForm
    {
      
        public SatinalmaTalepOlusturmaAltForm()
        {
            InitializeComponent();
            
        }
        private static SatinalmaTalep satinalmaTalep;
        public event EventHandler<object> VeriDegisti;
        
        public void UstFormuBagla(IUstForm ustForm)
        {
            ustForm.VeriDegisti += UstVerisiDegisti;
        }
        private void UstVerisiDegisti(object sender, object yeniDeger)
        {
            var deger = (SatinalmaTalep)yeniDeger;
            satinalmaTalep = deger;
        }
    }
    
}
