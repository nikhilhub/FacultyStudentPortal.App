using FacultyStudentPortal.Business.Interfaces;
using FacultyStudentPortal.DataAccess.Interfaces;
using FacultyStudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyStudentPortal.Business.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepo;
        private readonly IUserRepository _userRepo;

        public AssignmentService(IAssignmentRepository assignmentRepo, IUserRepository userRepo)
        {
            _assignmentRepo = assignmentRepo;
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<User>> GetAllStudentsAsync()
        {
            return await _assignmentRepo.GetAllStudentsAsync();
        }

        public async Task<int> CreateAssignmentAsync(Assignment assignment)
        {
            return await _assignmentRepo.CreateAssignmentAsync(assignment);
        }
        public async Task<IEnumerable<Assignment>> GetAllAssignmentAsync()
        {
            return await _assignmentRepo.GetAllAssignmentAsync();
        }
        public async Task<IEnumerable<Submission>> GetSubmissionsByAssignmentIdAsync(int Assignment)
        {
            return await _assignmentRepo.GetSubmissionsByAssignmentIdAsync(Assignment);
        }


        public async Task<int> SubmitAssessmentAsync(Assessment assessment)
        {
            return await _assignmentRepo.SubmitAssessmentAsync(assessment);
        }

        public async Task<IEnumerable<PerformanceData>> GetPerformanceDataAsync()
        {
            return await _assignmentRepo.GetPerformanceDataAsync();
        }
        public async Task<IEnumerable<PerformanceData>> GetStudentsWisePerformanceData(int StudentId)
        {
            return await _assignmentRepo.GetStudentsWisePerformanceData(StudentId);
        }
    }
}
