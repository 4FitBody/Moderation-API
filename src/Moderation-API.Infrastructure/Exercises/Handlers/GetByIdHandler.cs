namespace Moderation_API.Infrastructure.Exercises.Handlers;

using Moderation_API.Infrastructure.Exercises.Queries;
using Moderation_API.Core.Exercises.Models;
using MediatR;
using Moderation_API.Core.Exercises.Repositories;

public class GetByIdHandler : IRequestHandler<GetByIdQuery, Exercise>
{
    private readonly IExerciseRepository exerciseRepository;

    public GetByIdHandler(IExerciseRepository exerciseRepository) => this.exerciseRepository = exerciseRepository;

    public async Task<Exercise> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.Id);

        var exercise = await this.exerciseRepository.GetByIdAsync((int)request.Id);

        if (exercise is null)
        {
            return new Exercise();
        }

        return exercise!;
    }
}