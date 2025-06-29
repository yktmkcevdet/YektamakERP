using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Api.Controllers.GeneralMethods;
namespace Api.Controllers
{
    public class SatinalmaTalepController : Controller
    {
        private readonly IDataAccessLayer _dataAccesLayer;

        public SatinalmaTalepController(IDataAccessLayer dataAccesLayer)
        {
            _dataAccesLayer = dataAccesLayer;
        }

        [HttpPost, Route("api/SaveSatinalmaTalep")]
        public string SaveSatinalmaTalep([FromBody] string restData)
        {
            string result = _dataAccesLayer.SaveObject(JsonStringToModel<SatinalmaTalep>(restData), "spSaveSatinalmaTalep");
            return result;
        }
        [HttpPost, Route("api/GetSatinalmaTalepDetay")]
        public string GetSatinalmaTalepDetay([FromBody] string restData)
        {
            string result = _dataAccesLayer.GetObject(JsonStringToModel<SatinalmaTalepDetay>(restData), "spGetSatinalmaTalepDetay");
            return result;
        }
        [HttpPost, Route("api/GetSatinalmaTalepSatirDetay")]
        public string GetSatinalmaTalepSatirDetay([FromBody] string restData)
        {
            string result = _dataAccesLayer.GetObject(JsonStringToModel<SatinalmaTalepSatirDetay>(restData), "spGetSatinalmaTalepSatirDetay");
            return result;
        }
        [HttpPost, Route("api/GetSatinalmaTalep")]
        public string GetSatinalmaTalep([FromBody] string restData)
        {
            string result = _dataAccesLayer.GetObject(JsonStringToModel<SatinalmaTalep>(restData), "spGetSatinalmaTalep");
            return result;
        }
        [HttpPost, Route("api/DeleteSatinalmaTalep")]
        public string DeleteSatinalmaTalep([FromBody] string restData)
        {
            string result = _dataAccesLayer.GetObject(JsonStringToModel<SatinalmaTalep>(restData), "spDeleteSatinalmaTalep");
            return result;
        }
        [HttpPost, Route("api/SatinalmaTalepOnay")]
        public string SatinalmaTalepOnay([FromBody] string restData)
        {
            string result = _dataAccesLayer.GetObject(JsonStringToModel<SatinalmaTalep>(restData), "fnSatinalmaTalepOnay");
            return result;
        }
    }
}
