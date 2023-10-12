using System.ComponentModel.DataAnnotations;

namespace ChallengeDor.Models
{
    public class BlogPost : BlogElement
    {
        [Required]
        public string Title { get; set; }
        public bool Deleted { get; set; } 
        public List<BlogComment> Comments { get; set; } // Lista de comentarios en el blog post

        public BlogPost() : base() 
        {
            Comments = new List<BlogComment>();
            Deleted = false;
        }
    }
}
