using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Api.Controllers.GeneralMethods;

namespace Api.Controllers
{
    public class SatinalmaTeklifController:Controller
    {
        private readonly IDataAccessLayer _dataAccesLayer;

        public SatinalmaTeklifController(IDataAccessLayer dataAccesLayer)
        {
            _dataAccesLayer = dataAccesLayer;
        }
        [HttpPost, Route("api/SaveSatinalmaTeklif")]
        public string SaveSatinalmaTalep([FromBody] SatinalmaTeklifBaslik restData)
        {
            string result = _dataAccesLayer.SaveObject(restData, "spSaveSatinalmaTeklif");
            return result;
        }
        [HttpPost, Route("api/GetSatinalmaTeklif")]
        public string GetSatinalmaTeklif([FromBody] SatinalmaTeklifBaslik restData)
        {
            string result = _dataAccesLayer.GetObject(restData, "spGetSatinalmaTeklif");
            return result;
        }
        [HttpPost, Route("api/DeleteSatinalmaTeklif")]
        public string DeleteSatinalmaTeklif([FromBody] SatinalmaTeklifBaslik restData)
        {
            string result = _dataAccesLayer.DeleteObject(restData, "spDeleteSatinalmaTeklif");
            return result;
        }
    }
}
