using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    public class SatinalmaIrsaliyeController:Controller
    {
        private readonly IDataAccessLayer _dataAccesLayer;

        public SatinalmaIrsaliyeController(IDataAccessLayer dataAccesLayer)
        {
            _dataAccesLayer = dataAccesLayer;
        }
        [HttpPost, Route("api/SaveSatinalmaIrsaliye")]
        public string SaveSatinalmaIrsaliye([FromBody] SatinalmaIrsaliyeBaslik restData)
        {
            string result = _dataAccesLayer.SaveObject(restData, "spSaveSatinalmaIrsaliye");
            return result;
        }
        [HttpPost, Route("api/GetSatinalmaIrsaliye")]
        public string GetSatinalmaIrsaliye([FromBody] SatinalmaIrsaliyeBaslik restData)
        {
            string result = _dataAccesLayer.GetObject(restData, "spGetSatinalmaIrsaliye");
            return result;
        }
        [HttpPost, Route("api/DeleteSatinalmaIrsaliye")]
        public string DeleteSatinalmaIrsaliye([FromBody] SatinalmaIrsaliyeBaslik restData)
        {
            string result = _dataAccesLayer.GetObject(restData, "spDeleteSatinalmaIrsaliye");
            return result;
        }
    }
}
