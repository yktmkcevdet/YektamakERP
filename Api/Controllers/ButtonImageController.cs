using Api.Business;
using Microsoft.AspNetCore.Mvc;
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
