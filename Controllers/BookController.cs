using System;
using System.Collections.Generic;
using Library_System.Models;
using Library_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("/books")]
        public List<Book> GetAll()
        {
            return _bookService.GetAll();
        }

        [HttpGet("/book/{id}")]
        public ActionResult<Book> GetOne(int id)
        {
            return _bookService.GetOne(id);
        }

        [HttpPost("/book")]
        public Book Create(BookDTO book)
        {
            return _bookService.Create(book);
        }

        [HttpPut("/book")]
        public Book Update(BookDTO book)
        {
            return _bookService.Update(book);
        }

        [HttpDelete("/book/{id}")]
        public IActionResult Delete(int id)
        {
            var bookDelete = _bookService.GetOne(id);

            if(bookDelete == null)
            {
                return NotFound();
            }

            try
            {
                _bookService.Delete(bookDelete);

                return Ok();

            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}