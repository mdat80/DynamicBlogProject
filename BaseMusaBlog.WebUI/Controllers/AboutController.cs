using BaseMusaBlog.BusinessLayer.Concrete;
using BaseMusaBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace BaseMusaBlog.WebUI.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager();
        AuthorManager authorManager = new AuthorManager();
        public ActionResult Index()
        {
            var aboutContent = aboutManager.GetAll();
            return View(aboutContent);
        }    
        public PartialViewResult Footer()
        {
           var footerAbout= aboutManager.GetAll();
           return PartialView(footerAbout);
        }
        public PartialViewResult MeetTheTeam()
        {
           var authorList = authorManager.GetAll();
            return PartialView(authorList);
        }
        [HttpGet]
        public ActionResult UpdateAbout()
        {
            var aboutList = aboutManager.GetAll();
            return View(aboutList);
        }
        [HttpPost]
        public ActionResult UpdateAbout( About p)
        {      
            aboutManager.UpdateAboutBL(p);
            return RedirectToAction("UpdateAbout","About");
        }
    }
}