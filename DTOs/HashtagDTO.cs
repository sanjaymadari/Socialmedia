

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Socialmedia.DTOs;

public record HashtagDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }


    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("posts_tagged")]
    public List<PostDTO> Posts { get; set;}
}

public record HashtagCreateDTO
{
    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }
}