using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.FormDTO;

namespace Registery.Application.ComandAndQuery.Forms.Queries.GetForm
{
    public class GetFormByIdQueryHandler : IRequestHandler<GetFormByIdQuery, FormDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public GetFormByIdQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<FormDto> Handle(GetFormByIdQuery request, CancellationToken cancellationToken)
        {
            var formFromDb = await _db.Forms
                .Include(e => e.DistrictNumber)
                .Include(e => e.RosreestrStatus)
                .Include(e => e.OMSStatus)
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            return _mapper.Map<FormDto>(formFromDb);
        }
    }
}
