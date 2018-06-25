using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    [Table("ProductImages")]
    public class ProductImage : DomainEntity<int>
    {
        public int ProductId { get; set; }

        [StringLength(250)]
        public string Path { get; set; }

        [StringLength(250)]
        public string Caption { get; set; }

        
        //tạo khóa ngoại: foreignkey này đc tham chiếu từ class Product,
        //  nên phải qua Product xác nhận là có tham chiếu.
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}