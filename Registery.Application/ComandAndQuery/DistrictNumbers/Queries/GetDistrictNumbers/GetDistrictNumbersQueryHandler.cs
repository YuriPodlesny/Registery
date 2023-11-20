using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNambers;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.DistrictNumberDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System.Net;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNumbers
{
    public class GetDistrictNambersQueryHandler : IRequestHandler<GetDistrictNumbersQuery, APIResponse>
    {
        private readonly IBaseDbContext _db;
        protected APIResponse _response;
        private readonly IMapper _mapper;
        public GetDistrictNambersQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new();
            _mapper = mapper;
        }

        public async Task<APIResponse> Handle(GetDistrictNumbersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var districtNumber = await _db.DistrictNumbers.ToListAsync(cancellationToken);

                if (districtNumber == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return _response;
                }

                _response.Result = _mapper.Map<List<DistrictNumberDto>>(districtNumber);
                _response.StatusCode = HttpStatusCode.OK;

                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }

            return _response;
        }
    }
}
