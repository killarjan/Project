namespace UserManagementSystem.DAL.Models
{
    public class UserPhoneDal
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
