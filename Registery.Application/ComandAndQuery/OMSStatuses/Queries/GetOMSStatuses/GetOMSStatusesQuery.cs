using MediatR;
using Registery.Application.Mapping.OMSStatusDTO;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Queries.GetOMSStatuses
{
    public record GetOMSStatusesQuery : IRequest<List<OMSStatusDto>>;
}
