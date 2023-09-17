using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseMusaBlog.WebUI.Models
{
    public class GetCategoryByBlogs
    {
        public string CategoryName { get; set; }
        public int BlogCount { get; set; }
    }
}