using System.Data;
using HackHub_DotNET.Application;
using Microsoft.Data.SqlClient;

namespace HackHub_DotNET.Persistence;

public class SQLConnectionFactory(string connectionString) : ISQLConnectionFactory,IDisposable
{
    private readonly string _connectionString = connectionString;
    private IDbConnection? _connection;
    
    public string GetConnectionString()
    {
        return _connectionString;
    }

    public IDbConnection GetOpenConnection()
    {
        if (_connection is not null || _connection.State != ConnectionState.Open)
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        return _connection;
    }

    public IDbConnection CreateNewConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();

        return connection;
    }

    public void Dispose()
    {
        if(_connection is not null && _connection.State == ConnectionState.Open)
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}