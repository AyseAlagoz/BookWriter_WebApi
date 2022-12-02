using System.ComponentModel.DataAnnotations;

namespace BookWriter.WebApi2.Models
{
    public class WriterModel
    {
        [Key]
        public int WriterId { get; set; }
        public string WriterName { get; set; }

        public ICollection<BookModel> BookModels { get; set; }
    }
}
