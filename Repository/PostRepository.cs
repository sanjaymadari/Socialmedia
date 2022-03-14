
using Dapper;
using Socialmedia.Models;
using Socialmedia.Utilities;

namespace Socialmedia.Repositories;

public interface IPostRepository
{
    Task<Post> Create(Post Data);
    Task<List<Post>> GetList();
    Task<Post> GetById(long PostId);
    Task<bool> Update(Post Data);
    Task Delete(long PostId);
    Task<List<Post>> GetListForUser(long UserId);
    Task<List<Post>> GetListForHashtag(long HashtagId);
}

public class PostRepository : BaseRepository, IPostRepository
{
    public PostRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Post> Create(Post Data)
    {
        var query = $@"INSERT INTO ""{TableNames.post}"" (type, user_id, description) VALUES(@Type, @UserId, @Description) RETURNING *;";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Post>(query, Data);
    }

    public async Task Delete(long PostId)
    {
        var query = $@"DELETE FROM ""{TableNames.post}"" WHERE id = @PostId;";
        using (var con = NewConnection)
            await con.ExecuteAsync(query, new { PostId });
    }

    public async Task<Post> GetById(long PostId)
    {
        var query = $@"SELECT * FROM ""{TableNames.post}"" WHERE id = @PostId";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Post>(query, new { PostId });
    }

    public async Task<List<Post>> GetList()
    {
        var query = $@"SELECT * FROM ""{TableNames.post}"" ORDER BY id";
        using (var con = NewConnection)
            return (await con.QueryAsync<Post>(query)).AsList();
    }

    public async Task<List<Post>> GetListForHashtag(long HashtagId)
    {
        var query = $@"SELECT * FROM {TableNames.post_hashtag} ph
        LEFT JOIN {TableNames.post} p ON p.id = ph.post_id
        WHERE hashtag_id = @HashtagId;";
        using (var con = NewConnection)
            return (await con.QueryAsync<Post>(query, new { HashtagId })).AsList();
    }

    public async Task<List<Post>> GetListForUser(long UserId)
    {
        var query = $@"SELECT * FROM ""{TableNames.post}"" WHERE user_id = @UserId;";
        using (var con = NewConnection)
            return (await con.QueryAsync<Post>(query, new { UserId })).AsList();
    }

    public async Task<bool> Update(Post Data)
    {
        var query = $@"UPDATE ""{TableNames.post}"" SET description = @Description WHERE id = @Id";
        using (var con = NewConnection)
            return (await con.ExecuteAsync(query,Data)) == 1;
    }
}