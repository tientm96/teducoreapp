using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    [Table("WholePrices")]
    public class WholePrice : DomainEntity<int>
    {
        
        public int ProductId { get; set; }

        public int FromQuantity { get; set; }

        public int ToQuantity { get; set; }

        public decimal Price { get; set; }


        //tạo khóa ngoại: foreignkey này đc tham chiếu từ class Product, 
        //  nên phải qua Product xác nhận là có tham chiếu.
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
