using System.ComponentModel.DataAnnotations;

namespace ProniaTask.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(20), Required]
        public string Name { get; set; }

        [StringLength(100), Required]
        public string ImageUrl { get; set; }

        [Range(0,1000), Required]
        public double Price { get; set; }

        [StringLength(500), Required]
        public string Desc { get; set; }

        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int CategoryId { get; set; }
        public Size? Size { get; set; }
        public Category? Category { get; set; }
        public Color? Color { get; set; }
    }
}
