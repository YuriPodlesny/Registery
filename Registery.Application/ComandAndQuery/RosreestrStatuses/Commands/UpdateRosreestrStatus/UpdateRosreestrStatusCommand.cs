using MediatR;
using Registery.Application.Mapping.RosreestrStatusDTO;

namespace Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.UpdateRosreestrStatus
{
    public class UpdateRosreestrStatusCommand : IRequest<RosreestrStatusDto>
    {
        public Guid Id { get; set; }
        public string? Value { get; set; }
    }
}
