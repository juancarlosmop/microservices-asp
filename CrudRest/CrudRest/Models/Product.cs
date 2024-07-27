using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudRest.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("product_name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("price", TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
