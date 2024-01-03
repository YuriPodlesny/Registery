using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.DistrictNumberDTO;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNamberByName
{
    public class GetDistrictNumberByValueQueryHandler : IRequestHandler<GetDistrictNumberByValueQuery, DistrictNumberDto?>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public GetDistrictNumberByValueQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<DistrictNumberDto?> Handle(GetDistrictNumberByValueQuery request, CancellationToken cancellationToken)
        {
            var districtNamber = await _db.DistrictNumbers.AsNoTracking().FirstOrDefaultAsync(e => e.Value == request.Value && e.Delete != true, cancellationToken);

            if (districtNamber == null)
            {
                return null;
            }

            return _mapper.Map<DistrictNumberDto>(districtNamber);
        }
    }
}
