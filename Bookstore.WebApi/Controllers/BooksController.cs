using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bookstore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Bookscontroller : ControllerBase
    {

        private readonly IBookServices _bookServices;
        public Bookscontroller(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_bookServices.GetBooks());
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookServices.AddBook(book);
            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }


        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(string id)
        {
            return Ok(_bookServices.GetBook(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(string id)
        {
            _bookServices.DeleteBook(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            return Ok(_bookServices.UpdateBook(book));
        }


    }
}
