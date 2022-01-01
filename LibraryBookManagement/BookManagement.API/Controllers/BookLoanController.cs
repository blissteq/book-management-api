using BookManagement.Abstraction.Models;
using BookManagement.Abstraction.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookLoanController : ControllerBase
    {

        private readonly IBookLoanRepository _repository;


        public BookLoanController(IBookLoanRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookLoan>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BookLoan>>> GetBooks()
        {
            var loan = await _repository.GetLoans();
            return Ok(loan);
        }

        //[HttpGet("{id:length(24)}", Name = "GetBookLoan")]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //[ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<Book>> GetBookById(string id)
        //{
        //    var product = await _repository.;
        //    if (product == null)
        //    {

        //        return NotFound();
        //    }
        //    return Ok(product);
        //}

        [Route("loanbyname")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookByName(string bookName)
        {
            var bookLoans = await _repository.GetLoanByBook(bookName);
            return Ok(bookLoans);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Book>> CreateLoan([FromBody] BookLoan loan)
        {
            await _repository.BorrowBook(loan);

            return CreatedAtRoute("GetBook", new { id = loan.Id }, loan);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateLoan([FromBody] BookLoan loan)
        {
            return Ok(await _repository.UpdateLoan(loan));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteBookLoan")]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBookLoanById(string id)
        {
            return Ok(await _repository.DeleteLoan(id));
        }

    }
}
