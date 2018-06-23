using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    [Table("ProductQuantities")]
    public class ProductQuantity : DomainEntity<int>
    {
 
        [Column(Order = 1)]
        public int ProductId { get; set; }

        [Column(Order = 2)]
        public int SizeId { get; set; }


        [Column(Order = 3)]
        public int ColorId { get; set; }

        public int Quantity { get; set; }


        //tạo khóa ngoại: foreignkey này đc tham chiếu từ class Product, 
        //  nên phải qua Product xác nhận là có tham chiếu.
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        //tạo khóa ngoại: foreignkey này đc tham chiếu từ class Size, 
        //  nên phải qua Size xác nhận là có tham chiếu.
        [ForeignKey("SizeId")]
        public virtual Size Size { get; set; }

        //tạo khóa ngoại: foreignkey này đc tham chiếu từ class Color, 
        //  nên phải qua Color xác nhận là có tham chiếu.
        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }
    }
}
