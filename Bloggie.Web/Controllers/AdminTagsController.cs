﻿using Bloggie.Web.Data;
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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

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
            return View("Add");
        }

        //[HttpPost]
        //[ActionName("Add")]
        //public IActionResult SubmitTag()
        //{
        //    //var name = Request.Form["name"];
        //    //var displayName = Request.Form["displayName"];
        //    return View("Add");
        //}
    }
}