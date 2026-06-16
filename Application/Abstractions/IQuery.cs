using MediatR;

namespace HackHub_DotNET.Application.Abstractions;

public interface IQuery<out TResponse> : IRequest<TResponse>{}
