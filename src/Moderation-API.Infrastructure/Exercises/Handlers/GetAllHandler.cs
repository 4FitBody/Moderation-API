namespace Moderation_API.Infrastructure.Exercises.Handlers;

using Moderation_API.Infrastructure.Exercises.Queries;
using Moderation_API.Core.Exercises.Models;
using MediatR;
using Moderation_API.Core.Exercises.Repositories;

public class GetAllHandler : IRequestHandler<GetAllQuery, IEnumerable<Exercise>>
{
    private readonly IExerciseRepository exerciseRepository;

    public GetAllHandler(IExerciseRepository exerciseRepository) => this.exerciseRepository = exerciseRepository;

    public async Task<IEnumerable<Exercise>?> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var exercises = await this.exerciseRepository.GetAllAsync();

        if (exercises is null)
        {
            return Enumerable.Empty<Exercise>();
        }

        return exercises;
    }
}