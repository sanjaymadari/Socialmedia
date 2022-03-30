using Microsoft.AspNetCore.Mvc;
using Socialmedia.Models;
using Socialmedia.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Socialmedia.DTOs;
using System.Text.Json;

namespace Socialmedia.Controllers;

[ApiController]
[Route("api/hashtag")]
public class HashtagController : ControllerBase
{
    private readonly ILogger<HashtagController> _logger;
    private readonly IMemoryCache _memoryCache;
    private readonly IHashtagRepository _hashtag;
    private readonly IPostRepository _post;
    public HashtagController(ILogger<HashtagController> logger, IHashtagRepository hashtag, IPostRepository post, IMemoryCache memoryCache)
    {
        _logger = logger;
        _hashtag = hashtag;
        _post = post;
        _memoryCache = memoryCache;
    }

    [HttpGet]
    public async Task<ActionResult<List<HashtagDTO>>> GetList(int page, int limit)
    {
        var hashtagList = (await _hashtag.GetList(page,limit)).Select(x => x.asDto);
        //var paginationMetadata = new PaginationMetadata(hashtagList.Count(), @params.Page, @params.ItemsPerPage);
        //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));
        //var items = hashtagList.Skip((@params.Page - 1) * @params.ItemsPerPage).Take(@params.ItemsPerPage).ToList();
       

    //Memory Cache
        DateTime currentTime;
        bool AlreadyExist = _memoryCache.TryGetValue("Cached", out currentTime);
        if(!AlreadyExist)
        {
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(200),
        
            };

            _memoryCache.Set("Cached", hashtagList, cacheEntryOptions);
        }
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
