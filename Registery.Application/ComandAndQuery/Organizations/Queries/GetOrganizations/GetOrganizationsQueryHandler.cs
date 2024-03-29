﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.OrganizationDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System.Net;

namespace Registery.Application.ComandAndQuery.Organizations.Queries.GetOrganizations
{
    public class GetOrganizationsQueryHandler : IRequestHandler<GetOrganizationsQuery, List<Organization>>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        public GetOrganizationsQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<Organization>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
        {
            var organizationFromDb = await _db.Organizations.Include(e => e.DistrictNumber).ToListAsync(cancellationToken);

            return organizationFromDb;
        }
    }
}
