using Microsoft.AspNetCore.Mvc;

/*
-Tạo kiến trúc area(trong core ko có sẵn như mvc5, phải tự tạo kiến trúc)
+Kích phải prMVC, create folder Areas
+bên trong folder Areas tạo folder Admin
+trong fd Admin tự tạo tổ hợp MVC bằng các folder.

+**Tạo controller Home chẳng hạn. Nhưng phải cấu hình area cho nó bằng cách
    thêm [Area("Admin")] vào đầu controller đó.
+**Sau đó vào file Startup cấu hình phần UseMVC ở dưới cùng,
    để cấu hình đường dẫn mặc định cho are Admin.
+Kích phải vào index để add view, view index sẽ tự động đc tạo trong
    folder view của Admin.

-Gọi đến Admin: // GET: /Admin/Home/Index hoặc chỉ /Admin là nó tự tới
    Index của Home vì đã cài mặc định

 */

namespace TeduCoreApp.Areas.Controllers
{
    [Area("Admin")] //cấu hình controller thuộc Area Admin
    //Sau đó vào file Startup cấu hình phần UseMVC ở dưới cùng, để cấu hình
    // đường dẫn mặc định cho Admin.
    public class HomeController : Controller
    {
        // GET: /Admin/Home/Index
        public IActionResult Index()
        {
            return View();
        }
    }
}