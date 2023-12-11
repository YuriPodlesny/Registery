using MediatR;

namespace Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.DeleteRosreestrStatus
{
    public record DeleteRosreestrStatusCommand(Guid Id) : IRequest<Unit>;

}
