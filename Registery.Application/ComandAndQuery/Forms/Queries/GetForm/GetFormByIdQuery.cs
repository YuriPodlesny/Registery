using MediatR;
using Registery.Application.Models;

namespace Registery.Application.ComandAndQuery.Forms.Queries.GetForm
{
    public record GetFormByIdQuery(Guid Id) : IRequest<APIResponse>;
}
