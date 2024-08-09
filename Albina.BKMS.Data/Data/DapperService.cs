using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Albina.BKMS.Data.Data;

public class DapperService
{
    public async Task<int> ExecuteAsync(string query, object parameters = null)
    {
        using var connection = CreateConnection();
        return await connection.ExecuteAsync(query, parameters,
            commandType: CommandType.Text);
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string query, object parameters = null)
    {
        using var connection = CreateConnection();
        var response = await connection.QueryAsync<T>(query, parameters,
            commandType: CommandType.Text);
        return response.ToList();
    }

    public async Task<T> QueryFirstOrDefaultAsync<T>(string query, object id = null)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<T>(query, id,
            commandType: CommandType.Text);
    }

    public async Task<T> QueryFirstOrDefaultTextAsync<T>(string query, object id)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<T>(query, id,
            commandType: CommandType.Text);
    }

    public async Task<T> QuerySingleOrDefaultAsync<T>(string query, object id)
    {
        using var connection = CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<T>(query, id);
    }

    public SqlConnection CreateConnection()
    {
        var connectionString =
            "Server=localhost;Database=POS_API;User Id=SA;Password=rekcod321@;TrustServerCertificate=true";
        return new SqlConnection(connectionString);
    }

    public SqlConnection CreateSqlConnection()
    {
        var connectionString =
            "Server=localhost;Database=POS_API;User Id=SA;Password=rekcod321@;TrustServerCertificate=true";
        return new SqlConnection(connectionString);
    }
}