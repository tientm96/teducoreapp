using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeduCoreApp.Data.EF.Extensions
{
    //Extension method: xem lý thuyết trong csdl.
    //  là class add thêm method cho class khác. phải có static ở class này và method add.
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(   //AddConfiguration: là method add thêm cho class ModelBuilder.
          this ModelBuilder modelBuilder,//ModelBuilder,DbEntityConfiguration: là các class đc add thêm method AddConfiguration.
          DbEntityConfiguration<TEntity> entityConfiguration) where TEntity : class
        {
            //truyền vào DbEntityConfiguration và add nó bằng modelBuilder
            modelBuilder.Entity<TEntity>(entityConfiguration.Configure);
        }
    }

    public abstract class DbEntityConfiguration<TEntity> where TEntity : class
    {
        //thuộc tính Config để đẩy entity vào.
        public abstract void Configure(EntityTypeBuilder<TEntity> entity);
    }
}


//NHƯ VẬY, để config đến folder Entities của prj Data, và nếu ko config đc với notation 
//  thì sẽ config tới Refference API;
//HAY nói cách khác là CONFIGURATION: dùng để config cho các bảng mà ko thao tác 
//  đc với Id(Id là string mà kế thừa từ DomainEntity trong SharedKernel của pr Infrastructure), 
//  không thể cấu hình cụ thể cho Id khi gen xuống.

// LÚC TA CONFIGURATION (các class trong folder Configuration của pr EF) chỉ cần gọi đến
//  Extension này thì có thể sử dụng DbEntityConfiguration.