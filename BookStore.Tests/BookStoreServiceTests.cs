using BookStore.Repository.Interfaces;
using BookStore.Service.BusinessLogic;
using BookStore.Tests.Mocks;

namespace BookStore.Tests
{
    [TestFixture]
    public class BookStoreServiceTests
    {
        private IBookRepository _mockRepository;
        private BookStoreService _bookStoreService;

        [SetUp]
        public void Setup()
        {
            // Configuração do repositório mockado para os testes
            _mockRepository = new MockBookRepository();
            _bookStoreService = new BookStoreService(_mockRepository);
        }

        [Test]
        public async Task SearchBooksAsync_WhenAuthorIsProvided_ReturnsMatchingBooks()
        {
            // Arrange
            string author = "J.K. Rowling";

            // Act
            var result = await _bookStoreService.SearchBooksAsync(author, null, null);

            // Assert
            Assert.IsNotNull(result);            
            foreach (var book in result)
            {
                Assert.AreEqual(author, book.LastName + " " + book.FirstName);
            }
        }

        [Test]
        public async Task SearchBooksAsync_WhenIsbnIsProvided_ReturnsMatchingBook()
        {
            // Arrange
            string isbn = "9780439554930";

            // Act
            var result = await _bookStoreService.SearchBooksAsync(null, isbn, null);

            // Assert
            Assert.IsNotNull(result);
            // Verifique se apenas um livro com o ISBN especificado é retornado
            var resultLBooks = result.ToList();
            Assert.AreEqual(1, resultLBooks.Count);
            Assert.AreEqual(isbn, resultLBooks.First().ISBN);
        }   
    }   
    
}


