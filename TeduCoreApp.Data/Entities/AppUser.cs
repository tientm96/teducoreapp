using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.Interfaces;

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

        //--------------------tự thêm
        //xác nhận khóa ngoại: xác nhận có foreignkey tham chiếu từ class NÀY,
        // đến class Announcement và table Announcements trong db.
        public virtual ICollection<Announcement> Announcements { get; set; }

        //xác nhận khóa ngoại tham chiếu đến class AnnouncementUser.
        public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }

        //xác nhận khóa ngoại tham chiếu đến class Bill.
        public virtual ICollection<Bill> Bills { get; set; }
    }
}