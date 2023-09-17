using BaseMusaBlog.BusinessLayer.Concrete;
using BaseMusaBlog.EntityLayer.Concrete;
using System.Drawing;
using System.Web.Mvc;

namespace BaseMusaBlog.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager();
        Category category = new Category();
        public ActionResult Index()
        {
            var categoryList = categoryManager.GetAll();
            return View(categoryList);
        }
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categorList = categoryManager.GetAll();
           
            return PartialView(categorList);
        }
        public ActionResult AdminCategoryList()
        {
            var categorList = categoryManager.GetAll();
            return PartialView(categorList);           
        }

        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminCategoryAdd(Category p)
        {
            categoryManager.AdminCategoryAddBL(p);
            return RedirectToAction("AdminCategoryList","Category");
        }

        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult AdminCategoryEdit(int id)
        {
            category = categoryManager.FindEditCategoryBL(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult AdminCategoryEdit(Category p)
        {
            categoryManager.FindEditCategoryBL(p);
            return RedirectToAction("AdminCategoryList", "Category");
        }

        [Authorize(Roles = "A")]
        public ActionResult AdminCategoryDelete(int id)
        {            
            categoryManager.AdminPassiveCategoryBL(id);
            return RedirectToAction("AdminCategoryList", "Category");
        }
        [Authorize(Roles = "A")]
        public ActionResult AdminCategoryActive(int id)
        {
            categoryManager.AdminActiveCategoryBL(id);
            return RedirectToAction("AdminCategoryList", "Category");
        }
    }
}
