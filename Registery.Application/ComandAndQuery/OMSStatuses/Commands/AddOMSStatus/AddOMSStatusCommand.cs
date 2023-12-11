using MediatR;
using Registery.Application.Mapping.OMSStatusDTO;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Commands.AddOMSStatus
{
    public class AddOMSStatusCommand : IRequest<OMSStatusDto>
    {
        public string? Value { get; set; }
    }
}
