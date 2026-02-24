using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
namespace Api.Controllers
{
    public class SatinalmaTalepController:Controller
    {
        private readonly IDataAccessLayer _dataAccesLayer;

        public SatinalmaTalepController(IDataAccessLayer dataAccesLayer)
        {
            _dataAccesLayer = dataAccesLayer;
        }

        [HttpPost, Route("api/SaveSatinalmaTalep")]
        public string SaveSatinalmaTalep([FromBody] SatinalmaTalep restData)
        {
            string result = _dataAccesLayer.SaveObject(restData, "spSaveSatinalmaTalep");
            return result;
        }
        [HttpPost, Route("api/GetSatinalmaTalepDetay")]
        public string GetSatinalmaTalepDetay([FromBody] SatinalmaTalepDetay restData)
        {
            string result = _dataAccesLayer.GetObject(restData, "spGetSatinalmaTalepDetay");
            return result;
        }
        [HttpPost, Route("api/GetSatinalmaTalepSatirDetay")]
        public string GetSatinalmaTalepSatirDetay([FromBody] SatinalmaTalepSatirDetayDTO restData)
        {
            string result = _dataAccesLayer.GetObject(restData, "spGetSatinalmaTalepSatirDetay");
            return result;
        }
        [HttpPost, Route("api/GetSatinalmaTalep")]
        public string GetSatinalmaTalep([FromBody] SatinalmaTalep restData)
        {
            string result = _dataAccesLayer.GetObject(restData, "spGetSatinalmaTalep");
            return result;
        }
        [HttpPost, Route("api/DeleteSatinalmaTalep")]
        public string DeleteSatinalmaTalep([FromBody] SatinalmaTalep restData)
        {
            string result = _dataAccesLayer.DeleteObject(restData, "spDeleteSatinalmaTalep");
            return result;
        }
        [HttpPost, Route("api/SatinalmaTalepOnay")]
        public string SatinalmaTalepOnay([FromBody] SatinalmaTalep restData)
        {
            string result = _dataAccesLayer.GetObject(restData, "fnSatinalmaTalepOnay");
            return result;
        }
    }
}
