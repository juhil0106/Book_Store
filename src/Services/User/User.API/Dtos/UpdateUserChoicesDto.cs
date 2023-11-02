namespace User.API.Dtos
{
    public class UpdateUserChoicesDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GenreId { get; set; } = null!;
    }
}
