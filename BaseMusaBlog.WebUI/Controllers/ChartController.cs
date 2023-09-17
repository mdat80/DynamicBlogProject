using BaseMusaBlog.DataAccessLayer.Contexts;
using BaseMusaBlog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseMusaBlog.WebUI.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // Statik Chart Getirme İşlemi
        public ActionResult VisualizeResult()
        {
            return Json(categorlist(),JsonRequestBehavior.AllowGet);
        }

        public List<GetCategoryByBlogs> categorlist()
        {
            List<GetCategoryByBlogs> c = new List<GetCategoryByBlogs>();
            c.Add(new GetCategoryByBlogs()
            {
                CategoryName = "C#",
                BlogCount=13,
            });
            c.Add(new GetCategoryByBlogs()
            {
                CategoryName = "Javascript",
                BlogCount = 6,
            });
            c.Add(new GetCategoryByBlogs()
            {
                CategoryName = "Asp.Net Core",
                BlogCount = 6,
            });
            c.Add(new GetCategoryByBlogs()
            {
                CategoryName = "Asp.Net Core WebApi",
                BlogCount = 3,
            });
            c.Add(new GetCategoryByBlogs()
            {
                CategoryName = "Asp.Net Core Mvc",
                BlogCount = 3,
            });
            return c;
        }


        // Dinamik(DB)'den Chart Getirme İşlemi

        public ActionResult VisualizeResult2()
        {
            return Json(BlogRaitingChart(), JsonRequestBehavior.AllowGet);
        }

        public List<GetBlogRaiting> BlogRaitingChart()
        {         
            List<GetBlogRaiting> blogRaitings = new List<GetBlogRaiting>();
            using (var c = new BlogContext())
            {
                blogRaitings = c.Blogs.Select(x => new GetBlogRaiting
                {
                    BlogRaiting = x.BlogRaiting,
                    BlogTitle = x.BlogTitle,
                }).ToList();
            }
            return blogRaitings;
        }

        public ActionResult BlogRaitingList()
        {
            return View();
        }
        public ActionResult BlogRaitingList2()
        {
            return View();
        }
        public ActionResult BlogRaitingList3()
        {
            return View();
        }
    }
}