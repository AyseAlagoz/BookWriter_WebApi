using BookWriter.WebApi2.Db;
using BookWriter.WebApi2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization.Metadata;

namespace BookWriter.WebApi2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly BWDbContext dbContext;
        public BookController(BWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookModel addBookModel)
        {
            var book = new BookModel()
            {
                BookName = addBookModel.BookName,
                WriterId = addBookModel.WriterId,
            };
            await dbContext.BookModels.AddAsync(book);
            await dbContext.SaveChangesAsync();

            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> getBooks()
        {
            return Ok(await dbContext.BookModels.ToListAsync());
        }

        [HttpGet]
        [Route("{WriterId}")]
        public async Task<IActionResult> getWriter([FromRoute] int WriterId)
        {
            var deneme = await dbContext.WriterModels.FindAsync(WriterId);
            if (deneme != null)
            {
                var writer = await dbContext.BookModels.Where(b => b.WriterId == WriterId).ToListAsync();
                if (writer != null)
                {
                    return Ok(writer);
                }
            }
            return NotFound();
        }

        [HttpPut]
        [Route("{BookId}")]
        public async Task<IActionResult> updateBook([FromRoute] int BookId, AddBookModel addBookModel)
        {
            var book = await dbContext.BookModels.FindAsync(BookId);
            if (book != null)
            {
                book.BookName = addBookModel.BookName;
                book.WriterId = addBookModel.WriterId;

                await dbContext.SaveChangesAsync();
                return Ok(book);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{BookId}")]
        public async Task<IActionResult> deleteBook([FromRoute] int BookId)
        {
            var book = await dbContext.BookModels.FindAsync(BookId);
            if (book != null)
            {
                dbContext.Remove(book);
                await dbContext.SaveChangesAsync();
                return Ok(book);
            }
            return NotFound();
        }

    }
}
