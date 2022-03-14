
using Socialmedia.DTOs;

namespace Socialmedia.Models;

public enum PostType
{
    Image = 1,
    Video = 2,
}
public record Post
{
    public long Id { get; set; }
    public PostType Type { get; set; }
    public long UserId { get; set; }
    public DateTimeOffset PostedAt { get; set; }
    public string Description { get; set; }

    public PostDTO asDto => new PostDTO
    {
        Id =Id,
        Type = Type.ToString(),
        UserId = UserId,
        PostedAt = PostedAt,
        Description = Description
    };
    //  public PostListDTO asListDto => new PostListDTO
    // {
    //     Id =Id,
    //     Type = Type.ToString(),
    //     UserId = UserId,
    //     PostedAt = PostedAt,
    //     Description = Description
    // };
    //     public PostForUserDTO asByIdDto => new PostForUserDTO
    // {
    //     Id =Id,
    //     Type = Type.ToString(),
    //     PostedAt = PostedAt,
    //     Description = Description
    // };


}