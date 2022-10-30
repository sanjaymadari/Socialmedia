
using Dapper;
using Socialmedia.Models;
using Socialmedia.Utilities;

namespace Socialmedia.Repositories;

public interface IUserRepository
{
    Task<User> Create(User Data);
    Task<List<User>> GetList();
    Task<User> GetById(long UserId);
    Task<bool> Update(User Data);
    Task<bool> Login(string sername, string password);
}

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<User> Create(User Data)
    {
        var query = $@"INSERT INTO ""{TableNames.user}"" (user_name, first_name, last_name, date_of_birth, gender, mobile_number, email_id, bio, password) 
        VALUES(@UserName, @FirstName, @LastName, @DateOfBirth, @Gender, @MobileNumber, @EmailId, @Bio, @Password) RETURNING *;";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<User>(query, Data);
    }

    public async Task<User> GetById(long UserId)
    {
        var query = $@"SELECT * FROM ""{TableNames.user}"" WHERE id = @UserId;";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<User>(query, new { UserId });

    }

    public async Task<List<User>> GetList()
    {
        var query = $@"SELECT * FROM ""{TableNames.user}"" ORDER BY id;";
        using (var con = NewConnection)
            return (await con.QueryAsync<User>(query)).AsList();
    }

    public async Task<bool> Login(string Username, string Password)
    {
        var query = $@"SELECT * FROM ""{TableNames.users}"" WHERE username = @Username and password = @Password";
        using (var con = NewConnection)
            return (await con.QueryAsync(query, new { Username, Password })).Count() > 0;

    }

    public async Task<bool> Update(User Data)
    {
        var query = $@"UPDATE ""{TableNames.user}"" SET user_name = @UserName, password = @Password, 
        first_name = @FirstName, last_name = @LastName, bio = @Bio WHERE id = @Id;";
        using (var con = NewConnection)
            return (await con.ExecuteAsync(query, Data)) == 1;
    }
}