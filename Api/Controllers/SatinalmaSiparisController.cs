using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    public class SatinalmaSiparisController:Controller
    {
        private readonly IDataAccessLayer _dataAccesLayer;

        public SatinalmaSiparisController(IDataAccessLayer dataAccesLayer)
        {
            _dataAccesLayer = dataAccesLayer;
        }
        [HttpPost, Route("api/GetSatinalmaSiparis")]
        public string GetSatinalmaSiparis([FromBody] SatinalmaSiparis restData)
        {
            string result = _dataAccesLayer.GetObject(restData, "spGetSatinalmaSiparis");
            return result;
        }
        [HttpPost, Route("api/GetSatinalmaSiparisDetay")]
        public string GetSatinalmaSiparisDetay([FromBody] SatinalmaTeklifDetay restData)
        {
            string result = _dataAccesLayer.GetObject(restData, "spGetSatinalmaSiparisDetay");
            return result;
        }
        [HttpPost, Route("api/SaveSatinalmaSiparis")]
        public string SaveSatinalmaSiparis([FromBody] SatinalmaSiparis restData)
        {
            string result = _dataAccesLayer.SaveObject(restData, "spSaveSatinalmaSiparis");
            return result;
        }
        [HttpPost, Route("api/DeleteSatinalmaSiparis")]
        public string DeleteSatinalmaSiparis([FromBody] SatinalmaTeklifBaslik restData)
        {
            string result = _dataAccesLayer.SaveObject(restData, "spDeleteSatinalmaSiparis");
            return result;
        }
    }
}
