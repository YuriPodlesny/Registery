using MediatR;
using Registery.Application.Mapping.OMSStatusDTO;

namespace Registery.Application.ComandAndQuery.GetOMSStatus.Queries.GetQueries
{
    public record GetOMSStatusByIdQuery(Guid Id) : IRequest<OMSStatusDto>;

}
