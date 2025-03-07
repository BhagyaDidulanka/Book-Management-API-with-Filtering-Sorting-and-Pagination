using shorting_filtering_pagination.DTOs;
using shorting_filtering_pagination.Repositories;

namespace shorting_filtering_pagination.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync(string? search, string? sortBy, bool isDescending, int page, int pageSize)
        {
            var books = await _bookRepository.GetBooksAsync(search, sortBy, isDescending, page, pageSize);
            return books.Select(b => new BookDto
            {
                Title = b.Title,
                Price = b.Price,
                PublishedDate = b.PublishedDate,
                AuthorName = b.Author.Name
            }).ToList();
        }
    }
}
