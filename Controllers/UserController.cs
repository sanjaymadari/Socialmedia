using Microsoft.AspNetCore.Mvc;
using Socialmedia.DTOs;
using Socialmedia.Models;
using Socialmedia.Repositories;

namespace Socialmedia.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _user;
    private readonly IPostRepository _post;

    public UserController(ILogger<UserController> logger, IUserRepository user, IPostRepository post)
    {
        _logger = logger;
        _user = user;
        _post = post;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserListDTO>>> GetList()
    {
        var userList = (await _user.GetList()).Select(x => x.asListDto);
        return Ok(userList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetById([FromRoute] long id)
    {
        var user = (await _user.GetById(id));
        if(user == null)
            return NotFound("User not found for given id");

        var dto = user.asDto;
        dto.Posts = (await _post.GetListForUser(id)).Select(x => x.asDto).ToList();
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<UserListDTO>> Create([FromBody] UserCreateDTO Data)
    {
        if (!(new string[] { "male", "female" }.Contains(Data.Gender.Trim().ToLower())))
              return BadRequest("Gender value is not recognized");
        
        var toCreateUser = new User
        {
            UserName = Data.UserName,
            Password = Data.Password,
            FirstName = Data.FirstName,
            LastName = Data.LastName,
            DateOfBirth = Data.DateOfBirth.UtcDateTime,
            Gender = Enum.Parse<Gender>(Data.Gender, true),
            MobileNumber = Data.MobileNumber,
            EmailId = Data.EmailId,
            Bio = Data.Bio,

        };
        var createdUser = await _user.Create(toCreateUser);
        return StatusCode(StatusCodes.Status201Created, createdUser.asListDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserListDTO>> Update([FromRoute] long id,[FromBody] UserUpdateDTO Data)
    {
        var existing = await _user.GetById(id);
        if (existing is null)
            return NotFound("No user found with given user id");
        
        var toUpdateUser = existing with
        {
            UserName = Data.UserName ?? existing.UserName,
            Password = Data.Password ?? existing.Password,
            FirstName = Data.FirstName ?? existing.FirstName,
            LastName = Data.LastName ?? existing.LastName,
            Bio = Data.Bio ?? existing.Bio,
        };
        var didUpdate = await _user.Update(toUpdateUser);
        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update user");

         return NoContent();
    }

}
