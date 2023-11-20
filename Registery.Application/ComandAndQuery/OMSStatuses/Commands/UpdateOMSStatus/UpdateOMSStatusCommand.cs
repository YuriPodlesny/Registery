using MediatR;
using Registery.Application.Models;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Commands.UpdateOMSStatus
{
    public class UpdateOMSStatusCommand : IRequest<APIResponse>
    {
        public Guid Id { get; set; }
        public string? Value { get; set; }
    }
}
