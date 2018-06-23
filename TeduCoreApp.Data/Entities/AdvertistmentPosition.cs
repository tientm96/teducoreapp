using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    [Table("AdvertistmentPositions")]
    public class AdvertistmentPosition : DomainEntity<string>
    //Cũng như Tag.cs, kế thừa id, nhưng là string. Cũng dùng chung 1 file cấu
    //  hình TagConfiguration ở prj EF để cấu hình cho đúng kiểu varchar(50).  
    {
        [StringLength(20)]
        public string PageId { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        //tạo khóa ngoại. virtual vì entity sử dụng cơ chế Lazy loading chỉ chạy khi có virtual.
        //  foreignkey này đc tham chiếu từ AdvertistmentPage, 
        //  nên phải qua AdvertistmentPage xác nhận là có tham chiếu.
        [ForeignKey("PageId")]
        public virtual AdvertistmentPage AdvertistmentPage { get; set; }


        //xác nhận khóa ngoại: xác nhận có foreignkey tham chiếu từ class này 
        //tại class Advertistment và table Advertistments trong db.
        public virtual ICollection<Advertistment> Advertistments { get; set; }
    }
}
