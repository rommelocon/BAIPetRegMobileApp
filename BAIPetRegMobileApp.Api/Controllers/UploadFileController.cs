using Microsoft.AspNetCore.Mvc;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly ILogger<UploadFileController> logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly string _imageFolderPath;

        public UploadFileController(ILogger<UploadFileController> logger, IWebHostEnvironment webHostEnvironment)
        {
            this.logger = logger;
            this.webHostEnvironment = webHostEnvironment; 
            _imageFolderPath = Path.Combine(webHostEnvironment.ContentRootPath, "Resources", "Images");
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
                        // Check if director exist; if NO then create.
                        if (!Directory.Exists(_imageFolderPath))
                            Directory.CreateDirectory(_imageFolderPath);

                        // Copy the file to the folder
                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            System.IO.File.WriteAllBytes(Path.Combine(_imageFolderPath, file.FileName), memoryStream.ToArray());
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

        [HttpGet("images/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            try
            {
                var filePath = Path.Combine(_imageFolderPath, fileName);

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("Image not found");
                }

                var image = System.IO.File.OpenRead(filePath);
                return File(image, "image/jpeg"); // Adjust MIME type according to your image format
            }
            catch (Exception ex)
            {
                // Log the error
                logger.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}
