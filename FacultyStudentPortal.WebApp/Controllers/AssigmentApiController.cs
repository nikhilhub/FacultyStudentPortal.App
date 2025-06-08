using FacultyStudentPortal.Business.Interfaces;
using FacultyStudentPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FacultyStudentPortal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentApiController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentApiController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

      
        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _assignmentService.GetAllStudentsAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

      
        [HttpPost("create")]
        [Authorize(Roles = " Faculty")]
        public async Task<IActionResult> CreateAssignment([FromBody] Assignment assignment)
        {
            try
            {
                var result = await _assignmentService.CreateAssignmentAsync(assignment);
                if (result > 0)
                    return Ok(new { message = "Assignment created successfully." });

                return BadRequest(new { error = "Failed to create assignment." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
        
        [HttpGet("get-assignment")]
        [Authorize(Roles = "Faculty,Student")]
        public async Task<IActionResult> GetAssignments()
        {
            try
            {
                Assignment assignment = new Assignment();

                var result = await _assignmentService.GetAllAssignmentAsync();
                
                    return Ok(result);

               
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [Authorize(Roles = "Faculty")]

        [HttpPost("submit-assessment")]

        public async Task<IActionResult> SubmitAssessment([FromBody] Assessment assessment)
        {
            try
            {
                var result = await _assignmentService.SubmitAssessmentAsync(assessment);
                if (result > 0)
                    return Ok(new { message = "Assessment submitted successfully." });

                return BadRequest(new { error = "Failed to submit assessment." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
       

        [HttpGet("get-submissions/{assignmentId}")]
        [Authorize(Roles = "Faculty,Student")]
        public async Task<IActionResult> GetSubmissionsByAssignmentId(int assignmentId)
        {
            var result = await _assignmentService.GetSubmissionsByAssignmentIdAsync(assignmentId);

            return Ok(result);

        }



        [HttpGet("performance-data")]
        [Authorize(Roles = "Faculty")]
        public async Task<IActionResult> GetPerformanceData()
        {
            try
            {
                var data = await _assignmentService.GetPerformanceDataAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("performance-data/{studentId}")]
        [Authorize(Roles = "Faculty,Student")]
        public async Task<IActionResult> GetStudentsWisePerformanceData(int StudentId)
        {
            try
            {
                var data = await _assignmentService.GetPerformanceDataAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
