using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interface
{
    public interface IBaseEntity
    {
        public int? Id { get; set; }
        public string ad { get; set; }
        public string kod { get; set; }
    }
}
