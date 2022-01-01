using BookManagement.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Abstraction.Repositories
{
  public  interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(string id);
        Task<IEnumerable<Book>> GetBookByName(string name);
        Task<IEnumerable<Book>> GetBookByAuthor(string name);
        Task<IEnumerable<Book>> GetBookByRealeaseYear(int year);
        Task<IEnumerable<Book>> GetBookByCategory(string categoryName);

        Task CreateBook(Book book);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(string id);
    }
}
