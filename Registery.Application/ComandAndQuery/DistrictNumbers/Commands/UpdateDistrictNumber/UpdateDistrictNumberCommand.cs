using MediatR;
using Registery.Application.Mapping.DistrictNumberDTO;
using Registery.Application.Models;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Commands.UpdateDistrictNumber
{
    public class UpdateDistrictNumberCommand : IRequest<DistrictNumberDto>
    {
        public Guid Id { get; set; }
        public string? Value { get; set; }
    }

}
