using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    [Table("Permissions")]
    public class Permission : DomainEntity<int>//Id sẽ là int
    {
        //Những thuộc tính trỏ đến class AppRole và class Funtion,
        //  chỉ ra role này funtion này đc quyền đọc, ghi, sửa xóa gì đấy.

        //Vì đến AppRole, sd Identity nên dùng Guid để Identity tự lo độ dài.
        //  ko cần [Required], [StringLength(250)], [Column(TypeName = "varchar(250)")].
        //Như vậy ko cần phải có AppUserConfiguration như các class khác.
        [Required]
        public Guid RoleId { get; set; }

        [StringLength(128)]
        [Column(TypeName = "varchar(128)")]//khẳng định nó là varchar. Nếu ko thì gen ra có thể là nvarchar
        [Required]
        public string FunctionId { get; set; }

        public bool CanCreate { set; get; }
        public bool CanRead { set; get; }

        public bool CanUpdate { set; get; }
        public bool CanDelete { set; get; }


        //tạo khóa ngoại: foreignkey này đc tham chiếu từ class AppRole,
        //  nên phải qua AppRole xác nhận là có tham chiếu.
        [ForeignKey("RoleId")]
        public virtual AppRole AppRole { get; set; }

        //tạo khóa ngoại: foreignkey này đc tham chiếu từ class Function,
        //  nên phải qua Function xác nhận là có tham chiếu.
        [ForeignKey("FunctionId")]
        public virtual Function Function { get; set; }
    }
}