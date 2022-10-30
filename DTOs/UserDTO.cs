
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Socialmedia.Models;

namespace Socialmedia.DTOs;

public record UserDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("user_name")]
    public string UserName { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("date_of_birth")]
    public DateTimeOffset DateOfBirth { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("mobile_number")]
    public long MobileNumber { get; set; }

    [JsonPropertyName("email_id")]
    public string EmailId { get; set; }

    [JsonPropertyName("bio")]
    public string Bio { get; set; }

    [JsonPropertyName("posts")]
    public List<PostDTO> Posts { get; set; }

}

public record UserCreateDTO
{
    [JsonPropertyName("user_name")]
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }

    [JsonPropertyName("password")]
    [Required]
    [MaxLength(50)]
    public string Password { get; set; }

    [JsonPropertyName("first_name")]
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    [MaxLength(50)]
    public string LastName { get; set; }

    [JsonPropertyName("date_of_birth")]
    [Required]
    public DateTimeOffset DateOfBirth { get; set; }

    [JsonPropertyName("gender")]
    [Required]
    [MaxLength(6)]
    public string Gender { get; set; }

    [JsonPropertyName("mobile_number")]
    [Required]
    public long MobileNumber { get; set; }

    [JsonPropertyName("email_id")]
    [Required]
    [MaxLength(255)]
    public string EmailId { get; set; }

    [JsonPropertyName("bio")]
    [MaxLength(255)]
    public string Bio { get; set; }

}
public record UserLoginDTO
{
    [JsonPropertyName("username")]
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }

    [JsonPropertyName("password")]
    [Required]
    [MaxLength(50)]
    public string Password { get; set; }

}

public record UserUpdateDTO
{
    [JsonPropertyName("user_name")]
    [MaxLength(50)]
    public string UserName { get; set; }

    [JsonPropertyName("password")]
    [MaxLength(50)]
    public string Password { get; set; }

    [JsonPropertyName("first_name")]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    [MaxLength(50)]
    public string LastName { get; set; }

    [JsonPropertyName("bio")]
    [MaxLength(255)]
    public string Bio { get; set; }

}


public record UserListDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("user_name")]
    public string UserName { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("date_of_birth")]
    public DateTimeOffset DateOfBirth { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("mobile_number")]
    public long MobileNumber { get; set; }

    [JsonPropertyName("email_id")]
    public string EmailId { get; set; }

    [JsonPropertyName("bio")]
    public string Bio { get; set; }

}
