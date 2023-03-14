using AlbumStorer.DbEntities;
using AlbumStorer.DtoModels;

namespace AlbumStorer.ServiceInterfaces
{
    public interface IAlbumRepository
    {
        Task<Album> GetAlbum(int albumId);
        Task<Album> AddAlbum(AlbumDto albumDto);
        Task<Album> DeleteAlbum(int albumId);
        Task<Album> UpdateAlbum(Album album);
        Album ConvertToAlbum(AlbumDto dto);
    }
}
