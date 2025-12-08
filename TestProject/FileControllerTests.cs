using System;
using System.IO;
using System.Text;
using Api.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace TestProject;

public class FileControllerTests
{
    private class FakeWebHostEnvironment : IWebHostEnvironment
    {
        public string ApplicationName { get; set; } = string.Empty;
        public IFileProvider WebRootFileProvider { get; set; } = new NullFileProvider();
        public string WebRootPath { get; set; } = string.Empty;
        public string EnvironmentName { get; set; } = Environments.Development;
        public string ContentRootPath { get; set; } = string.Empty;
        public IFileProvider ContentRootFileProvider { get; set; } = new NullFileProvider();
    }

    [Fact]
    public async Task UploadAndDownload_UseSameContentRootUploadsDirectory()
    {
        var tempRoot = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempRoot);
        var uploadsPath = Path.Combine(tempRoot, "Uploads");

        try
        {
            var env = new FakeWebHostEnvironment
            {
                ContentRootPath = tempRoot,
                WebRootPath = Path.Combine(tempRoot, "wwwroot")
            };

            var controller = new FileController(env);
            var content = "hello uploads";
            await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            stream.Position = 0;
            var formFile = new FormFile(stream, 0, stream.Length, "file", "test.txt")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };

            var uploadResult = await controller.Upload(formFile) as OkObjectResult;

            Assert.NotNull(uploadResult);
            Assert.True(System.IO.File.Exists(Path.Combine(uploadsPath, "test.txt")));

            var downloadResult = controller.DownloadFile("test.txt") as FileContentResult;

            Assert.NotNull(downloadResult);
            Assert.Equal(content, Encoding.UTF8.GetString(downloadResult!.FileContents));
        }
        finally
        {
            Directory.Delete(tempRoot, true);
        }
    }
}
