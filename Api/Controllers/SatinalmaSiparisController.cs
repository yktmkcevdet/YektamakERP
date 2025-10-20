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
        public string GetSatinalmaSiparis([FromBody] SatinalmaTeklifBaslik restData)
        {
            string result = _dataAccesLayer.GetObject(restData, "spGetSatinalmaSiparis");
            return result;
        }
        [HttpPost, Route("api/SaveSatinalmaSiparis")]
        public string SaveSatinalmaSiparis([FromBody] SatinalmaTeklifBaslik restData)
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
