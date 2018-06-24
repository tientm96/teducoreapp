using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TeduCoreApp.Application.ViewModels.Product;
using TeduCoreApp.Data.Entities;

namespace TeduCoreApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile //kế thừa Profile của NuGet:AutoMapper
    {
        //
        public DomainToViewModelMappingProfile()
        {
            //CreateMap từ ProductCategory sang ProductCategoryViewModel.
            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
    }
}
