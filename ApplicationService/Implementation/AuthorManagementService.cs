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
    public class AuthorManagementService
    {
        private MusicLibrary1SystemDBContext ctx = new MusicLibrary1SystemDBContext();

        public List<AuthorDTO> Get()
        {
            List<AuthorDTO> authorDtos = new List<AuthorDTO>();

            foreach (var item in ctx.Authors.ToList())
            {
                authorDtos.Add(new AuthorDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                    City = item.City
                });
            }
            return authorDtos;
        }

        public AuthorDTO GetById(int id)
        {
            Author item = ctx.Authors.Find(id);

            AuthorDTO authorDto = new AuthorDTO
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                City = item.City
            };
            return authorDto;
        }

        public bool Save(AuthorDTO authorDTO)
        {
            Author author = new Author
            {
                Id = authorDTO.Id,
                Name = authorDTO.Name,
                Age = authorDTO.Age,
                City = authorDTO.City
            };
            try
            {
                if (authorDTO.Id == 0)
                    ctx.Authors.Add(author);
                else
                    ctx.Authors.AddOrUpdate(author);

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
                Author author = ctx.Authors.Find(id);
                ctx.Authors.Remove(author);
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
