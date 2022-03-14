
using Dapper;
using Socialmedia.Models;
using Socialmedia.Utilities;

namespace Socialmedia.Repositories;

public interface ILikeRepository
{
    Task<Like> Create(Like Data);
    Task<Like> GetById(long LikeId);
    Task Delete(long LikeId);
    Task<List<Like>> GetListForPost(long PostId);
}

public class LikeRepository : BaseRepository, ILikeRepository
{
    public LikeRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Like> Create(Like Data)
    {
        var  query = $@"INSERT INTO ""{TableNames.like}"" (user_id,post_id) VALUES(@UserId, @PostId) RETURNING *;";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Like>(query, Data);
    }

    public async Task Delete(long LikeId)
    {
        var query = $@"DELETE FROM ""{TableNames.like}"" WHERE id = @LikeId;";
        using (var con = NewConnection)
            await con.ExecuteAsync(query, new { LikeId });
    }

    public async Task<Like> GetById(long LikeId)
    {
        var query = @$"SELECT * FROM ""{TableNames.like}"" WHERE id = @LikeId;";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Like>(query, new { LikeId });
    }

    public async Task<List<Like>> GetListForPost(long PostId)
    {
        var query = $@"SELECT l.*,u.user_name FROM ""{TableNames.like}"" l
        LEFT JOIN ""{TableNames.user}"" u ON u.id = l.user_id
        WHERE l.post_id = @PostId;";
        using (var con = NewConnection)
            return (await con.QueryAsync<Like>(query, new { PostId })).AsList();
    }
}