using MediatR;
using Registery.Application.Mapping.RosreestrStatusDTO;

namespace Registery.Application.ComandAndQuery.RosreestrStatuses.Queries.GetRosreestrStatus
{
    public record GetRosreestrStatusByValueQuery(string Value) : IRequest<RosreestrStatusDto?>;
}
