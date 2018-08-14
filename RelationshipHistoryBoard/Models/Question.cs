using System.Collections.Generic;

namespace RelationshipHistoryBoard.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int SurveyOccationId { get; set; }
        public virtual SurveyOccation SurveyOccation { get; set; }
        public IEnumerable<FeedBack> FeedBacks { get; set; }

    }
}