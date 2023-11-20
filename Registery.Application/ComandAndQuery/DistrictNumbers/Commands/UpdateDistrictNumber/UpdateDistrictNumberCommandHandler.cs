using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Commands.UpdateDistrictNumber
{
    public class UpdateDistrictNumberCommandHandler : IRequestHandler<UpdateDistrictNumberCommand, APIResponse>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public UpdateDistrictNumberCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new();
            _mapper = mapper;
        }

        public async Task<APIResponse> Handle(UpdateDistrictNumberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                DistrictNumber districtNumber = _mapper.Map<DistrictNumber>(request);
                _db.DistrictNumbers.Update(districtNumber);
                await _db.SaveChangesAsync(cancellationToken);
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
