using HackHub_DotNET.Application.Hackathons.GetAllHackathons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackHub_DotNET.Presentation.Controllers.Hackathon;

[ApiController]
[Route("[controller]")]
public class HackathonController
    (IMediator mediator) : ControllerBase
{
    //todo cancellation token
    [HttpGet]
    public async Task<IReadOnlyList<GetAllHackathonsDto>> GetAllHackathons()
    {
        return await mediator.Send(new GetAllHackathonsQuery());
    }
}