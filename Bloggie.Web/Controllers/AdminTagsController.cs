using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{

    public class AdminTagsController : Controller
    {
        private readonly BloggieDbContext bloggieDbContext;

        //private BloggieDbContext _bloggieDbContext;
        public AdminTagsController(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }

        //Adding Tags Get Method
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //Adding Tags Post Method
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            //var name = addTagRequest.Name;
            //var display = addTagRequest.DisplayName;

            var tag = new Tag { 
            Name = addTagRequest.Name,
            DisplayName = addTagRequest.DisplayName
            };
            bloggieDbContext.Add(tag);
            bloggieDbContext.SaveChanges();
            return RedirectToAction("List");
        }

        //[HttpPost]
        //[ActionName("Add")]
        //public IActionResult SubmitTag()
        //{
        //    //var name = Request.Form["name"];
        //    //var displayName = Request.Form["displayName"];
        //    return View("Add");
        //}

        //Listing Tags
        [HttpGet]
        public IActionResult List()
        {
            var tags = bloggieDbContext.Tags.ToList();
            return View(tags);
        }

        //Edit Page View Action
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            // First usage var tag = bloggieDbContext.Tags.Find(id);

            //Second usage
            var tag = bloggieDbContext.Tags.FirstOrDefault(t => t.Id == id);
            return View(tag);
        }


    }
}
