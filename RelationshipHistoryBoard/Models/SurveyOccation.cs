using System;
using System.Collections.Generic;

namespace RelationshipHistoryBoard.Models
{
    public class SurveyOccation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual IEnumerable<Question> Questionses { get; set; }
        public virtual IEnumerable<UserGroup> UserGroups { get; set; }


        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }

    }
}