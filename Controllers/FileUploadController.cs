using Microsoft.AspNetCore.Mvc;

namespace Socialmedia.Controllers;

[Route("api/fileupload")]
[ApiController]
public class FileUploadController : ControllerBase
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileUploadController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    [HttpPost]
    public IActionResult UploadFile(List<IFormFile> files)
    {
        if(files.Count == 0)
            return BadRequest("No files found");
        string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");

        foreach(var file in files)
        {
                string filePath = Path.Combine(directoryPath, file.FileName);
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

        }
        return Ok("Uploaded successfully");
    }
}