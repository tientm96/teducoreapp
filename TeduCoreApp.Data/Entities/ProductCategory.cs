using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.Interfaces;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    [Table("ProductCategories")]
    public class ProductCategory : DomainEntity<int>,  //kế thừa Id từ abstract class
        IHasSeoMetaData, ISwitchable, ISortable, IDateTracking  //lấy các th.tính chung khác từ interface.
    {
        //Vì khóa ngoại (đc xác nhận ở dưới cùng) ban đầu sẽ null, nên khởi tạo cho nó để tránh lỗi.
        public ProductCategory()
        {
            Products = new List<Product>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }


        //implement from interface
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
        public string SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeywords { set; get; }
        public string SeoDescription { set; get; }


        //xác nhận khóa ngoại: xác nhận có foreignkey tham chiếu từ class này
        //  đến class Product và table Products trong db.
        public virtual ICollection<Product> Products { set; get; } 
    }
}