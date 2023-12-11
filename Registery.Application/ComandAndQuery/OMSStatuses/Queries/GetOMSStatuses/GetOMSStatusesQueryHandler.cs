using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.OMSStatusDTO;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Queries.GetOMSStatuses
{
    public class GetOMSStatusesQueryHandler : IRequestHandler<GetOMSStatusesQuery, List<OMSStatusDto>>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public GetOMSStatusesQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<OMSStatusDto>> Handle(GetOMSStatusesQuery request, CancellationToken cancellationToken)
        {

            var omsStatusesFromDb = await _db.OMSStatuses.ToListAsync(cancellationToken)
                ?? throw new ArgumentException();

            return _mapper.Map<List<OMSStatusDto>>(omsStatusesFromDb);
        }
    }
}
