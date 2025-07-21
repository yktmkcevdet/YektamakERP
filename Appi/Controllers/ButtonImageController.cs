using Appi.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Appi.Controllers.GeneralMethods;
namespace Appi.Controllers
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
