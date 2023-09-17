using BaseMusaBlog.BusinessLayer.Concrete;
using BaseMusaBlog.EntityLayer.Concrete;
using System.Web.Mvc;

namespace BaseMusaBlog.WebUI.Controllers
{
    [AllowAnonymous]
    public class MailSubscribeController : Controller
    {
        SubscribeMailManager mailManager = new SubscribeMailManager();
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {
            mailManager.BLAdd(p);
            return PartialView();
        }
    }
}