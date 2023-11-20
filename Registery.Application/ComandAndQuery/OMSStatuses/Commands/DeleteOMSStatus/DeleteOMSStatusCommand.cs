using MediatR;
using Registery.Application.Models;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Commands.DeleteOMSStatus
{
    public record DeleteOMSStatusCommand(Guid Id) : IRequest<APIResponse>;
}
