using MediatR;
using Registery.Application.Mapping.OMSStatusDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Commands.AddOMSStatus
{
    public class AddOMSStatusCommand : IRequest<OMSStatusDto>
    {
        public string? Value { get; set; }
    }
}
