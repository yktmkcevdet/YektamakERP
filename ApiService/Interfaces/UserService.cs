using ApiService.Common;
using ApiService.Implementetions;
using Models;
using System.Data;

namespace ApiService.Interfaces
{
    public class UserService : IUserService
    {
        private readonly IApiService _apiService;

        public UserService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<Kullanici> GetKullaniciAsync(string username)
        {
            var response = await _apiService.GetAsync($"users/{username}");
            DataSet dataSet = ConvertHelper.JsonStringToDataSet(response);
            if (dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0) return null;
            return ConvertHelper.DataRowToModel<Kullanici>(dataSet.Tables[0].Rows[0]);
        }
    }
}
