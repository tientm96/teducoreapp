using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    [Table("Colors")]
    public class Color : DomainEntity<int>
    {
        [StringLength(250)]
        public string Name
        {
            get; set;
        }

        [StringLength(250)]
        public string Code { get; set; }

        //Xác  nhận khóa ngoại tham chiếu từ lớp này đến class BillDetail
        public virtual ICollection<BillDetail> BillDetails { set; get; }

        //Xác  nhận khóa ngoại tham chiếu từ lớp này đến class ProductQuantity
        public virtual ICollection<ProductQuantity> ProductQuantitys { set; get; }
    }
}