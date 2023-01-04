using System.ComponentModel.DataAnnotations;

namespace ProniaTask.Models
{
    public class Color
    {
        public int Id { get; set; }
        [StringLength(20), Required]
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
