namespace UserManagementSystem.Models.UsersPhones.Requests
{
    public class CreateUserPhoneRequest
    {
        public long UserId { get; set; }

        public string PhoneNumber { get; set; }
    }
}
