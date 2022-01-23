using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class SongVM
    {
        public int Id { get; set; }

        [Required]
        public string SongName { get; set; }
        public string SongType { get; set; }

        public SongVM() { }

        public SongVM(SongDTO songDTO)
        {
            Id = songDTO.Id;
            SongName = songDTO.SongName;
            SongType = songDTO.SongType;
        }
    }
}