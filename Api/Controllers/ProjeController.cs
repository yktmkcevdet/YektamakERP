using Api.Business;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    public class ProjeController:Controller
    {
        private readonly IDataAccessLayer _dataAccessLayer;
        private readonly IProjeStokKartService _projeStokKartService;

        public ProjeController(IDataAccessLayer dataAccessLayer, IProjeStokKartService projeStokKartService)
        {
            _dataAccessLayer = dataAccessLayer;
            _projeStokKartService = projeStokKartService;
        }
        [HttpPost, Route("api/SaveProje")]
        public string SaveProje([FromBody] Proje proje)
        {
            string result = _dataAccessLayer.SaveObject(proje, "spSaveProje");
            return result;
        }
        [HttpPost, Route("api/GetProje")]
        public string GetProje([FromBody] Proje proje)
        {
            string result = _dataAccessLayer.GetObject(proje, "spGetProje");
            return result;
        }
        [HttpPost, Route("api/GetProjeSorumlu")]
        public string GetProjeSorumlu([FromBody] ProjeSorumlu projeSorumlu)
        {
            string result = _dataAccessLayer.GetObject(projeSorumlu, "spGetProjeSorumlu");
            return result;
        }
        [HttpPost, Route("api/SaveProjeSorumlu")]
        public string SaveProjeSorumlu([FromBody] ProjeSorumlu projeSorumlu)
        {
            string result = _dataAccessLayer.SaveObject(projeSorumlu, "spSaveProjeSorumlu");
            return result;
        }
        [HttpPost, Route("api/DeleteProje")]
        public string DeleteProje([FromBody] Proje proje)
        {
            string result = _dataAccessLayer.DeleteObject(proje, "spDeleteProje");
            return result;
        }
        [HttpPost, Route("api/SaveProjeStokKart")]
        public string SaveProjeStokKart([FromBody] ProjeStokKart projeStokKart)
        {
            //return await _projeStokKartService.SaveProjeStokKartAsync(projeStokKart);
            string result = _dataAccessLayer.SaveObject(projeStokKart, "spSaveProjeStokKart");
            return result;
        }
        [HttpPost, Route("api/GetProjeStokKart")]
        public string GetProjeStokKart([FromBody] ProjeStokKart projeStokKart)
        {
            string result = _dataAccessLayer.GetObject(projeStokKart, "spGetProjeStokKart");
            return result;
        }
        [HttpPost, Route("api/DeleteProjeStokKart")]
        public string DeleteProjeStokKart([FromBody] ProjeStokKart projeStokKart)
        {
            string result = _dataAccessLayer.DeleteObject(projeStokKart, "spDeleteProjeStokKart");
            return result;
        }
        [HttpPost, Route("api/GetProjeBomList")]
        public string GetBomList([FromBody] ProjeBom projeBomList)
        {
            string result = _dataAccessLayer.GetObject(projeBomList, "spGetProjeBomList");
            return result;
        }
    }
}
