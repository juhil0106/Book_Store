namespace User.API.Dtos
{
    public class UserChoiceDto
    {
        public int Id { get; set; }
        public UserDetailsDto User { get; set; }
        public string GenreId { get; set; } = null!;
    }
}
