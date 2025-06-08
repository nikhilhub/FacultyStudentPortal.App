using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FacultyStudentPortal.App.Controllers
{
    public class StudentController : Controller
    {
        [Authorize(Roles = " Studnet")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
