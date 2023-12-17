using MediatR;
using Registery.Application.Mapping.FormDTO;

namespace Registery.Application.ComandAndQuery.Forms.Queries.GetForms
{
    public class GetFormsQuery : IRequest<List<FormDto>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public GetFormsQuery(int PageSize, int PageNumber) 
        { 
            this.PageSize = PageSize;
            this.PageNumber = PageNumber;
        }
    }
}
