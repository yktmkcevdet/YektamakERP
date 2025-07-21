using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class AnaMenuDTO:IEntity
    {
        public int Id { get; set; }
        public string ad { get; set; }
        public string formAdi { get; set; }
        public string icon { get; set; }
        public int rolId { get; set; }
    }
}
