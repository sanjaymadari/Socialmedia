using Microsoft.AspNetCore.Mvc;

namespace Socialmedia.Controllers;

[ApiController]
[Route("[controller]")]
public class CacheController : ControllerBase
{
    [HttpGet]
    public int Get()
    {
        var result = CacheModel.Get("test");
        return result;
    }
}