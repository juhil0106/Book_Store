namespace User.API.Models
{
    public partial class UserChoice
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GenreId { get; set; } = null!;

        public virtual UserDetails User { get; set; } = null!;
    }
}
