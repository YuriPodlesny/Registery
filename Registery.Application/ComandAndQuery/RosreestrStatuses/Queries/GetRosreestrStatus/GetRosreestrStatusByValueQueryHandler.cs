using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.RosreestrStatusDTO;

namespace Registery.Application.ComandAndQuery.RosreestrStatuses.Queries.GetRosreestrStatus
{
    internal class GetRosreestrStatusByValueQueryHandler : IRequestHandler<GetRosreestrStatusByValueQuery, RosreestrStatusDto?>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public GetRosreestrStatusByValueQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RosreestrStatusDto?> Handle(GetRosreestrStatusByValueQuery request, CancellationToken cancellationToken)
        {
            var rosreestrStatusFromDb = await _db.RosreestrStatuses.AsNoTracking().FirstOrDefaultAsync(e => e.Value == request.Value && e.Delete != true, cancellationToken);

            if (rosreestrStatusFromDb == null)
            {
                return null;
            }

            return _mapper.Map<RosreestrStatusDto>(rosreestrStatusFromDb);
        }
    }
}
