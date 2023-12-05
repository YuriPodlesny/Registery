using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.OMSStatusDTO;
using Registery.Application.Models;
using System.Net;

namespace Registery.Application.ComandAndQuery.GetOMSStatus.Queries.GetQueries
{
    public class GetOMSStatusByIdQueryHandler : IRequestHandler<GetOMSStatusByIdQuery, APIResponse>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public GetOMSStatusByIdQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }

        public async Task<APIResponse> Handle(GetOMSStatusByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var omsStatusFromDb = await _db.OMSStatuses.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

                if (omsStatusFromDb == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return _response;
                }
                _response.Result = _mapper.Map<OMSStatusDto>(omsStatusFromDb);
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
