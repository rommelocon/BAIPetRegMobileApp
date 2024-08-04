using Microsoft.AspNetCore.Mvc;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly ILogger<UploadFileController> logger;
        private readonly IWebHostEnvironment webHostEnvironment;

        public UploadFileController(ILogger<UploadFileController> logger, IWebHostEnvironment webHostEnvironment)
        {
            this.logger = logger;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                // Store the content
                var httpContent = HttpContext.Request;

                // Check if null
                if (httpContent is null)
                    return BadRequest();

                // Check if the context contains multiple files.
                if (httpContent.Form.Files.Count > 0)
                {
                    // Loop through
                    foreach (var file in httpContent.Form.Files)
                    {
                        // Get File Path
                        var filePath = Path.Combine(webHostEnvironment.ContentRootPath, "Resources/Images");

                        // Check if director exist; if NO then create.
                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);

                        // Copy the file to the folder
                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            System.IO.File.WriteAllBytes(Path.Combine(filePath, file.FileName), memoryStream.ToArray());
                        }
                    }
                    return Ok(httpContent.Form.Files.Count.ToString() + " file(s) upload");
                }
                return BadRequest("No file selected.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}
