using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeDor.Models
{
    public abstract class BlogElement
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public User Author { get; set; } // Usuario que escribió el comentario
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
