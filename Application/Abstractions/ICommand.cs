using MediatR;

namespace HackHub_DotNET.Application.Abstractions;

public interface ICommand : IRequest{}
 
public interface ICommand<out TResponse> : IRequest<TResponse>{}
