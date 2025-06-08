using FacultyStudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyStudentPortal.Business.Interfaces
{
    public interface IUserService
    {
        Task<int> RegisterUserAsync(User user);
        Task<User> LoginAsync(string email, string password);
    }
}
