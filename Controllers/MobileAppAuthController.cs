using Microsoft.AspNetCore.Mvc;
using Socialmedia.DTOs;
using Socialmedia.Models;
using Socialmedia.Repositories;

namespace Socialmedia.Controllers;

[ApiController]
[Route("api/login")]
public class MobileAppAuthController : ControllerBase
{
    private readonly ILogger<MobileAppAuthController> _logger;
    private readonly IUserRepository _user;

    public MobileAppAuthController(ILogger<MobileAppAuthController> logger, IUserRepository user, IPostRepository post)
    {
        _logger = logger;
        _user = user;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserListDTO>>> GetList()
    {
        var userList = (await _user.GetList()).Select(x => x.asListDto);
        return Ok(userList);
    }

    [HttpPost]
    public async Task<ActionResult> Login([FromBody] UserLoginDTO Data)
    {
        var user = await _user.Login(Data.Username, Data.Password);
        return Ok(user);
    }



}
