using Book.API.Model;

namespace Book.API.ResponseModel
{
    public class BookResponse
    {
        public BookDetail BookDetail { get; set; } = null!;
        public List<BookImage>? BookImages { get; set; }
    }
}
