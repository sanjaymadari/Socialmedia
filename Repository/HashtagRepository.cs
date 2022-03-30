
using Dapper;
using Socialmedia.Models;
using Socialmedia.Utilities;

namespace Socialmedia.Repositories;

public interface IHashtagRepository
{
    Task<Hashtag> Create(Hashtag Data);
    Task<List<Hashtag>> GetList(int PageNumber, int Limit);
    Task<Hashtag> GetById(long HashtagId);
    Task<List<Hashtag>> GetListForPost(long PostId);
}

public class HashtagRepository : BaseRepository, IHashtagRepository
{
    public HashtagRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Hashtag> Create(Hashtag Data)
    {
        var query = $@"INSERT INTO ""{TableNames.hashtag}"" (name) VALUES(@Name) RETURNING *;";
        using (var con =NewConnection)
            return await con.QuerySingleOrDefaultAsync<Hashtag>(query, Data);
    }

    public async Task<Hashtag> GetById(long HashtagId)
    {
        var query = @$"SELECT * FROM ""{TableNames.hashtag}"" WHERE id = @HashtagId;";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Hashtag>(query, new { HashtagId });
    }

    public async Task<List<Hashtag>> GetList(int PageNumber, int Limit)
    {
        var query = $@"SELECT * FROM ""{TableNames.hashtag}"" ORDER BY id LIMIT @Limit OFFSET @PageNumber";
        using (var con = NewConnection)
            return (await con.QueryAsync<Hashtag>(query, new { PageNumber = (PageNumber - 1)*Limit, Limit })).AsList();
    }

    public async Task<List<Hashtag>> GetListForPost(long PostId)
    {
        var query = $@"SELECT * FROM ""{TableNames.post_hashtag}"" ph
        LEFT JOIN ""{TableNames.hashtag}"" h ON h.id = ph.hashtag_id
        WHERE ph.post_id = @PostId;";
        using (var con = NewConnection)
            return (await con.QueryAsync<Hashtag>(query, new { PostId })).AsList();
    }
}