using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Song : BaseEntity
    {
        public string SongName { get; set; }
        public string SongType { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
