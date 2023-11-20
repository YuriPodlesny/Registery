using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.OMSStatusDTO;
using Registery.Application.Mapping.RosreestrStatusDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.RosreestrStatuses.Queries.GetRosreestrStatuses
{
    public class GetRosreestrStatusesQueryHandler : IRequestHandler<GetRosreestrStatusesQuery, APIResponse>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public GetRosreestrStatusesQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }

        public async Task<APIResponse> Handle(GetRosreestrStatusesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rosreestrStatusFromDb = await _db.RosreestrStatuses.ToListAsync(cancellationToken);

                if (rosreestrStatusFromDb == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return _response;
                }

                _response.Result = _mapper.Map<List<RosreestrStatusDto>>(rosreestrStatusFromDb);
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
