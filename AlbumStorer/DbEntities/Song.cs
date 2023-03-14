using System.ComponentModel.DataAnnotations.Schema;

namespace AlbumStorer.DbEntities
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
       
    }
}
