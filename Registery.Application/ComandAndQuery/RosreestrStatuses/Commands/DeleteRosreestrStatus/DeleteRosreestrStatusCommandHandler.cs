using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;

namespace Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.DeleteRosreestrStatus
{
    public class DeleteRosreestrStatusCommandHandler : IRequestHandler<DeleteRosreestrStatusCommand, Unit>
    {
        private readonly IBaseDbContext _db;

        public DeleteRosreestrStatusCommandHandler(IBaseDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(DeleteRosreestrStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var rosreestrStatusFronDb = await _db.RosreestrStatuses.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

                if (rosreestrStatusFronDb is null)
                {
                    throw new ArgumentNullException(nameof(rosreestrStatusFronDb));
                }
                rosreestrStatusFronDb.Delete = true;
                _db.RosreestrStatuses.UpdateRange(rosreestrStatusFronDb);
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
