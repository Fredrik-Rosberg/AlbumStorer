using AlbumStorer.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace AlbumStorer.Context
{
    public class RecordsDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }

        public RecordsDbContext(DbContextOptions<RecordsDbContext> options) : base(options)
        {
            
        }

        
        

    }
}
