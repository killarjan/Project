using Dapper;
using Npgsql;
using System.Data;
using UserManagementSystem.BLL.Models;
using UserManagementSystem.DAL.Models;

namespace UserManagementSystem.DAL.Repositories
{
    public class UserRepository
    {
        private readonly string _connectionString;
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("DbSettings:ConnectionString").Value;
        }

        public UserDal[] GetUsersList()
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                return db.Query<UserDal>("SELECT id, name, email, created_at FROM public.users_table;").ToArray();
            }
        }

        public UserDal GetUser(long id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                return db.Query<UserDal>("SELECT id, name, email, created_at FROM public.users_table WHERE Id = @id;", new { id }).FirstOrDefault();
            }
        }
    }
}
