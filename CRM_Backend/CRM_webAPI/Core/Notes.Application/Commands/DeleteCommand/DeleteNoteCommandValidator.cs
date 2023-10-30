
using FluentValidation;

namespace Notes.Application.Commands.DeleteCommand
{
    public class DeleteNoteCommandValidator
        : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidator() 
        {
            RuleFor(deleteNoteCommand =>
                deleteNoteCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
