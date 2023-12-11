using MediatR;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Commands.DeleteDistrictNumber
{
    public record DeleteDistrictNumberCommand(Guid Id) : IRequest<Unit>;

}
