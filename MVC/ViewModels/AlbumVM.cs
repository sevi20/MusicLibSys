using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class AlbumVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int SongId { get; set; }

        public AuthorVM AuthorVM { get; set; }
        public SongVM SongVM { get; set; }

        public AlbumVM() { }

        public AlbumVM(AlbumDTO albumDTO)
        {
            Id = albumDTO.Id;
            Title = albumDTO.Title;
            AuthorId = albumDTO.AuthorId;
            SongId = albumDTO.SongId;

            AuthorVM = new AuthorVM
            {
                Id = albumDTO.AuthorId,
                Name = albumDTO.Author.Name,
                Age = albumDTO.Author.Age,
                City = albumDTO.Author.City
            };

            SongVM = new SongVM
            {
                Id = albumDTO.SongId,
                SongName = albumDTO.Song.SongName,
                SongType = albumDTO.Song.SongType
            };
        }
    }
}