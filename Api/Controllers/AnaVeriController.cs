using Api.DatabaseJobs;
using Models;
using Microsoft.AspNetCore.Mvc;
using Api.Business;

namespace Api.Controllers
{
    public class AnaVeriController : Controller
    {
        private readonly IDataAccessLayer _dataAccesLayer;

        public AnaVeriController(IDataAccessLayer dataAccesLayer)
        {
            _dataAccesLayer = dataAccesLayer;
        }

        [HttpGet, Route("api/GetParcaGrupList/")]
        public string GetParcaGrupList()
        {
            string result = _dataAccesLayer.GetObject("spGetParcaGrupList");
            return result;
        }
        [HttpGet, Route("api/GetParcaAltGrupList/")]
        public string GetParcaAltGrupList()
        {
            string result = _dataAccesLayer.GetObject("spGetParcaAltGrupList");
            return result;
        }
        [HttpGet, Route("api/GetReferansKaynak/")]
        public string GetReferansKaynak()
        {
            string result = _dataAccesLayer.GetObject("spGetReferansKaynak");
            return result;
        }
    }
}
