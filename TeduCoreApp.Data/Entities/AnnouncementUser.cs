using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    [Table("AnnouncementUsers")]
    public class AnnouncementUser : DomainEntity<int>
    {
        [StringLength(128)]
        [Required]
        [Column(TypeName = "varchar(128)")]//khẳng định nó là varchar. Nếu ko thì gen ra có thể là nvarchar
        public string AnnouncementId { get; set; }

        public Guid UserId { get; set; }

        public bool? HasRead { get; set; }

        //tạo khóa ngoại: foreignkey này đc tham chiếu từ Announcement,
        //  nên phải qua Announcement xác nhận là có tham chiếu.
        [ForeignKey("AnnouncementId")]
        public virtual Announcement Announcement { get; set; }
    }
}