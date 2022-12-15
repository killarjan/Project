using UserManagementSystem.BLL.Models;
using UserManagementSystem.DAL.Models;
using UserManagementSystem.DAL.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace UserManagementSystem.BLL.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUsersListResult[]> GetUsersList()
        {
            return (await _userRepository.GetUsersList())
                .Select(r => new GetUsersListResult()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Email = r.Email
                })
                .ToArray();
        }

        public async Task<GetUsersListResult> GetUser(long id)
        {
            var dalResult = await _userRepository.GetUser(id);

            if (dalResult == null)
            {
                return null;
            }

            return new GetUsersListResult()
            {
                Id = dalResult.Id,
                Name = dalResult.Name,
                Email = dalResult.Email,
            };
        }

        public void CreateUser(CreateUserModel user)
        {
            var userDal = new UserDal()
            {
                Name = user.Name,
                Email = user.Email,
                CreatedAt = DateTime.Now,
            };
            _userRepository.CreateUser(userDal);
        }
    }
}
