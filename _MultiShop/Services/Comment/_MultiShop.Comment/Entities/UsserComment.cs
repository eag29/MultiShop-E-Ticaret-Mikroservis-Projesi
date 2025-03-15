namespace _MultiShop.Comment.Entities
{
    public class UsserComment
    {
        public int UsserCommentID { get; set; }
        public string NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        public string Email { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Satus { get; set; }
        public string ProductID { get; set; }
    }
}
