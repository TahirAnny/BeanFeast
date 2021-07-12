using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core.Mappings;
using Domain;
using Infrastructure;
using MediatR;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Result<Activity>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Activity>>
        {
            private readonly ApplicationDbContext _dbContext;
            public Handler(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Result<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _dbContext.Activities.FindAsync(request.Id);

                return Result<Activity>.Success(activity);
            }
        }
    }
}