using System.ComponentModel.DataAnnotations;

namespace ProniaTask.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [StringLength(100),Required]
        public string ImageUrl { get; set; }
    }
}
