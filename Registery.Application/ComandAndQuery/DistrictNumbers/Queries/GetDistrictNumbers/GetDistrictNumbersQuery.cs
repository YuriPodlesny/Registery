using MediatR;
using Registery.Application.Mapping.DistrictNumberDTO;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNambers
{
    public record GetDistrictNumbersQuery() : IRequest<List<DistrictNumberDto>>;
}
