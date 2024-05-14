namespace Moderation_API.Infrastructure.Exercises.Handlers;

using Moderation_API.Core.Exercises.Repositories;
using Moderation_API.Infrastructure.Exercises.Commands;
using MediatR;

public class ApproveHandler : IRequestHandler<ApproveCommand>
{
    private readonly IExerciseRepository exerciseRepository;

    public ApproveHandler(IExerciseRepository exerciseRepository) => this.exerciseRepository = exerciseRepository;

    public async Task Handle(ApproveCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.Id);

        await this.exerciseRepository.ApproveAsync((int)request.Id);
    }
}