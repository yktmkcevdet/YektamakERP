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

    }
}
