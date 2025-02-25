using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Api.Controllers.GeneralMethods;
namespace Api.Controllers
{
    public class ButtonImageController:Controller
    {
        private readonly IDataAccessLayer _dataAccesLayer;

        public ButtonImageController(IDataAccessLayer dataAccesLayer)
        {
            _dataAccesLayer = dataAccesLayer;
        }

        [HttpPost, Route("api/GetButtonImage")]
        public string GetButtonImage([FromBody] string restData)
        {
            string result = _dataAccesLayer.SaveObject(JsonStringToModel<ButtonImage>(restData), "spGetButtonImage");
            return result;
        }
    }
}
