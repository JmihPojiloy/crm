using MediatR;

namespace Notes.Application.Queries.GetNoteList
{
    public class GetNoteListQuery : IRequest<NoteListVm>
    {
        //public Guid Id { get; set; } // нужен ли мне Id???
    }
}
