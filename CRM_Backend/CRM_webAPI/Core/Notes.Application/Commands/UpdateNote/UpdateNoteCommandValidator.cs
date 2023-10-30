
using FluentValidation;

namespace Notes.Application.Commands.UpdateNote
{
    public class UpdateNoteCommandValidator
        : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator() 
        {
            RuleFor(updateNoteCommand =>
                updateNoteCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand =>
                updateNoteCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(updateNoteCommand =>
                updateNoteCommand.Description).NotEmpty().MaximumLength(250);
            RuleFor(updateNoteCommand =>
                updateNoteCommand.Contact).NotEmpty().MaximumLength(50);
            RuleFor(updateNoteCommand =>
                updateNoteCommand.Status).NotEmpty().MaximumLength(20);
        }
    }
}
