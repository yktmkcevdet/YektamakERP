using Appi.Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Appi.Controllers.GeneralMethods;
namespace Appi.Controllers
{
    public class SatisSiparisTeklifTalepController
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public SatisSiparisTeklifTalepController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        [HttpPost, Route("api/SaveSatisSiparisTeklifTalep")]
        public string SaveSatisSiparis([FromBody] string siparisTeklifTalep)
        {
            string result = _dataAccessLayer.SaveObject(JsonStringToModel<SatisTeklifTalep>(siparisTeklifTalep), "spSaveSatisSiparisTeklifTalep");
            return result;
        }
        [HttpPost, Route("api/GetSatisTeklifTalep")]
        public string GetSatisTeklifTalep([FromBody] string siparisTeklifTalep)
        {
            string result = _dataAccessLayer.GetObject(JsonStringToModel<SatisTeklifTalep>(siparisTeklifTalep), "spGetSatisSiparisTeklifTalep");
            return result;
        }
        [HttpGet, Route("api/GetSiparisTeklifTalep/{teklifTalepId}")]
        public string GetSatisSiparisTeklifTalepWithId(string teklifTalepId)
        {
            string result  = _dataAccessLayer.GetObject(teklifTalepId, "spGetSatisSiparisTeklifTalep");
            return result;
        }
        [HttpDelete, Route("api/DeleteSatisSiparisTeklifTalep/{teklifTalepId}")]
        public string DeleteSatisTeklifTalep(string teklifTalepId)
        {
            SatisTeklifTalep satisTeklifTalep = new SatisTeklifTalep();
            satisTeklifTalep.Id = int.Parse(teklifTalepId);
            return _dataAccessLayer.DeleteObject(satisTeklifTalep, "spDeleteSatisSiparisTeklifTalep");
        }
    }
}
