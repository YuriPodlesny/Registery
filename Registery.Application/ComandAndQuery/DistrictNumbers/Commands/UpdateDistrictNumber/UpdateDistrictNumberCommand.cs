using MediatR;
using Registery.Application.Models;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Commands.UpdateDistrictNumber
{
    public class UpdateDistrictNumberCommand : IRequest<APIResponse>
    {
        public Guid Id { get; set; }
        public string? Value { get; set; }
    }

}
