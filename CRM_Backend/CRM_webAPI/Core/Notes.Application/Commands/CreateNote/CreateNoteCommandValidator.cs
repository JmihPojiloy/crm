using FluentValidation;

namespace Notes.Application.Commands.CreateNote
{
    public class CreateNoteCommandValidator
        : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(createNoteCommand =>
                createNoteCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(createNoteCommand =>
                createNoteCommand.Description).NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand =>
                createNoteCommand.Contact).NotEmpty().MaximumLength(50);
        }
    }
}
