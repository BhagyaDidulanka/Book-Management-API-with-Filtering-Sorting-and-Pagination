namespace shorting_filtering_pagination.DTOs
{
    public class BookDto
    {
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public string AuthorName { get; set; } = string.Empty;
    }
}
