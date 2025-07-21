using Appi.Business;
using Microsoft.AspNetCore.Mvc;

namespace Appi.Controllers
{
    public class DovizCinsiController
    {
        private readonly IDataAccessLayer _dataAccessLayer;
        public DovizCinsiController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        [HttpGet, Route("api/GetDovizCinsi")]
        public string GetDovizCinsi()
        {
            return _dataAccessLayer.GetObject("spGetDovizCinsi");
        }
    }
}
