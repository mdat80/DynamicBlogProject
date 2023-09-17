using BaseMusaBlog.BusinessLayer.Concrete;
using BaseMusaBlog.EntityLayer.Concrete;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseMusaBlog.WebUI.Controllers
{
   
    public class AuthorController : Controller
    {    
        BlogManager blogManager = new BlogManager();
        AuthorManager authorManager = new AuthorManager();
        Author author = new Author();

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetail = blogManager.GetBlogByID(id);
            return PartialView(authorDetail);
        }

        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogAuthorId = blogManager.GetAll().Where(x =>x.BlogID == id)
                .Select(y => y.AuthorID).FirstOrDefault();
           
            var authorOtherBlogs = blogManager.GetBlogByAuthor(blogAuthorId);
            return PartialView(authorOtherBlogs);
        }
        public ActionResult AuthorList()
        {
           var authorList = authorManager.GetAll();
            return View(authorList);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            authorManager.AddAuthorBL(p);
            return RedirectToAction("AuthorList", "Author");
        }

        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            author = authorManager.FindeEditAuthorBL(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            authorManager.FindeEditAuthorBL(p);
            return RedirectToAction("AuthorList", "Author");
        }
    }
}
