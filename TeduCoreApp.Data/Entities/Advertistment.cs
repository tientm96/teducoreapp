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
    [Table("Advertistments")]
    public class Advertistment : DomainEntity<int>, //kế thừa id từ abstrach và gán nó dùng int
        ISwitchable, ISortable, IDateTracking   //lấy các thuộc tính chung khác
    {
        [StringLength(250)]
        public string Name { get; set; }    //string mà ko [Required]: có thể null

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        [StringLength(20)]
        public string PositionId { get; set; }



        //implement from interfaces
        public Status Status { set; get; }
        public int SortOrder { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }


        //tạo khóa ngoại. virtual vì entity sử dụng cơ chế Lazy loading chỉ chạy khi có virtual.
        //  foreignkey này đc tham chiếu từ class AdvertistmentPosition.
        [ForeignKey("PositionId")]
        public virtual AdvertistmentPosition AdvertistmentPosition { get; set; }
    }
}
