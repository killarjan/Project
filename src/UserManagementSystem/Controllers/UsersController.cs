using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.BLL.Models.Users;
using UserManagementSystem.BLL.Services;
using UserManagementSystem.Models.Users.Requests;
using UserManagementSystem.Models.Users.Responses;

namespace UserManagementSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
           _userService = userService;
        }

        [HttpGet]
        public async Task<GetUsersResponse[]> Get()
        {
           return (await _userService.GetUsersList())
                .Select(r => new GetUsersResponse()
                {
                    Name = r.Name,
                    Email = r.Email,
                })
                .ToArray();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            var serviceResult =await _userService.GetUser(id);

            if (serviceResult == null)
            {
                return NotFound();
            }

            return Ok (new GetUsersResponse()
            {
                Name = serviceResult.Name,
                Email = serviceResult.Email,
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(CreateUserRequest user)
        {
            var userModel = new CreateUserModel()
            {
                Name = user.Name,
                Email = user.Email,
            };

            await _userService.CreateUser(userModel);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest user)
        {
            var userModel = new UpdateUserModel()
            {
                Id = user.Id,
                Name = user.Name,
                Email= user.Email,
            };

            await _userService.UpdateUser(userModel);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(long id)
        {
            await _userService.DeleteUser(id);

            return Ok();
        }
    }
}
