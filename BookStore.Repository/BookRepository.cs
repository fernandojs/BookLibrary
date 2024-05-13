using BookStore.Domain.Models;
using BookStore.Repository.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace BookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly string connectionString;

        public BookRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<Book> AddBookAsync(string author, string isbn, string status)
        {
            //Todo need implementation to add to database
            return new Book() { FirstName =  author, ISBN = isbn, Status = status };
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string author, string isbn, string status)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"
                SELECT book_id as bookid, title, first_name as firstname, last_name as lastname, total_copies as totalcopies, copies_in_use as copiesinuse, type, isbn, category, status
                FROM Books
                WHERE (@Author IS NULL OR (first_Name + ' ' + last_name) LIKE '%' + @Author + '%')
                AND (@ISBN IS NULL OR ISBN LIKE '%' + @ISBN + '%')
                AND (@Status IS NULL OR Status = @Status);
            ";
                return await connection.QueryAsync<Book>(query, new { Author = author, ISBN = isbn, Status = status });
            }
        }
    }
}
