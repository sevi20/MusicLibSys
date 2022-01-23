using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class AuthorVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, byte.MaxValue, ErrorMessage = "The Volume must have positive values!")]
        public byte Age { get; set; }
        public string City { get; set; }

        public AuthorVM() { }

        public AuthorVM(AuthorDTO authorDTO)
        {
            Id = authorDTO.Id;
            Name = authorDTO.Name;
            Age = authorDTO.Age;
            City = authorDTO.City;
        }
    }
}