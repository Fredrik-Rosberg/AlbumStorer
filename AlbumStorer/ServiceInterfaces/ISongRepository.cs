using AlbumStorer.DbEntities;

namespace AlbumStorer.ServiceInterfaces
{
    public interface ISongRepository
    {
        Task<Song> GetBySongId(int songId);

       
    }
}
