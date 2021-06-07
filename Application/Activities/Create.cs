using System.Threading;
using System.Threading.Tasks;
using Domain;
using Infrastructure;
using MediatR;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
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
                _dbContext.Activities.Add(request.Activity);

                await _dbContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}