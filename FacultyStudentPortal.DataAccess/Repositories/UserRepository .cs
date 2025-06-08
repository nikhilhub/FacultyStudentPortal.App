using Dapper;
using FacultyStudentPortal.DataAccess.Interfaces;
using FacultyStudentPortal.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyStudentPortal.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _db;

        public UserRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }

        public async Task<int> AddUserAsync(User user)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Mode", "AddUser");
                parameters.Add("@FullName", user.FullName);
                parameters.Add("@Email", user.Email);
                parameters.Add("@PasswordHash", user.PasswordHash);
                parameters.Add("@Role", user.Role);

                return await _db.ExecuteAsync("sp_AssignmentPortalOperations", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                // Optionally log the exception here
                throw new Exception("An error occurred while adding the user.", ex);
            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                    throw new ArgumentException("Email cannot be null or empty.", nameof(email));

                var parameters = new DynamicParameters();
                parameters.Add("@Mode", "GetUserByEmail");
                parameters.Add("@Email", email);

                var user = await _db.QueryFirstOrDefaultAsync<User>(
                    "sp_AssignmentPortalOperations", parameters, commandType: CommandType.StoredProcedure);

                return user; 
            }
            catch (Exception ex)
            {
               
                throw new Exception("An error occurred while retrieving the user by email.", ex);
            }
        }

    }

}
