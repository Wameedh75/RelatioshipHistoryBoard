using System.Collections.Generic;

namespace RelationshipHistoryBoard.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<SurveyOccation> SurveyOccations { get; set; }

    }
}