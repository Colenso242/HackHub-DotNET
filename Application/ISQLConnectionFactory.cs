using System.Data;

namespace HackHub_DotNET.Application;

public interface ISQLConnectionFactory
{
    IDbConnection GetOpenConnection();
    IDbConnection CreateNewConnection();
    string GetConnectionString();
}