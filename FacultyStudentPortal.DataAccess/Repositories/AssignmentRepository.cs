using Dapper;
using FacultyStudentPortal.DataAccess.Interfaces;
using FacultyStudentPortal.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FacultyStudentPortal.DataAccess.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly IDbConnection _db;

        public AssignmentRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }

        public async Task<int> CreateAssignmentAsync(Assignment assignment)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Mode", "CreateAssignment");
                parameters.Add("@Title", assignment.Title);
                parameters.Add("@Description", assignment.Description);
                parameters.Add("@DueDate", assignment.DueDate);
                parameters.Add("@FilePath", assignment.FilePath);

                return await _db.ExecuteAsync("sp_AssignmentPortalOperations", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating assignment", ex);
            }
        }
        public async Task<IEnumerable<Assignment>> GetAllAssignmentAsync()
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Mode", "GetAllAssignments");
               
                return await _db.QueryAsync<Assignment>("sp_AssignmentPortalOperations", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating assignment", ex);
            }
        }
        public async Task<IEnumerable<Submission>> GetSubmissionsByAssignmentIdAsync(int AssignmentId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Mode", "GetSubmission");
                parameters.Add("@AssignmentId", AssignmentId);

                return await _db.QueryAsync<Submission>("sp_AssignmentPortalOperations", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating assignment", ex);
            }
        }

        public async Task<int> SubmitAssessmentAsync(Assessment assessment)
        {
            try
            {
                var parameters = new DynamicParameters();
                string criteriaJson = JsonConvert.SerializeObject(assessment.Criteria);
                parameters.Add("@Mode", "SubmitAssessment");
                parameters.Add("@AssignmentId", assessment.AssignmentId);
                parameters.Add("@StudentId", assessment.StudentId);
                parameters.Add("@CriteriaScores", criteriaJson);
                parameters.Add("@Remarks", assessment.Remarks);
                return await _db.ExecuteAsync("sp_AssignmentPortalOperations", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error submitting assessment", ex);
            }
        }

        public async Task<IEnumerable<User>> GetAllStudentsAsync()
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Mode", "GetAllStudents");

                return await _db.QueryAsync<User>("sp_AssignmentPortalOperations", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving student list", ex);
            }
        }

        public async Task<IEnumerable<PerformanceData>> GetPerformanceDataAsync()
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Mode", "GetPerformanceData");

                return await _db.QueryAsync<PerformanceData>("sp_AssignmentPortalOperations", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving performance data", ex);
            }
        }
        public async Task<IEnumerable<PerformanceData>> GetStudentsWisePerformanceData(int StudentId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Mode", "GetPerformanceData");
                parameters.Add("@StudentId", StudentId);

                return await _db.QueryAsync<PerformanceData>("sp_AssignmentPortalOperations", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving performance data", ex);
            }
        }
    }
}
