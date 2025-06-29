using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Interfaces
{
    public interface IConvertHelper
    {
        /// <summary>
        /// Model listesini datatable'a çevirir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable ToDataTable<T>(List<T> data) where T : IEntity, new();
        /// <summary>
        /// Model içindeki Field ve Property'leri DataTable'a sütun olarak ekler
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsComplexType(Type type);
    }
}
