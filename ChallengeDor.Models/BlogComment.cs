using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeDor.Models
{
    public class BlogComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public User Author { get; set; } // Usuario que escribió el comentario
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public BlogPost BlogPost { get; set; } // Blog post al que se refiere el comentario

    }
}
