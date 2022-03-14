using Microsoft.AspNetCore.Mvc;
using Socialmedia.Models;
using Socialmedia.Repositories;
namespace Socialmedia.Controllers;

[ApiController]
[Route("[controller]")]
public class HashtagController : ControllerBase
{
    private readonly ILogger<HashtagController> _logger;
    private readonly IHashtagRepository _hashtag;
    private readonly IPostRepository _post;
    public HashtagController(ILogger<HashtagController> logger, IHashtagRepository hashtag, IPostRepository post)
    {
        _logger = logger;
        _hashtag = hashtag;
        _post = post;
    }

    [HttpGet]
    public async Task<ActionResult<List<HashtagDTO>>> GetList()
    {
        var hashtagList = (await _hashtag.GetList()).Select(x => x.asDto);
        return Ok(hashtagList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HashtagDTO>> GetById([FromRoute] long id)
    {
        var hashtag = (await _hashtag.GetById(id)).asDto;
        if(hashtag == null)
            return NotFound("Hashtag not found with given id");
    
        hashtag.Posts = (await _post.GetListForHashtag(id)).Select(x => x.asDto).ToList();

        return Ok(hashtag);

    }

    [HttpPost]
    public async Task<ActionResult<HashtagDTO>> Create([FromBody] HashtagCreateDTO Data)
    {
        var toCreateHashtag = new Hashtag
        {
            Name = Data.Name,
        };
        var createdHashtag = await _hashtag.Create(toCreateHashtag);
        return StatusCode(StatusCodes.Status201Created, createdHashtag.asDto);
    }
}
