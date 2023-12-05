using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.FormDTO;
using Registery.Application.Models;
using System.Net;

namespace Registery.Application.ComandAndQuery.Forms.Queries.GetForms
{
    public class GetFormsQueryHandler : IRequestHandler<GetFormsQuery, APIResponse>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public GetFormsQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }

        public async Task<APIResponse> Handle(GetFormsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var formFromDb = await _db.Forms
                    .Include(e => e.DistrictNumber)
                    .Include(e => e.RosreestrStatus)
                    .Include(e => e.OMSStatus)
                    .ToListAsync(cancellationToken);

                if (formFromDb == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return _response;
                }

                _response.Result = _mapper.Map<List<FormDto>>(formFromDb);
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
