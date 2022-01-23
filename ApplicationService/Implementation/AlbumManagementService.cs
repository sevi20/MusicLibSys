using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementation
{
    public class AlbumManagementService
    {
        private MusicLibrary1SystemDBContext ctx = new MusicLibrary1SystemDBContext();

        public List<AlbumDTO> Get()
        {
            List<AlbumDTO> albumDtos = new List<AlbumDTO>();

            foreach (var item in ctx.Albums.ToList())
            {
                albumDtos.Add(new AlbumDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    SongId = item.SongId,
                    AuthorId = item.AuthorId,
                    Song = new SongDTO
                    {
                        Id = item.SongId,
                        SongName = item.Song.SongName,
                        SongType = item.Song.SongType
                    },
                    Author = new AuthorDTO
                    {
                        Id = item.AuthorId,
                        Name = item.Author.Name,
                        Age = item.Author.Age,
                        City = item.Author.City
                    }
                });
            }
            return albumDtos;
        }

        public AlbumDTO GetById(int id)
        {
            Album item = ctx.Albums.Find(id);

            AlbumDTO albumDto = new AlbumDTO
            {
                Id = item.Id,
                Title = item.Title,
                SongId = item.SongId,
                AuthorId = item.AuthorId,
                Song = new SongDTO
                {
                    Id = item.SongId,
                    SongName = item.Song.SongName,
                    SongType = item.Song.SongType
                },
                Author = new AuthorDTO
                {
                    Id = item.AuthorId,
                    Name = item.Author.Name,
                    Age = item.Author.Age,
                    City = item.Author.City
                }
            };
            return albumDto;
        }

        public bool Save(AlbumDTO albumsDto)
        {
            // check if album has author || author_id && song || song_id
            if (albumsDto.Author == null || albumsDto.AuthorId == 0 || albumsDto.Song == null || albumsDto.SongId == 0)
            {
                return false;
            }
            Album album = new Album
            {
                Id = albumsDto.Id,
                Title = albumsDto.Title,
                SongId = albumsDto.SongId,
                AuthorId = albumsDto.AuthorId,
            };
            try
            {
                if (albumsDto.Id == 0)
                    ctx.Albums.Add(album);
                else
                    ctx.Albums.AddOrUpdate(album);

                ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Album album = ctx.Albums.Find(id);
                ctx.Albums.Remove(album);
                ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
