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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<int> RegisterUserAsync(User user)
        {
            return await _userRepo.AddUserAsync(user);
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _userRepo.GetUserByEmailAsync(email);
            if (user != null && user.PasswordHash == password) 
            {
                return user;
            }
            return null;
        }
    }

}
