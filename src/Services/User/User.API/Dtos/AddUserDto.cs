namespace User.API.Dtos
{
    public class AddUserDto
    {
        public string Name { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Gender { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
    }
}
