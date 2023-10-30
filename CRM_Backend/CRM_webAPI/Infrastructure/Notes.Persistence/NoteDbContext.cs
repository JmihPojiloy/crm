using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Persistence.EntityTypeConfiguration;

namespace Notes.Persistence
{
    public class NoteDbContext : DbContext, INoteDbContext
    {
        public DbSet<Note> Notes { get ; set ; }

        public NoteDbContext(DbContextOptions<NoteDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
