using MediatR;
using Registery.Application.Models;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNambers
{
    public record GetDistrictNumbersQuery() : IRequest<APIResponse>;
}
