using AutoMapper;
using Book.API.Repositories.IRepositories;
using Book.API.ResponseModel;
using EventBus.Messages.Event;
using MassTransit;

namespace Book.API.EventBusConsumer
{
    public class BookQuantityConsumer : IConsumer<BookEvent>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public BookQuantityConsumer(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task Consume(ConsumeContext<BookEvent> context)
        {
            var bookMessage = _mapper.Map<BookMessage>(context.Message);
            foreach (var bookQuantity in bookMessage.BookQuantities)
            {
                var book = await _bookRepository.GetBookDetailById(bookQuantity.BookId);
                if (book is not null)
                {
                    book.Quantity -= bookQuantity.Quantity;
                    await _bookRepository.UpdateBook(book);
                    Console.WriteLine($"Book with Id: {book.Id} is updated.");
                }
            }
        }
    }
}
