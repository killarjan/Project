using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.BLL.Models;
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
            var serviceResult = await _userService.GetUser(id);

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

        public IActionResult PostUser(CreateUserRequest user)
        {
            var userModel = new CreateUserModel()
            {
                Name = user.Name,
                Email = user.Email,
            };

            _userService.CreateUser(userModel);

            return Ok();
        }
    }
}
