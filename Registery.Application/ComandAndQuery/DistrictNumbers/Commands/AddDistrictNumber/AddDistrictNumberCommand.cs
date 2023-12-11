using MediatR;
using Registery.Application.Mapping.DistrictNumberDTO;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Commands.AddDistrictNumber
{
    public class AddDistrictNumberCommand : IRequest<DistrictNumberDto>
    {
        public string? Value { get; set; }
    }
}
