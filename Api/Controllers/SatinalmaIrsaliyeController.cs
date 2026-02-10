using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Models.Satinalma;

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
    }
}
