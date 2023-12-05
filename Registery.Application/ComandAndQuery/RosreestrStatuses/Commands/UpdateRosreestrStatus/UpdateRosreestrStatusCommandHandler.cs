using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.DistrictNumberDTO;
using Registery.Application.Mapping.RosreestrStatusDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.UpdateRosreestrStatus
{
    public class UpdateRosreestrStatusCommandHandler : IRequestHandler<UpdateRosreestrStatusCommand, RosreestrStatusDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public UpdateRosreestrStatusCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RosreestrStatusDto> Handle(UpdateRosreestrStatusCommand request, CancellationToken cancellationToken)
        {
            var rosreestrStatus = _mapper.Map<RosreestrStatus>(request);

            _db.RosreestrStatuses.Update(rosreestrStatus);
            await _db.SaveChangesAsync(cancellationToken);

            return _mapper.Map<RosreestrStatusDto>(rosreestrStatus);
        }
    }
}
