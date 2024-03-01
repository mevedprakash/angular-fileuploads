using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{

    private readonly ILogger<FileController> _logger;
    private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

    public FileController(ILogger<FileController> logger,
    Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
    {
        _logger = logger;
        _hostingEnvironment = hostingEnvironment;
    }

    [HttpPost("upload")]
    public ActionResult Upload([FromForm] List<IFormFile> files)
    {

        string FilePath = _hostingEnvironment.ContentRootPath + "/files";

        if (!Directory.Exists(FilePath))
            Directory.CreateDirectory(FilePath);

        foreach (var file in files)
        {
            var filePath = Path.Combine(FilePath, file.FileName);
            using (FileStream fs = System.IO.File.Create(filePath))
            {
                file.CopyTo(fs);

            }
        }

        return Ok(new { test = "test" });
    }
}
