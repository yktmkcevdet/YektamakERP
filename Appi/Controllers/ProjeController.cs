using Appi.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Org.BouncyCastle.Ocsp;
using static Appi.Controllers.GeneralMethods;

namespace Appi.Controllers
{
    public class ProjeController:Controller
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public ProjeController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        [HttpPost, Route("api/SaveProje")]
        public string SaveProje([FromBody] Proje proje)
        {
            string result = _dataAccessLayer.SaveObject(proje, "spSaveProje");
            return result;
        }
        [HttpPost, Route("api/GetProje")]
        public string GetProje([FromBody] Proje proje)
        {
            string result = _dataAccessLayer.GetObject(proje, "spGetProje");
            return result;
        }
        [HttpPost, Route("api/SaveProjeStokKart")]
        public string SaveProjeStokKart([FromBody] ProjeStokKart projeStokKart)
        {
            string result = _dataAccessLayer.SaveObject(projeStokKart, "spSaveProjeStokKart");
            return result;
        }
        [HttpPost, Route("api/GetProjeStokKart")]
        public string GetProjeStokKart([FromBody] ProjeStokKart projeStokKart)
        {
            string result = _dataAccessLayer.GetObject(projeStokKart, "spGetProjeStokKart");
            return result;
        }
    }
}
