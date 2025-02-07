using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Stok
{
    public partial class MalzemeGrubu : Form,IForm
    {
        private static MalzemeGrubu _malzemeGrubu;
        public static MalzemeGrubu malzemeGrubu
        {
            get
            {
                if (_malzemeGrubu == null) _malzemeGrubu = new MalzemeGrubu();
                return _malzemeGrubu;
            }
        }

        public List<Control> controlsToDisable { get; set; }
        public bool activeForm { get; set; }

        public MalzemeGrubu()
        {
            InitializeComponent();
        }
    }
}
