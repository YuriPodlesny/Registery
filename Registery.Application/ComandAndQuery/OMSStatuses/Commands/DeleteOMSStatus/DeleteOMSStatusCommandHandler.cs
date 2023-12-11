﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Commands.DeleteOMSStatus
{
    public class DeleteOMSStatusCommandHandler : IRequestHandler<DeleteOMSStatusCommand, Unit>
    {
        private readonly IBaseDbContext _db;

        public DeleteOMSStatusCommandHandler(IBaseDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(DeleteOMSStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var omsStatusFronDb = await _db.OMSStatuses.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

                if (omsStatusFronDb is null)
                {
                    throw new ArgumentNullException(nameof(omsStatusFronDb));
                }
                omsStatusFronDb.Delete = true;
                _db.OMSStatuses.UpdateRange(omsStatusFronDb);
                await _db.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                new List<string> { ex.Message };
            }

            return Unit.Value;
        }
    }
}
