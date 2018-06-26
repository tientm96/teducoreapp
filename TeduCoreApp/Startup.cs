﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeduCoreApp.Data;
using TeduCoreApp.Models;
using TeduCoreApp.Services;
using TeduCoreApp.Data.EF;
using TeduCoreApp.Data.Entities;
using AutoMapper;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Data.EF.Repositories;
using TeduCoreApp.Data.IRepositories;
using TeduCoreApp.Application.Implementation;

namespace TeduCoreApp
{
    /*Cấu hình file statup, thay thế ApplicationDbContext mặc định thành AppDbContext của ta.
        Mục đích cấu hình để gen ra db đúng với custom của ta.

        -Sau khi cấu hình xong thì ta xóa folder Data (trong pr MVC) đc gen mặc định từ trước, với
        ApplicationDbContext
     */

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //thay vì dùng ApplicationDbContext tạo sẵn, ta dùng AppDbContext tự custom
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                o => o.MigrationsAssembly("TeduCoreApp.Data.EF")));
            //"DefaultConnection" lấy trong file appsetting.json, đã đc sửa lại.
            //add object o.MigrationsAssembly để tự động DbContext trong Assembly đấy.

            //cấu hình lại Identity
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Configure Identity: CẤU HÌNH USER, PASS CHO IDENTITY
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings //cấu hình cho password
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6; //pass: cho phép độ dài 6
                options.Password.RequireNonAlphanumeric = false; //ko yêu cầu ký tự đặc biệt
                options.Password.RequireUppercase = false; //lp yêu cầu hoa thường
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            //để sd đc dòng này cần add nuget: AutoMapper.Extensions.Microsoft.DependencyInjection
            services.AddAutoMapper(); 


            // Add application services.***
            
            //Nếu muốn tạo đc dữ liệu User và Role mẫu ở DbInitializer thì phải cấu hình ở đây.
            //Dùng AddScoped để giới hạn 1 request
            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

            //Cấu hình cho AUTOMAPPER (Nhớ NuGet AutoMapper ở pr này trước khi cấu hình)
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));


            services.AddTransient<IEmailSender, EmailSender>();

            /*Class DbInitializer dùng để khởi tạo một số dlieu để làm việc khi khởi tạo db.
             * Chúng ta cấu hình class này tại đây.
             *
             *  Ta sẽ gọi nó (DbInitializer) dưới cùng của method Configure() ở dưới, bằng
             *  cách đưa nó vào tham số của Configure()
             */
            //Add DbInitializer services
            services.AddTransient<DbInitializer>();


            //Phần ProductCategoryService trong pr Application muốn tự động chạy thì phải
            //  cấu hình trong file starup của pr MVC
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();//bật Authen để sử dụng Identity

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //Vì tự cấu hình Area nên phải qua starup này cấu hình 
                //  đường dẫn MẶC ĐỊNH cho area
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                //area: tên area đó  |  contrll mđ là Home  | Act mđ Index  | id dấu ? =  null Able.
            });


            //gọi đến hàm Seed() để tạo dữ liệu
            //dbInitializer.Seed().Wait();    //.Wait() gọi theo bất đồng bộ, nghĩa là đợi
            //vì bên method dbInitializer.Seed() cấu hình theo bất đồng bộ.
            //   Nghĩa là ĐỢI cho Task complete mới thực thi.

        }
    }
}


//NHỚ:
/*- Sửa ApplicationUser thành AppUser cho phù hợp với Identity đã custom

+ find trong file startup(MVC): chọn crrent Project và file All thì 
sẽ tìm ra 1 danh sách chứa nó. Dùng Ctrl+H để thay thế nhanh.
 */
