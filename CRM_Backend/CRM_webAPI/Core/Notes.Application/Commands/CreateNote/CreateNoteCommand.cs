using MediatR;
namespace Notes.Application.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
    }
}
