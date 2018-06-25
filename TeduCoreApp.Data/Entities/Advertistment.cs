using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.Interfaces;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    [Table("Advertistments")]
    public class Advertistment : DomainEntity<int>, //kế thừa id từ abstrach và gán nó dùng int
        ISwitchable, ISortable      //lấy các thuộc tính chung khác (thiếu IDateTracking)
    {
        [StringLength(250)]
        public string Name { get; set; } //string mà ko [Required]: có thể null

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]//khẳng định nó là varchar. Nếu ko thì gen ra có thể là nvarchar
        public string PositionId { get; set; }

        //implement from interfaces
        public Status Status { set; get; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public int SortOrder { set; get; }

        //tạo khóa ngoại. virtual vì entity sử dụng cơ chế Lazy loading chỉ chạy khi có virtual.
        //  foreignkey này đc tham chiếu từ class AdvertistmentPosition.
        //  nên phải qua AdvertistmentPosition xác nhận là có tham chiếu.
        [ForeignKey("PositionId")]
        public virtual AdvertistmentPosition AdvertistmentPosition { get; set; }
    }
}