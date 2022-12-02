using BookWriter.WebApi2.Db;
using BookWriter.WebApi2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWriter.WebApi2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WriterController : Controller
    {
        private readonly BWDbContext dbContext;
        public WriterController(BWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddWriter(AddWriterModel addWriterModel)
        {
            var writer = new WriterModel()
            {
                WriterName = addWriterModel.WriterName,
            };
            await dbContext.WriterModels.AddAsync(writer);
            await dbContext.SaveChangesAsync();

            return Ok(writer);
        }

        [HttpGet]
        public async Task<IActionResult> getWriters()
        {
            return Ok(await dbContext.WriterModels.ToListAsync());
        }

        [HttpPut]
        [Route("{WriterId}")]
        public async Task<IActionResult> updateWriter([FromRoute] int WriterId, AddWriterModel addWriterModel)
        {
            var writer = await dbContext.WriterModels.FindAsync(WriterId);
            if (writer != null)
            {
                writer.WriterName = addWriterModel.WriterName;

                await dbContext.SaveChangesAsync();
                return Ok(writer);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{WriterId}")]
        public async Task<IActionResult> deleteWriter([FromRoute] int WriterId)
        {
            var writer = await dbContext.WriterModels.FindAsync(WriterId);
            if (writer != null)
            {
                dbContext.Remove(writer);
                await dbContext.SaveChangesAsync();
                return Ok(writer);
            }
            return NotFound();
        }

    }
}
