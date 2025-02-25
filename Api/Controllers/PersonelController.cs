using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Api.Controllers.GeneralMethods;

namespace Api.Controllers
{
    public class PersonelController:Controller
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public PersonelController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        [HttpPost, Route("api/SavePersonel/")]
        public string SavePersonel([FromBody]string restData)
        {
            string result = _dataAccessLayer.SaveObject(JsonStringToModel<Personel>(restData), "spSavePersonel");
            return result;
        }

        [HttpPost, Route("api/DeletePersonel/")]
        public string DeletePersonel([FromBody] string restData)
        {
            string result = _dataAccessLayer.DeleteObject(JsonStringToModel<Personel>(restData), "spDeletePersonel");
            return result;
        }

        [HttpPost, Route("api/GetPersonel/")]
        public string GetPersonel([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<Personel>(restData), "spGetPersonel");
            return result;
        }

        [HttpPost, Route("api/GetPersonelResim/")]
        public string GetPersonelResim([FromBody] string restData)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<PersonelResim>(restData), "spGetPersonelResim");
            return result;
        }
    }
}
