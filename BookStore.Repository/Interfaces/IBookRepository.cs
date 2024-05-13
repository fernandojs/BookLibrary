﻿using BookStore.Domain.Models;
namespace BookStore.Repository.Interfaces
{
    public interface IBookRepository
    {        
        Task<IEnumerable<Book>> SearchBooksAsync(string? author = null, string? isbn = null, string? status = null);
    }
}
