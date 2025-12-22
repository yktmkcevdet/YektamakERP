using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class VersionControl : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _contentRootDownloadPath;
        public VersionControl(IWebHostEnvironment env)
        {
            _env = env;
            _contentRootDownloadPath = Path.Combine(_env.ContentRootPath, "Download");
        }
        [HttpGet("version")]
        public IActionResult Version()
        {
            return Json(new
            {
                version = "1.3.7",
                setupUrl = $"{_contentRootDownloadPath}\\YektamakERP_Setup.exe"
            });
        }
    }
}
