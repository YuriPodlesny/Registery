using MediatR;
using Registery.Application.Models;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNumber
{
    public record GetDistrictNumberByIdQuery(Guid Id) : IRequest<APIResponse>;
}
