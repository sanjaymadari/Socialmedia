

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Socialmedia.Models;

namespace Socialmedia.DTOs;
public record PostDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    [JsonPropertyName("posted_at")]
    public DateTimeOffset PostedAt { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("likes")]
    public List<LikeForPostDTO> Likes { get; set; }
    
    [JsonPropertyName("hashtags")]
    public List<HashtagDTO> Hashtags { get; set; }
}


public record PostCreateDTO
{
     [JsonPropertyName("type")]
     [Required]
    public string Type { get; set; }

    [JsonPropertyName("user_id")]
     [Required]
    public long UserId { get; set; }

    [JsonPropertyName("description")]
    [MaxLength(255)]
    public string Description { get; set; }
}

public record PostUpdateDTO
{
    [JsonPropertyName("description")]
    public string Description { get; set; }   
}

public record PostForUserDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("posted_at")]
    public DateTimeOffset PostedAt { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}

public record PostListDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    [JsonPropertyName("posted_at")]
    public DateTimeOffset PostedAt { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}

