using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace AlbumStorer.DbEntities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Bio { get; set; }
        public List<Album> Albums { get; set; }

        public void UpdateBio(string newBio)
        {
            Bio = newBio;
        }

    }
}
