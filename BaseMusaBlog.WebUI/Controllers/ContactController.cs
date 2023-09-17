using BaseMusaBlog.BusinessLayer.Concrete;
using BaseMusaBlog.EntityLayer.Concrete;
using System.Web.Mvc;

namespace BaseMusaBlog.WebUI.Controllers
{
    public class ContactController : Controller
    {      
        ContactManager contactManager = new ContactManager();

        [AllowAnonymous]
        public ActionResult Index()
        {         
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendMessage( Contact p)
        {
            contactManager.BLContactAdd(p);
            return View();
        }
        [AllowAnonymous]
        public ActionResult InBox()
        {
            var mesajList = contactManager.GetAll();
            return View(mesajList);
        }
        [AllowAnonymous]
        public ActionResult MessageDetails(int id)
        {
            var mesasegaDetails = contactManager.GetContactDetails(id);
            return View(mesasegaDetails);
        }
    }
}