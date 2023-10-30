using MediatR;
using Notes.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Domain;

namespace Notes.Application.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler
        : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INoteDbContext _dbContext;

        public UpdateNoteCommandHandler(INoteDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateNoteCommand request,
            CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.Notes.FirstOrDefaultAsync(
                    note => note.Id == request.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Contact = request.Contact;
            entity.Status = request.Status;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
