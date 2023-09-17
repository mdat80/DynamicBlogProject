using BaseMusaBlog.BusinessLayer.Concrete;
using BaseMusaBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseMusaBlog.WebUI.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager();
        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var commentBlog = commentManager.CommentByBlog(id);
            return PartialView(commentBlog);
        }


        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.Id = id;    
            return PartialView();
        }

        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment p)
        {
            p.CommentStatus = true;
            commentManager.CommentAdd(p);            
            return PartialView();
        }
        //Durumu true olan mesajları getir
        public ActionResult AdminCommentListTrue() 
        { 
            var commentList = commentManager.CommentByStatusTrue();
            return View(commentList); 
        }
        //Durumu true olan mesajları getir
        public ActionResult AdminCommentListFalse()
        {
            var commentList = commentManager.CommentByStatusFalse();
            return View(commentList);
        }
        //Durumu true olan mesajları kaldır false yap
        public ActionResult StatusToChangeToFalse(int id)
        {
            commentManager.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCommentListTrue", "Comment");
        }
        //Durumu false olan mesajları kaldır true yap
        public ActionResult StatusToChangeToTrue(int id)
        {
            commentManager.CommentStatusChangeToTrue(id);
            return RedirectToAction("AdminCommentListFalse", "Comment");
        }
    }
}