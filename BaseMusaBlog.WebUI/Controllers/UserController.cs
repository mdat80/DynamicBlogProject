using BaseMusaBlog.BusinessLayer.Concrete;
using BaseMusaBlog.DataAccessLayer.Contexts;
using BaseMusaBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebGrease;

namespace BaseMusaBlog.WebUI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // UserController Yazarlar için-sisteme authentice olan kullanıcının bilgilerini getirme session değeri ile
        UserProfileManager profileManager = new UserProfileManager();
        BlogContext blogContext = new BlogContext();  
        Blog blog = new Blog();
        BlogManager blogManager = new BlogManager();
        public ActionResult Index()
        {         
            return View();
        }
        public PartialViewResult IndexPartial1(string p)
        {
            p = (string)Session["EmailAddress"];
            var profileValues = profileManager.GetAuthorByMail(p);
            return PartialView(profileValues);
        }

        public ActionResult UpdateAuthorProfile(Author p)
        {
            profileManager.FindeEditAuthorBL(p);
            return RedirectToAction("Index","User");
        }

        public ActionResult AuthorBlogList(string p)
        {
            p = (string)Session["EmailAddress"];

            int id = blogContext.Authors.Where(x => x.EmailAddress == p)
                .Select(y => y.AuthorID).FirstOrDefault();

            var authorBlogs = profileManager.GetBlogByAuthor(id);
            return View(authorBlogs);
        }
        public ActionResult UpdateBlogByAuthor(int id)
        {
            blog = blogManager.FindUpdateBlogBL(id);
            List<SelectListItem> categoryList = (from x in blogContext.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID.ToString()
                                                 }).ToList();
            ViewBag.categoryNameDropdown = categoryList;

            List<SelectListItem> authorList = (from x in blogContext.Authors.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.AuthorName,
                                                   Value = x.AuthorID.ToString()
                                               }).ToList();
            ViewBag.authorNameDropdown = authorList;
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlogByAuthor(Blog p)
        {
            blogManager.UpdateBlogBL(p);
            return RedirectToAction("AuthorBlogList");
        }
        [HttpGet]
        public ActionResult AddNewBlogAuthor()
        {
            List<SelectListItem> categoryList = (from x in blogContext.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID.ToString()
                                                 }).ToList();
            ViewBag.categoryNameDropdown = categoryList;

            List<SelectListItem> authorList = (from x in blogContext.Authors.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.AuthorName,
                                                   Value = x.AuthorID.ToString()
                                               }).ToList();
            ViewBag.authorNameDropdown = authorList;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlogAuthor(Blog p)
        {
            blogManager.AddBlogBL(p);
            return RedirectToAction("AuthorBlogList");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }
    }
}