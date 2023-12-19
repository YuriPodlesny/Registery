using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping;
using Registery.Application.Mapping.FormDTO;
using Registry.Domain.Entities;

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
            int pageSize = 10;

            IQueryable<Form> formFromDb = _db.Forms
                .Include(e => e.DistrictNumber)
                .Include(e => e.RosreestrStatus)
                .Include(e => e.OMSStatus);

            var count = await formFromDb.CountAsync();
            var items = await formFromDb.Skip((request.PageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            PageModel pageViewModel = new PageModel(count, request.PageNumber, pageSize);
            IndexPagination<FormDto> pagination = new IndexPagination<FormDto>()
            {
                Model = _mapper.Map<List<FormDto>>(items),
                PageModel = pageViewModel
            };

            return pagination;
        }
    }
}
