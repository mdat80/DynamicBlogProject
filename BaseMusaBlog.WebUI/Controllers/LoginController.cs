using BaseMusaBlog.DataAccessLayer.Contexts;
using BaseMusaBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BaseMusaBlog.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        BlogContext blogContext = new BlogContext();
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AuthorLogin(Author p)
        {
            var userİnfo = blogContext.Authors.FirstOrDefault
                (x => x.EmailAddress == p.EmailAddress && x.Password == p.Password);
            if(userİnfo != null)
            {
                FormsAuthentication.SetAuthCookie(userİnfo.EmailAddress, false);
                Session["EmailAddress"] = userİnfo.EmailAddress.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("AuthorLogin", "Login");
            }
        }


        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var adminİnfo = blogContext.Admins.FirstOrDefault
                (x => x.UserName == p.UserName && x.Password == p.Password);
            if (adminİnfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminİnfo.UserName, false);
                Session["UserName"] = adminİnfo.UserName.ToString();
                return RedirectToAction("AdminBlogList2", "Blog");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }
        }
    }
}