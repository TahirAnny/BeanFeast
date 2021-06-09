using System;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure;
using MediatR;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ApplicationDbContext _dbContext;
            public Handler(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activiity = await _dbContext.Activities.FindAsync(request.Id);

                _dbContext.Remove(activiity);

                await _dbContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}