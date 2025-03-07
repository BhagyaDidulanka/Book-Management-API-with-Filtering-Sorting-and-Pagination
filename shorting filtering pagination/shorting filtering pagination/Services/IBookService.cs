using shorting_filtering_pagination.DTOs;


namespace shorting_filtering_pagination.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync(string? search, string? sortBy, bool isDescending, int page, int pageSize);
    }
}
