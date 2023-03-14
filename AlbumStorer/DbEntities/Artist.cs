using System.ComponentModel.DataAnnotations.Schema;

namespace AlbumStorer.DbEntities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Bio { get; set; }

        public void UpdateBio(string newBio)
        {
            Bio = newBio;
        }

    }
}
