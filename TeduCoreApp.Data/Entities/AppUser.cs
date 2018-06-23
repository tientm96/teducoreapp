using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TeduCoreApp.Data.Interfaces;
using TeduCoreApp.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduCoreApp.Data.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>, //Key hay Id của AppUser là Guid
        IDateTracking, ISwitchable  //các Interface cần kế thừa.
    {
        //thuộc về Identity. Ta kế thừa 2 class của nó để tiện tùy chỉnh.
        //vậy nên phải Nuget: 	Microsoft.AspNetCore.Identity.EntityFrameworkCore

        //thêm 4 thuộc tính cho user mà chúng ta nghĩ nó cần thiết
        public string FullName { get; set; }

        public DateTime? BirthDay { set; get; }

        public decimal Balance { get; set; }

        public string Avatar { get; set; }


        //implement method from Interface
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; }
    }
}
