using MediatR;
using Registery.Application.Mapping.OMSStatusDTO;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Commands.UpdateOMSStatus
{
    public class UpdateOMSStatusCommand : IRequest<OMSStatusDto>
    {
        public Guid Id { get; set; }
        public string? Value { get; set; }
    }
}
