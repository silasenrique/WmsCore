using MediatR;

namespace Wms.Core.Application.Abstractions.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse> { }