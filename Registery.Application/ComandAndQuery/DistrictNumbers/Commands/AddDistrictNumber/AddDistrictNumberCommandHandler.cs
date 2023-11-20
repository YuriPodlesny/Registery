using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.DistrictNumberDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System.Net;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Commands.AddDistrictNumber
{
    public class AddDistrictNumberCommandHandler : IRequestHandler<AddDistrictNumberCommand, APIResponse>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public AddDistrictNumberCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new();
            _mapper = mapper;
        }

        public async Task<APIResponse> Handle(AddDistrictNumberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }

                var districtNamber = new DistrictNumber
                {
                    Value = request.Value
                };

                await _db.DistrictNumbers.AddAsync(districtNamber, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);

                _response.Result = _mapper.Map<DistrictNumberDto>(districtNamber);
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
