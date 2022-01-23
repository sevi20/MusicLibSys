using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SongId { get; set; }
        public virtual SongDTO Song { get; set; }
        public int AuthorId { get; set; }

        //виртуален обект, с който може да работим с националността като нещо отделно, а не само като ID
        public virtual AuthorDTO Author { get; set; }
    }
}
