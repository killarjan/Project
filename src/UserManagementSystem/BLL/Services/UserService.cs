using UserManagementSystem.BLL.Models;
using UserManagementSystem.DAL.Models;
using UserManagementSystem.DAL.Repositories;

namespace UserManagementSystem.BLL.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public GetUsersListResult[] GetUsersList()
        {
            return _userRepository.GetUsersList()
                .Select(r => new GetUsersListResult()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Email = r.Email
                })
                .ToArray();
        }

        public GetUsersListResult GetUser(long id)
        {
            var dalResult = _userRepository.GetUser(id);

            if (dalResult == null)
            {
                return null;
            }

            return new GetUsersListResult()
            {
                Id = dalResult.Id,
                Name= dalResult.Name,
                Email= dalResult.Email,
            };
        }
    }
}
