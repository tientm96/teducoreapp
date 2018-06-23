using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TeduCoreApp.Data.Entities
{
    [Table("AppRoles")]
    public class AppRole : IdentityRole<Guid>   //Key hay Id của AppRole là Guid
    {
        //thuộc về Identity. Ta kế thừa 2 class của nó để tiện tùy chỉnh.
        //vậy nên phải Nuget: 	Microsoft.AspNetCore.Identity.EntityFrameworkCore

        public AppRole() : base()
        {

        }

        //thêm constructor mới, có description
        public AppRole(string name, string description) : base(name)
        {
            this.Description = description;
        }

        //thêm 4 thuộc tính cho user mà chúng ta nghĩ nó cần thiết
        [StringLength(250)]
        public string Description { get; set; }
    }
}
