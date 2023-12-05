using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.Forms.Commands.DeleteForm
{
    public class DeleteFormCommandHandler : IRequestHandler<DeleteFormCommand, APIResponse>
    {
        private readonly IBaseDbContext _db;
        protected APIResponse _response;
        public DeleteFormCommandHandler(IBaseDbContext db)
        {
            _db = db;
            _response = new APIResponse();
        }

        public async Task<APIResponse> Handle(DeleteFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return _response;
                }

                var formFronDb = await _db.Forms.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

                if (formFronDb == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                }
                _db.Forms.Remove(formFronDb);
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
