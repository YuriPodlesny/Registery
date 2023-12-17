using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.FormDTO;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.Forms.Queries.GetForms
{
    public class GetFormsQueryHandler : IRequestHandler<GetFormsQuery, List<FormDto>>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public GetFormsQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<FormDto>> Handle(GetFormsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Form> formFromDb = _db.Forms
                .Include(e => e.DistrictNumber)
                .Include(e => e.RosreestrStatus)
                .Include(e => e.OMSStatus);

            if (request.PageSize > 0)
            {
                if (request.PageSize > 100)
                {
                    request.PageSize = 100;
                }
                formFromDb = formFromDb.Skip(request.PageSize * (request.PageNumber - 1)).Take(request.PageSize);
            }

            return _mapper.Map<List<FormDto>>(formFromDb);
        }
    }
}
