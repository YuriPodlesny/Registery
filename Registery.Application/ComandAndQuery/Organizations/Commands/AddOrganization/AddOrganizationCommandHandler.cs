using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.OrganizationDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System.Net;

namespace Registery.Application.ComandAndQuery.Organizations.Commands.AddOrganization
{
    public class AddOrganizationCommandHandler : IRequestHandler<AddOrganizationCommand, APIResponse>
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

        public async Task<APIResponse> Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }

                var organization = new Organization
                {
                    Name = request.Name,
                    INN = request.INN,
                    DistrictNumberId = request.DistrictNumberId
                };

                await _db.Organizations.AddAsync(organization, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);

                _response.Result = _mapper.Map<OrganizationCreateDto>(organization);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }
}
