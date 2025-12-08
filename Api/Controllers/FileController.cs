using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _contentRootUploadPath;
        public FileController(IWebHostEnvironment env)
        {
            _env = env;
            _contentRootUploadPath = Path.Combine(_env.ContentRootPath, "Uploads");
        }

        [HttpPost("ProcessDirectory")]
        public IActionResult ProcessDirectory([FromForm] IFormFile file)
        {
            // 1. Dosyanın geçici bir dizine kaydedilmesi
            var uploadsPath = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }

            var filePath = Path.Combine(uploadsPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // 2. Dosyanın bulunduğu dizin ve alt dizinlerde PDF'leri tarama
            var directory = Path.GetDirectoryName(filePath); // Dosyanın bulunduğu dizin
            var pdfFiles = Directory.GetFiles(directory, "*.pdf", SearchOption.AllDirectories);

            // 3. PDF dosyalarını veritabanına kaydetme (Örnek)
            foreach (var pdfFile in pdfFiles)
            {
                Console.WriteLine($"Found PDF: {pdfFile}");
                // Burada PDF dosyasıyla ilgili işlemleri gerçekleştirebilirsiniz
                // Örneğin, dosya adı ve yolu gibi bilgileri veritabanına kaydedebilirsiniz.
            }

            return Ok(new { message = "PDF files processed successfully.", pdfCount = pdfFiles.Length });
        }
        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Dosya boş olamaz.");

            // Uygulama dizini altına "Uploads" klasörüne kaydediyoruz
            Directory.CreateDirectory(_contentRootUploadPath);

            var filePath = Path.Combine(_contentRootUploadPath, file.FileName);

            // Dosyayı sunucuya kaydet
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { message = "Dosya başarıyla yüklendi.", path = filePath });
        }
        [HttpGet("download/{fileName}")]
        public IActionResult DownloadFile(string fileName)
        {
            Directory.CreateDirectory(_contentRootUploadPath);

            var filePath = Path.Combine(_contentRootUploadPath, fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound("Dosya bulunamadı.");

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var contentType = "application/octet-stream";
            return File(fileBytes, contentType, fileName);
        }

    }
}
