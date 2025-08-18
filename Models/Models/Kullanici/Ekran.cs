namespace Models
{
    public class Ekran:IEntity
    {
        public int? Id { get; set; }
        private Menu _menu;
        public Menu menu
        {
            get
            {
                if (_menu == null)
                    _menu = new Menu();
                return _menu;
            }
            set
            {
                _menu = value;
            }
        }
        public int? altMenuId { get; set; }
        public string ekranAdi { get; set; }
        public string formAd { get; set; }
        public int? siraNo { get; set; }
    }
    public class Menu:IEntity
    {
        public int? Id { get; set; }
        public string ad { get; set; }
        public string formAd { get; set; }
        public string icon { get; set; }
        public string model { get; set; }
    }
    public class Yetki:IEntity
    {
        public int? yetkiId { get; set; }
        public int? rolId { get; set; }
        private Ekran _ekran;
		public Ekran ekran
		{
			get
			{
				if (_ekran == null)
					_ekran = new Ekran();
				return _ekran;
			}
			set
			{
				_ekran = value;
			}
		}
		private Menu _menu;
        public Menu menu 
        { 
            get 
            { 
                if(_menu==null) 
                    _menu = new Menu(); 
                return _menu; 
            }
            set 
            {
                _menu = value; 
            }
        }
        
    }
}
