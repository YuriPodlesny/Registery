using MediatR;
using Registery.Application.Mapping.DistrictNumberDTO;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNamberByName
{
    public record GetDistrictNumberByValueQuery(string Value) : IRequest<DistrictNumberDto?>;

}
