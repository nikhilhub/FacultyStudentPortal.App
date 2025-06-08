using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyStudentPortal.Models
{
    public class Submission
    {
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
        public string StudentName { get; set; }
        public string FilePath { get; set; }
        public DateTime SubmittedAt { get; set; }
    }

}
