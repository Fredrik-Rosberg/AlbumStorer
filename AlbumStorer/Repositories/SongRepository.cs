using AlbumStorer.Context;
using AlbumStorer.DbEntities;
using AlbumStorer.ServiceInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AlbumStorer.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly RecordsDbContext _context;

        public SongRepository(RecordsDbContext context)
        {
            _context = context;
        }
        public async Task<Song> GetBySongId(int songId)
        {
            var song = await _context.Songs.FindAsync(songId);
            return song == null ? throw new NullReferenceException("Song not found") : song;
        }
    }
}
