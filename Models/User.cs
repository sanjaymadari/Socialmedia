
using Socialmedia.DTOs;

namespace Socialmedia.Models;

public enum Gender
{
    Female = 1,
    Male = 2
}
public record User
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public long MobileNumber { get; set; }
    public string EmailId { get; set; }
    public string Bio { get; set; }

    public UserListDTO asListDto => new UserListDTO
    {
        Id =Id,
        UserName = UserName,
        FirstName = FirstName,
        LastName = LastName,
        DateOfBirth = DateOfBirth,
        Gender = Gender.ToString(),
        MobileNumber = MobileNumber,
        EmailId = EmailId,
        Bio = Bio,
        
    };
    public UserDTO asDto => new UserDTO
    {
        Id =Id,
        UserName = UserName,
        FirstName = FirstName,
        LastName = LastName,
        DateOfBirth = DateOfBirth,
        Gender = Gender.ToString(),
        MobileNumber = MobileNumber,
        EmailId = EmailId,
        Bio = Bio,
        
    };

}