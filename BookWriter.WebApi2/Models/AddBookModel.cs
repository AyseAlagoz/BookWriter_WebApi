using System.ComponentModel.DataAnnotations.Schema;

namespace BookWriter.WebApi2.Models
{
    public class AddBookModel
    {
        public string BookName { get; set; }
        public int WriterId { get; set; }

    }
}
