using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyStudentPortal.Models
{
    public class Assessment
    {
        public int AssessmentId { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public List<AssessmentCriterion> Criteria { get; set; }
        public string Remarks { get; set; }
    }

    public class AssessmentCriterion
    {
        public string Criterion { get; set; }
        public int Score { get; set; }
    }

}
