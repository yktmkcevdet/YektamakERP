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
        public string SavePersonel([FromBody]Personel restData)
        {
            string result = _dataAccessLayer.SaveObject(restData, "spSavePersonel");
            return result;
        }
        [HttpPost, Route("api/SavePersonelResim/")]
        public string SavePersonelResim([FromBody] PersonelResim restData)
        {
            string result = _dataAccessLayer.SaveObject(restData, "spSavePersonelResim");
            return result;
        }

        [HttpPost, Route("api/DeletePersonel/")]
        public string DeletePersonel([FromBody] Personel restData)
        {
            string result = _dataAccessLayer.DeleteObject(restData, "spDeletePersonel");
            return result;
        }

        [HttpPost, Route("api/GetPersonel/")]
        public string GetPersonel([FromBody] Personel restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetPersonel");
            return result;
        }
        [HttpPost, Route("api/GetPozisyon/")]
        public string GetPozisyon([FromBody] Pozisyon restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetPozisyon");
            return result;
        }

        [HttpPost, Route("api/GetPersonelResim/")]
        public string GetPersonelResim([FromBody] Personel restData)
        {
            string result = _dataAccessLayer.GetObject(restData, "spGetPersonelResim");
            return result;
        }
    }
}
