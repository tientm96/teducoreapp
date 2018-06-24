using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeduCoreApp.Application.AutoMapper
{
    //trước khi dùng automapper thì phải NuGet: AutoMapper, lúc đó kế thừa đc class Profile

    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            //gọi 2 profile này vào. trả về đối tượng MapperConfiguration
            return new MapperConfiguration(cfg =>   //truyền vào đối tượng config
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
