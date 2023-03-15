using AlbumStorer.Context;
using AlbumStorer.DbEntities;
using AlbumStorer.Repositories;
using AlbumStorer.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace AlbumStorer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        //[HttpGet]
        //public async Task<string> GetSpotify()
        //{
        //    SpotifyTest test = new SpotifyTest();
        //    var result = await test.GetSpotifyAlbum();
        //    return result;
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtist(int id)
        {
            try
            {
                var result = await _artistRepository.GetArtist(id);
                return Ok(result);
            }
            catch (ArgumentException ex) { 
                return BadRequest(ex.Message);
            }
            

        }

        [HttpPost]
        public async Task<IActionResult> AddArtist([FromBody] Artist updatedArtist)
        {
            var artist = await _artistRepository.AddArtist(updatedArtist);
            if (artist is null)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(artist);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteArtist(int id)
        {
            var message = await _artistRepository.DeleteArtist(id);
            
            return message;
        }
    }
}
