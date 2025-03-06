using shorting_filtering_pagination.Models;

namespace shorting_filtering_pagination.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync(string? search, string? sortBy, bool isDescending, int page, int pageSize);
    }
}
