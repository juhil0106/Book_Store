namespace User.API.Models
{
    public partial class UserDetails
    {
        public UserDetails()
        {
            UserChoices = new HashSet<UserChoice>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Gender { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string Password { get; set; } = null!;

        public virtual ICollection<UserChoice> UserChoices { get; set; }
    }
}
