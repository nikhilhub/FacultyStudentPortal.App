using FacultyStudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyStudentPortal.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<int> AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        
    }
}
