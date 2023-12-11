using MediatR;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Commands.DeleteOMSStatus
{
    public record DeleteOMSStatusCommand(Guid Id) : IRequest<Unit>;
}
