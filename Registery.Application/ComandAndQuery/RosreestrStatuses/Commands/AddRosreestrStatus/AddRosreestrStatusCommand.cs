using MediatR;
using Registery.Application.Mapping.RosreestrStatusDTO;

namespace Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.AddRosreestrStatus
{
    public class AddRosreestrStatusCommand : IRequest<RosreestrStatusDto>
    {
        public string? Value { get; set; }
    }
}
