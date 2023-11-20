using MediatR;
using Registery.Application.Models;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Commands.AddOMSStatus
{
    public class AddOMSStatusCommand : IRequest<APIResponse>
    {
        public string? Value { get; set; }
    }
}
