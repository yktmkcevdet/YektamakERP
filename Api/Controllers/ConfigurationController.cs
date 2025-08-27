
using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Configuration;

namespace Api.Controllers
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
        [HttpPost, Route("api/GetDosyalamaYapisi")]
        public string GetDosyalamaYapisi([FromBody] DosyalamaYapisi restData)
        {
            return _dataAccessLayer.GetObject(restData, "spGetDosyalamaYapisi");
        }
    }
}
