using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    [Table("AdvertistmentPages")]
    public class AdvertistmentPage : DomainEntity<string>
    //Cũng như Tag.cs, kế thừa id, nhưng là string. Cũng dùng chung 1 file cấu
    //  hình TagConfiguration ở prj EF để cấu hình cho đúng kiểu varchar(50).  
    {
        public string Name { get; set; }


        //xác nhận khóa ngoại: xác nhận có foreignkey tham chiếu từ class NÀY, 
        // đến class AdvertistmentPosition và table AdvertistmentPositions trong db.
        public virtual ICollection<AdvertistmentPosition> AdvertistmentPositions { get; set; }
    }
}
