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
        private readonly RecordsDbContext _context;
        private readonly IArtistRepository _artistRepository;

        public ArtistController(RecordsDbContext context, IArtistRepository artistRepository)
        {
            _context = context;
            _artistRepository = artistRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtist(int artistId)
        {
            //var artist = _context.Artists.Find(artistId);
            //return artist == null ? NotFound() : Ok(artist);
            try
            {
                var result = await _artistRepository.GetArtist(artistId);
                return Ok(result);
            }
            catch (ArgumentException ex) { 
                return BadRequest(ex.Message);
            }
            

        }

        [HttpPost]
        public async Task<IActionResult> AddArtist([FromBody] Artist updatedArtist)
        {
            var artist = await _context.Artists.AddAsync(updatedArtist);
            await _context.SaveChangesAsync();

            return artist == null ? BadRequest() : Ok(artist);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteArtist(int artistId)
        {
            var artist = _context.Artists.Find(artistId);
            if(artist == null)
            {
                return NotFound();
            }
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
            return Ok(artist);
        }
    }
}
