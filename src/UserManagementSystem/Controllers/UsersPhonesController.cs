using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.BLL.Models.UsersPhones;
using UserManagementSystem.BLL.Services;
using UserManagementSystem.Models.UsersPhones.Requests;
using UserManagementSystem.Models.UsersPhones.Responses;

namespace UserManagementSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersPhonesController : ControllerBase
    {
        private readonly PhoneService _phoneService;

        public UsersPhonesController(PhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserPhone(CreateUserPhoneRequest userPhone)
        {
            var userPhoneModel = new CreateUserPhoneModel()
            {
                UserId = userPhone.UserId,
                PhoneNumber = userPhone.PhoneNumber,
            };

            await _phoneService.CreateUserPhone(userPhoneModel);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserPhone(UpdateUserPhoneRequest userPhone)
        {
            var userPhoneModel = new UpdateUserPhoneModel()
            {
                Id = userPhone.Id,
                PhoneNumber = userPhone.PhoneNumber,
            };

            await _phoneService.UpdateUserPhone(userPhoneModel);

            return Ok();
        }

        [HttpGet]
        public async Task<GetUserPhonesResponse[]> GetUserPhonesList(long userId)
        {
            return (await _phoneService.GetUserPhonesList(userId))
                .Select(r => new GetUserPhonesResponse()
                {
                    PhoneNumber=r.PhoneNumber,
                })
                .ToArray();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePhoneByUserId(long userId)
        {
            await _phoneService.DeleteUserById(userId);
            return Ok();
        }

        [HttpDelete("deletephone")]
        public async Task <IActionResult> DeleteUserByPhone(string phoneNumber)
        {
            await _phoneService.DeleteUserByPhone(phoneNumber);
            return Ok();
        }
    }
}
