using Socialmedia.DTOs;

namespace Socialmedia.Models;

public record Like
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long PostId { get; set; }

    public string UserName { get;}


    public LikeForPostDTO asByIdDto => new LikeForPostDTO
    {
        Id =Id,
        UserId = UserId,
        UserName = UserName,
    };
    
}
