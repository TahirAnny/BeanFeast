using System.Threading;
using System.Threading.Tasks;
using Application.Core.Mappings;
using AutoMapper;
using Domain;
using FluentValidation;
using Infrastructure;
using MediatR;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Activity Activity { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            public Handler(ApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var actvity = await _dbContext.Activities.FindAsync(request.Activity.Id);

                if (actvity == null) return null;

                _mapper.Map(request.Activity, actvity);

                var result = await _dbContext.SaveChangesAsync() > 0;

                if (!result)
                    return Result<Unit>.Failure("Failed to Update Activity!");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}