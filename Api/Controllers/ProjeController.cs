using Api.Business;
using Api.Factory;
using Api.Interfaces;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    public class ProjeController:Controller
    {
        private readonly IDataAccessLayer _dataAccessLayer;
        private readonly IStokService _stokService;
        private readonly IDbConnectionFactory _connectionFactory;

        public ProjeController(IDataAccessLayer dataAccessLayer, IStokService stokService, IDbConnectionFactory connectionFactory)
        {
            _dataAccessLayer = dataAccessLayer;
            _stokService = stokService;
            _connectionFactory = connectionFactory;
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
        [HttpPost, Route("api/DeleteProjeFile")]
        public string DeleteProjeFile([FromBody] ProjeDosya projeDosya)
        {
            string result = _dataAccessLayer.DeleteObject(projeDosya, "spDeleteProjeFile");
            return result;
        }
        [HttpPost, Route("api/SaveProjeStokKart")]
        public string SaveProjeStokKart([FromBody] ProjeStokKart projeStokKart)
        {
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
