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

        public async Task<UserDal[]> GetUsersList()
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                return (await db.QueryAsync<UserDal>("SELECT id, name, email, created_at FROM public.users_table;")).ToArray();
            }
        }

        public async Task<UserDal> GetUser(long id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                return (await db.QueryAsync<UserDal>("SELECT id, name, email, created_at FROM public.users_table WHERE Id = @id;", new { id })).FirstOrDefault();
            }
        }

        public async Task CreateUser(UserDal user)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                await db.ExecuteAsync("INSERT INTO public.users_table (name, email, created_at) VALUES(@Name, @Email, @CreatedAt);", user);
            }
        }

        public async Task UpdateUser(UserDal user)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                await db.ExecuteAsync("UPDATE public.users_table SET name = @Name, email = @Email WHERE id=@Id;", user);
            }
        }
    }
}
