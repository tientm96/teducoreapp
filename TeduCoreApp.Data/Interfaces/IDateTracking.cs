using System;
using System.Collections.Generic;
using System.Text;

//danh sách các interface dùng chung.

namespace TeduCoreApp.Data.Interfaces
{
    public interface IDateTracking
    {
        //interface ko dùng tiền tố

        DateTime DateCreated { set; get; }

        DateTime DateModified { set; get; }
    }
}
