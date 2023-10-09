namespace ChallengeDor.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public User Author { get; set; } // Usuario que escribió el blog post
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<BlogComment> Comments { get; set; } // Lista de comentarios en el blog post

        public BlogPost()
        {
            Comments = new List<BlogComment>();
        }
    }
}
