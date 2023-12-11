using MediatR;
using Registery.Application.Mapping.RosreestrStatusDTO;

namespace Registery.Application.ComandAndQuery.RosreestrStatuses.Queries.GetRosreestrStatuses
{
    public record GetRosreestrStatusesQuery : IRequest<List<RosreestrStatusDto>>;

}
