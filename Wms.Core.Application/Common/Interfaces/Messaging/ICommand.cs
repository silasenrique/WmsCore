using MediatR;

namespace Wms.Core.Application.Common.Interfaces.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse> { }