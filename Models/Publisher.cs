using System.ComponentModel.DataAnnotations;

namespace Ghiriti_Edmond_Lab2.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        [Display(Name = "Publisher's name")]
        public string PublisherName { get; set; }
        public ICollection<Book>? Books { get; set; } //navigation property
    }
}
