using MediatR;
using Registery.Application.Mapping;
using Registery.Application.Mapping.FormDTO;

namespace Registery.Application.ComandAndQuery.Forms.Queries.GetFormsWithPagination
{
    public class GetFormsWithPagination : IRequest<IndexPagination<FormDto>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public GetFormsWithPagination(int PageSize, int PageNumber)
        {
            this.PageSize = PageSize;
            this.PageNumber = PageNumber;
        }
    }
}
