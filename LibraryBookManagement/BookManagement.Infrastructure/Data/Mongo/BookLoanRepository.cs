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
  public  class BookLoanRepository : IBookLoanRepository
    {
        private readonly MongoContext _context;
        public BookLoanRepository(IOptions<AppSettings> config)
        {
            _context = new MongoContext(config);
        }
        public  async Task BorrowBook(BookLoan loan)
        {
            await _context.Loans.InsertOneAsync(loan);
        }

        public async Task<bool> DeleteLoan(string id)
        {
            FilterDefinition<BookLoan> filter = Builders<BookLoan>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Loans
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<BookLoan>> GetLoanByBook(string bookId)
        {
            FilterDefinition<BookLoan> filter = Builders<BookLoan>.Filter.Eq(p => p.BookId, bookId);

            return await _context
                            .Loans
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<BookLoan>> GetLoanByReader(string reader)
        {
            FilterDefinition<BookLoan> filter = Builders<BookLoan>.Filter.Eq(p => p.ReaderName, reader);

            return await _context
                            .Loans
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<BookLoan>> GetLoans()
        {
            return await _context
                             .Loans
                             .Find(p => true)
                             .ToListAsync();
        }

        public Task<bool> ReturnBook(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateLoan(BookLoan book)
        {
            var updateResult = await _context
                              .Loans
                              .ReplaceOneAsync(filter: g => g.Id == book.Id, replacement: book);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
