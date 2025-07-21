
using Appi.Business;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Appi.Controllers
{
    public class ConfigurationController:Controller
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public ConfigurationController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        [HttpPost, Route("api/SaveGridSettings")]
        public string SaveGridSettings([FromBody] GridSettings restData)
        {
            return _dataAccessLayer.SaveObject(restData, "spSaveGridSettings");
        }
        [HttpPost, Route("api/GetGridSettings")]
        public string GetGridSettings([FromBody] GridSettings restData)
        {
            return _dataAccessLayer.SaveObject(restData, "spGetGridSettings");
        }
    }
}
