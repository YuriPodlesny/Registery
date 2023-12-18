using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.ComandAndQuery.Forms.Queries.GetForms;
using Registery.Application.Interfaces;
using Registery.Application.Mapping;
using Registery.Application.Mapping.FormDTO;
using Registry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.Forms.Queries.GetFormsWithPagination
{
    public class GetFormsWithPaginationHandler : IRequestHandler<GetFormsWithPagination, IndexPagination<FormDto>>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public GetFormsWithPaginationHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IndexPagination<FormDto>> Handle(GetFormsWithPagination request, CancellationToken cancellationToken)
        {
            IQueryable<Form> formFromDb = _db.Forms
                .Include(e => e.DistrictNumber)
                .Include(e => e.RosreestrStatus)
                .Include(e => e.OMSStatus);

            var count = await formFromDb.CountAsync();
            var items = formFromDb.Skip(request.PageSize * (request.PageNumber - 1)).Take(request.PageSize);

            IndexPagination<FormDto> pagination = new IndexPagination<FormDto>()
            {
                Model = _mapper.Map<List<FormDto>>(items),
                PageViewModel = new PageModel(count, request.PageNumber, request.PageSize)
            };

            return pagination;
        }
    }
}
