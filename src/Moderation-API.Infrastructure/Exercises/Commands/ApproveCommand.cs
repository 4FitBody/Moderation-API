using MediatR;

namespace Moderation_API.Infrastructure.Exercises.Commands;

public class ApproveCommand : IRequest
{
    public int? Id { get; set;}

    public ApproveCommand(int? id)
    {
        this.Id = id;
    }

    public ApproveCommand() { }
}