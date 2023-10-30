
using Microsoft.EntityFrameworkCore;
using Notes.Persistence;

namespace Notes.Tests.Common
{
    public class NotesContextFactory
    {
        public static Guid NoteIdForDelete = Guid.NewGuid();
        public static Guid NoteIdForUpdate = Guid.NewGuid();

        public static NoteDbContext Create()
        {
            var options = new DbContextOptionsBuilder<NoteDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new NoteDbContext(options);
            context.Database.EnsureCreated();

            context.Notes.AddRange(
                new Domain.Note
                {
                    Id = Guid.Parse("{26463829-F590-4790-8ECD-9F75F6A26FAB}"),
                    Name = "Name1",
                    Description = "Description1",
                    Contact = "Contact1",
                    Status = "Status1",
                    CreationDate = DateTime.Today,
                },
                new Domain.Note
                {
                    Id = Guid.Parse("{9C5DA3D5-A23C-48A7-8005-B8BECB913905}"),
                    Name = "Name2",
                    Description = "Description2",
                    Contact = "Contact2",
                    Status = "Status2",
                    CreationDate = DateTime.Today,
                },
                new Domain.Note
                {
                    Id = NoteIdForDelete,
                    Name = "Name3",
                    Description = "Description3",
                    Contact = "Contact3",
                    Status = "Status3",
                    CreationDate = DateTime.Today,
                },
                new Domain.Note
                {
                    Id = NoteIdForUpdate,
                    Name = "Name4",
                    Description = "Description4",
                    Contact = "Contact4",
                    Status = "Status4",
                    CreationDate = DateTime.Today,
                });

            context.SaveChanges();
            return context;
        }


        public static void Destroy(NoteDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();  
        }
    }
}
