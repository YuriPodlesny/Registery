using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.DistrictNumberDTO;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Commands.UpdateDistrictNumber
{
    public class UpdateDistrictNumberCommandHandler : IRequestHandler<UpdateDistrictNumberCommand, DistrictNumberDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public UpdateDistrictNumberCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DistrictNumberDto> Handle(UpdateDistrictNumberCommand request, CancellationToken cancellationToken)
        {
            DistrictNumber districtNumber = _mapper.Map<DistrictNumber>(request);
            
            _db.DistrictNumbers.Update(districtNumber);
            await _db.SaveChangesAsync(cancellationToken);
            
            return _mapper.Map<DistrictNumberDto>(districtNumber);
        }
    }
}
