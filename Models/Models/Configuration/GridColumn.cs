using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GridColumn
    {
        public string PropertyName { get; set; }   
        public string HeaderText { get; set; }    
        public bool Visible { get; set; }
        public bool Selected { get; set; }  
    }
}
