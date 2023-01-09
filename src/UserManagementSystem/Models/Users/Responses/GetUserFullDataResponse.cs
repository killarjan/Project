namespace UserManagementSystem.Models.Users.Responses
{
    public class GetUserFullDataResponse
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public List<GetUserFullDataPhonesResponse> Phones { get; set; }
    }

    public class GetUserFullDataPhonesResponse
    {
        public string PhoneNumber { get; set; }
    }
}
