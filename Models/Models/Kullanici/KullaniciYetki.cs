using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class KullaniciYetki:IEntity
    {
        private Rol _rol;
        public Rol rol
        {
            get { if (_rol == null) { _rol = new(); } return _rol; }
            set { _rol = value; }
        }
        private Menu _menu;
        public Menu menu
        {
            get { if (_menu == null) { _menu = new(); } return _menu; }
            set { _menu = value; }
        }
        private Menu _altMenu;
        public Menu altMenu
        {
            get { if (_altMenu == null) { _altMenu = new(); } return _altMenu; }
            set { _altMenu = value; }
        }
    }
}
