using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.OMSStatusDTO;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Queries.GetOMSStatus
{
    public class GetOMSStatusByValueQueryHandler : IRequestHandler<GetOMSStatusByValueQuery, OMSStatusDto?>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public GetOMSStatusByValueQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<OMSStatusDto?> Handle(GetOMSStatusByValueQuery request, CancellationToken cancellationToken)
        {
            var omsStatusFromDb = await _db.OMSStatuses.AsNoTracking().FirstOrDefaultAsync(e => e.Value == request.Value && e.Delete != true, cancellationToken);

            if (omsStatusFromDb == null)
            {
                return null;
            }
                
            return _mapper.Map<OMSStatusDto>(omsStatusFromDb);
        }
    }
}
