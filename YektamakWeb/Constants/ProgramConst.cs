using BlazorApp1.Features.Commands.Account.Login;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Models;
using System.Data;
using ApiService;
using Utilities.Interfaces;
using Utilities.Implementations;

namespace YektamakWeb
{
    public class ProgramConst
    {
        public static string NavMenuCssClass { get; set; } = "default-class";
        private readonly ICache _cache;
        private readonly UserSession _userSession;
        /// <summary>
        /// Kendi firmamızın id'si
        /// </summary>
        public static int kendiFirmaId;

        public ProgramConst( UserSession userSession,ICache cache) 
        {
            _cache = cache;
            _userSession = userSession;
        }

        public async Task<List<Menu>> AnaMenuList ()
        {
            IJsonConvertHelper jsonConvertHelper = new JsonConvertHelper();
            DataSet dataSetGlobalData = jsonConvertHelper.JsonStringToDataSet(await WebMethods.GetAsyncMethod("GetGlobalData"));
            List<Menu> anaMenuList = new List<Menu>();
            foreach (DataRow dr in dataSetGlobalData.Tables[9].Select($"rolId={_userSession.rolId}"))
            {
                Menu menu = new();
                menu.Id = int.Parse(dr["Id"].ToString()??"");
                menu.ad = dr["ad"].ToString()??"";
                menu.icon = dr["icon"].ToString()??"";
                anaMenuList.Add(menu);
            }
            return anaMenuList;
        }
        public async Task<List<Yetki>> YetkiList()
        {
            IJsonConvertHelper jsonConvertHelper = new JsonConvertHelper();
            DataSet dataSetGlobalData = jsonConvertHelper.JsonStringToDataSet(await WebMethods.GetAsyncMethod("GetGlobalData"));
            List<Yetki> yetkiList = new List<Yetki>();
            foreach (DataRow dr in dataSetGlobalData.Tables[10].Select($"rolId={_userSession.rolId}"))
            {
                Yetki yetki = new();
                yetki.yetkiId = int.Parse(dr["yetkiId"].ToString()??"");
                yetki.menu.Id = string.IsNullOrWhiteSpace(dr["menuId"].ToString()) ? 0 : int.Parse(dr["menuId"].ToString()??"");
                yetki.menu.ad = dr["menu"].ToString()??"";
                yetki.menu.icon = dr["Icon"].ToString()??"";
                yetki.ekran.ekranId = int.Parse(dr["ekranId"].ToString()??"");
                yetki.ekran.ekranAdi = dr["ekranAdi"].ToString()??"";
                yetki.ekran.formAdi = dr["formAdi"].ToString()??"";
                yetkiList.Add(yetki);
            }
            return yetkiList;
        }
        public List<Proje> Projes()
        {
            Proje proje = new();
            proje.personel.Id = _cache.kullanici.personel.Id;
            List<Proje> projeKod = new List<Proje>();
            string jsonString = WebMethods.GetProjeKodByUserId(proje);
            IJsonConvertHelper jsonConvertHelper = new JsonConvertHelper();
            IDataTableHelper DataTableConverter = new DataTableHelper();
            DataSet dataSet = jsonConvertHelper.JsonStringToDataSet(jsonString);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Proje proje1;
                proje1 = DataTableConverter.DataRowToModel<Proje>(dataRow);
                projeKod.Add(proje1);
            }
            return projeKod;
        }
        public List<ParcaGrup> ParcaGrup(ParcaGrup parcaGrup)
        {
            List<ParcaGrup> parcaGrups = new List<ParcaGrup>();
            string jsonString = WebMethods.GetParcaGrup(parcaGrup);
            IJsonConvertHelper jsonConvertHelper = new JsonConvertHelper();
            DataSet dataSet = jsonConvertHelper.JsonStringToDataSet(jsonString);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                ParcaGrup parcaGrup1;
                IDataTableHelper DataTableConverter = new DataTableHelper();
                parcaGrup1 = DataTableConverter.DataRowToModel<ParcaGrup>(dataRow);
                parcaGrups.Add(parcaGrup1);
            }
            return parcaGrups;
        }
        public List<MalzemeGrup> MalzemeGrup(MalzemeGrup malzemeGrup)
        {
            List<MalzemeGrup> malzemeGrups = new List<MalzemeGrup>();
            string jsonString = WebMethods.GetMalzemeGrup(malzemeGrup);
            IJsonConvertHelper jsonConvertHelper = new JsonConvertHelper();
            DataSet dataSet = jsonConvertHelper.JsonStringToDataSet(jsonString);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                MalzemeGrup malzemeGrup1;
                IDataTableHelper DataTableConverter = new DataTableHelper();
                malzemeGrup1 = DataTableConverter.DataRowToModel<MalzemeGrup>(dataRow);
                malzemeGrups.Add(malzemeGrup1);
            }
            return malzemeGrups;
        }
    }
}
