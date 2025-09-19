using LibraryManagement.Data;
using LibraryManagement.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext dbContext;  //field to hld dbcntxt

        //cntrlr can acss db
        public BooksController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var allbooks = dbContext.Books.ToList();
            return Ok(allbooks);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBooksById(int id)
        {
            var book = dbContext.Books.Find(id);
            if (book == null)
                return NotFound(new { Message = "Book not found" });

            return Ok(book);
        }

        [HttpGet("search")]
        public IActionResult SearchBooksByAuthor(string author)
        {
            var books = dbContext.Books
                .Where(b => b.Author.Contains(author))
                .ToList();
            return Ok(books);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        { 
            //check for unique SBIN
            var existingBook = dbContext.Books.FirstOrDefault(b => b.ISBN == book.ISBN);
            if (existingBook != null)
            {
                return BadRequest(new { Message = "ISBN already exists." });
            }

            dbContext.Books.Add(book);
            dbContext.SaveChanges();
            return Ok(new { Message = "Books added", Data = book });
        }

        [HttpPut]
        [Route("{id}")]

        public IActionResult UpdatedBook(int id, [FromBody] Book UpdatedBook)
        {
            var book = dbContext.Books.Find(id);

            if (book == null)
                return NotFound(new { Message = "Book not found" });

            var duplicateIsbn = dbContext.Books
        .   FirstOrDefault(b => b.ISBN == UpdatedBook.ISBN && b.Id != id); //check for same isbn by their id

            if (duplicateIsbn != null)
            {
                return BadRequest(new { Message = "ISBN already exists. Existing ISBN cannot be added." });
            }

            book.Title = UpdatedBook.Title;
            book.Author = UpdatedBook.Author;
            book.ISBN = UpdatedBook.ISBN;
            book.Price = UpdatedBook.Price;
            book.PublishedDate = UpdatedBook.PublishedDate;
            dbContext.SaveChanges();
            return Ok(new { Message = "Book updated", Data = book });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var book =dbContext.Books.Find(id);

            if (book == null)
                return NotFound(new { Message = "No Books To Delete" });

            dbContext.Books.Remove(book);
            dbContext.SaveChanges();
            return Ok(new { Message = "employee deleted", Data = book });
        }






    }
}

