using Microsoft.EntityFrameworkCore;
using shorting_filtering_pagination.Data;
using shorting_filtering_pagination.Models;

namespace shorting_filtering_pagination.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(string? search, string? sortBy, bool isDescending, int page, int pageSize)
        {
            var query = _context.Books.Include(b => b.Author).AsQueryable();

            // Filtering
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(b => b.Title.Contains(search) || b.Author.Name.Contains(search));
            }

            // Sorting
            query = sortBy switch
            {
                "title" => isDescending ? query.OrderByDescending(b => b.Title) : query.OrderBy(b => b.Title),
                "price" => isDescending ? query.OrderByDescending(b => b.Price) : query.OrderBy(b => b.Price),
                "date" => isDescending ? query.OrderByDescending(b => b.PublishedDate) : query.OrderBy(b => b.PublishedDate),
                _ => query
            };

            // Pagination
            return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
