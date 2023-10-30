
using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Commands.CreateNote
{
    public class CreateNoteCommandHandler
        :IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INoteDbContext _dbContext;

        public CreateNoteCommandHandler(INoteDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateNoteCommand request,
            CancellationToken cancellationToken)
        {
            var note = new Note
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Name = request.Name,
                Description = request.Description,
                Contact = request.Contact,
                Status = "Получена"
            };

            await _dbContext.Notes.AddAsync(note);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
