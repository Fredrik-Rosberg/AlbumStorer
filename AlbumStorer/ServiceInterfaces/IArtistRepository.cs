using AlbumStorer.DbEntities;

namespace AlbumStorer.ServiceInterfaces
{
    public interface IArtistRepository
    {
        Task<Artist> GetArtist(int artistId);
        Task<Artist[]> GetAllArtists();
        Task<Artist> UpdateArtist(int artistId);
        Task DeleteArtist(int artistId);

    }
}
