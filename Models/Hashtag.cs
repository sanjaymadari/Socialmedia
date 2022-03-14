
using System.Text.Json.Serialization;
using Socialmedia.DTOs;

namespace Socialmedia.Models;

public record Hashtag
{
    [JsonPropertyName("id")]
    public long Id { get; set; }


    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("posts_tagged")]
    public List<PostDTO> Posts { get; set;}


    public HashtagDTO asDto => new HashtagDTO
    {
        Id =Id,
        Name = Name,
    };
}