using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;

namespace Registery.Application.ComandAndQuery.Forms.Commands.DeleteForm
{
    public class DeleteFormCommandHandler : IRequestHandler<DeleteFormCommand, Unit>
    {
        private readonly IBaseDbContext _db;
        public DeleteFormCommandHandler(IBaseDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(DeleteFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var formFromDb = await _db.Forms.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

                if (formFromDb is null)
                {
                    throw new ArgumentNullException(nameof(formFromDb));
                }
                
                _db.Forms.Remove(formFromDb);
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
