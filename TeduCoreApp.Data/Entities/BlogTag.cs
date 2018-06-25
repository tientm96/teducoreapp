using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    [Table("BlogTags")]
    public class BlogTag : DomainEntity<int>
    {
        public int BlogId { set; get; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string TagId { set; get; }


        //tạo khóa ngoại: foreignkey này đc tham chiếu từ class Blog,
        //  nên phải qua Blog xác nhận là có tham chiếu.
        [ForeignKey("BlogId")]
        public virtual Blog Blog { set; get; }


        
        //tạo khóa ngoại: foreignkey này đc tham chiếu từ class Tag,
        //  nên phải qua Tag xác nhận là có tham chiếu.
        [ForeignKey("TagId")]
        public virtual Tag Tag { set; get; }
    }
}
