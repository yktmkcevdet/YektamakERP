using Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MaliyetUnsur : IEntity, IBaseEntity
    {
        public int? Id { get; set; }
        public string ad { get; set; }
        public string kod { get; set; }
    }
}
