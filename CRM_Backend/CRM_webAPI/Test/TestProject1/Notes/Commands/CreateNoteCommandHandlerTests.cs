using Microsoft.EntityFrameworkCore;
using Notes.Application.Commands.CreateNote;
using Notes.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Notes.Tests.Notes.Commands
{
    public class CreateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateNoteCommandHandler_Succes()
        {
            //Arrange
            var handler = new CreateNoteCommandHandler(Context);
            var noteName = "note name";
            var noteDescription = "note description";
            var noteContact = "note contact";

            //Act
            var noteId = await handler.Handle(
                new CreateNoteCommand
                {
                    Name = noteName,
                    Description = noteDescription,
                    Contact = noteContact
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(await Context.Notes.SingleOrDefaultAsync(note =>
                note.Id == noteId && note.Name == noteName &&
                note.Description == noteDescription && note.Contact == noteContact));
        }
    }
}
