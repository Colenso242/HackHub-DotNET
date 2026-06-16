using Dapper;
using HackHub_DotNET.Application.Abstractions;

namespace HackHub_DotNET.Application.Hackathons.GetAllHackathons;

internal class GetAllHackathonsQueryHandler(ISQLConnectionFactory sqlConnectionFactory) : IQueryHandler<GetAllHackathonsQuery, IEnumerable<GetAllHackathonsDto>>
{
    public async Task<IEnumerable<GetAllHackathonsDto>> Handle(GetAllHackathonsQuery request,
        CancellationToken cancellationToken)
    {
        string sql = "SELECT Id, Name, Location, State, Prize, MaxTeamSize FROM Hackathons ORDER BY Name";
        using var connection = sqlConnectionFactory.GetOpenConnection();
        return (await connection.QueryAsync<GetAllHackathonsDto>(sql)).AsList();
    }
}