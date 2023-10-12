using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeDor.Models
{
    public class BlogComment : BlogElement
    {
        [Required]
        public int BlogPostId { get; set; }

    }
}
