using MediatR;
using Registery.Application.Mapping.OMSStatusDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Commands.UpdateOMSStatus
{
    public class UpdateOMSStatusCommand : IRequest<OMSStatusDto>
    {
        public Guid Id { get; set; }
        public string? Value { get; set; }
    }
}
