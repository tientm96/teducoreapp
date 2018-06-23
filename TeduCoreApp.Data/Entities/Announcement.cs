using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.Interfaces;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    [Table("Announcements")]
    public class Announcement : DomainEntity<string>,//Cũng như Tag.cs, kế thừa id, nhưng là string. Cũng dùng chung 1 file cấu
                                                    //  hình TagConfiguration ở prj EF để cấu hình cho đúng kiểu varchar(50).  
        ISwitchable, IDateTracking  //Ghi đè lại các thuộc tính chung từ các Interface.
    {
        //Vì khóa ngoại (đc xác nhận ở dưới cùng) ban đầu sẽ null, 
        //  nên khởi tạo cho nó để tránh lỗi.
        public Announcement()
        {
            AnnouncementUsers = new List<AnnouncementUser>();
        }

        [Required]
        [StringLength(250)]
        public string Title { set; get; }

        [StringLength(250)]
        public string Content { set; get; }

        [StringLength(450)]
        public string UserId { set; get; }

        //tạo khóa ngoại.(virtual vì entity sử dụng cơ chế Lazy loading chỉ chạy khi có virtual).
        //  foreignkey này đc tham chiếu từ AppUser, 
        //  nên phải qua AppUser xác nhận là có tham chiếu.
        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }


        //TỚI ĐÂY PHẢI QUA BÊN AppUser XÁC NHẬN


        //xác nhận khóa ngoại: xác nhận có foreignkey tham chiếu từ class NÀY, 
        // đến class AnnouncementUser và table AnnouncementUsers trong db.
        public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }


        //implement from interfaces
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public Status Status { set; get; }
    }
}
