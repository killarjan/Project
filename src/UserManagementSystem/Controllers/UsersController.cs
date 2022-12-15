using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.BLL.Services;
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
        public GetUsersResponse[] Get()
        {
           return _userService.GetUsersList()
                .Select(r => new GetUsersResponse()
                {
                    Name = r.Name,
                    Email = r.Email,
                })
                .ToArray();
        }

        [HttpGet("{id}")]

        public IActionResult GetUser(long id)
        {
            var serviceResult = _userService.GetUser(id);

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
    }
}
