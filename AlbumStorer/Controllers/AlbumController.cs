using AlbumStorer.Context;
using AlbumStorer.DbEntities;
using AlbumStorer.DtoModels;
using AlbumStorer.Repositories;
using AlbumStorer.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlbumStorer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepo;

        public AlbumController(IAlbumRepository albumRepo)
        {
            _albumRepo = albumRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum(int id)
        {
            Album album = await _albumRepo.GetAlbum(id);
            return Ok(album);
        }


        [HttpPost]
        [Route("addAlbum")]
        public async Task<IActionResult> AddAlbum([FromBody] AlbumDto albumDto)
        {
           Album album = await _albumRepo.AddAlbum(albumDto);
           return Ok(album);
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteAlbum(int albumId)
        //{
        //    var albumToDelete = await _albumRepo.DeleteAlbum(albumId);
        //    return Ok(albumToDelete);
        //}

        //[HttpPut]
        //[Route("updateRating")]
        //public async Task<IActionResult> UpdateRating(RatingDto ratingDto)
        //{
        //    Album albumToUpdate = await _albumRepo.GetAlbum(ratingDto.AlbumId);
        //    albumToUpdate.SetAlbumRating(ratingDto.NewRating);
        //    var album = _albumRepo.UpdateAlbum(albumToUpdate);
        //    return Ok(album);
        //}

    }
}
