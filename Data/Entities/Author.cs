using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public byte Age { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
