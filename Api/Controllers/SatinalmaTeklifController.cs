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
        public string SaveSatinalmaTalep([FromBody] string restData)
        {
            string result = _dataAccesLayer.SaveObject(JsonStringToString(restData), "spSaveSatinalmaTeklif");
            return result;
        }
        [HttpPost, Route("api/GetSatinalmaTeklif")]
        public string GetSatinalmaTeklif([FromBody] string restData)
        {
            string result = _dataAccesLayer.GetObject(JsonStringToString(restData), "spGetSatinalmaTeklif");
            return result;
        }
        [HttpPost, Route("api/DeleteSatinalmaTeklif")]
        public string DeleteSatinalmaTeklif([FromBody] string restData)
        {
            string result = _dataAccesLayer.DeleteObject(JsonStringToModel<SatinalmaTeklifBaslik>(restData), "spDeleteSatinalmaTeklif");
            return result;
        }
    }
}
