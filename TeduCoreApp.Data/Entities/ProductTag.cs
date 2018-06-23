using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    public class ProductTag : DomainEntity<int> //chỉ dùng chung 1 Id, Id kiểu int
    {                     //không dùng các thuộc tính chung, nên ko kế thừa các Interface.

        public int ProductId { get; set; }

        //varchar[50] trong sql
        [StringLength(50)]
        [Column(TypeName = "varchar")] //khẳng định nó là varchar. Nếu ko thì gen ra có thể là nvarchar
        public string TagId { set; get; }

        //tạo khóa ngoại
        [ForeignKey("ProductId")]
        public virtual Product Product { set; get; }

        //tạo khóa ngoại
        [ForeignKey("TagId")]
        public virtual Tag Tag { set; get; }
    }
}
