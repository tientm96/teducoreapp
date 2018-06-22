using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
    public class Tag : DomainEntity<string> //kế thừa lấy id, và id lúc này là string
    {                               //nhưng ko thể cấu hình nó là varchar[n] hay nvarchar[n]
                                    //Lúc này cần dùng đến TagConfiguration ở prj EF để cấu hình.
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }
    }
}
