using AlbumStorer.Context;
using AlbumStorer.DbEntities;
using AlbumStorer.DtoModels;
using AlbumStorer.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace AlbumStorer.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly RecordsDbContext _context;
        public AlbumRepository(RecordsDbContext context)
        {
            _context = context;
        }

        public async Task<Album> GetAlbum(int albumId)
        {
            var album = _context.Albums.Include(a => a.Artist).Where(a => a.Id == albumId).FirstOrDefault();
            return album;
        }

        public async Task<Album> AddAlbum(AlbumDto albumDto)
        {
            Album album = ConvertToAlbum(albumDto);
            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();
            return album;
        }

        public async Task<Album> DeleteAlbum(int albumId)
        {
            var albumToDelete = await GetAlbum(albumId);
            _context.Albums.Remove(albumToDelete);
            await _context.SaveChangesAsync();
            return albumToDelete;
        }

        public async Task<Album> UpdateAlbum(Album album)
        {
            _context.Albums.Update(album);
            _context.SaveChanges();
            return album;
        }

        public Album ConvertToAlbum(AlbumDto dto)
        {
            Album album = new Album() { Id = dto.Id, ArtistId = dto.ArtistId, Songs = dto.Songs, Title = dto.Title, Rating = dto.Rating };
            return album;
        }

    }
}
