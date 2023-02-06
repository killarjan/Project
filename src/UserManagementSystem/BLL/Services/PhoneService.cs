using UserManagementSystem.BLL.Models.UsersPhones;
using UserManagementSystem.DAL.Models;
using UserManagementSystem.DAL.Repositories;

namespace UserManagementSystem.BLL.Services
{
    public class PhoneService
    {
        private readonly PhoneRepository _phoneRepository;

        public PhoneService(PhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public async Task CreateUserPhone(CreateUserPhoneModel userPhone)
        {
            var userPhoneDal = new UserPhoneDal()
            {
                UserId = userPhone.UserId,
                PhoneNumber = userPhone.PhoneNumber,
                CreatedAt = DateTime.Now,
            };

            await _phoneRepository.CreateUserPhone(userPhoneDal);
        }

        public async Task UpdateUserPhone(UpdateUserPhoneModel userPhone)
        {
            var userPhoneDal = new UserPhoneDal()
            {
                Id = userPhone.Id,
                PhoneNumber = userPhone.PhoneNumber,
                UpdatedAt = DateTime.Now,
            };

            await _phoneRepository.UpdateUserPhone(userPhoneDal);
        }

        public async Task<List<GetUserPhonesListResult>> GetUserPhonesList(long userId)
        {
            return (await _phoneRepository.GetUserPhonesList(userId))
                .Select(r => new GetUserPhonesListResult()
                {
                    PhoneNumber=r.PhoneNumber,
                })
                .ToList();
        }

        public async Task DeletePhoneByUserId(long userId)
        {
            await _phoneRepository.DeletePhoneByUserId(userId);
        }

        public async Task DeletePhone(string phoneNumber)
        {
            await _phoneRepository.DeletePhone(phoneNumber);
        }
    }
}
