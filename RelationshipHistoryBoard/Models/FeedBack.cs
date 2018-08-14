namespace RelationshipHistoryBoard.Models
{
    public class FeedBack
    {
        public int Id { get; set; }
        public int FeedBackValue { get; set; }
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}