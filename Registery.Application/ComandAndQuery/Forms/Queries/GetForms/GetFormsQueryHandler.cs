using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.FormDTO;

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
            var formFromDb = await _db.Forms
                .Include(e => e.DistrictNumber)
                .Include(e => e.RosreestrStatus)
                .Include(e => e.OMSStatus)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<FormDto>>(formFromDb);
        }
    }
}
