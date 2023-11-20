using MediatR;
using Registery.Application.Models;

namespace Registery.Application.ComandAndQuery.Forms.Queries.GetForms
{
    public record GetFormsQuery : IRequest<APIResponse>;
}
