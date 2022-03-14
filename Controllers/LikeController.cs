using Microsoft.AspNetCore.Mvc;
using Socialmedia.DTOs;
using Socialmedia.Models;
using Socialmedia.Repositories;

namespace Socialmedia.Controllers;

[ApiController]
[Route("[controller]")]
public class LikeController : ControllerBase
{
    private readonly ILogger<LikeController> _logger;
    private readonly ILikeRepository _like;

    public LikeController(ILogger<LikeController> logger, ILikeRepository like)
    {
        _logger = logger;
        _like = like;
    }

    [HttpPost]
    public async Task<ActionResult<LikeDTO>> Create([FromBody] LikeCreateDTO Data)
    {
        var toCreateLike = new Like
        {
            UserId = Data.UserId,
            PostId = Data.PostId
        };
        await _like.Create(toCreateLike);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] long id)
    {
        var existing = await _like.GetById(id);
        if(existing == null)
            return NotFound("No like found with given id");
        await _like.Delete(id);
        return NoContent();
    }

}
