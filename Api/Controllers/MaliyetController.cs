using Api.Business;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
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
