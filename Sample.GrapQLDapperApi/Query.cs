using System.Data;
using Dapper;
using Sample.GrapQLDapperApi.Models;

namespace Sample.GrapQLDapperApi;

public class Query
{
    public async Task<IEnumerable<Person>> GetPersons([Service] IDbConnection db)
    {
        var sql = "SELECT * FROM Person";
        return await db.QueryAsync<Person>(sql);
    }

    public async Task<IEnumerable<Company>> GetCompanies([Service] IDbConnection db)
    {
        var sql = "SELECT * FROM Company";
        return await db.QueryAsync<Company>(sql);
    }
}
