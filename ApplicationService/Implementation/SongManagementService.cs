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
    public class SongManagementService
    {
        private MusicLibrary1SystemDBContext ctx = new MusicLibrary1SystemDBContext();

        public List<SongDTO> Get()
        {
            List<SongDTO> songDtos = new List<SongDTO>();

            foreach (var item in ctx.Songs.ToList())
            {
                songDtos.Add(new SongDTO
                {
                    Id = item.Id,
                    SongName = item.SongName,
                    SongType = item.SongType
                });
            }
            return songDtos;
        }

        public SongDTO GetById(int id)
        {
            Song item = ctx.Songs.Find(id);

            SongDTO songDto = new SongDTO
            {
                Id = item.Id,
                SongName = item.SongName,
                SongType = item.SongType
            };
            return songDto;
        }

        public bool Save(SongDTO songDTO)
        {
            Song song = new Song
            {
                Id = songDTO.Id,
                SongName = songDTO.SongName,
                SongType = songDTO.SongType
            };
            try
            {
                if (songDTO.Id == 0)
                    ctx.Songs.Add(song);
                else
                    ctx.Songs.AddOrUpdate(song);

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
                Song song = ctx.Songs.Find(id);
                ctx.Songs.Remove(song);
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
