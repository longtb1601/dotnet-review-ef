using System;
using System.Collections.Generic;
using Library_System.Models;
using Library_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("/authors")]
        public List<Author> GetAll()
        {
            return _authorService.GetAll();
        }

        [HttpGet("/author/{id}")]
        public ActionResult<Author> GetOne(int id)
        {
            return _authorService.GetOne(id);
        }

        [HttpPost("/author")]
        public Author Create(AuthorDTO author)
        {
            return _authorService.Create(author);
        }

        [HttpPut("/author")]
        public Author Update(AuthorDTO author)
        {
            return _authorService.Update(author);
        }

        [HttpDelete("/author/{id}")]
        public IActionResult Delete(int id)
        {
            var authorDelete = _authorService.GetOne(id);

            if(authorDelete == null)
            {
                return NotFound();
            }

            try
            {
                _authorService.Delete(authorDelete);

                return Ok();

            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}