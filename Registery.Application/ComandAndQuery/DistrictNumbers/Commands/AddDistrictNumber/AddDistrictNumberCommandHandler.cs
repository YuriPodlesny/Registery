using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.DistrictNumberDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System.Net;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Commands.AddDistrictNumber
{
    public class AddDistrictNumberCommandHandler : IRequestHandler<AddDistrictNumberCommand, DistrictNumberDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public AddDistrictNumberCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DistrictNumberDto> Handle(AddDistrictNumberCommand request, CancellationToken cancellationToken)
        {

            var districtNamber = _mapper.Map<DistrictNumber>(request);

            await _db.DistrictNumbers.AddAsync(districtNamber, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DistrictNumberDto>(districtNamber);

        }
    }
}
