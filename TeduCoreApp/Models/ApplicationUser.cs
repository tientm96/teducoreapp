using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TeduCoreApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class

        //vì ta đã custom lại thành AppUser cho đầy đủ thuộc tính nên gọi lại AppUser.
    public class ApplicationUser : IdentityUser
    {
    }
}
