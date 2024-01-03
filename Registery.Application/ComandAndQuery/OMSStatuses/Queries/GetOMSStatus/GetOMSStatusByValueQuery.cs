using MediatR;
using Registery.Application.Mapping.OMSStatusDTO;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Queries.GetOMSStatus
{
    public record GetOMSStatusByValueQuery(string Value) : IRequest<OMSStatusDto?>;
}
