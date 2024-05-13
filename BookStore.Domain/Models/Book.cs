namespace BookStore.Domain.Models
{
    public class Book
    {
        public Book() { 
        }
        public string Title { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int TotalCopies { get; set; }
        public int CopiesInUse { get; set; }
        public string Type { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

    }
}
