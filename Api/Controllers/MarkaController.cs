using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    public class MarkaController : Controller
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public MarkaController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        [HttpGet, Route("api/GetMarka/")]
        public string GetMarka()
        {
            string result = _dataAccessLayer.GetObject("spGetMarka");
            return result;
        }
            
        [HttpGet, Route("api/GetMarkaAltGrup/")]
        public string GetMarkaAltGrup()
        {
            string result = _dataAccessLayer.GetObject("spGetMarkaAltGrup");
            return result;
        }
        [HttpGet, Route("api/GetMarkaAltGrupKategori/")]
        public string GetMarkaAltGrupKategori()
        {
            string result = _dataAccessLayer.GetObject("spGetMarkaAltGrupKategori");
            return result;
        }
    }
}