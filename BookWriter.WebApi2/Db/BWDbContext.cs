using BookWriter.WebApi2.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWriter.WebApi2.Db
{
    public class BWDbContext : DbContext
    {
        public BWDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BookModel> BookModels { get; set; }
        public DbSet<WriterModel> WriterModels { get; set; }
    }
}
