using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Models;
using System.Net;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Commands.DeleteDistrictNumber
{
    public class DeleteDistrictNumberCommandHandler : IRequestHandler<DeleteDistrictNumberCommand, APIResponse>
    {
        private readonly IBaseDbContext _db;
        protected APIResponse _response;

        public DeleteDistrictNumberCommandHandler(IBaseDbContext db)
        {
            _db = db;
            _response = new();
        }

        public async Task<APIResponse> Handle(DeleteDistrictNumberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return _response;
                }

                var districtNamberFronDb = await _db.DistrictNumbers.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

                if (districtNamberFronDb == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                }
                _db.DistrictNumbers.Remove(districtNamberFronDb);
                await _db.SaveChangesAsync(cancellationToken);

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
