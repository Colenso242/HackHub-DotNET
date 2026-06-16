using MediatR;

namespace HackHub_DotNET.Application.Abstractions;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
    
}
public interface ICommandHandler<in TCommand,TResponse> : IRequestHandler<TCommand,TResponse>
    where TCommand : ICommand<TResponse>
{
    
}