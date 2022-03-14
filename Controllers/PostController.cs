using Microsoft.AspNetCore.Mvc;
using Socialmedia.DTOs;
using Socialmedia.Models;
using Socialmedia.Repositories;

namespace Socialmedia.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly ILogger<PostController> _logger;
    private readonly IPostRepository _post;
    private readonly ILikeRepository _like;
    private readonly IHashtagRepository _hashtag;

    public PostController(ILogger<PostController> logger, IPostRepository post, ILikeRepository like, IHashtagRepository hashtag)
    {
        _logger = logger;
        _post = post;
        _like = like;
        _hashtag = hashtag;
    }

    [HttpGet]
    public async Task<ActionResult<List<PostDTO>>> GetList()
    {
        var postList = (await _post.GetList()).Select(x => x.asDto);
        return Ok(postList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostDTO>> GetById([FromRoute] long id)
    {
        var post = (await _post.GetById(id));
        if(post == null)
            return NotFound("Post not found for given id");
        var dto = post.asDto;
        dto.Likes = (await _like.GetListForPost(id)).Select(x => x.asByIdDto).ToList();
        dto.Hashtags = (await _hashtag.GetListForPost(id)).Select(x => x.asDto).ToList();
        
        
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<PostDTO>> Create([FromBody] PostCreateDTO Data)
    {
        if (!(new string[] { "image", "video" }.Contains(Data.Type.Trim().ToLower())))
            return BadRequest("Type value is not recognized");

        var toCreatePost = new Post
        {
            Type = Enum.Parse<PostType>(Data.Type, true),
            UserId = Data.UserId,
            Description = Data.Description,
        };
        var createdPost = await _post.Create(toCreatePost);
        return StatusCode(StatusCodes.Status201Created, createdPost.asDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PostDTO>> Update([FromRoute] long id, [FromBody] PostUpdateDTO Data)
    {
        var existing = await _post.GetById(id);
        if(existing == null)
            return NotFound("No post found with given post id");
        var toUpdatePost = existing with
        {
            Description = Data.Description,
        };
        var didUpdate = await _post.Update(toUpdatePost);
        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update user");

         return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] long id)
    {
        var existing = await _post.GetById(id);
        if(existing == null)
            return NotFound("No post fount with given id");
        await _post.Delete(id);
        return NoContent();
    }

}
