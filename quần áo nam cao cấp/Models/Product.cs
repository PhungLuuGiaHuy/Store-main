using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quần_áo_nam_cao_cấp.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ProductId")]
        public int ProductId { get; set; }

        [Column("ProductName", TypeName = "nvarchar(50)")]
        public string ProductName { get; set; }

        [Column("ProductSize", TypeName = "char(5)")]
        public string ProductSize { get; set; }

        [Column("CategoryId", TypeName = "int")]
        public string CategoryId { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }

        [Column("Image", TypeName = "varchar(50)")]
        public string Image { get; set; }

        [Column("Description", TypeName = "nvarchar")]
        public string Description { get; set; }

        [Column("DateCapNhat", TypeName = "datetime")]
        public int DateCapNhat { get; set; }
    }
}