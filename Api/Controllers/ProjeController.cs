using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Api.Controllers.GeneralMethods;

namespace Api.Controllers
{
    public class ProjeController:Controller
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public ProjeController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        [HttpPost, Route("api/SaveProje")]
        public string SaveProje([FromBody] string proje)
        {
            string result = _dataAccessLayer.SaveObject(JsonStringToModel<Proje>(proje), "spSaveProje");
            return result;
        }
        [HttpPost, Route("api/GetProje")]
        public string GetProje([FromBody] string proje)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<Proje>(proje), "spGetProje");
            return result;
        }
    }
}
