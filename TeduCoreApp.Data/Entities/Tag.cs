using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    public class Tag : DomainEntity<string>//kế thừa id, và id lúc này là string
    {   //nhưng ko thể cấu hình nó là varchar[n] hay nvarchar[n], vì ở đây ko gọi nó ra tr.tiep.
        //Lúc này cần dùng đến TagConfiguration ở prj EF để cấu hình
        //    để cho nó đúng 1 kiểu csdl là varchar khi gen ra trong csdl.

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }

        //tự thêm-------------------------------------------
        //Xác nhận khóa ngoại tham chiếu từ lớp này đến class BlogTag
        public virtual ICollection<BlogTag> BlogTags { set; get; }

        //Xác nhận khóa ngoại tham chiếu từ lớp này đến class ProductTag
        public virtual ICollection<ProductTag> ProductTags { set; get; }
    }
}