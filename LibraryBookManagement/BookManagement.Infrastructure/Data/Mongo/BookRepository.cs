using BookManagement.Abstraction;
using BookManagement.Abstraction.Models;
using BookManagement.Abstraction.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Infrastructure.Data.Mongo
{
    public class BookRepository : IBookRepository
    {
        private readonly MongoContext _context;
        public BookRepository(IOptions<AppSettings> config)
        {
            _context = new MongoContext(config);
        }


        public async Task CreateBook(Book book)
        {
            await _context.Books.InsertOneAsync(book);
        }

        public async Task<bool> DeleteBook(string id)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Books
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<Book> GetBook(string id)
        {
            return await _context
                     .Books
                     .Find(p => p.Id == id)
                     .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetBookByAuthor(string author)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(p => p.AuthorName, author);

            return await _context
                            .Books
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBookByCategory(string categoryName)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(p => p.Category, categoryName);

            return await _context
                            .Books
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBookByName(string name)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(p => p.Name, name);

            return await _context
                            .Books
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBookByRealeaseYear(int year)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(p => p.PublishYear, year);

            return await _context
                            .Books
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context
                            .Books
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<bool> UpdateBook(Book book)
        {
            var updateResult = await _context
                                .Books
                                .ReplaceOneAsync(filter: g => g.Id == book.Id, replacement: book);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
