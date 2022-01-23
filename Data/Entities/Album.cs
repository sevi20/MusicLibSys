using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Album : BaseEntity
    {
        public string Title { get; set; }
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
