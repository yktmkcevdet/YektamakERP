using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Common
{
    public class DataGridHelper: IDataGridHelper
    {
        private readonly IJsonConvertHelper _jsonConverter;

        public DataGridHelper(IJsonConvertHelper jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }

        /// <summary>
        /// Webmethod fonksiyonu ile modele ait veriler filtre nesnesine göre veritabanından çekilir ve datatable nesnesine aktarır
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="filterModel"></param>
        /// <returns></returns>
        public DataTable FillDataTable<T>(Func<T, string> func, T filterModel) where T : class
        {
            DataTable dataTable = new DataTable();
            string result = func(filterModel);
            if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(result);
            }
            else
            {
                dataTable = _jsonConverter.JsonStringToDataSet(result).Tables[0];
            }
            return dataTable;
        }
        /// <summary>
        /// Webmethod fonksiyonu ile modele ait veriler filtre nesnesine göre veritabanından çekilir ve datatable nesnesine aktarır
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="filterModel"></param>
        /// <returns></returns>
        public DataTable FillDataTable<T>(List<T> list, T filterModel) where T : class
        {
            DataTable dataTable = new DataTable();
            return dataTable;
        }
    }
}
