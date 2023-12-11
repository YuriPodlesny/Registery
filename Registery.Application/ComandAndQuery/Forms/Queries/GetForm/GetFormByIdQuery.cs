using MediatR;
using Registery.Application.Mapping.FormDTO;

namespace Registery.Application.ComandAndQuery.Forms.Queries.GetForm
{
    public record GetFormByIdQuery(Guid Id) : IRequest<FormDto>;
}
