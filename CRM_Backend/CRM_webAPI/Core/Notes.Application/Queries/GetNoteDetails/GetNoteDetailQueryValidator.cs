
using FluentValidation;

namespace Notes.Application.Queries.GetNoteDetails
{
    public class GetNoteDetailQueryValidator
        : AbstractValidator<GetNoteDetailsQuery>
    {
        public GetNoteDetailQueryValidator() 
        {
            RuleFor(note =>
                note.Id).NotEqual(Guid.Empty);
        }
    }
}
