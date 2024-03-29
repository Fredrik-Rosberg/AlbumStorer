﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AlbumStorer.DbEntities
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Song> Songs { get; set; } = new();
        public int? Rating { get; set; }

        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }
        [JsonIgnore]
        public Artist Artist { get; set; }


        public void SetAlbumRating(int newRating)
        {
            Rating = newRating;
        }

    }

   
}
