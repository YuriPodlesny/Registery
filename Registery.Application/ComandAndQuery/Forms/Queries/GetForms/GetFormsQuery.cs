using MediatR;
using Registery.Application.Mapping.FormDTO;

namespace Registery.Application.ComandAndQuery.Forms.Queries.GetForms
{
    public record GetFormsQuery : IRequest<List<FormDto>>;
}
