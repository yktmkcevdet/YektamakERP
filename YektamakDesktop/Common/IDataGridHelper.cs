using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YektamakDesktop.Common
{
    public interface IDataGridHelper
    {
        public DataTable FillDataTable<T>(Func<T, string> func, T filterModel) where T:class;
        public DataTable FillDataTable<T>(List<T> list, T filterModel) where T:class;
    }
}
