using AlbumStorer.Context;
using AlbumStorer.DbEntities;
using AlbumStorer.ServiceInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace AlbumStorer.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly RecordsDbContext _context;

        public ArtistRepository(RecordsDbContext context)
        {
            _context = context;
        }

        public Task DeleteArtist(int artistId)
        {
            throw new NotImplementedException();
        }

        public Task<Artist[]> GetAllArtists()
        {
            throw new NotImplementedException();
        }

        public async Task<Artist> GetArtist(int artistId)
        {
            Artist artist = _context.Artists.Find(artistId);
            return artist == null ? throw new ArgumentException("Artist not found") : artist; 
        }

        public Task<Artist> UpdateArtist(int artistId)
        {
            throw new NotImplementedException();
        }
    }
}
