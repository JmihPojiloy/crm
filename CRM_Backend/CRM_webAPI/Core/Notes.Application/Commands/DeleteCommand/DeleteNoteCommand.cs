using MediatR;

namespace Notes.Application.Commands.DeleteCommand
{
    public class DeleteNoteCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
