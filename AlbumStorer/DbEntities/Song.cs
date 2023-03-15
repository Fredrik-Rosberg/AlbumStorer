using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AlbumStorer.DbEntities
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }
        [JsonIgnore]
        public Album Album { get; set; }
    }
}
