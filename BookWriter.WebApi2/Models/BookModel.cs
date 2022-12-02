using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWriter.WebApi2.Models
{
    public class BookModel
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }

        [ForeignKey("WriterModel")]
        public int WriterId { get; set; }

        public virtual WriterModel WriterModel { get; set; }
    }
}
