using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Infrastructure;
using MediatR;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            public Handler(ApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var actvity = await _dbContext.Activities.FindAsync(request.Activity.Id);

                _mapper.Map(request.Activity, actvity);

                await _dbContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}