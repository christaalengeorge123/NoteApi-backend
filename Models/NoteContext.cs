using Microsoft.EntityFrameworkCore;

namespace NoteAPI.Models
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options) : base(options)
        {

        }
        public DbSet<Note> NoteItems { get; set; }
    }
}

