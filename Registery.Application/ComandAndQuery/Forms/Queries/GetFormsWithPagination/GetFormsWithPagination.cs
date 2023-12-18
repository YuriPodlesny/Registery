using MediatR;
using Registery.Application.Mapping;
using Registery.Application.Mapping.FormDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
