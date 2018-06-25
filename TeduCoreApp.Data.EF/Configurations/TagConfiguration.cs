using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeduCoreApp.Data.EF.Extensions;
using TeduCoreApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TeduCoreApp.Data.EF.Configurations
{
    /// <summary>
    /// CONFIGURATION: dùng để config cho các bảng mà ko thao tác đc với  Id, không thể
    /// cấu hình cụ thể cho Id khi gen xuống.
    /// 
    /// Class DbEntityConfiguration đc extension thêm method Configure để hỗ trợ cho các 
    /// class trong folder Configurations này.
    /// (Xem Extension method tại class ModelBuilderExtensions trong folder Extensions.)
    /// 
    /// Các Configuration này sẽ auto config khi ta gọi nó trong dbContext.
    /// </summary>
    /// 

    public class TagConfiguration : DbEntityConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(50)
                .IsRequired().HasColumnType("varchar(50)");//Cấu hình để Id của Tag có kdl 
              //=true: ko đc null                         //varchar(50)
        }
    }

}
