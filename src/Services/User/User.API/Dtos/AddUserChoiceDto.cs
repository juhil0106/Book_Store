namespace User.API.Dtos
{
    public class AddUserChoiceDto
    {
        public int UserId { get; set; }
        public string GenreId { get; set; } = null!;
    }
}
