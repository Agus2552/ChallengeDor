namespace ChallengeDor.Models
{
    public class BlogPost : BlogElement
    {
        public string Title { get; set; }
        public bool Deleted { get; set; } = false;
        public List<BlogComment> Comments { get; set; } // Lista de comentarios en el blog post

        public BlogPost()
        {
            Comments = new List<BlogComment>();
        }
    }
}
