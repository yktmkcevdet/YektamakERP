using Appi.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Appi.Controllers.GeneralMethods;

namespace Appi.Controllers
{
    public class VadeController
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public VadeController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        [HttpGet, Route("api/GetVade")]
        public string GetStokKartFilter()
        {
            string result = _dataAccessLayer.GetObject("spGetVade");
            return result;
        }
    }
}
