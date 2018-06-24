using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TeduCoreApp.Data.Entities;
using TeduCoreApp.Data.IRepositories;

namespace TeduCoreApp.Data.EF.Repositories
{
    public class ProductCategoryRepository : EFRepository<ProductCategory, int>, IProductCategoryRepository
    {
        AppDbContext _context;
        public ProductCategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductCategory> GetByAlias(string alias)
        {
            return _context.ProductCategories.Where(x => x.SeoAlias == alias).ToList();

            //Đọc bài sự SỰ KHÁC NHAU GIỮA IENUMERABLE VÀ IQUERYABLE trong file ctdlgt
            //ToList() thì nó mới thực sự đọc dl, excute câu query đấy vào trong db.
            //Còn nếu ko có ToList(), SingleDefaul()...: thì nó chưa lấy dl về  
        }

        //ProductCategoryRepository kế thừa EFRepository nên có đc các method của EFRepository,
        //  nhưng lại trùng với các method của IProductCategoryRepository, nên ko cần implement lại.
    }
}
