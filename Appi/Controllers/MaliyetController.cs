using Appi.Business;
using Microsoft.AspNetCore.Mvc;

namespace Appi.Controllers
{
    public class MaliyetController
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public MaliyetController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        
    }
}
