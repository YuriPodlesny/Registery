using MediatR;
using Registery.Application.Mapping.DistrictNumberDTO;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNumber
{
    public record GetDistrictNumberByIdQuery(Guid Id) : IRequest<DistrictNumberDto>;
}
