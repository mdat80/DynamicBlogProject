using BaseMusaBlog.BusinessLayer.Concrete;
using BaseMusaBlog.DataAccessLayer.Contexts;
using BaseMusaBlog.EntityLayer.Concrete;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Profile;

namespace BaseMusaBlog.WebUI.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager();
        CommentManager commentManager = new CommentManager();
        BlogContext blogContext = new BlogContext();
        Category category = new Category();
        Blog blog = new Blog();
        UserProfileManager profileManager = new UserProfileManager();

        [AllowAnonymous]
        public ActionResult Index()
        {      
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {
            var blogList = blogManager.GetAll().ToPagedList(page,6);          
            return PartialView(blogList);
        }

        [AllowAnonymous]
        public PartialViewResult FeaturedPosts()
        {
            //1.post
            var posttitle1 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage1 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var postdate1 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
               .Where(x => x.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid1 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
               .Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.postdate1 = postdate1;
            ViewBag.blogpostid1 = blogpostid1;


            //2.post
            var posttitle2 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage2 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var postdate2 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
               .Where(x => x.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid2 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
           .Where(x => x.CategoryID == 2).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle2 = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.postdate2 = postdate2;
            ViewBag.blogpostid2 = blogpostid2;
            //3.post
            var posttitle3 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage3 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            var postdate3 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
               .Where(x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid3 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
           .Where(x => x.CategoryID == 3).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.postdate3 = postdate3;
            ViewBag.blogpostid3 = blogpostid3;
            
            //5.post-Ortadaki
            var posttitle5 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage5 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 5).Select(y => y.BlogImage).FirstOrDefault();
            var postdate5 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
               .Where(x => x.CategoryID == 5).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid5 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
           .Where(x => x.CategoryID == 5).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle5 = posttitle5;
            ViewBag.postimage5 = postimage5;
            ViewBag.postdate5 = postdate5;
            ViewBag.blogpostid5 = blogpostid5;

            //4.post
            var posttitle4 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage4 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var postdate4 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
               .Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid4 = blogManager.GetAll().OrderByDescending(z => z.BlogID)
           .Where(x => x.CategoryID == 4).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.postdate4 = postdate4;
            ViewBag.blogpostid4 = blogpostid4;

            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPosts()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var blogDetailsList = blogManager.GetBlogByID(id);
            return PartialView(blogDetailsList);
        }

        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var blogDetailsList = blogManager.GetBlogByID(id);
            return PartialView(blogDetailsList);
        }

        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var categoryName = blogManager.GetBlogByCategory(id).Select(y => y.Category.CategoryName)
                .FirstOrDefault();
            ViewBag.name = categoryName;

            var categoryDescription = blogManager.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription)
              .FirstOrDefault();
            ViewBag.description = categoryDescription;

            var blogListByCategory = blogManager.GetBlogByCategory(id);
            return View(blogListByCategory);
        }

        //Admin tarafı-Blogları getir
        public ActionResult AdminBlogList()
        {
            var blogList = blogManager.GetAll();           
            return View(blogList);
        }
        public ActionResult AdminBlogList2()
        {
            var blogList = blogManager.GetAll();
            return View(blogList);
        }

        //Admin tarafı-Yeni Blog Ekle 

        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult AddNewBlog()
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
        public ActionResult AddNewBlog(Blog p)
        {
            blogManager.AddBlogBL(p);
            return RedirectToAction("AdminBlogList", "Blog");
        }

        [Authorize(Roles = "A")]
        //Admin tarafı-Blog Sil
        public ActionResult RemoveBlog(int id)
        {
            blogManager.DeleteBlogBL(id);
            return RedirectToAction("AdminBlogList", "Blog");
        }


        [Authorize(Roles = "A")]
        //Admin tarafı-Blog Güncelle
        [HttpGet]
        public ActionResult UpdateBlog(int id)
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
        public ActionResult UpdateBlog(Blog p)
        {
            blogManager.UpdateBlogBL(p);
            return RedirectToAction("AdminBlogList", "Blog");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            var commentList = commentManager.CommentByBlog(id);
            return View(commentList);
        }

        public ActionResult AuthorBlogList(int id)
        {                    
            var authorBlogs = blogManager.GetBlogByAuthor(id);
            return View(authorBlogs);
        }
    }
}