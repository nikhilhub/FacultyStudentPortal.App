using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FacultyStudentPortal.App.Controllers
{
    public class FacultyController : Controller
    {
        [Authorize(Roles = " Faculty")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
