using AlbumStorer.DbEntities;

namespace AlbumStorer.DtoModels
{
    public class AlbumDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Song> Songs { get; set; } = new();
        public int ArtistId { get; set; }
        public int Rating { get; set; }
    }
}
