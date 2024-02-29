using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{

    private readonly ILogger<HomeController> _logger;
    private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

    public HomeController(ILogger<HomeController> logger,
    Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
    {
        _logger = logger;
        _hostingEnvironment = hostingEnvironment;
    }

    [HttpPost]
    public async Task<ActionResult> Get([FromForm] List<IFormFile> files)
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
