
namespace Notes.Persistence
{
    public class DbInitilazer
    {
        public static void Initialize(NoteDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
