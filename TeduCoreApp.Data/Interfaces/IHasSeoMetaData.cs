using System;
using System.Collections.Generic;
using System.Text;

namespace TeduCoreApp.Data.Interfaces
{
    public interface IHasSeoMetaData
    {
        string SeoPageTitle { set; get; } //tiêu đề trang seo
        string SeoAlias { set; get; }   //đường dẫn truyền sang html
        string SeoKeywords { set; get; }
        string SeoDescription { get; set; }
    }
}
