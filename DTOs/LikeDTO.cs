
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Socialmedia.DTOs;

public record LikeDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    [JsonPropertyName("post_id")]
    public long PostId { get; set; }
}

public record LikeCreateDTO
{

    [JsonPropertyName("user_id")]
    [Required]
    public long UserId { get; set; }

    [JsonPropertyName("post_id")]
    [Required]
    public long PostId { get; set; }
}

public record LikeForPostDTO
{
    [JsonPropertyName("like_id")]
    public long Id { get; set; }

    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    [JsonPropertyName("user_name")]
    public string UserName { get; set; }

}