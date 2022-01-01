using BookManagement.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Abstraction.Repositories
{
 public   interface IBookLoanRepository
    {
        Task BorrowBook(BookLoan loan);

        Task<bool> ReturnBook(Book book);
        Task<bool> UpdateLoan(BookLoan book);
        Task<bool> DeleteLoan(string id);

        Task<IEnumerable<BookLoan>> GetLoans();

        Task<IEnumerable<BookLoan>> GetLoanByReader(string reader);
        Task<IEnumerable<BookLoan>> GetLoanByBook(string bookName);
    }
}
