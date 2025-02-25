using Api.Business;
using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Models;

namespace Api.Controllers
{
    public class LogController:Controller
    {
        private readonly Business.IDataAccessLayer _dataAccessLayer;

        public LogController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        [HttpPost, Route("api/SaveErrorLog/")]
        public string SaveErrorLog([FromBody] string restData)
        {
            string result = _dataAccessLayer.SaveObject(restData,"spGetMarka");
            return GeneralMethods.ResultData<ErrorLog>(result);
        }
    }
}
