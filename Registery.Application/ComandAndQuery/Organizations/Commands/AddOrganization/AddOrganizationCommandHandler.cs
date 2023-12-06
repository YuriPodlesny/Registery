using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.DistrictNumberDTO;
using Registery.Application.Mapping.OrganizationDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System.Net;

namespace Registery.Application.ComandAndQuery.Organizations.Commands.AddOrganization
{
    public class AddOrganizationCommandHandler : IRequestHandler<AddOrganizationCommand, OrganizationDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public AddOrganizationCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }

        public async Task<OrganizationDto> Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = _mapper.Map<Organization>(request);

            await _db.Organizations.AddAsync(organization, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrganizationDto>(organization);
        }
    }
}
