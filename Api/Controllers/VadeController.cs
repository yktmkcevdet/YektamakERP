using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Api.Controllers.GeneralMethods;

namespace Api.Controllers
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
