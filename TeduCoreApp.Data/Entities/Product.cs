using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.Interfaces;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    //gọi interface để lấy các thuộc tính dùng chung. Ở đây gán Id là int

    [Table("Products")] //gen ra table Products
    public class Product : DomainEntity<int>, ISwitchable, IDateTracking, IHasSeoMetaData
    {
        [StringLength(255)]
        [Required] //cần thiết, ko đc null
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [StringLength(255)] //ko có [Required] nên: có thể null
        public string Image { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        //Dấu ?: có thể null
        public decimal? PromotionPrice { get; set; }

        [Required]
        public decimal OriginalPrice { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(255)]
        public string Tags { get; set; }

        [StringLength(255)]
        public string Unit { get; set; }

        //tạo khóa ngoại. virtual vì entity sử dụng cơ chế Lazy loading chỉ chạy khi có virtual.
        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { set; get; }

        public string SeoPageTitle { set; get; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string SeoAlias { set; get; }

        [StringLength(255)]
        public string SeoKeywords { set; get; }

        [StringLength(255)]
        public string SeoDescription { set; get; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }

        public Status Status { set; get; }
    }
}