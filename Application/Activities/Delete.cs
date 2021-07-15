using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core.Mappings;
using Infrastructure;
using MediatR;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ApplicationDbContext _dbContext;
            public Handler(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activiity = await _dbContext.Activities.FindAsync(request.Id);

                if (activiity == null) return null;

                _dbContext.Remove(activiity);

                var result = await _dbContext.SaveChangesAsync() > 0;

                if (!result)
                    return Result<Unit>.Failure("Failed to Delete Activity!");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}