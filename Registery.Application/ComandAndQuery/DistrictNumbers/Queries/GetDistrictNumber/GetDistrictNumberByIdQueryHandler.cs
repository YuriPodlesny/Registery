using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNumber;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.DistrictNumberDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System.Net;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNumber
{
    public class GetDistrictNumberByIdQueryHandler : IRequestHandler<GetDistrictNumberByIdQuery, APIResponse>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public GetDistrictNumberByIdQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new();
            _mapper = mapper;
        }

        public async Task<APIResponse> Handle(GetDistrictNumberByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var districtNamber = await _db.DistrictNumbers.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

                if (districtNamber == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return _response;
                }
                _response.Result = _mapper.Map<DistrictNumberDto>(districtNamber);
                _response.StatusCode = HttpStatusCode.OK;
                return _response;
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
