using AlbumStorer.Context;
using AlbumStorer.DbEntities;
using AlbumStorer.Migrations;
using AlbumStorer.ServiceInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace AlbumStorer.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly DbSet<Artist> _artists;
        private readonly RecordsDbContext _context;

        public ArtistRepository(RecordsDbContext context)
        {
            _artists = context.Artists;
            _context = context;
        }

        public async Task<Artist> AddArtist(Artist newArtist)
        {
            await _artists.AddAsync(newArtist);
            await _context.SaveChangesAsync();

            return newArtist;
        }

        public async Task<string> DeleteArtist(int artistId)
        {
            Artist artistToRemove = await GetArtist(artistId);
            if(artistToRemove == null)
            {
                return "Could not find artist";
            }
            _artists.Remove(artistToRemove);
            await _context.SaveChangesAsync();

            return $"{artistToRemove.Name} has been removed from db";
        }

        public async Task<Artist[]> GetAllArtists()
        {
            return _artists.ToArray();
        }

        public async Task<Artist> GetArtist(int artistId)
        {
            var artist = _artists.Where(a => a.Id == artistId).FirstOrDefault();
                
            return artist == null ? throw new ArgumentException("Artist not found") : artist; 
        }

        /// <summary>
        /// Gets full info on Artist. Album and Songs included.
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns>Artist, Album, and Songs information</returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Artist> GetAllArtistInfo(int artistId)
        {
            var artist = _artists.Where(a => a.Id == artistId)
                .Include(a => a.Albums)
                .ThenInclude(al => al.Songs)
                .FirstOrDefault();

            return artist == null ? throw new ArgumentException("Artist not found") : artist;
        }

        public Task<Artist> UpdateArtist(int artistId)
        {
            throw new NotImplementedException();
        }
    }
}
