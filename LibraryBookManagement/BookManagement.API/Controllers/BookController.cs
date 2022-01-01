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
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;
       

        public BookController(IBookRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _repository.GetBooks();
            return Ok(books);
        }

        [HttpGet]
        [Route("getbookbyId")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Book>> GetBookById(string id)
        {
            var book = await _repository.GetBook(id);
            if (book== null)
            {
             
                return NotFound();
            }
            return Ok(book);
        }

        [Route("bookbycategory")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookByCategory(string category)
        {
            var books = await _repository.GetBookByCategory(category);
            return Ok(books);
        }

        [Route("bookbyname")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookByName(string name)
        {
            var books = await _repository.GetBookByName(name);
            return Ok(books);
        }
        [Route("bookbyauthor")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookByAuthor(string author)
        {
            var books = await _repository.GetBookByAuthor(author);
            return Ok(books);
        }

        [Route("bookbypublishyear")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookByYear(int year)
        {
            var books = await _repository.GetBookByRealeaseYear(year);
            return Ok(books);
        }




        [HttpPost]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Book>> CreateBook([FromBody] Book book)
        {
            await _repository.CreateBook(book);

            return Ok(book);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBook([FromBody] Book product)
        {
            return Ok(await _repository.UpdateBook(product));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _repository.DeleteBook (id));
        }


    }
}
