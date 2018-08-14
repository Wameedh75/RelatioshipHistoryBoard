using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RelationshipHistoryBoard.Models
{
    public class Survey
    {
        public int Id { get; set; }
        [Required,StringLength(30)]
        public string Name { get; set; }
        public virtual IEnumerable<SurveyOccation> SurveyOccations { get; set; }

    }
}