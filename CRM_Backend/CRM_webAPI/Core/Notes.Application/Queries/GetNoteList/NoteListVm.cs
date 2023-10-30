using Notes.Domain;

namespace Notes.Application.Queries.GetNoteList
{
    public class NoteListVm
    {
        public IList<NoteLookUpDto> Notes { get; set; }
    }
}
