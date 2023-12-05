using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.DistrictNumberDTO;
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
    public class GetRosreestrStatusesQueryHandler : IRequestHandler<GetRosreestrStatusesQuery, List<RosreestrStatusDto>>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public GetRosreestrStatusesQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<RosreestrStatusDto>> Handle(GetRosreestrStatusesQuery request, CancellationToken cancellationToken)
        {
            var rosreestrStatus = await _db.RosreestrStatuses.ToListAsync(cancellationToken)
                ?? throw new ArgumentNullException();

            return _mapper.Map<List<RosreestrStatusDto>>(rosreestrStatus);
        }
    }
}
