using FacultyStudentPortal.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyStudentPortal.Business.Interfaces
{
    public interface IAssignmentService
    {
        Task<IEnumerable<User>> GetAllStudentsAsync();
        Task<int> CreateAssignmentAsync(Assignment assignment);
        Task<IEnumerable<Assignment>> GetAllAssignmentAsync();
        Task<IEnumerable<Submission>> GetSubmissionsByAssignmentIdAsync(int AssignmentId);
     
        Task<int> SubmitAssessmentAsync(Assessment assessment);
        Task<IEnumerable<PerformanceData>> GetPerformanceDataAsync();
        Task<IEnumerable<PerformanceData>> GetStudentsWisePerformanceData(int StudentId);
    }
}
