namespace UserManagementSystem.BLL.Models.Users
{
    public class GetUserFullDataResult
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public List<GetUserFullDataPhonesResult> Phones { get; set; }
    }

    public class GetUserFullDataPhonesResult
    {
        public string PhoneNumber { get; set; }
    }
}
