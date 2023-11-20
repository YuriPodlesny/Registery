using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Models;
using System.Net;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Commands.DeleteOMSStatus
{
    public class DeleteOMSStatusCommandHandler : IRequestHandler<DeleteOMSStatusCommand, APIResponse>
    {
        private readonly IBaseDbContext _db;
        protected APIResponse _response;

        public DeleteOMSStatusCommandHandler(IBaseDbContext db)
        {
            _db = db;
            _response = new();
        }

        public async Task<APIResponse> Handle(DeleteOMSStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return _response;
                }

                var omsStatusFronDb = await _db.OMSStatuses.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

                if (omsStatusFronDb == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                }
                _db.OMSStatuses.Remove(omsStatusFronDb);
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
